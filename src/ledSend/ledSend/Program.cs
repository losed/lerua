using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ledSend
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 6)
                return 1;
            string pScreenStatusFile = args[4],
                pIpAddress = args[0],
                cmd = args[5],fileName="";
            int screenNumber = 1,
                nWidth = Convert.ToInt32(args[2]),
                nHeight = Convert.ToInt32(args[3]),
                nPort = Convert.ToInt32(args[1]),
                nStunt = 30, 
                nScrollSpeed=20, 
                nShowTime=0;

            
            try
            {
                int nResult = LEDInterface.AddScreen(LEDInterface.CONTROLLER_TYPE.bx5M1, 1, nWidth, nHeight,
                           LEDInterface.SCREEN_TYPE.DUAL_COLOR, LEDInterface.PIXEL_MODE.RG,
                           LEDInterface.DATA_DA.POSITIVE, LEDInterface.DATA_OE.OE_LOW,
                           LEDInterface.ROW_ORDER.NORMAL, LEDInterface.FREQ_PAR.ZERO,
                           "", 57600, pIpAddress, nPort, "", 5005, pScreenStatusFile);
                if (nResult != 0)
                {
                    return nResult;
                }
                nResult = LEDInterface.GetScreenStatus(screenNumber, (int)LEDInterface.SEND_MODE.NET);
                if (nResult != 0)
                {
                    return nResult;
                }
                switch (cmd)
                {
                    case "showRtf":
                        fileName = args[6];
                        if (args.Length == 10)
                        {
                            nStunt = Convert.ToInt32(args[7]);
                            nScrollSpeed = Convert.ToInt32(args[8]);
                            nShowTime = Convert.ToInt32(args[9]);
                        }
                        nResult = LEDInterface.DeleteScreenProgram(screenNumber, 0);
                        nResult = LEDInterface.AddScreenProgram(screenNumber, (int)LEDInterface.PROGRAM_TYPE.SIMPLE, (int)LEDInterface.PLAY_LENGTH.AUTO, 65535 /*DateTime.Now.Year*/, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 1, 1, 1, 1, 1, 1, 0, 0, 23, 59);
                        if (nResult != 0)
                        {
                            return nResult;
                        }

                        nResult = LEDInterface.AddScreenProgramBmpTextArea(screenNumber, 0, 0, 0, nWidth, nHeight);
                        if (nResult != 0)
                        {
                            return nResult;
                        }

                        nResult = LEDInterface.AddScreenProgramAreaBmpTextFile(screenNumber, 0, 0, fileName, 1, "Tahoma", 10, 0, 5500, nStunt, nScrollSpeed, nShowTime);
                        if (nResult != 0)
                        {
                            return nResult;
                        }
                        return LEDInterface.SendScreenInfo(screenNumber, LEDInterface.SEND_MODE.NET, LEDInterface.SEND_CMD.SENDALLPROGRAM, 0);
                        break;
                    case "resetShowRtf":
                            fileName = args[6];
                                if (args.Length == 10)
                                {
                                    nStunt = Convert.ToInt32(args[7]);
                                    nScrollSpeed = Convert.ToInt32(args[8]);
                                    nShowTime = Convert.ToInt32(args[9]);
                                }

                            nResult = LEDInterface.SendScreenInfo(1, LEDInterface.SEND_MODE.NET, LEDInterface.SEND_CMD.PARAMETER, 1);
                            if (nResult != 0)
                            {
                                return nResult;
                            }
                            nResult = LEDInterface.AddScreenProgram(screenNumber, (int)LEDInterface.PROGRAM_TYPE.SIMPLE, (int)LEDInterface.PLAY_LENGTH.AUTO, 65535 /*DateTime.Now.Year*/, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 1, 1, 1, 1, 1, 1, 0, 0, 23, 59);
                            if (nResult != 0)
                            {
                                return nResult;
                            }

                            nResult = LEDInterface.AddScreenProgramBmpTextArea(screenNumber, 0, 0, 0, nWidth, nHeight);
                            if (nResult != 0)
                            {
                                return nResult;
                            }

                            nResult = LEDInterface.AddScreenProgramAreaBmpTextFile(screenNumber, 0, 0, fileName, 1, "Tahoma", 10, 0, 5500, nStunt, nScrollSpeed, nShowTime);
                            if (nResult != 0)
                            {
                                return nResult;
                            }
                            return LEDInterface.SendScreenInfo(screenNumber, LEDInterface.SEND_MODE.NET, LEDInterface.SEND_CMD.SENDALLPROGRAM, 0);
                        break;
                    case "powerOn":
                             return LEDInterface.SendScreenInfo(screenNumber, LEDInterface.SEND_MODE.NET, LEDInterface.SEND_CMD.POWERON, 0);
                        break;
                    case "powerOff":
                             return LEDInterface.SendScreenInfo(screenNumber, LEDInterface.SEND_MODE.NET, LEDInterface.SEND_CMD.POWEROFF, 0);
                        break;
                    case "adjustBrightness":
                        int level = Convert.ToInt32(args[6]);
                            nResult = LEDInterface.SetScreenAdjustLight(screenNumber, LEDInterface.ADDJUST_TYPE.MANUAL, level, 0, 0, 0, 6, 0, 0, 12, 0, 0, 18, 0, 0);
                            if (nResult != 0) return nResult;
                            return LEDInterface.SendScreenInfo(screenNumber, LEDInterface.SEND_MODE.NET, LEDInterface.SEND_CMD.ADJUSTLIGHT, 0);
                        break;
                }
                return 0;

            }
            catch (Exception ex)
            {
                return 1;
            }
        }
    }
}
