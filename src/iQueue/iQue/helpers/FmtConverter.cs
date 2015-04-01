using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using HtmlRenderer;
using MarkupConverter;
using iQueue.Properties;

namespace iQueue
{
    public static class FmtConverter
    {
        public static string HTML2BMP(string inHTML,int inW,int inH,string fileName)
        {
            Size imgSize = Size.Empty;
            imgSize.Height = inH;
            imgSize.Width = inW;
            Image img = HtmlRender.RenderToImage(inHTML,imgSize);//,Color.Transparent
            img.Save(fileName);
            return fileName;
        }
        public static string HTML2RTF(string inHTML, RichTextBox rtbTemp)
        {
            string res = "";
            try
            {
                Font fnt = new Font(Settings.Default.Properties["fontFamily"].DefaultValue.ToString(), (float)Convert.ToDecimal(Settings.Default.Properties["fontSize"].DefaultValue));
                rtbTemp.Font = fnt;
                rtbTemp.Rtf = HtmlToRtfConverter.ConvertHtmlToRtf(inHTML);
                rtbTemp.SelectAll();
                rtbTemp.SelectionFont = fnt;
                res = rtbTemp.Rtf;
            }
            catch (Exception ex)
            {
                Program.Log("Exception while run HTML2RTF  Exception.Message:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");
                return null;
            }
            return res;
        }
        public static string HTML2RTF_old(string inHTML, RichTextBox rtbTemp)
        {
            string res = "";
            try
            {
                Font fnt = new Font(Settings.Default.Properties["fontFamily"].DefaultValue.ToString(), (float)Convert.ToDecimal(Settings.Default.Properties["fontSize"].DefaultValue));
                rtbTemp.Font = fnt;
                WebBrowser wb = new WebBrowser();
                wb.Navigate("about:blank");

                string clipBefore = "";
                if (Clipboard.ContainsText())
                {
                    clipBefore = Clipboard.GetText();
                    
                }
                Clipboard.Clear();
                wb.Document.Write(inHTML);
                wb.Document.ExecCommand("SelectAll", true, null);
                wb.Document.ExecCommand("Copy", true, null);
                rtbTemp.Clear();
                rtbTemp.Paste();
                rtbTemp.SelectAll();
                rtbTemp.SelectionFont = fnt;               
                res = rtbTemp.Rtf;
                if (clipBefore != "")
                    Clipboard.SetText(clipBefore);
            }
            catch (Exception ex)
            {
                Program.Log("Exception while run HTML2RTF  Exception.Message:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");
                return null;
            }
            return res;
        }
    }
}
