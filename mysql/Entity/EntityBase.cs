﻿using mysql.Pref;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mig.DBUtils;

namespace Mig.Entity
{
    public class EntityBase
    { 
        public virtual string SQL_SEL
        {
            get { return "SELECT* FROM " + Pref.Scheme + "."+ GetType().Name.ToLower() + " where id = @param1"; }          
        }
        public virtual string SQL_UPD
        {
            get { return "UPDATE " + Pref.Scheme + "." + GetType().Name.ToLower() + " SET "; }           
        }
        public virtual string SQL_INS
        {
            get { return "INSERT INTO " + Pref.Scheme + "." + GetType().Name.ToLower() + " "; }          
        }
        public virtual string SQL_MAX_ID
        {
            get { return "SELECT MAX(id) FROM " + Pref.Scheme + "." + GetType().Name.ToLower() + ";"; }            
        }
        long _id;
        public long id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        string _LastErrorMessage;
        public string LastErrorMessage
        {
            get { return _LastErrorMessage; }
            set { _LastErrorMessage = value; }
        }

        public string mode;
        public DataTable tbl;
        public List<string> change;
        MySqlConnection conn;
        MySqlTransaction myTrans;

        public void Audit(string field, string value)
        {

        }
        public DataTable GetDataTable()
        {
            RefreshTable();
            return tbl;
        }

        public virtual void Init()
        {
            tbl = new DataTable();
            change = new List<string>();
            conn = new MySqlConnection(Pref.MySqlconnStr);
            conn.Open();
           //
        }
        public EntityBase()
        {           
            mode = "default";
        }
        public EntityBase(string pMode)
        {          
            mode = pMode;
        }
        public virtual void RefreshTable()
        {
            /*заполнение таблицы данными из свойств*/
        }
        public virtual void RefreshData()
        {
            /*заполнение свойств данными из таблицы*/
        }
        public virtual void ReadFromDB(int Row_id)
        {
            change.Clear();
            MySqlResultTable rw_tmp = new MySqlResultTable();
            rw_tmp = DBUtils.MySqlGetData(conn,myTrans, SQL_SEL, new List<object> { Row_id });
            if (rw_tmp.HasError)
            {
                LastErrorMessage = rw_tmp.ErrorText;
                throw new System.InvalidOperationException("Ошибка чтения из БД!");
            }
            /*Обновляем внутренние переменные*/
            tbl = rw_tmp.ResultTbl;
        }
        public virtual void Save()
        {

            if (change.Count != 0)
            {
                if (myTrans == null)
                    myTrans = conn.BeginTransaction();       
                string statement = SQL_UPD;
                /*собрать Update*/
                foreach (string st in change)
                {
                    statement += st;
                }
                statement += ("updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',");
                statement += ("updated_by='" + Pref.LoginName + "' ");
                statement += "where (id=" + id.ToString() + ")";
                /*чистим изменения*/
                change.Clear();
                /*обновляем*/
                MySqlResultExec rs = new MySqlResultExec();
                rs = MySqlExecuteNonQuery(conn, myTrans, statement, null);
                if (rs.HasError)
                {
                    myTrans.Rollback();
                    LastErrorMessage = rs.ErrorText;
                    throw new System.InvalidOperationException("Ошибка при обновлении записи!");
                }
                myTrans.Commit();

            }
        }
        public virtual void Add()
        {
            myTrans = conn.BeginTransaction();
           
             mode = "Add";            
            string statement = SQL_INS;
            /*собрать Update*/
            statement += "(contact_id) VALUES("+ GetNextId().ToString()+");";            
            /*обновляем*/
            MySqlResultExec rs = new MySqlResultExec();
            rs = MySqlExecuteNonQuery(conn, myTrans, statement, null);
            if (rs.HasError)
            {
                LastErrorMessage = rs.ErrorText;
                throw new System.InvalidOperationException("Ошибка при добавлении записи!");
            }
            id = rs.Result;
            
        }
        public int GetNextId()
        {
            MySqlResultScalar rw = new MySqlResultScalar();
            rw = MySqlExecuteScalar(conn, myTrans, SQL_MAX_ID, null, "int");
            return (int)rw.Result+1;
        }

        
        

        }
}
