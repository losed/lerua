using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;

namespace iQueue
{
    public class DBInterface
    {
        private SQLiteConnection sqlConn;
        private SQLiteCommand sqlCmd;
        public DBInterface(string dbFilePath)
        {
            string connString = "Data Source=" + dbFilePath + ";Version=3;Compress=True;";
            try
            {
                sqlConn = new SQLiteConnection(connString);
                sqlConn.Open();
            }
            catch (Exception ex)
            {
                Program.Log("Exception while trying to create DBInterface:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");
            }
        }
        ~DBInterface()
        {
          //  sqlConn.Close();
        }
        public object[] getScreens()
        {
            sqlCmd = new SQLiteCommand("SELECT * FROM screens ORDER BY behavior");
            sqlCmd.Connection = sqlConn;
            SQLiteDataReader reader = sqlCmd.ExecuteReader();

            return null;
        }

        public int modifyQuery(string query)
        {
            try
            {
                sqlCmd = new SQLiteCommand(query);
                sqlCmd.Connection = sqlConn;
                int res = sqlCmd.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                Program.Log("Exception while trying to run modifyQuery with sql:[" + query + "] Exception.Message:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");
                return 0;
            }
        }

        public Dictionary<string, string>[] selectQuery(string query)
        {
            Dictionary<string, string>[] results = null;
            sqlCmd = new SQLiteCommand(query);
            sqlCmd.Connection = sqlConn;
            try
            {
                SQLiteDataReader reader = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                results = new Dictionary<string, string>[dt.Rows.Count];
                int numRec = 0;
                DataTableReader read = dt.CreateDataReader();
                foreach (DbDataRecord record in read)
                {
                    Dictionary<string, string> res = new Dictionary<string, string>();
                    res.Clear();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        res.Add(dt.Columns[i].ColumnName, record.GetValue(i).ToString());
                    }
                    results.SetValue(res, numRec);
                    numRec++;
                }
            }
            catch (Exception ex)
            {
                Program.Log("Exception while trying to run selectQuery with sql:[" + query + "] Exception.Message:[" + ex.Message + "] StackTrace = [" + ex.StackTrace + "]");
                return new Dictionary<string, string>[0];
            }
            return results;
        }
    }
}
