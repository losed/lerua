using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using iQueue.Properties;
using System.Windows.Forms;


namespace iQueue
{
    // Класс-обработчик клиента
    class Client
    {
        public NetworkStream clStream;
        StreamReader clReader;
        StreamWriter clWriter;
        // Отправка страницы с ошибкой
        private void SendError(TcpClient Client, int Code)
        {
            /*Client.SendTimeout = 10000;
            Client.ReceiveTimeout = 10000;
            Client.SendBufferSize = 0;
            Client.ReceiveBufferSize = 0;*/
            Program.Log("client SendError " + Code.ToString());
            // Получаем строку вида "200 OK"
            // HttpStatusCode хранит в себе все статус-коды HTTP/1.1
            string CodeStr = Code.ToString() + " " + ((HttpStatusCode)Code).ToString();
            // Код простой HTML-странички
            string Html = "<html><body><h1>" + CodeStr + "</h1></body></html>";
            // Необходимые заголовки: ответ сервера, тип и длина содержимого. После двух пустых строк - само содержимое
            string Str = "HTTP/1.1 " + CodeStr + "\nCache-Control:private, no-cache, no-store, proxy-revalidate\nConnection:close\nContent-type: text/html\nContent-Length:" + Html.Length.ToString() + "\n\n" + Html;
            // Приведем строку к виду массива байт
            byte[] Buffer = Encoding.ASCII.GetBytes(Str);
            // Отправим его клиенту
            clStream.Write(Buffer, 0, Buffer.Length);
            clStream.Flush();
            // Закроем соединение
           // Client.Close();
        }
        public string processManageCommands(string cmdType, Dictionary<string, string> cmdParams)
        {
            string answerString = "";
            switch (cmdType)
            {
                case "dbQuery":
                    if(cmdParams["sql"]!=""){
                        DBInterface iface = new DBInterface(Settings.Default.dbFilePath);
                        Dictionary<string,string>[] results = iface.selectQuery(cmdParams["sql"]);

                        answerString = JsonConvert.SerializeObject(results);
                        
                    }
                    break;
                case "dbExecute":
                    if (cmdParams["sql"] != "")
                    {
                        DBInterface iface = new DBInterface(Settings.Default.dbFilePath);
                        int res = iface.modifyQuery(cmdParams["sql"]);
                        answerString = JsonConvert.SerializeObject(res);
                    }
                    break;
                case "ledTest":
                    break;
                case "softwareVersion":
                    Dictionary<string, string> result = new Dictionary<string, string>();

                    result["product"] = Application.ProductName;
                    result["version"] = Application.ProductVersion;
                    if (!FingerPrint.isPair(Program.fingerPrint, Settings.Default.softCode))
                    {
                        result["version"] += " ILLEGAL COPY";
                    }
                        answerString = JsonConvert.SerializeObject(result);
                    break;
            }

            return answerString;
        }
        // Конструктор класса. Ему нужно передавать принятого клиента от TcpListener
        public Client(TcpClient Client)
        {
            Thread.CurrentThread.Name = "clientThread";
            clStream = Client.GetStream();
            clReader = new StreamReader(clStream);
            clWriter = new StreamWriter(clStream);
            clWriter.AutoFlush = true;
            
            /*Client.SendTimeout = 30000;
            Client.ReceiveTimeout = 30000;
            Client.ReceiveBufferSize = 1024 * 1024 * 5; 
            Client.SendBufferSize = 1024*1024*5;
            */
            Program.Log("New WEB-client");
            // Объявим строку, в которой будет хранится запрос клиента
            string Request = "";
            // Буфер для хранения принятых от клиента данных
            byte[] Buffer = new byte[1024*1024*5];
            // Переменная для хранения количества байт, принятых от клиента
            int Count;
            // Переменные в ответе
            string Headers = "";
            byte[] HeadersBuffer = null;
            // Читаем из потока клиента до тех пор, пока от него поступают данные
            try
            {
               // NetworkStream stream = clStream;
                while (Client.Available>0)
                {
                    Count = clStream.Read(Buffer, 0, Buffer.Length);
                    // Преобразуем эти данные в строку и добавим ее к переменной Request
                    Request += Encoding.ASCII.GetString(Buffer, 0, Count);
                    // Запрос должен обрываться последовательностью \r\n\r\n
                    // Либо обрываем прием данных сами, если длина строки Request превышает 4 килобайта
                    // Нам не нужно получать данные из POST-запроса (и т. п.), а обычный запрос
                    // по идее не должен быть больше 4 килобайт
                    if (Request.IndexOf("\r\n\r\n") >= 0 || Request.Length > 1024*1024*2)
                    {
                        break;
                    }
                }
            /*    if(!clReader.EndOfStream)
                    Request=clReader.ReadToEnd();*/
            }
            catch (Exception ex)
            {
                Program.Log("Client REQUEST exception: [" + ex.Message + "]");
                return;
            }
            Program.Log("Client REQUEST: [" + Request + "]");
            if (Request == "")
            {
                Program.Log("Empty REQUEST!!!!");
            }
            // Парсим строку запроса с использованием регулярных выражений
            // При этом отсекаем все переменные GET-запроса
            Match ReqMatch = Regex.Match(Request, @"^\w+\s+([^\s\?]+)[^\s]*\s+HTTP/.*|");

            // Если запрос не удался
            if (ReqMatch == Match.Empty)
            {
                // Передаем клиенту ошибку 400 - неверный запрос
                SendError(Client, 400);
                return;
            }

            // Получаем строку запроса
            string RequestUri = ReqMatch.Groups[1].Value;

            // Приводим ее к изначальному виду, преобразуя экранированные символы
            // Например, "%20" -> " "
            RequestUri = Uri.UnescapeDataString(RequestUri);

            // Если в строке содержится двоеточие, передадим ошибку 400
            // Это нужно для защиты от URL типа http://example.com/../../file.txt
            if (RequestUri.IndexOf("..") >= 0)
            {
                SendError(Client, 400);
                return;
            }

            // Если строка запроса оканчивается на "/", то добавим к ней index.html
            if (RequestUri.EndsWith("/"))// || RequestUri.Equals(""))
            {
                RequestUri += "index.html";
            }
            else
            {
                MatchCollection managementReq = Regex.Matches(ReqMatch.Groups[0].Value, @"^([A-Z]+)\s+/_(\w+)(\?([^&^=]+)=([^&^=]+)[&]?)*\s+HTTP.*$");
                if (managementReq.Count > 0)
                {
                    string manageRequestType = managementReq[0].Groups[2].Value;
                    //управляющий запрос - вычисляем параметры и отправляем в обработку
                    CaptureCollection paramNames = managementReq[0].Groups[4].Captures;
                    CaptureCollection paramValues = managementReq[0].Groups[5].Captures;
                    Dictionary<string, string> manageParams = new Dictionary<string, string>();
                    manageParams.Clear();
                    for (int i = 0; i < paramNames.Count; i++)
                    {
                        if (!manageParams.ContainsKey(paramNames[i].Value))
                             manageParams.Add(paramNames[i].Value, System.Web.HttpUtility.UrlDecode(paramValues[i].Value));
                    }
                    string AnswerManageCommand = processManageCommands(manageRequestType, manageParams);
                    Buffer = System.Text.Encoding.UTF8.GetBytes(AnswerManageCommand);
                    Headers = "HTTP/1.1 200 OK\nCache-Control:private, no-cache, no-store, proxy-revalidate\nConnection:close\nContent-Type: application/json; charset=utf-8\nContent-Length: " + Buffer.Length + "\nConnection: close\nCache-Control: no-cache\n\n";
                    HeadersBuffer = Encoding.ASCII.GetBytes(Headers);
                    clStream.Write(HeadersBuffer, 0, HeadersBuffer.Length);
                    clStream.Flush();
                    clStream.Write(Buffer, 0, Buffer.Length);
                    clStream.Flush();
                    // Закроем соединение
                    Client.Close();

                    return;
                }
            }

            string FilePath = "www/" + RequestUri; //Path.Combine("www", RequestUri);
            Program.Log("Finding path=["+FilePath+"]");
            // Если в папке www не существует данного файла, посылаем ошибку 404
            if (!File.Exists(FilePath))
            {
                SendError(Client, 404);
                return;
            }

            // Получаем расширение файла из строки запроса
            string Extension = RequestUri.Substring(RequestUri.LastIndexOf('.'));

            // Тип содержимого
            string ContentType = "";

            // Пытаемся определить тип содержимого по расширению файла
            switch (Extension)
            {
                case ".htm":
                case ".html":
                    ContentType = "text/html; charset=UTF-8";
                    break;
                case ".css":
                    ContentType = "text/css";
                    break;
                case ".js":
                    ContentType = "text/javascript; charset=UTF-8";
                    break;
                case ".jpg":
                    ContentType = "image/jpeg";
                    break;
                case ".jpeg":
                case ".png":
                case ".gif":
                    ContentType = "image/" + Extension.Substring(1);
                    break;
                case ".woff":
                    ContentType = "application/x-font-woff";
                    break;
                default:
                    if (Extension.Length > 1)
                    {
                        ContentType = "application/" + Extension.Substring(1);
                    }
                    else
                    {
                        ContentType = "application/unknown";
                    }
                    break;
            }

            // Открываем файл, страхуясь на случай ошибки
            FileStream FS;
            try
            {
                FS = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }
            catch (Exception)
            {
                // Если случилась ошибка, посылаем клиенту ошибку 500
                SendError(Client, 500);
                return;
            }

            // Посылаем заголовки
            Headers = "HTTP/1.1 200 OK\nCache-Control:private, no-cache, no-store, proxy-revalidate\nConnection:close\nContent-Type: " + ContentType + "\nContent-Length: " + FS.Length + "\nConnection: close\nCache-Control: no-cache\n\n";
            HeadersBuffer = Encoding.ASCII.GetBytes(Headers);
            try
            {
                clStream.Write(HeadersBuffer, 0, HeadersBuffer.Length);
                clStream.Flush();
                // Пока не достигнут конец файла
                while (FS.Position < FS.Length && Client.Connected)
                {
                    // Читаем данные из файла
                    Count = FS.Read(Buffer, 0, Buffer.Length);
                    // И передаем их клиенту
                    clStream.Write(Buffer, 0, Count);
                    clStream.Flush();
                }
                // Закроем файл и соединение
                FS.Close();
//                Client.Close();
            }
            catch (Exception ex)
            {
                Program.Log("Exception while trying to send data to client = ["+ex.Message+"] stackTrace={"+ex.StackTrace+"}!");
            }
        }
    }

}
