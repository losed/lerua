﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using iQueue.Properties;

namespace iQueue
{

    public class LedInterface
    {
        
        public string libPath;
        public IntPtr dllHandle;
        public IntPtr funcHandler;
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32", CharSet = CharSet.Ansi)]
        private static extern IntPtr GetProcAddress(int hwnd, string procedureName);

       public  delegate int addScreen(CONTROLLER_TYPE nControlType, int nScreenNo,
                                        int nWidth, int nHeight, SCREEN_TYPE nScreenType, PIXEL_MODE nPixelMode, DATA_DA nDataDA,
                                        DATA_OE nDataOE, ROW_ORDER nRowOrder, FREQ_PAR nFreqPar, string pCom, int nBaud,
                                        string pSocketIP, int nSocketPort, string pWiFiIP, int nWiFiPort, string pScreenStatusFile); //Добавить экране
        
       public   delegate int deleteScreen(int nScreenNo);//Удалить экрана

       public   delegate int sendScreenInfo(int nScreenNo, SEND_MODE nSendMode, SEND_CMD nSendCmd, int nOtherParam1);//Отправить соответствующие команды на дисплей。 

       public   delegate int addScreenProgram(int nScreenNo, int nProgramType, int nPlayLength,
            int nStartYear, int nStartMonth, int nStartDay, int nEndYear, int nEndMonth, int nEndDay,
            int nMonPlay, int nTuesPlay, int nWedPlay, int nThursPlay, int bFriPlay, int nSatPlay, int nSunPlay,
            int nStartHour, int nStartMinute, int nEndHour, int nEndMinute); //Добавить программу в указанный дисплей； 
       public   delegate int deleteScreenProgram(int nScreenNo, int nProgramOrd); //Удаление программ
       public   delegate int deleteScreenProgramArea(int nScreenNo, int nProgramOrd, int nAreaOrd);//Удалить зоны
       public   delegate int addScreenProgramBmpTextArea(int nScreenNo, int nProgramOrd, int nX, int nY,
                                                            int nWidth, int nHeight);//Добавить в указанном графическом дисплее участок, предназначенный программы；
       public   delegate int addScreenProgramAreaBmpTextFile(int nScreenNo, int nProgramOrd, int nAreaOrd,
                                                                string pFileName, int nShowSingle, string pFontName, int nFontSize, int nBold, int nFontColor,
                                                                int nStunt, int nRunSpeed, int nShowTime); //Укажите нужный, чтобы добавить файл, указанный участок, предназначенный программы
       public   delegate int deleteScreenProgramAreaBmpTextFile(int nScreenNo, int nProgramOrd, int nAreaOrd, int nFileOrd); //Удаляет указанную область отображения графической программе назначенный указанному файлу указан，Удалить файлы после успешной удалить информацию о файле
       public   delegate int setScreenAdjustLight(int nScreenNo, ADDJUST_TYPE nAdjustType, int nHandleLight, int nHour1, int nMinute1, int nLight1, int nHour2, int nMinute2, int nLight2, int nHour3, int nMinute3, int nLight3, int nHour4, int nMinute4, int nLight4); //задает уровень яркости

