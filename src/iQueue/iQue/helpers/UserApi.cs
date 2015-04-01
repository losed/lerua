using System;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using iQueue.Properties;

namespace iQueue
{
    class UserApi
    {
        public dynamic error, errorMessage, props;
        public string sysId;

        public dynamic getRemoteJson(string url, dynamic inObj)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
            WebRequest req = HttpWebRequest.Create(url);
            // req.RequestUri = url;
            req.Method = "POST";
            req.ContentType = "application/json";
            req.Timeout = 60000;
            Stream inStream = req.GetRequestStream();
            string inJson = inObj.ToString();
            StreamWriter sw = new StreamWriter(inStream);
            sw.Write(inJson);
            sw.Close();
            WebResponse resp = null;
            dynamic data = new DynamicJsonObject();
            try
            {
                resp = req.GetResponse();
                Stream outStream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(outStream);
                string json = sr.ReadToEnd();
                sr.Close();
                data = serializer.Deserialize<object>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректный ответ центра регистрации - повторите попытку позже! " + ex.Message, "Ошибка", MessageBoxButtons.OK);
                data.status = -1;
                return data;
            }
            if (data == null)
            {
                data = new DynamicJsonObject();
                data.error = -1;
                data.errorMessage = "Ошибка - некорректный ответ центра регистрации";
            }

            this.error = data.error;
            this.errorMessage = data.errorMessage;

            return data;
        }

        public dynamic getRemoteFile(string url, dynamic inObj)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
            WebRequest req = HttpWebRequest.Create(url);
            // req.RequestUri = url;
            req.Method = "POST";
            req.ContentType = "application/json";
            req.Timeout = 300000;
            Stream inStream = req.GetRequestStream();
            string inJson = inObj.ToString();
            StreamWriter sw = new StreamWriter(inStream);
            sw.Write(inJson);
            sw.Close();
            WebResponse resp = null;
            dynamic data = new DynamicJsonObject();
            try
            {
                resp = req.GetResponse();
                Stream outStream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(outStream);
                string json = sr.ReadToEnd();
                sr.Close();
                data.file = json;
                data.status = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректный ответ центра регистрации - повторите попытку позже! " + ex.Message, "Ошибка", MessageBoxButtons.OK);
                data.status = -1;
                return data;
            }
            if (data == null)
            {
                data = new DynamicJsonObject();
                data.error = -1;
                data.errorMessage = "Ошибка - некорректный ответ центра регистрации";
            }

            this.error = data.error;
            this.errorMessage = data.errorMessage;

            return data;
        }
        public UserApi(string sysId)
        {
            this.sysId = sysId;
            this.props = new DynamicJsonObject();
        }
        public string LastError()
        {
            return this.error;
        }
        public string LastErrorMessage()
        {
            return this.errorMessage;
        }
        public dynamic registerInstance()
        {
            dynamic obj = new DynamicJsonObject();
            dynamic ret = new DynamicJsonObject();
            obj.action = "registerInstance";
            obj.sysId = this.sysId;
            string url = Settings.Default.regUrl;
            dynamic result = getRemoteJson(url, obj);
            ret.result = result;
            ret.returnCode = false;

            if (result.status == 0)
            {
                ret.returnCode = true;
            }

            return ret;
        }
        public dynamic checkUpdates()
        {
            dynamic obj = new DynamicJsonObject();
            dynamic ret = new DynamicJsonObject();
            obj.action = "checkUpdates";
            obj.sysId = this.sysId;
            dynamic result = getRemoteJson(Settings.Default.updateUrl, obj);
            ret.result = result;
            ret.returnCode = false;

            if (result.status == 0)
            {
                ret.returnCode = true;
            }

            return ret;
        }
        public dynamic downloadUpdates(string url)
        {
            dynamic obj = new DynamicJsonObject();
            dynamic ret = new DynamicJsonObject();
            obj.action = "downloadUpdates";
            obj.url = url;
            obj.sysId = this.sysId;
            dynamic result = getRemoteFile(Settings.Default.updateUrl, obj);
            ret.result = result;
            ret.returnCode = false;

            if (result.status == 0)
            {
                ret.returnCode = true;
            }

            return ret;
        }
    }
}
