using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using iQueue.Properties;


namespace iQueue
{
   public  class LedScreen
    {
       //для логов
       public bool logSuccessOpers;

       public Thread runThread;
        public int screenNumber;
        public int programNumber;
        public int areaCount;
        public int width;
        public int height;
        public int ipPort;
        public string ipAddress;
        public int txtTimeout = 0;
        public string screenStatusFile;
        public Dictionary<string, string> statusObj;
        public int bmpAreaCount;
        public int behavior;
        public RichTextBox richBox;
        public int stuntCode;
        public int scrollSpeed;
        public int scrollDelay;
        private Dictionary<string, string> dictionary;
        public static LedScreen InitLedScreen(Dictionary<string, string> screenData)            
        {
            int screenNo = 1;
            string pIpAddress="";
            int pIpPort = 5005, nWidth=32, nHeight = 16;
            int pBehavior = 0;
            if (screenData["id"] != null)
            {
                screenNo = Convert.ToInt32(screenData["id"]);
            }
            if (screenData["ip"] != null)
            {
                pIpAddress = screenData["ip"];
            }
            if (screenData["port"] != null)
            {
                pIpPort = Convert.ToInt32(screenData["port"]);
            }
            if (screenData["width"] != null)
            {
                nWidth = Convert.ToInt32(screenData["width"]);
            }
            if (screenData["height"] != null)
            {
                nHeight = Convert.ToInt32(screenData["height"]);
            }
            if (screenData["behavior"] != null)
            {
                pBehavior = Convert.ToInt32(screenData["behavior"]);
            }
            string pScreenStatusFile = Path.Combine(Settings.Default.statusDirectoryPath, "status-"+screenNo+".ini");
            return new LedScreen(screenNo, pIpAddress, pIpPort, nWidth, nHeight, pScreenStatusFile, pBehavior);
        } 

        public LedScreen(int screenNo, string pIpAddress, int pIpPort, int nWidth, int nHeight, string pScreenStatusFile,int pBehavior)
        {
            try
            {
               // LEDInterface = new LedInterface();
                this.logSuccessOpers = true;
                string stuntStr = Settings.Default.Properties["stuntCode"].DefaultValue.ToString();
                string[] arr = stuntStr.Split(':');
                this.stuntCode = Convert.ToInt32(arr[0], 16);
                this.scrollSpeed = Convert.ToInt32(Settings.Default.Properties["scrollSpeed"].DefaultValue);
                this.scrollDelay = Convert.ToInt32(Settings.Default.Properties["scrollDelay"].DefaultValue);
                this.behavior = 0;
               // int nResult = 0;
                this.screenNumber = 0;
                this.bmpAreaCount = 0;
                this.screenStatusFile = "";
              //  int nBaud = 57600,
             //       nWiFiPort = 5005;
              //  string pCom = "",
              //          pWiFiIP = "";
                this.richBox = new RichTextBox();
                this.statusObj = new Dictionary<string, string>();
                this.screenStatusFile = pScreenStatusFile;
                if (!File.Exists(this.screenStatusFile)) File.WriteAllText(this.screenStatusFile, "");
                this.ipAddress = pIpAddress;
                this.ipPort = pIpPort;
                var client = new TcpClient();
                var result = client.BeginConnect(pIpAddress, pIpPort, null, null);

                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

                if (!success)
                {
                    throw new Exception("Failed to connect.");
                }
                else
                {
                    this.screenNumber = screenNo;
                    this.behavior = pBehavior;
                    this.width = nWidth;
                    this.height = nHeight;
                }

                // we have connected
                client.EndConnect(result);
                client.Close();

                Program.Log("LedScreen created: " + this.ToString());
               
            }
            catch (Exception ex)
            {
                Program.Log("Exception while creating ledScreen = " + ex.Message + " stack=["+ex.StackTrace+"]");
            }
        }

        public LedScreen(Dictionary<string, string> dictionary)
        {
            // TODO: Complete member initialization
            this.dictionary = dictionary;
        }
       /******************* END OF MAIN CONSTRUCTOR**************************/
        public override string ToString()
        {
            string res = "";
            res += "LED#" + this.screenNumber.ToString() + " IP#" + this.ipAddress + " PORT#" + this.ipPort.ToString();
            return res;
        }