       public   delegate int getScreenStatus(int nScreenNo, int nSendMode);
        //==============================================================================
        //коды ошибок
        public enum RETURN_ERROR:int
        {
            AERETYPE = 0xF7,//Тип зоны ошибки, добавлять, удалять, графический файл зоны возвращает эту ошибку, если тип зоны типа ошибки.
            RA_SCREENNO = 0xF8,  //Дисплей имеет информации. Если Вам необходимо изменить, пожалуйста, удалите дисплей, а затем добавить DeleteScreen,
            NOFIND_AREAFILE = 0xF9, //Нет правильного файла зоны (участки изображения), 
            NOFIND_AREA = 0xFA,  //Не найдено эффективная площадь изображения, региональная информация может быть использована для добавления AddScreenProgramBmpTextArea.
            NOFIND_PROGRAM = 0xFB,  //Нет правильная программа дисплей, AddScreenProgram функция не может быть использована для добавления указанной программы
            NOFIND_SCREENNO = 0xFC,  //Система не находит дисплей, AddScreen функция может быть использована для добавления дисплей 
            NOW_SENDING = 0xFD, //Связь с системой отображения, которые, зайдите чуть позже связь,
            OTHER = 0xFF, //Другие ошибки, 
            NOERROR = 0, //нет ошибки 
            NOSUPPORT_USB = 0xF6, //не поддерживается USB-режим
            NO_USB_DISK=0xF5 //нет USB-диска
        }
        //==============================================================================
        // Тип контроллера
        public enum CONTROLLER_TYPE:int
        {
            bx5AT = 81,
            bx5A0 = 337,
            bx5A1 = 593,
            bx5A1_WiFi = 1617,
            bx5A = 2385,
            bx5A2 = 849,
            bx5A2_RF = 4945,
            bx5A2_WiFi = 1873,
            bx5A3 = 1105,
            bx5A4 = 1361,
            bx5A4_RF = 5457,
            bx5A4_WiFi = 2129,
            bx5M1 = 82,
            bx5M2 = 594,
            bx5M3 = 850,
            bx5M4 = 1106,
            bx5UT = 85,
            bx5U0 = 341,
            bx5U1 = 597,
            bx5U2 = 853,
            bx5U3 = 1109,
            bx5U4 = 1365,
            bx5E1 = 340,
            bx5E2 = 596,
            bx5E3 = 852,
            bx5Q1 = 342,
            bx5Q2 = 598,
            bx5QS1 = 343,
            bx5QS2 = 599,
            bx5QS = 855,
            bx4T1 = 320,
            bx4T2 = 576,
            bx4T3 = 832,
            bx4A1 = 321,
            bx4A2 = 577,
            bx4A3 = 833,
            bx4AQ = 4161,
            bx4A = 65,
            bx4UT = 1093,
            bx4U0 = 69,
            bx4U1 = 325,
            bx4U2 = 581,
            bx4U2X = 1349,
            bx4U3 = 837,
            bx4M0 = 578,
            bx4M1 = 322,
            bx4M = 66,
            bx4MC = 3138,
            bx4C = 67,
            bx4E1 = 324,
            bx4E = 68,
            bx4EL = 2116,
            bx3T = 16,
            bx3A1 = 33,
            bx3A2 = 34,
            bx3A = 32,
            bx3M = 48,
            bx5Q0plus = 4182,
            bx5Q1plus = 4438,
            bx5Q2plus = 4694,
            bx5QS1plus = 4439,
            bx5QS2plus = 4695,
            bx5QSplus = 4951
        }
        //==============================================================================
        // Режим связи контроллера
        public enum SEND_MODE:int
        {
            COMM = 0,
            NET = 2
        }
        //==============================================================================
        // коды команды "пользовательского" режима
        public enum SEND_CMD:int
        {
            PARAMETER = 0xA1FF, //Экран загрузки параметров.
            SCREENSCAN = 0xA1FE, //Установите режим сканирования.
            SENDALLPROGRAM = 0xA1F0, //Отправить всю информацию о программе
            POWERON = 0xA2FF, //Принудительная загрузка
            POWEROFF = 0xA2FE, //Принудительное отключение
            TIMERPOWERONOFF = 0xA2FD, //Таймером
            CANCEL_TIMERPOWERONOFF = 0xA2FC, //Отменить таймер
            RESIVETIME = 0xA2FB, //время коррекции
            ADJUSTLIGHT = 0xA2FA //регулировка яркости
        }
        //==============================================================================
        // Тип модулей (цветность)
        public enum SCREEN_TYPE : int
        {
            SINGLE_COLOR = 1,
            DUAL_COLOR = 2,
            FULL_COLOR = 3
        }
        //==============================================================================
        // Тип пикселей
         public enum PIXEL_MODE : int{
             RG = 1,
             GR = 2
         }
         //==============================================================================
         // полярность данных
         public enum DATA_DA : int{
             NEGATIVE = 0,
             POSITIVE = 1
         }
         //==============================================================================
         // OE polarity
         public enum DATA_OE : int{
             OE_LOW = 0,
             OE_HIGH = 1
         }
         //==============================================================================
         // порядок строк
         public enum ROW_ORDER : int{
             NORMAL = 0,
             ADD_ONE_LINE = 1,
             DELETE_ONE_LINE = 2
         }
         //==============================================================================
         //Scan frequency
         public enum FREQ_PAR : int{
             ZERO = 0,
             ONE = 1,
             TWO = 2,
             THREE = 3,
             FOUR = 4,
             FIVE = 5,
             SIX = 6
         }
         //==============================================================================
         //Color code
         public enum TXT_COLOR_CODE : int
         {
             BLACK = 0,
             RED = 1,
             GREEN = 2,
             YELLOW = 3,
             BLUE = 4,
             MAUVE = 5,
             LIGHTGREEN = 6,
             WHITE = 7
         }
         //==============================================================================
         //STUNT EFFECT
         public enum STUNT_CODE : int
         {
           RANDOM =  0x00,
           STATIC = 0x01,
           DIRECT_SHOW = 0x02,
           MOVE_LEFT = 0x03,
           CONTINOUS_MOVE_LEFT = 0x04,
           MOVE_UP = 0x05,
          CONTINOUS_MOVE_UP = 0x06/*
0x07: flicker BX-3T do not support
0x08: snowing
0x09: bubbling
0x0A: middle out
0x0B: move around
0x0C: horizontal cross move
0x0D: vertical cross move
0x0E: scroll closed
0x0F: scroll opened
0x10: left stretch
0x11: right stretch
0x12: up stretch
0x13: down stretch BX-3T do not support
0x14: left laser
0x15: right laser
0x16: up laser
0x17: down laser
0x18: cross curtain left and right
0x19: cross curtain up and down 3T、3A、4A、3A1、3A2、4A1、4A2、4A3、4AQ do not
support
0x1A: curtain scattered to the left 3T、3A、4A、3A1、3A2、4A1、4A2、4A3、4AQ do not
support
0x1B: horizontal blinds
0x1C: vertical blinds 3M、4M、4M1、4MC 类型控制卡无此特技do not support
Ox1D: Curtain left 3T、3A、4A do not support
Ox1E: Curtain right 3T、3A、4A do not support
0x1F: Curtain up 3T、3A、4A do not support
0x20: Curtain down (Above:except 3T/3A/4A) 3T、3A、4A do not support
0x21: Move to center from left and right 3T do not support
0x22: Split to left and right 3T do not support
0x23: Move to center from up and down 3T do not support
0x24: Split to up and down 3T do not support
0x25: Move right
BX-IV Dynamic Library User Manual/shanghai ONBON software technology co.,ltd
0x26: Continuum move right
0x27: Move down 3T do not support
0x28: Continuum move down 3T do not support
Return value: Integer*/
         }
         //==============================================================================
         //LIGHT ADDJUST TYPE
         public enum ADDJUST_TYPE : int
         {
            MANUAL = 0,
            AUTO = 1
         }
         //==============================================================================
         // PROGRAM_TYPE 
         public enum PROGRAM_TYPE : int
         {
            SIMPLE = 0,
            COMPLEX = 1
         }
         //==============================================================================
         //PLAY_LENGTH
         public enum PLAY_LENGTH : int
         {
            AUTO = 0
         }
         //==============================================================================
         
