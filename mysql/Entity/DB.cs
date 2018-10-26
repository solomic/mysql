
using mysql.Pref;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mig
{
    public class MySqlResultExec
    {
        public int Result;
        public string ErrorText;
        public bool HasError;
    }
    public class MySqlResultScalar
    {
        public int ResultInt;
        public string ResultString;
        public DateTime ResultDateTime;
        public string ErrorText;
        public bool HasError;
    }
    public class MySqlResultTable
    {
        public DataTable ResultTbl;
        public string ErrorText;
        public bool HasError;
    }
    public static class DB
    {
        public static MySqlConnection connection;
        public static MySqlTransaction transaction;

        public static void Open()
        {
            try
            {
                connection = new MySqlConnection(Pref.MySqlconnStr);
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException("Ошибка подключения к БД!\n\n" + ex.Message);
            }
        }
        public static void Reconnect()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException("Ошибка подключения к БД!\n\n" + ex.Message);
            }
        }
        public static void BeginTransaction()
        {
            try
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction = null;
                }
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException("Ошибка!\n\n" + ex.Message);
            }
        }
        public static void CommitTransaction()
        {
            try
            {
                if (transaction != null)
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException("Ошибка!\n\n" + ex.Message);
            }
        }
        public static void RollbackTransaction()
        {
            try
            {
                if (transaction != null)
                    transaction.Rollback();
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException("Ошибка!\n\n" + ex.Message);
            }
        }
        public static void CloseConnect()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException("Ошибка закрытия подключения БД!\n\n" + ex.Message);
            }
        }

       
        

        
        public static MySqlResultTable MySqlGetData(string sql, List<object> param)
        {
            MySqlResultTable rw= new MySqlResultTable();     
            MySqlCommand sqlCom = new MySqlCommand(sql, connection, transaction);
            try {               
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
            }
            catch(Exception ex)
            {
                rw.HasError = true;
                rw.ErrorText = ex.Message;
            }           
            return rw;
        }

        /*Выполнение sql запроса, возврат первой строки первого столбца*/
        public static MySqlResultScalar MySqlExecuteScalar(string sql, List<object> param,string ret_type)
        {
            MySqlResultScalar rw = new MySqlResultScalar();          
            MySqlCommand sqlCom = new MySqlCommand(sql, connection, transaction);
            try
            {               
                if (param != null)
                {
                    int i = 1;
                    foreach (object prm in param)
                    {
                        sqlCom.Parameters.AddWithValue("param" + i.ToString(), prm);
                        i++;
                    }
                }
                if(ret_type == "string")
                    rw.ResultString = sqlCom.ExecuteScalar().ToString();
                if (ret_type == "int")
                {                                           
                    rw.ResultInt = Convert.ToInt16(sqlCom.ExecuteScalar());
                }
                if (ret_type == "DateTime")
                    rw.ResultDateTime = Convert.ToDateTime(sqlCom.ExecuteScalar());               
            }
            catch (Exception ex)
            {
                rw.HasError = true;
                rw.ErrorText = ex.Message;
            }            
            return rw;
        }

        /*Выполнение sql запроса без возврата данных, только id последней записи*/
        public static MySqlResultExec MySqlExecuteNonQuery(string sql, List<object> param)
        {
            MySqlResultExec rw = new MySqlResultExec();
            MySqlCommand sqlCom = new MySqlCommand(sql, connection, transaction);
            try
            {       
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
                rw.Result = Convert.ToInt32(sqlCom.LastInsertedId);              
            }
            catch (Exception ex)
            {
                rw.HasError = true;
                rw.ErrorText = ex.Message;
            }           
            return rw;
        }
    }
}
