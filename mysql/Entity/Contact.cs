﻿using Mig.Tables;
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
    public partial class Contact
    {
       
        DataTable tbl;
        List<string> change;
        string _LastErrorMessage;

        void Validate(string mode)
        {
            /**/
            //throw new System.InvalidOperationException("Поле <Фамилия> обязательно для заполнения!");
        }
        public string LastErrorMessage
        {
            get { return _LastErrorMessage; }
        }

        public Contact()
        {            
            tbl =  new DataTable();
            change = new List<string>();
            
        }
        public void ReadFromDB(int ContactId)
        {
            change.Clear();
            string sql = "SELECT * FROM cmo.contact where id=@param1";
            MySqlResultTable rw_tmp = new MySqlResultTable();
            rw_tmp = DBUtils.MySqlGetData(sql,new List<object> { ContactId });
            if (rw_tmp.HasError)
            {
                _LastErrorMessage = rw_tmp.ErrorText;
                throw new System.InvalidOperationException("Ошибка чтения из БД!");
            }
            else
            {
                /*Обновляем внутренние переменные*/
                tbl = rw_tmp.ResultTbl;
                RefreshData();
            }
            
        }
        
        public DataTable GetContactDataTable()
        {
            RefreshTable();
            return tbl;
        }
        public int RefreshTable()
        {
            tbl.Rows[0]["id"] = _id;
            tbl.Rows[0]["contact_id"] = _contact_id; 
            tbl.Rows[0]["last_name"] = _last_name;
            tbl.Rows[0]["first_name"] = _first_name;
            tbl.Rows[0]["second_name"] = _second_name;
            if (_birthday == null)
                tbl.Rows[0]["birthday"] = DBNull.Value;
            else
                tbl.Rows[0]["birthday"] = _birthday;
         
            /*... все поля*/
            return 0;
        }
        public int RefreshData()
        {
            
            _id= Convert.ToInt32(tbl.Rows[0]["id"]);
            _contact_id= Convert.ToInt32(tbl.Rows[0]["contact_id"]) ;
            _last_name = tbl.Rows[0]["last_name"].ToString();
            _first_name= tbl.Rows[0]["first_name"].ToString();
            _second_name=tbl.Rows[0]["second_name"].ToString()  ;
            if (tbl.Rows[0]["birthday"] == DBNull.Value)
                _birthday = null;
            else
                _birthday=Convert.ToDateTime(tbl.Rows[0]["birthday"]);
            /*... все поля*/
            return 0;
        }
        public void Save(string mode)
        {
           
            if (change.Count != 0)
            {
                Validate(mode);

                string statement="UPDATE cmo.contact SET ";
                /*собрать Update*/
                foreach (string st in change)
                {
                    statement += st ;
                }
                statement += ("updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',");
                statement += ("updated_by='" +"ARUDENKO" +"' " );
                statement += "where (id=" + _id.ToString()+")";
                /*обновляем*/
                MySqlResultUpdate rs = new MySqlResultUpdate();
                rs = MySqlUpdateData(statement,  null );
                if (rs.HasError)
                    throw new System.InvalidOperationException("Ошибка при обновлении контакта!");
                /*чистим изменения*/
                change.Clear();
            }
        }
    }
}