         //error function
        public static string GetErrorMessage(string szfunctionName, int nResult)
        {
            string szResult, errorMessage = "";
            DateTime dt = DateTime.Now;
            szResult = dt.ToString() + " функция [" + szfunctionName + "] возврат=[" + nResult.ToString()+"] ";
            switch (nResult)
            {
                case (int)RETURN_ERROR.AERETYPE:
                    errorMessage = szResult + "Тип зоны ошибки, добавлять, удалять, графический файл зоны возвращает эту ошибку, если тип зоны типа ошибки. errorMessage=[" + errorMessage + "]";
                    break;
                case (int)RETURN_ERROR.RA_SCREENNO:
                    errorMessage = szResult + "Дисплей имеет информацию. Если Вам необходимо изменить, пожалуйста, удалите дисплей, а затем добавьте снова errorMessage=[" + errorMessage + "]";
                    break;
                case (int)RETURN_ERROR.NOFIND_AREAFILE:
                    errorMessage = szResult + "Нет правильного файла зоны (участки изображения) errorMessage=[" + errorMessage + "]";
                    break;
                case (int)RETURN_ERROR.NOFIND_AREA:
                    errorMessage = szResult + "Нет эффективной площади с указанным индексом. errorMessage=[" + errorMessage + "]";
                    break;
                case (int)RETURN_ERROR.NOFIND_PROGRAM:
                    errorMessage = szResult + "Нет программы с указанным индексом errorMessage=[" + errorMessage + "]";
                    break;
                case (int)RETURN_ERROR.NOFIND_SCREENNO:
                    errorMessage = szResult + "Система не находит экран с заданным индексом errorMessage=[" + errorMessage + "]";
                    break;
                case (int)RETURN_ERROR.NOW_SENDING:
                    errorMessage = szResult + "В настоящий момент идет отправка. errorMessage=[" + errorMessage + "]";
                    break;
                case (int)RETURN_ERROR.OTHER:
                    errorMessage = szResult + "Другие ошибки errorMessage=[" + errorMessage + "]";
                    break;
                case (int)RETURN_ERROR.NOERROR:
                    szResult = dt.ToString() + " функция [" + szfunctionName + "] OK";
                    errorMessage = szResult;
                    break;
                case 0x01:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x02:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x03:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x04:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x05:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x06:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x07:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x08:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x09:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x0A:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x0B:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x0C:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x0D:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x0E:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x0F:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x10:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x11:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x12:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x13:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x14:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x15:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x16:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x17:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0x18:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
                case 0xFE:
                    errorMessage = szResult + "ошибка связи #" + nResult + " errorMessage=[" + errorMessage + "]";
                    break;
            }
            return errorMessage;

        }
        public addScreen  AddScreen;
        public deleteScreen  DeleteScreen;
        public sendScreenInfo  SendScreenInfo;
        public addScreenProgram  AddScreenProgram;
        public deleteScreenProgram  DeleteScreenProgram;
        public deleteScreenProgramArea  DeleteScreenProgramArea;
        public addScreenProgramBmpTextArea  AddScreenProgramBmpTextArea;
        public addScreenProgramAreaBmpTextFile  AddScreenProgramAreaBmpTextFile;
        public deleteScreenProgramAreaBmpTextFile  DeleteScreenProgramAreaBmpTextFile;
        public setScreenAdjustLight  SetScreenAdjustLight;
        public getScreenStatus GetScreenStatus;

