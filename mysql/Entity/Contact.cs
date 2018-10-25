using mysql.Pref;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mig.Entity
{
    public partial class Contact: EntityBase
    {
       
        Addr_inter AddrInter;

        public void Validate()
        {
            /*валидация текущий свойств контакта*/
            if (_last_name == "" )
                throw new System.InvalidOperationException("Поле <Фамилия> обязательно для заполнения!");
            if (_first_name == "")
                throw new System.InvalidOperationException("Поле <Имя> обязательно для заполнения!");
        }

        public override void Init()
        {
            base.Init();
            AddrInter = new Addr_inter();
            //AddrInter.Init();
        }
        public Contact(int contact_id_in)
        {
            CONTACT_ID = contact_id_in;
            Init();           
        }
        
        public override void ReadFromDB(int Row_id)
        {
            base.ReadFromDB(Row_id);
            RefreshData();
            AddrInter.ReadFromDB(CONTACT_ID);

        }
        
       
        public override void RefreshTable()
        {            
            tbl.Rows[0]["id"] = id;
            tbl.Rows[0]["contact_id"] = _contact_id; 
            tbl.Rows[0]["last_name"] = _last_name;
            tbl.Rows[0]["first_name"] = _first_name;
            tbl.Rows[0]["second_name"] = _second_name;
            if (_birthday == null)
                tbl.Rows[0]["birthday"] = DBNull.Value;
            else
                tbl.Rows[0]["birthday"] = _birthday;
         
           
        }
        public override void RefreshData()
        {
            try
            {
                if (tbl.Rows.Count > 0)
                {
                    id = Convert.ToInt32(tbl.Rows[0]["id"]);
                    _contact_id = Convert.ToInt32(tbl.Rows[0]["contact_id"]);
                    _last_name = tbl.Rows[0]["last_name"].ToString();
                    _first_name = tbl.Rows[0]["first_name"].ToString();
                    _second_name = tbl.Rows[0]["second_name"].ToString();
                    if (tbl.Rows[0]["birthday"] == DBNull.Value)
                        _birthday = null;
                    else
                        _birthday = Convert.ToDateTime(tbl.Rows[0]["birthday"]);
                }
            }
            catch(Exception ex)
            {
                LastErrorMessage = ex.Message;
                throw new System.InvalidOperationException("Ошибка: "+ex.Message);
            }
            /*... все поля*/
           
        }
        
    }
}
