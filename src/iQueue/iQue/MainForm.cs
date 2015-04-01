using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Data.SQLite;
using Newtonsoft.Json;
using iQueue.Properties;

namespace iQueue
{
    public partial class MainForm : Form
    {
        public Thread srvThread, mainLedThread;
        public Server srv;
        public DBInterface db;
        public TcpListener Listener; // Объект, принимающий TCP-клиентов           
        public SQLiteConnection sqlConn;
        public SQLiteCommand sqlCmd;
        public bool forceClose;
        public LedScreen[] screens;
     //   public LedThread[] ledThreads;
        public string lastlogHash;
        public string oldRtf, oldFRtf;
        public ActivationForm activationForm;
        private UserApi api;

        public MainForm()
        {
            InitializeComponent();
            api = new UserApi(Program.fingerPrint);
           // Thread.CurrentThread.Name = "mainThread";
            forceClose = false;
            oldFRtf = "";
            oldRtf = "";
            screens = new LedScreen[3];
            //ledThreads = new LedThread[3];
            String strHostName = Dns.GetHostName();
            Program.Log("HostName of this Machine is [" + strHostName + "]");
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);
            Program.Log("HostName has " + iphostentry.AddressList.Length + " addresses");
            // Перечисляем IP адреса
            int nIP = 0;
            webServiceAddress.Items.Clear();
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                Program.Log("IP #" + ++nIP + ": " +
                                  ipaddress.ToString());
                webServiceAddress.Items.Add(ipaddress.ToString());
            }

            loadSettings();
            //if (webServiceAddress.Text.Length < 3) 
                webServiceAddress.Text = "0.0.0.0";

            if (!File.Exists(dbFilePath.Text)) initDB();
            db = new DBInterface(dbFilePath.Text);

