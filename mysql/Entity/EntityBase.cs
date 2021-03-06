﻿using mysql.Pref;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mig.DB;

namespace Mig.Entity
{
    public class EntityBase
    {
        public int CONTACT_ID;
        public virtual string SQL_ENTITY_NAME
        {
            get { return GetType().Name.ToLower() ; }
        }
        public virtual string SQL_ENTITY_ID
        {
            get { return GetType().Name.ToLower() + "_id"; }
        }
        public virtual string SQL_SEL
        {
            get { return "SELECT * FROM " + Pref.Scheme + "."+ GetType().Name.ToLower() + " where id = @param1"; }          
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
            get { return "SELECT IFNULL(MAX("+ SQL_ENTITY_ID + "),0) FROM " + Pref.Scheme + "." + GetType().Name.ToLower() + ";"; }            
        }
        int _id;
        public int id
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

        public void Audit(string entity,string field, object old_value, object new_value)
        {
            string old = old_value == null ? "" : old_value.ToString();
            string new_v = new_value == null ? "" : new_value.ToString();
            MySqlResultExec rs = new MySqlResultExec();
            string statement = "INSERT INTO " + Pref.Scheme+"."+"audit " + "(tbl,clmn,old_value,new_value,updated_by,created_by)"+
                " VALUES(@param1,@param2,@param3,@param4,@param5,@param6);";
            rs = Mig.DB.MySqlExecuteNonQuery(statement, new List<object> { entity, field, old, new_v, Pref.LoginName, Pref.LoginName });
            if (rs.HasError)
            {
                LastErrorMessage = rs.ErrorText;
                throw new System.InvalidOperationException("Ошибка при добавлении записи аудита!\n\n"+rs.ErrorText);
            }
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
        }
        public EntityBase()
        {           
            mode = "default";
            Init();
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
            rw_tmp = MySqlGetData(SQL_SEL, new List<object> { Row_id });
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

            if (change.Count != 0 || mode == "Add")
            {                  
                string statement = SQL_UPD;
                /*собрать Update*/
                foreach (string st in change)
                {
                    statement += st;
                }
                statement += ("updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',");
                statement += ("updated_by='" + Pref.LoginName + "' ");
                if (mode == "Add")
                    statement += (",status='Active' ");
                statement += "where (id=" + id.ToString() + ")";
                /*чистим изменения*/
                change.Clear();
                /*обновляем*/
                MySqlResultExec rs = new MySqlResultExec();
                rs = MySqlExecuteNonQuery(statement, null);
                if (rs.HasError)
                {                   
                    LastErrorMessage = rs.ErrorText;
                    throw new System.InvalidOperationException("Ошибка при обновлении записи!\n\n" + rs.ErrorText);
                }
               

            }
        }
        public virtual void Add()
        {
            mode = "Add";            
            string statement = SQL_INS;
            /*собрать INSERT + дефолтные поля*/
            statement += "("+ SQL_ENTITY_ID+",status,created_by) VALUES(" + GetNextEntityId().ToString()+",'Blank','"+Pref.LoginName+"');";            
            /*обновляем*/
            MySqlResultExec rs = new MySqlResultExec();
            rs = MySqlExecuteNonQuery(statement, null);
            if (rs.HasError)
            {
                LastErrorMessage = rs.ErrorText;
                throw new System.InvalidOperationException("Ошибка при добавлении новой записи!\n\n" + rs.ErrorText);
            }
            id = rs.Result;
            
        }
        int GetNextEntityId()
        {
            MySqlResultScalar rw = new MySqlResultScalar();
            rw = MySqlExecuteScalar(SQL_MAX_ID, null, "int");
            return rw.ResultInt+1;
        }
        

        }
}
