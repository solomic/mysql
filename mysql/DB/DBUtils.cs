
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mig
{
    static class DBUtils
    {
        static string MySqlconnStr = "server=localhost;user=root;database=cmo;port=3306;password=123456;";
        public class MySqlResultExec
        {
            public long Result;
            public string ErrorText;
            public bool HasError;
        }
        public class MySqlResultTable
        {           
            public DataTable ResultTbl;           
            public string ErrorText;           
            public bool HasError;
        }
        
        static public MySqlResultTable MySqlGetData(string sql, List<object> param)
        {
            MySqlResultTable rw = new MySqlResultTable();
            MySqlConnection connection = new MySqlConnection(MySqlconnStr);
            MySqlCommand sqlCom = new MySqlCommand(sql, connection);
            try {
                connection.Open();
                int i = 1;
                foreach (object prm in param)
                {
                    sqlCom.Parameters.AddWithValue("param" + i.ToString(), prm);
                    i++;
                }
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
                DataSet ds1 = new DataSet();
                dataAdapter.Fill(ds1);
                rw.ResultTbl = ds1.Tables[0];
                connection.Close();
            }
            catch(Exception ex)
            {
                rw.HasError = true;
                rw.ErrorText = ex.ToString();
            }
            finally
            {
                connection.Close();
            }
            return rw;
        }
        static public MySqlResultExec MySqlUpdateData(string sql, List<object> param)
        {
            MySqlResultExec rw = new MySqlResultExec();
            MySqlConnection connection = new MySqlConnection(MySqlconnStr);
            MySqlCommand sqlCom = new MySqlCommand(sql, connection);
            try
            {               
                connection.Open();
                if (param != null)
                {
                    int i = 1;
                    foreach (object prm in param)
                    {
                        sqlCom.Parameters.AddWithValue("param" + i.ToString(), prm);
                        i++;
                    }
                }
                sqlCom.ExecuteNonQuery();
                rw.Result = sqlCom.LastInsertedId;


                connection.Close();
            }
            catch (Exception ex)
            {
                rw.HasError = true;
                rw.ErrorText = ex.ToString();
            }
            finally
            {
                connection.Close();
            }
            return rw;
        }
    }
}