        public bool powerOff()
        {

            string ledSendExe = Path.Combine("bin", "ledSend.exe");
            string cmd = "powerOff";
            string args = "\"" + this.ipAddress + "\" " + this.ipPort + " " + this.width + " " + this.height + " \"" + this.screenStatusFile + "\" " + cmd;// +" \"" + fileName + "\" " + this.stuntCode + " " + this.scrollSpeed + " " + this.scrollDelay;
            Program.Log("Running " + ledSendExe + " " + args);
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(ledSendExe, args);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            //   startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.ErrorDialog = false;
            System.Diagnostics.Process proc = null;
            try
            {
                proc = System.Diagnostics.Process.Start(startInfo);
                if(!proc.WaitForExit(1000)) // если не дождались завершения за секунду - убиваем
                    proc.Kill();
                return true;
            }
            catch (Exception)
            {
                // proc.Kill();
            }

            return false;             

        }
        public bool powerOn()
        {
            string ledSendExe = Path.Combine("bin", "ledSend.exe");
            string cmd = "powerOn";
            string args = "\"" + this.ipAddress + "\" " + this.ipPort + " " + this.width + " " + this.height + " \"" + this.screenStatusFile + "\" " + cmd;// +" \"" + fileName + "\" " + this.stuntCode + " " + this.scrollSpeed + " " + this.scrollDelay;
            Program.Log("Running " + ledSendExe + " " + args);
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(ledSendExe, args);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            //   startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.ErrorDialog = false;
            System.Diagnostics.Process proc = null;
            try
            {
                proc = System.Diagnostics.Process.Start(startInfo);
                proc.WaitForExit(1000);
                return true;
            }
            catch (Exception)
            {
                // proc.Kill();
            }

            return false;   

        }

        public bool setBrightness(int value)
        {

            string ledSendExe = Path.Combine("bin", "ledSend.exe");
            string cmd = "adjustBrightness";
            string args = "\"" + this.ipAddress + "\" " + this.ipPort + " " + this.width + " " + this.height + " \"" + this.screenStatusFile + "\" " + cmd +" "+value;//\"" + fileName + "\" " + this.stuntCode + " " + this.scrollSpeed + " " + this.scrollDelay;
            Program.Log("Running " + ledSendExe + " " + args);
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(ledSendExe, args);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            //   startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.ErrorDialog = false;
            System.Diagnostics.Process proc = null;
            try
            {
                proc = System.Diagnostics.Process.Start(startInfo);
                proc.WaitForExit(1000);
                return true;
            }
            catch (Exception)
            {
                // proc.Kill();
            }

            return false;   
        }

        public bool getScreenStatus()
        {

            return true;
        }

        public void showOnScreen()
        {

        }
        public bool playOnScreen(string fileName)
        {
            string ledSendExe = Path.Combine("bin", "ledSend.exe");
            string cmd = "showRtf";
            string args = "\"" + this.ipAddress + "\" " + this.ipPort + " " + this.width + " " + this.height + " \"" + this.screenStatusFile + "\" " + cmd + " \"" + fileName + "\" " + this.stuntCode + " " + this.scrollSpeed + " " + this.scrollDelay;
            Program.Log("Running " + ledSendExe + " " + args);
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(ledSendExe, args);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            //   startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.ErrorDialog = false;
            System.Diagnostics.Process proc = null;
            try
            {
                proc = System.Diagnostics.Process.Start(startInfo);
                proc.WaitForExit(1000);
                return true;
            }
            catch (Exception)
            {
               // proc.Kill();
            }
            
            return false;            

        }

        public bool resetPlayOnScreen(string fileName)
        {
            string ledSendExe = Path.Combine("bin", "ledSend.exe");
            string cmd = "resetShowRtf";
            string args = "\"" + this.ipAddress + "\" " + this.ipPort + " " + this.width + " " + this.height + " \"" + this.screenStatusFile + "\" " + cmd + " \"" + fileName + "\" " + this.stuntCode + " " + this.scrollSpeed + " " + this.scrollDelay;
            Program.Log("Running " + ledSendExe + " " + args);
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(ledSendExe, args);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            //   startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.ErrorDialog = false;
            System.Diagnostics.Process proc = null;
            try
            {
                proc = System.Diagnostics.Process.Start(startInfo);
                proc.WaitForExit(1000);
                return true;
            }
            catch (Exception)
            {
                // proc.Kill();
            }

            return false;

        }
    
        ~LedScreen()
        {
            if (this.runThread!=null)
            {
                runThread.Abort();
                runThread.Join();
            }
        }
    }
}
