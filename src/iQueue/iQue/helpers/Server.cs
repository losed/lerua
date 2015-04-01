using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace iQueue
{
    public class Server
    {
        // Запуск сервера
        public Server(TcpListener Listener)//; // Объект, принимающий TCP-клиентов)
        {
            Program.Log("Starting server...");
           /* Listener.Server.ReceiveTimeout = 0;
            Listener.Server.SendTimeout = 0;
            Listener.Server.SendBufferSize = 1024 * 128;
            Listener.Server.ReceiveBufferSize = 1024 * 128;*/
            //Listener.Server.DontFragment = true;
            //Listener.Server.LingerState = new LingerOption(false,0);
          //  Listener.Server.Ttl = 
        //    Listener.Server.Blocking = true;
            Listener.Server.ReceiveTimeout =  int.MaxValue;
            Listener.Server.SendTimeout = int.MaxValue;
            Listener.Server.ReceiveBufferSize = int.MaxValue;
            Listener.Server.SendBufferSize = int.MaxValue;
            //Listener.Server.NoDelay = true;
            Listener.Start(); // Запускаем его
            Program.Log("Server started");
            // В бесконечном цикле
            while (true)
            {
                while (Listener.Server.Poll(1000*1000*15, SelectMode.SelectRead & SelectMode.SelectWrite & SelectMode.SelectError))
                {
                    // Принимаем новых клиентов. После того, как клиент был принят, он передается в новый поток (ClientThread)
                    // с использованием пула потоков.
                    try
                    {

                        //ThreadPool.UnsafeQueueUserWorkItem(new WaitCallback(ClientThread), Listener.AcceptTcpClient());
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), Listener.AcceptTcpClient());
                    }
                    catch (Exception ex)
                    {
                        Program.Log("Exception while trying to work with client:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");
                        //NEED TO LOG EXCEPTION!
                    }
                }
                /*
                // Принимаем нового клиента
                TcpClient Client = Listener.AcceptTcpClient();
                // Создаем поток
                Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                // И запускаем этот поток, передавая ему принятого клиента
                Thread.Start(Client);
                */
            }
        }

        static void ClientThread(Object StateInfo)
        {
           // Просто создаем новый экземпляр класса Client и передаем ему приведенный к классу TcpClient объект StateInfo
            TcpClient cl = (TcpClient)StateInfo;
            //ждем данных (КОСТЫЛЬ)
            int times = 0;
            while (cl.Available == 0 && times < 100) { times++; Thread.Sleep(100); }

            if (cl.Connected && cl.Available > 0)
                new Client(cl);
            cl.Close();
            Thread.CurrentThread.Abort();
        }
    }
}
