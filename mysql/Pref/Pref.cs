using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysql.Pref
{
    public static class Pref
    {
        public static string Scheme = "cmo";
        public static string LoginName = "ARUDENKO";
        public static string MySqlconnStr = "server=localhost;user=cmoadmin;database=cmo;port=3306;password=cmoadmin;";
    }
    public static class DbCon
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
                transaction = connection.BeginTransaction();
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
    }
}
