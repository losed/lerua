using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using iQueue.Properties;

namespace iQueue
{
    static class Program
    {
        public static string fingerPrint;
        public static void Log(string mess)
        {
            if (!Directory.Exists(Settings.Default.logDirectoryPath))
            {
                Directory.CreateDirectory(Settings.Default.logDirectoryPath);
            }
            string PID = "";// Thread.CurrentThread.Name + "-";
            if (mess.IndexOf("Exception") != -1)
                PID += "EXC-";

            string filePath = Path.Combine(Settings.Default.logDirectoryPath, PID + DateTime.Today.Year + "_" + DateTime.Today.Month + "_" + DateTime.Today.Day + ".log");
            int tries = 0;
            do
            {
                tries++;
                try
                {
                    string line = "[" + DateTime.Now.ToString() + "] PID=[" + Thread.CurrentThread.ManagedThreadId.ToString() + "] ThreadName=[" + Thread.CurrentThread.Name + "] " + mess + "\n";
                    bool done = false;
                    do
                    {
                        done = false;
                        try
                        {
                            StreamWriter wr = File.AppendText(filePath);
                            wr.Write(line);
                            wr.Flush();
                            wr.Close();
                            done = true;
                        }
                        catch (Exception ex2)
                        {
                            Console.WriteLine("Exception", ex2);
                            //Program.Log("Exception while trying to writeToLogFile Exception.Message:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");
                        }

                    } while (!done);

                    return;
                }
                catch (Exception ex)
                {
                    Program.Log("Exception while trying to writeToLogFile Exception.Message:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");

                }
            } while (tries < 100);
        }

        public static void Log(string mess, string type)
        {
            string newMessage = "[###" + type.ToUpperInvariant() + "###] " + mess;
            Log(newMessage);
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            fingerPrint = FingerPrint.Value();
            Program.Log("System ID = [" + fingerPrint + "]");
            Thread.CurrentThread.Name = "MainThread";
            if (!Directory.Exists(Settings.Default.statusDirectoryPath))
            {
                Directory.CreateDirectory(Settings.Default.statusDirectoryPath);
                if (!Directory.Exists(Path.Combine(Settings.Default.statusDirectoryPath,"showing")))
                {
                    Directory.CreateDirectory(Path.Combine(Settings.Default.statusDirectoryPath, "showing"));
                }
            }
            if (!Directory.Exists("bin"))
            {
                Directory.CreateDirectory("bin");
                byte[] dllCntnt = Properties.Resources.LED_DLL;
                string dllFilePath = Path.Combine("bin", "ledDll.dll");
                File.WriteAllBytes(dllFilePath, dllCntnt);

                byte[] exeCntnt = Properties.Resources.ledSend;
                string ledFilePath = Path.Combine("bin", "ledSend.exe");
                File.WriteAllBytes(ledFilePath, exeCntnt);
            }
            if (!Directory.Exists(Settings.Default.tplDirPath))
            {
                Directory.CreateDirectory(Settings.Default.tplDirPath);
            }

            if (!Directory.Exists(Settings.Default.statusDirectoryPath))
            {
                Directory.CreateDirectory(Settings.Default.statusDirectoryPath);
            }
          /*  int MaxThreadsCount = Environment.ProcessorCount * 4;
            ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