            loadSettingsFromDatabase();
            delayedLoadSettings();
            srvThread = new Thread(srvThreadMain);
            srvThread.Name = "srvThread";
            IPAddress ipAddr = IPAddress.Parse(webServiceAddress.Text);
            Listener = new TcpListener(ipAddr, (int)serverPort.Value); // Создаем "слушателя" для указанного порта
            // Создадим новый сервер на порту 80
            if (Settings.Default.serverAutoStart)
            {
                runWebServiceButton_Click(null,null);
            }
            if (Settings.Default.ledThreadsAutoStart)
            {
                ledRestartButton_Click(null, null);
             //   queueToScreen_Click(null, null);
            }
            if (FingerPrint.isPair(Program.fingerPrint, Settings.Default.softCode))
            {
                Program.Log("Software copy successfully activated!");
                Settings.Default.softActivated = true;
                активацияПрограммногоОбеспеченияToolStripMenuItem.Enabled = false;
                регистрацияПОЧерезИнтернетToolStripMenuItem.Enabled = false;
                saveSettings();
            }
            else
            {
                string codePath = Path.Combine(Settings.Default.statusDirectoryPath, "status-255.ini");
                if (File.Exists(codePath))
                {
                    Program.Log("Software copy is not activated - checking serial!");
                    Settings.Default.softCode = File.ReadAllText(codePath);
                    saveSettings();
                    File.Delete(codePath);
                    doRestart();

                }
                Program.Log("Software copy is not activated!");
                Settings.Default.softActivated = false;
                активацияПрограммногоОбеспеченияToolStripMenuItem.Enabled = true;
                регистрацияПОЧерезИнтернетToolStripMenuItem.Enabled = true;
                активацияПрограммногоОбеспеченияToolStripMenuItem_Click(null, null);
                saveSettings();
            }
            
        }
        public void loadSettingsFromDatabase()
        {
            Dictionary<string, string>[] sts = db.selectQuery("SELECT * FROM settings");
            foreach (Dictionary<string, string> st in sts)
            {
                System.Configuration.SettingsProperty nProp = new System.Configuration.SettingsProperty(st["key"]);
                nProp.DefaultValue = st["value"];
                try
                {
                    Settings.Default.Properties.Add(nProp);
                }
                catch (Exception ex)
                {
                    // Program.Log("Exception while trying to Add property:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]. Setting defaultValue");
                    Program.Log("DEFAULT FOR " + st["key"] + " DETECTED (EXCEPTION=[" + ex.Message + "]");
                    Settings.Default.Properties[st["key"]].DefaultValue = st["value"];
                }
            }
        }
        public void loadSettings()
        {
            
            Settings.Default.Reload();
            dbFilePath.Text = Settings.Default.dbFilePath;
            logDirectoryPath.Text = Settings.Default.logDirectoryPath;
            serverPort.Value = Settings.Default.webServicePort;
            serverAutoStart.Checked = Settings.Default.serverAutoStart;
            webServiceAddress.Text = Settings.Default.webServiceAddress;
            ledAutoStart.Checked = Settings.Default.ledThreadsAutoStart;
            /**********НАСТРОЙКИ ИЗ БД - ПО УМОЛЧАНИЮ*************/
            if (Settings.Default.Properties["stuntCode"] == null)
            {
                Settings.Default.Properties.Add(new System.Configuration.SettingsProperty("stuntCode"));
                Settings.Default.Properties["stuntCode"].DefaultValue = 0x06;
            }
            if (Settings.Default.Properties["scrollSpeed"] == null)
            {
                Settings.Default.Properties.Add(new System.Configuration.SettingsProperty("scrollSpeed"));
                Settings.Default.Properties["scrollSpeed"].DefaultValue = 0x10;
            }
            if (Settings.Default.Properties["fontSize"] == null)
            {
                Settings.Default.Properties.Add(new System.Configuration.SettingsProperty("fontSize"));
                Settings.Default.Properties["fontSize"].DefaultValue = 10;
            }
            if (Settings.Default.Properties["fontFamily"] == null)
            {
                Settings.Default.Properties.Add(new System.Configuration.SettingsProperty("fontFamily"));
                Settings.Default.Properties["fontFamily"].DefaultValue = "Courier";
            }
            /********КОНЕЦ НАСТРОЙКИ ИЗ БД - ПО УМОЛЧАНИЮ********/
          
        }
        public void delayedLoadSettings()
        {
            if (Settings.Default.Properties["fontSize"] != null)
            {
                ledTestFontSize.Value = Convert.ToInt32(Settings.Default.Properties["fontSize"].DefaultValue.ToString());
            }
            else
            {
                ledTestFontSize.Value = 10;
            }
            Font fnt = null;
            if (Settings.Default.Properties["fontFamily"] != null)
            {
                
                fnt = new Font(Settings.Default.Properties["fontFamily"].DefaultValue.ToString(), (float)ledTestFontSize.Value);
            }
            else
            {
                fnt = new Font("Courier", (float)ledTestFontSize.Value);
            }
            
            ledTestRichText.Font = fnt;
            ledTestRichTextFull.Font = fnt;

            if (Settings.Default.Properties["ledRefreshTimeout"] != null)
            {
                checkRefreshTimer.Interval = Convert.ToInt32(Settings.Default.Properties["ledRefreshTimeout"].DefaultValue.ToString()) * 1000;
            }
            else
            {
                checkRefreshTimer.Interval = 10000;
            }
            if (Settings.Default.Properties["stuntCode"] != null)
            {
                ledTestStunt.Text = Settings.Default.Properties["stuntCode"].DefaultValue.ToString();
            }
            else
            {
                ledTestStunt.Text = "0x06: cmu";
            }
            if (Settings.Default.Properties["scrollSpeed"] != null)
            {
                ledTestSpeed.Value = Convert.ToInt32(Settings.Default.Properties["scrollSpeed"].DefaultValue.ToString());
            }
            else
            {
                ledTestSpeed.Value = 10;
            }
            if (Settings.Default.Properties["scrollDelay"] != null)
            {
                ledTestDelay.Value = Convert.ToInt32(Settings.Default.Properties["scrollDelay"].DefaultValue.ToString());
            }
            else
            {
                ledTestDelay.Value = 10;
            }            
        }
        public void saveSettings()
        {
            Settings.Default.Save();
        }
        public void srvThreadMain(){
            srv = new Server(Listener);
        }
        public void shutDown()
        {
            srvThread.Abort();
            Listener.Stop();
          //  for (int i = 0; i < screens.Length; i++)
          //  {
                ledTestRichText.Clear();
                ledTestRichTextFull.Clear();
                int ledsOnline = sendToLed();
           // }
        }

        //функция создания исходной БД
        public bool initDB()
        {
            string connString = "Data Source=" + dbFilePath.Text + ";Version=3;Compress=True;";
            try
            {
                sqlConn = new SQLiteConnection(connString);
                sqlConn.Open();
                sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = Settings.Default.initialDBStructure;
                int res = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Program.Log("Exception while trying to initDB:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");
                return false;
            }
            return true;
        }
  

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!forceClose)
            {
                e.Cancel = true;
            }
            notifyIcon1.Visible = true; // это я делаю видимым иконку трея
            notifyIcon1.ShowBalloonTip(5 * 1000);
            this.Hide(); // это я делаю невидимым форму 
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
            //на закрытие окна - останавливаем WEB-сервер
           // button2_Click(null, null);
            shutDown();
         //   db.
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите закрыть приложение?","Подтвердите",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                forceClose = true;
            
            Close();
        }

        private void открытьЖурналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Settings.Default.logDirectoryPath, DateTime.Today.Year + "_" + DateTime.Today.Month + "_" + DateTime.Today.Day + ".log");
            System.Diagnostics.Process.Start(fileName);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void ledTestBrightness_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < screens.Length; i++)
            {
                if (screens[i]!=null)
                {
                    screens[i].setBrightness((int)ledTestBrightness.Value);

                }
            }
        }

        private long deltaLogSize, wasLogSize;
        StreamReader logWatchStream;
        private void logReadTimer_Tick(object sender, EventArgs e)
        {
            
            if (logWatch.CheckState != CheckState.Checked) return;
            string PID = "";// Thread.CurrentThread.Name + "-";
            string filePath = Path.Combine(Settings.Default.logDirectoryPath, PID + DateTime.Today.Year + "_" + DateTime.Today.Month + "_" + DateTime.Today.Day + ".log");
            this.deltaLogSize = 0;
            this.wasLogSize = 0;
            if (!File.Exists(filePath)) return;
            try
            {
                if (logWatchStream == null || logWatchStream.BaseStream == null)
                {
                    Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    if (stream != null)
                        logWatchStream = new StreamReader(stream);
                    else
                        return;
                }
                
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                md5.Initialize();

                long offset = logWatchStream.BaseStream.Position;
                logWatchStream.BaseStream.Seek(0, 0);
                byte[] hash = md5.ComputeHash(logWatchStream.BaseStream);

                //stream.Close();

                string mdHash = "";
                for (int i = 0; i < hash.Length; i++)
                {

                    mdHash += hash[i].ToString("x2");
                }
                //stream.Close();
                md5.Clear();
                logWatchStream.BaseStream.Seek(offset, 0);
                string deltaFileText = logWatchStream.ReadToEnd();
                

                if (this.lastlogHash != mdHash)
                {
                  //  ledTestRichText.Select(0, ledTestRichText.Text.Length);
                  //  ledTestRichText.SelectedText = "LOGTIMER-HASHES:" + this.lastlogHash + "!=" + mdHash + "\n";
                  //  ledTestRichText.SelectionBullet = true;
                    FileInfo info = new FileInfo(filePath);
                    this.deltaLogSize = info.Length - this.wasLogSize;
                    
                    lastlogHash = mdHash;
                    logBox.SelectAll();
                    logBox.SelectionColor = Color.Black;

                    logBox.AppendText(deltaFileText);
                    int selectionStart = logBox.Text.Length - deltaFileText.Length;
                    if (selectionStart < 0) selectionStart = 0;
                    int selectionCount = deltaFileText.Length;
                    if (selectionCount > logBox.Text.Length) selectionCount = logBox.Text.Length;
                    logBox.Select(selectionStart, selectionCount);
                    logBox.SelectionColor = Color.DarkGreen;
                    //logBox.SelectedText = fileText.Substring((int)(wasLogSize-deltaLogSize));
                   // logBox.Select(logBox.Text.Length - (int)this.deltaLogSize - 1, (int)this.deltaLogSize);
                    logBox.ScrollToCaret();
                    this.wasLogSize = info.Length;

                }
            }
            catch (Exception ex)
            {
                Program.Log("Exception while trying to refreshLog Exception.Message:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");
            }
        }

        private void logWatch_CheckStateChanged(object sender, EventArgs e)
        {
            if (logWatch.Checked)
            {
              //  logReadTimer.Interval = 1000 * 5;
                logReadTimer.Start();
                this.Width = 1146;
                this.Height = 760;
                logBox.Width = 1016;
                logBox.Height = 324;
                logBox.BringToFront();
                logBox.Show();
               // form size 1146; 760
            }
            else
            {
                logReadTimer.Stop();
                logBox.Hide();
                this.Width = 771; 
                this.Height = 439;
                //form 699; 447
            }
        }

        private void ledTestFontSize_ValueChanged(object sender, EventArgs e)
        {
            setFontSizeButton_Click(sender, e);
            sendTextToLedButton_Click(sender, e);
        }

        private void очиститьЛогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string logPath = Settings.Default.logDirectoryPath;//Path.Combine(, DateTime.Today.Year + "_" + DateTime.Today.Month + "_" + DateTime.Today.Day + ".log");
            logWatchStream.Close();
            Directory.Delete(logPath,true);
            Directory.CreateDirectory(logPath);
            logBox.Clear();
        }

        private void logBox_SelectionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel7.Text = logBox.SelectedText.Length.ToString();
        }
        private void ledReload()
        {

            Dictionary<string, string>[] scrs = db.selectQuery("SELECT * FROM screens ORDER BY id;");
            Dictionary<string, Dictionary<string, string>> screenDatas = new Dictionary<string, Dictionary<string, string>>();
            //screens = new LedScreen[ledThreads.Length];
            for (int i = 0; i < scrs.Length; i++)
            {
                screenDatas[scrs[i]["id"]] = scrs[i];
            }

            for (int i = 0; i < screens.Length; i++)
            {

                if (screenDatas.ContainsKey((i + 1).ToString()))
                {
                    screens[i] = LedScreen.InitLedScreen(screenDatas[(i + 1).ToString()]);
                    if (screens[i].screenNumber != 0)
                    {
                        /*screens[i].setBrightness((int)ledTestBrightness.Value);
                        string rtfFile = Path.Combine(Path.Combine(Settings.Default.statusDirectoryPath, "showing"), "screen-" + screens[i].screenNumber + new Random(1000).Next() + ".rtf");
                        File.WriteAllText(rtfFile, FmtConverter.HTML2RTF(File.ReadAllText(Path.Combine(Settings.Default.tplDirPath, "empty.html")), screens[i].richBox));
                        screens[i].resetPlayOnScreen(rtfFile);*/
                        //             screens[i] = new LedScreen(screenDatas[(i + 1).ToString()]);
                        //ledThreads[i].Run();
                        Program.Log("screens[" + i + "] = SCREEN#" + screens[i].screenNumber + " - ledThread runned NAME=" + screens[i]);
                    }
                    else
                    {
                        screens[i] = null;
                        Program.Log("screens[" + i + "] - seems not to be responding");
                    }
                }
                else
                {
                    screens[i] = null;
                    Program.Log("screens[" + i + "] - not found settings");
                }

            }
            // sendToLed();

        }
        private void ledRestartButton_Click(object sender, EventArgs e)
        {
            
            Dictionary<string, string>[] scrs = db.selectQuery("SELECT * FROM screens ORDER BY id;");
            Dictionary<string, Dictionary<string, string>> screenDatas = new Dictionary<string, Dictionary<string, string>>();
            //screens = new LedScreen[ledThreads.Length];
            for (int i = 0; i < scrs.Length; i++)
            {
                screenDatas[scrs[i]["id"]] = scrs[i];
            }

            for (int i = 0; i < screens.Length; i++)
            {

                if (screenDatas.ContainsKey((i + 1).ToString()))
                {
                    screens[i] = LedScreen.InitLedScreen(screenDatas[(i + 1).ToString()]);
                    if (screens[i].screenNumber != 0)
                    {
                        screens[i].setBrightness((int)ledTestBrightness.Value);
                        string rtfFile = Path.Combine(Path.Combine(Settings.Default.statusDirectoryPath, "showing"), "screen-" + screens[i].screenNumber + new Random(1000).Next() + ".rtf");
                        File.WriteAllText(rtfFile, FmtConverter.HTML2RTF(File.ReadAllText(Path.Combine(Settings.Default.tplDirPath, "empty.html")), screens[i].richBox));
                        screens[i].resetPlayOnScreen(rtfFile);
                        //             screens[i] = new LedScreen(screenDatas[(i + 1).ToString()]);
                        //ledThreads[i].Run();
                        Program.Log("screens[" + i + "] = SCREEN#" + screens[i].screenNumber + " - ledThread runned NAME=" + screens[i]);
                    }
                    else
                    {
                        screens[i] = null;
                        Program.Log("screens[" + i + "] - seems not to be responding");
                    }
                }
                else
                {
                    screens[i] = null;
                    Program.Log("screens[" + i + "] - not found settings");
                }

            }
           // sendToLed();

        }

        private void ledStopButton_Click(object sender, EventArgs e)
        {
            checkRefreshTimer.Enabled = false;
        }

        public int sendToLed()
        {
            int res = 0;
            for (int i = 0; i < screens.Length; i++)
            {
                if (screens[i] != null)
                {
                        string rtfFileName = "screen-" + screens[i].screenNumber+ new Random(1000).Next() + ".rtf";
                        string fileName = Path.Combine(Path.Combine(Settings.Default.statusDirectoryPath, "showing"), rtfFileName);
                        string txt = ledTestRichText.Rtf;
                        if (screens[i].behavior == 1000)
                        {
                            txt = ledTestRichTextFull.Rtf;
                        }
                        //txt = screens[i].richBox.Rtf;
                        StreamWriter wr = File.CreateText(fileName);
                        wr.Write(txt);
                        wr.Flush();
                        wr.Close();
                        if (screens[i].playOnScreen(fileName))
                            res++;
                    //   screens[i].clearScreen();
                  /*  int fileOrd = 0; //насколько я понимаю всегда
                    int areaOrd = 0; //насколько я понимаю всегда
                    screens[i].deleteRtfFileAreaOnScreen(areaOrd, fileOrd);
                    //   screens[i].deleteAreaOnScreen(areaOrd);
                    {
                        string rtfFileName = "screen-" + screens[i].screenNumber+ new Random(1000).Next() + ".rtf";
                        string fileName = Path.Combine(Path.Combine(Settings.Default.statusDirectoryPath, "showing"), rtfFileName);
                        string txt = ledTestRichText.Rtf;
                        if (screens[i].behavior == 1000)
                        {
                            txt = ledTestRichTextFull.Rtf;
                        }
                        //txt = screens[i].richBox.Rtf;
                        StreamWriter wr = File.CreateText(fileName);
                        wr.Write(txt);
                        wr.Flush();
                        wr.Close();

                        screens[i].addRtfFileOnScreenArea(0, fileName);//, stunt, speed, delay);
                        if (screens[i].sendProgram())
                        {
                            res++;
                        }
                        //File.Delete(fileName);

                    }
                   */
                }
            }
            return res;
        }

        private void sendTextToLedButton_Click(object sender, EventArgs e)
        {
            sendToLed();

        }

        private void setColorButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ledTestColorDialog.ShowDialog())
            {
                ledTestRichText.SelectionColor = ledTestColorDialog.Color;
            }
        }

        private void setFontSizeButton_Click(object sender, EventArgs e)
        {
            Font fnt = ledTestRichText.SelectionFont;
            fnt = new Font(fnt.FontFamily, (float)ledTestFontSize.Value);
            ledTestRichText.Font = fnt;
        }

        private void fullRESETButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < screens.Length; i++)
            {
                if (screens[i] != null)
                {
                   // screens[i].fullReset();
                }
            }
        }
        private void ledOnButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < screens.Length; i++)
            {
                if (screens[i] != null)
                    screens[i].powerOn();
            }
        }
        private void ledOffButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < screens.Length; i++)
            {
                if (screens[i] != null)
                    screens[i].powerOff();
            }
        }

        private void screenScanButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < screens.Length; i++)
            {
              /*  if (screens[i] != null)
                    screens[i].screenScan();*/
            }
        }

        private void ledGetStatusButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < screens.Length; i++)
            {
                if (screens[i] != null)
                {
                    screens[i].getScreenStatus();
                    string[] status = File.ReadAllLines(screens[i].screenStatusFile);
                    Program.Log("STATUS OF SCREEN #" + screens[i].screenNumber + " FOLLOWS:" + status.ToString());
                    for (int j = 0; j < status.Length; j++)
                    {
                        string str = status[j];
                        string[] kV = str.Split('=');
                        if (kV.Length == 2)
                        {
                            // MatchCollection kv = Regex.Matches(str,"")
                            string sKey = kV[0];
                            screens[i].statusObj[sKey] = kV[1];
                            Program.Log("screen[" + screens[i].screenNumber + "].statusObj[" + sKey + "]=[" + kV[1] + "]");
                        }
                    }
                }
            }
        }

        private void ledClearButton_Click(object sender, EventArgs e)
        {
          /*  ledTestRichText.Rtf = "";
            for (int i =0; i < screens.Length; i++)
            {
                if (screens[i]!=null)
                {
                    screens[i].clearScreen();
                    //добавляем пустой текст
                }
            }
            sendTextToLedButton_Click(sender, e);
           */ 
        }

        private void ledStartButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string>[] scrs = db.selectQuery("SELECT * FROM screens;");
            ledTestRichText.Rtf = "";
            //screens = new LedScreen[ledThreads.Length];
            for (int i = 0; i < scrs.Length; i++)
            {
                screens[i] = LedScreen.InitLedScreen(scrs[i]);
            }
        }

        private void initDBButton_Click(object sender, EventArgs e)
        {
            if (initDB())
            {
                databaseStatus.Text = "OK";
                databaseStatus.ForeColor = Color.Green;
            }
            else
            {
                databaseStatus.Text = "БД не создана";
                databaseStatus.ForeColor = Color.Red;
            }
        }

        private void dbFileSelectButton_Click(object sender, EventArgs e)
        {
            DialogResult rs = openDBFile.ShowDialog();
            if (rs == DialogResult.OK)
            {
                dbFilePath.Text = openDBFile.FileName;
            }
        }

        private void runWebServiceButton_Click(object sender, EventArgs e)
        {
            if (srvThread.ThreadState == ThreadState.Stopped || srvThread.ThreadState == ThreadState.Suspended || srvThread.ThreadState == ThreadState.SuspendRequested || srvThread.ThreadState == ThreadState.Aborted || srvThread.ThreadState == ThreadState.AbortRequested || srvThread.ThreadState == ThreadState.StopRequested)
            {
                srvThread = new Thread(srvThreadMain);
            }
            srvThread.Start();
            webServerStatus.Text = "Запущен";
            webServerStatus.ForeColor = Color.Green;
        }

        private void stopWebServiceButton_Click(object sender, EventArgs e)
        {
            if (Listener != null)
            {
                Listener.Stop();
            }
            srvThread.Interrupt();
            srvThread.Abort();
            webServerStatus.Text = "Остановлен";
            webServerStatus.ForeColor = Color.Red;
            Program.Log("Server stopped");
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.serverAutoStart = serverAutoStart.Checked;
            Settings.Default.dbFilePath = dbFilePath.Text;
            Settings.Default.logDirectoryPath = logDirectoryPath.Text;
            Settings.Default.webServicePort = (int)serverPort.Value;
            Settings.Default.webServiceAddress = webServiceAddress.Text;
            Settings.Default.ledThreadsAutoStart = ledAutoStart.Checked;
            saveSettings();
        }

        private void resetSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            saveSettings();
            loadSettings();
        }

        private void selectLogDirButton_Click(object sender, EventArgs e)
        {
            DialogResult rs = logDirOpen.ShowDialog();
            if (rs == DialogResult.OK)
            {
                logDirectoryPath.Text = logDirOpen.SelectedPath;
            }
        }

        private void goToWEBInterface_Click(object sender, EventArgs e)
        {
            string bindAddress = webServiceAddress.Text;
            if (bindAddress == "0.0.0.0") bindAddress = "127.0.0.1";
            System.Diagnostics.Process.Start("http://" + bindAddress + ":" + serverPort.Value + "/");
        }

        private void toggleMainWindow_Click(object sender, EventArgs e)
        {
            if (this.Visible) this.Hide(); else this.Show();
        }
        public Dictionary<string, string>[] getVisitorsTable()
        {
            Dictionary<string, string>[] vS = db.selectQuery("SELECT * FROM (SELECT *, (strftime('%s',datetime(CURRENT_TIMESTAMP, 'localtime')) - strftime('%s',start))/60 -(SELECT value FROM settings WHERE key='setExpiryTimeout') as late, (strftime('%s',datetime(CURRENT_TIMESTAMP, 'localtime')) - strftime('%s',start))/60 as wait, (strftime('%s',datetime(CURRENT_TIMESTAMP, 'localtime')) - strftime('%s',end))/60 as waitDone FROM visitors WHERE status IN (0,1,2)) as foo WHERE status IN(0,1) OR status='2' AND waitDone<=(SELECT value FROM settings WHERE key='doneVisibleTimeout') ORDER BY done DESC, start DESC");
            Dictionary<string, string>[] newTable = new Dictionary<string, string>[vS.Length];
            int curInd = 0;
            foreach (Dictionary<string, string> row in vS)
            {
               // Program.Log("Found visitor with NUMBER=[" + row["number"] + "]");
                newTable[curInd] = new Dictionary<string, string>(row);
                newTable[curInd]["N"] = row["number"];
                DateTime startVis = DateTime.Parse(row["start"]);
                TimeSpan dT = new TimeSpan(DateTime.Now.Ticks - startVis.Ticks);

                switch (row["status"])
                {
                    case "0": //Добавить зависимость от размера строки
                        newTable[curInd]["S"] = "ОЖИДАНИЕ";
                        break;
                    case "1":
                newTable[curInd]["T"] = Convert.ToInt32(dT.TotalSeconds).ToString();
                        newTable[curInd]["S"] = "ОЖИДАНИЕ";
                        break;
                    case "2":
                        newTable[curInd]["S"] = "ГОТОВ";
                        break;
                    default:
                        break;
                }
                curInd++;
            }
            return newTable;
        }

        private void checkRefreshTimer_Tick(object sender, EventArgs e)
        {
            ledReload();
            loadSettingsFromDatabase();
            delayedLoadSettings();
            string fRtf = createRtfTable(1000);
            string rtf = createRtfTable(0);
            bool someChanged = false;
                Dictionary<string,string>[] stats =  db.selectQuery(" SELECT '0' as label,count(*) as cnt FROM visitors WHERE status IN (0,1)  AND start>date('now') ");
                if (stats.Length > 0 && visitorsWaitCount.Text != stats[0]["cnt"])
                {
                    someChanged = true;
                    visitorsWaitCount.Text = stats[0]["cnt"];
                }
                stats =  db.selectQuery(" SELECT '2' as label,count(*) as cnt FROM visitors WHERE status IN (2)  AND start>date('now') ");
                if (stats.Length > 0 && visitorsDoneCount.Text != stats[0]["cnt"])
                {
                    someChanged = true;
                    visitorsDoneCount.Text = stats[0]["cnt"];
                }
                stats =  db.selectQuery(" SELECT 'l' as label,count(*) as cnt FROM visitors WHERE status IN (0,1)  AND ((strftime('%s',datetime(CURRENT_TIMESTAMP, 'localtime')) - strftime('%s',start))/60 -(SELECT value FROM settings WHERE key='setExpiryTimeout'))>=0 ");
                if (stats.Length > 0 && visitorsLateCount.Text != stats[0]["cnt"])
                {
                    someChanged = true;
                    visitorsLateCount.Text = stats[0]["cnt"];
                }
                stats =  db.selectQuery(" SELECT 'a' as label,count(*) as cnt FROM visitors WHERE status IN (0,1,2)  AND  start>date('now')");
                if (stats.Length > 0 && visitorsOnlineCount.Text != stats[0]["cnt"])
                {
                    someChanged = true;
                    visitorsOnlineCount.Text = stats[0]["cnt"];
                }

                if (fRtf.CompareTo(oldFRtf) != 0 || rtf.CompareTo(oldRtf) != 0)
                {
                    ledTestRichText.Rtf = rtf;
                    ledTestRichTextFull.Rtf = fRtf;
                    int ledsOnline = sendToLed();
                    ledOnlineCount.Text = ledsOnline.ToString();
                    if (someChanged && Settings.Default.Properties["playSound"]!=null && Settings.Default.Properties["playSound"].DefaultValue.ToString() == "1" && oldFRtf!="")
                    {
                        System.Media.SoundPlayer play = new System.Media.SoundPlayer("sounds/play.wav");
                        play.Play();
                    }
                    oldFRtf = fRtf;
                    oldRtf = rtf;
                }
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Settings.Default.tplDirPath, "table.rtf"); 
            ledTestRichText.LoadFile(filePath, RichTextBoxStreamType.RichText);
        }

        private void ledAutoStart_CheckStateChanged(object sender, EventArgs e)
        {
            checkRefreshTimer.Enabled = ledAutoStart.Checked;
        }

        private void ledLogSuccess_CheckStateChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < screens.Length; i++)
            {
                if (screens[i] != null)
                {
                    lock (screens[i])
                    {
                        screens[i].logSuccessOpers = ledLogSuccess.Checked;
                    }
                }
            }
        }

        private void ledTestStunt_TextUpdate(object sender, EventArgs e)
        {
        }

        private void ledTestStunt_Validated(object sender, EventArgs e)
        {
            if (db.modifyQuery("UPDATE settings set value='" + ledTestStunt.Text + "' WHERE key='stuntCode'") > 0)
            {
                Settings.Default.Properties["stuntCode"].DefaultValue = ledTestStunt.Text;
                ledRestartButton_Click(null, null);
                sendTextToLedButton_Click(null, null);
            }
        }

        private void ledTestSpeed_Validated(object sender, EventArgs e)
        {
            if (db.modifyQuery("UPDATE settings set value='" + ledTestSpeed.Value + "' WHERE key='scrollSpeed'") > 0)
            {
                Settings.Default.Properties["scrollSpeed"].DefaultValue = ledTestSpeed.Value;
                ledRestartButton_Click(null, null);
                sendTextToLedButton_Click(null, null);
            }
        }

        private void ledTestDelay_Validated(object sender, EventArgs e)
        {
            if (db.modifyQuery("UPDATE settings set value='" + ledTestDelay.Value + "' WHERE key='scrollDelay'") > 0)
            {
                Settings.Default.Properties["scrollDelay"].DefaultValue = ledTestDelay.Value;
                ledRestartButton_Click(null, null);
                sendTextToLedButton_Click(null, null);
            }
        }

        public string createRtfTable(int beh){
            Dictionary<string, string>[] vTable = getVisitorsTable();
            string fontSize = Settings.Default.Properties["fontSize"].DefaultValue.ToString();
            string fontFamily = Settings.Default.Properties["fontFamily"].DefaultValue.ToString();
            string fullHtml = "<body>";
            //string fullHtml = "<body leftmargin=0 topmargin=0 ><table >";//style='font-size:" + fontSize + "px;font-family:" + fontFamily + "' align=left>",
            string html = "<body>";
            //string html = "<body leftmargin=0 topmargin=0 ><table >";// style='font-size:" + fontSize + "px;font-family:" + fontFamily + "'  align=left>";
            if (!Settings.Default.softActivated)
            {
                html += "<font color='red'>Неактивированная копия ПО</font><br>";
                fullHtml += "<font color='red'>Неактивированная копия ПО</font><br>";
            }
            if (vTable.Length == 0 && Settings.Default.Properties["idlePlayAdRtf"].DefaultValue.ToString() == "1")// && beh == 0)
            {
                Program.Log("idlePlayAdRtf detected.");
                string customRtf = "";
                if (File.Exists("templates/custom.rtf")) customRtf = File.ReadAllText("templates/custom.rtf");
                return customRtf;
            }
            foreach (Dictionary<string, string> visitor in vTable)
            {
                string color = "yellow";
                switch (visitor["status"])
                {
                    case "1":
                    case "0":
                        break;
                    case "2":
                        color = "green";
                        break;
                }
                string fColor=color;
                if (Convert.ToInt32(visitor["late"]) > 0 && color!="green" && beh==1000)
                {
                    fColor = "red";
                }
                //рассчитать по длине
                fullHtml += "<div style='white-space:nowrap;overflow:hidden;width:10;'>"; //проверить будет ли переносить текст
                html += "<div style='white-space:nowrap;overflow:hidden;width:10;'>";
                //fullHtml += "<font color='" + fColor + "'>" + visitor["number"] + "</font><font color=black>00</font><font color='" + fColor + "'>" + visitor["S"] + "</font><font color=black>00</font><font color='" + fColor + "'>" + visitor["wait"] + "</font>";
                fullHtml += "<font color='" + fColor + "'>" + visitor["number"] + "</font>&nbsp;<font color='" + fColor + "'>" + visitor["S"] + "</font> <font color='" + fColor + "'>" + visitor["wait"] + "</font>";
                // fullHtml += "<tr><td width=10></td><td width=50><font size='" + fontSize + "' color='" + fColor + "'>" + visitor["number"] + "</font></td><td width=100><font color='" + fColor + "'>" + visitor["S"] + "</font></td><td width=50><font color='" + fColor + "'>" + visitor["wait"] + "</font></td></tr>";
                //html += "<font color='" + fColor + "'>" + visitor["number"] + "</font><font color=black>000</font><font color='" + fColor + "'>" + visitor["S"] + "</font>";
                html += "<font color='" + fColor + "'>" + visitor["number"] + "</font>&nbsp;<font color='" + fColor + "'>" + visitor["S"] + "</font>";
                //html += "<tr><td width=10></td><td width=50><font size='" + fontSize + "'  color='" + color + "'>" + visitor["number"] + "</font></td><td width=100><font color='" + color + "'>" + visitor["S"] + "</font></td></tr>";
                fullHtml += "</div>";
                html += "</div>";
                //fullHtml += "<br>";
                //html += "<br>";
            }
            if(!Settings.Default.softActivated){
                html+="<font color='red'>Неактивированная копия ПО</font><br>";
                fullHtml+="<font color='red'>Неактивированная копия ПО</font><br>";
            }
            fullHtml += "</body>";// "</pre>";
            //fullHtml += "</table></body>";
            html += "</body>";// "</pre>";
            //html += "</table></body>";
            ledTestRichTextFulldbl.Clear();
            ledTestRichTextdbl.Clear();
            string styles = "<style>table{font-size:88px;border:1px solid red;}</style>";
            string fullRtf = FmtConverter.HTML2RTF(styles+fullHtml, ledTestRichTextFulldbl);
            string rtf = FmtConverter.HTML2RTF(styles + html, ledTestRichTextdbl);
            if (beh == 1000)
                return fullRtf;
            else
                return rtf;

        }
        private void queueToScreen_Click(object sender, EventArgs e)
        {
            ledTestRichTextFull.Rtf = createRtfTable(1000);
            ledTestRichText.Rtf = createRtfTable(0);
          //  sendToLed();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                forceClose = true;

            Close();
        }

        public void doRestart()
        {
            forceClose = true;
            Application.Restart();
        }
        private void перезапуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doRestart();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                //включаем хоткеи только на CONTROL
                switch (e.KeyCode)
                {
                    case Keys.R:
                            Program.Log("Hotkey RESTART (CTRL+R) GOT! Bye...");
                            doRestart();
                            return;
                    case Keys.D:
                            delayedLoadSettings();
                            return;
                    case Keys.Q:
                            Program.Log("Hotkey SHUTDOWN (CTRL+Q) GOT! Bye...");
                            forceClose = true;
                            this.Close();
                            return ;
                    case Keys.L:
                        if (e.Shift)
                        {
                            logWatch.Checked = false;
                        }
                        else
                        {
                            logWatch.Checked = true;
                        }
                        return;
                }
            }
        }

        private void перейтиВWEBинтерфейсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goToWEBInterface_Click(sender, e);
        }

        private void скрытьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleMainWindow_Click(sender, e);
        }

        private void открытьЖурналПриложенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            открытьЖурналToolStripMenuItem_Click(sender,e);
        }

        private void перезапуститьПриложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doRestart();
        }

        private void закрытьПриложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                forceClose = true;

            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программное обеспечение " + Application.ProductName +" версии "+ Application.ProductVersion + " предназначено для автоматизации обслуживания потока посетителей в очередях массового обслуживания.\n\nПроектирование и разработка: Евгений loSed Зайков\nКонтакты разработчика: тел. +7(913)913-0977, e-mail: info@0977.ru", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void активацияПрограммногоОбеспеченияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activationForm = new ActivationForm();
            activationForm.ShowDialog();
        }

        private void открытьЖурналПриложенияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            открытьЖурналToolStripMenuItem_Click(sender, e);
        }

        void checkUpdates()
        {
            dynamic updates = api.checkUpdates();
            Invoke((Action)(() =>
            {
                if (updates.returnCode)
                {
                    if (updates.result.version == Application.ProductVersion)
                        statusLabel.Text = "У Вас установлена последняя версия программного обеспечения";
                    else
                    {
                        if (MessageBox.Show("Доступно обновление до версии " + updates.result.version + "\nОбновить сейчас?", "Обновление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            dynamic dlUpdates = api.downloadUpdates(updates.result.downloadUrl);
                            if (dlUpdates.returnCode)
                            {
                                string path = Path.Combine(Settings.Default.statusDirectoryPath, ProductName+"_"+updates.result.version+"_updates.exe");
                                File.WriteAllBytes(path, Convert.FromBase64String(dlUpdates.result.file));
                                forceClose = true;
                                Application.Exit();
                                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(path);

                                proc.Close();

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось проверить обновления");
                }
            }));
        }

        private void проверитьНаличиеОбновленийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(checkUpdates);
            thread.Start();
        }

        private void регистрацияПОЧерезИнтернетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserApi api = new UserApi(Program.fingerPrint);
            dynamic reg = api.registerInstance();
            if (reg.result != null)
            {
                if (reg.result.actCode != null)
                {
                    string actCode = reg.result.actCode;
                    Program.Log("Software copy is activated - checking serial!");
                    string codePath = Path.Combine(Settings.Default.statusDirectoryPath, "status-255.ini");
                    File.WriteAllText(codePath, actCode);
                    //doRestart();
                    MessageBox.Show("Код регистрации получен и записан. Перезапустите приложение");

                }
            }
        }

        private void изменитьРекламныйКонтентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wordpad"," templates/custom.rtf");
        }



    }
}