        public LedInterface()
        {
            libPath="BX_IV.dll";
            this.dllHandle = LoadLibrary(this.libPath);
            int err = Marshal.GetLastWin32Error();
          //  Program.Log("LedInterface constructor. LastError = " + err);
            funcHandler = GetProcAddress((int)this.dllHandle, "AddScreen");
            AddScreen = (addScreen)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(addScreen));

            funcHandler = GetProcAddress((int)this.dllHandle, "DeleteScreen");
            DeleteScreen = (deleteScreen)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(deleteScreen));

            funcHandler = GetProcAddress((int)this.dllHandle, "SendScreenInfo");
            SendScreenInfo = (sendScreenInfo)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(sendScreenInfo));

            funcHandler = GetProcAddress((int)this.dllHandle, "AddScreenProgram");
            AddScreenProgram = (addScreenProgram)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(addScreenProgram));

            funcHandler = GetProcAddress((int)this.dllHandle, "DeleteScreenProgram");
            DeleteScreenProgram = (deleteScreenProgram)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(deleteScreenProgram));

            funcHandler = GetProcAddress((int)this.dllHandle, "DeleteScreenProgramArea");
            DeleteScreenProgramArea = (deleteScreenProgramArea)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(deleteScreenProgramArea));

            funcHandler = GetProcAddress((int)this.dllHandle, "AddScreenProgramBmpTextArea");
            AddScreenProgramBmpTextArea = (addScreenProgramBmpTextArea)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(addScreenProgramBmpTextArea));

            funcHandler = GetProcAddress((int)this.dllHandle, "AddScreenProgramAreaBmpTextFile");
            AddScreenProgramAreaBmpTextFile = (addScreenProgramAreaBmpTextFile)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(addScreenProgramAreaBmpTextFile));

            funcHandler = GetProcAddress((int)this.dllHandle, "DeleteScreenProgramAreaBmpTextFile");
            DeleteScreenProgramAreaBmpTextFile = (deleteScreenProgramAreaBmpTextFile)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(deleteScreenProgramAreaBmpTextFile));

            funcHandler = GetProcAddress((int)this.dllHandle, "SetScreenAdjustLight");
            SetScreenAdjustLight = (setScreenAdjustLight)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(setScreenAdjustLight));

            funcHandler = GetProcAddress((int)this.dllHandle, "GetScreenStatus");
            GetScreenStatus = (getScreenStatus)Marshal.GetDelegateForFunctionPointer(funcHandler, typeof(getScreenStatus));
	   


        }

        public bool unloadDll(){
            if (this.dllHandle != null)
            {
                FreeLibrary(this.dllHandle);
                int err = Marshal.GetLastWin32Error();
              //  Program.Log("LedInterface unloadDll. LastError = " + err);
                return true;
            }

            return false;
        }
        ~LedInterface()
        {
            if (this.dllHandle != null)
            {
                FreeLibrary(this.dllHandle);
                int err = Marshal.GetLastWin32Error();
               // Program.Log("LedInterface destructor. LastError = " + err);
            }
            
        }
    }
}
