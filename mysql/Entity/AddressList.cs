using mysql.Pref;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mig.Entity
{
    public partial class Addr_inter:EntityBase
    {
        List<Address> Addr;
        public DataTable AllAddress;       

        public Addr_inter()
        {
            Init();           
        }
        int _address_id;
        int _contact_id;
        public int address_id
        {
            get
            {
                return _address_id;
            }
            set
            {
                _address_id = value;
                change.Add("address_id=" + _address_id + ",");
            }
        }
        public int contact_id
        {
            get
            {
                return _contact_id;
            }
            set
            {
                _contact_id = value;
                change.Add("contact_id=" + _contact_id + ",");
            }
        }
        public void Validate()
        {
            /*валидация текущий свойств*/
            //if (_last_name == "")
            //    throw new System.InvalidOperationException("Поле <Фамилия> обязательно для заполнения!");           
        }
        public override void Init()
        {
            base.Init();
            Addr = new List<Address>();
            AllAddress = new DataTable();
        }
        public override string SQL_SEL
        {
            get { return "SELECT * FROM " + Pref.Scheme + "." + GetType().Name.ToLower() + " where contact_id = @param1"; }
        }
        public string SQL_SEL_ALL_ADDR
        {
            // Pref.Scheme + "." + GetType().Name.ToLower() +
            get { return "SELECT a.full_address,ai.status FROM cmo.addr_inter ai "+
                    " join cmo.address a ON a.address_id=ai.address_id "+
                    " where ai.contact_id = @param1"; }
        }
        public override void ReadFromDB(int contact_id_in)
        {
            base.ReadFromDB(contact_id_in);

            RefreshData();

        }

        public void LoadAllAddress()
        {
            MySqlResultTable rw_tmp = new MySqlResultTable();
            rw_tmp = Mig.DB.MySqlGetData(SQL_SEL_ALL_ADDR, new List<object> { CONTACT_ID });
            if (rw_tmp.HasError)
            {
                LastErrorMessage = rw_tmp.ErrorText;
                throw new System.InvalidOperationException("Ошибка чтения из БД!");
            }
            /*Обновляем внутренние переменные*/
            AllAddress = rw_tmp.ResultTbl;
        }
        public override void RefreshTable()
        {
            
            //tbl.Rows[0]["id"] = id;
            //tbl.Rows[0]["address_id"] = _address_id;
            //tbl.Rows[0]["last_name"] = _last_name;
            //tbl.Rows[0]["first_name"] = _first_name;
            //tbl.Rows[0]["second_name"] = _second_name;
            //if (_birthday == null)
            //    tbl.Rows[0]["birthday"] = DBNull.Value;
            //else
            //    tbl.Rows[0]["birthday"] = _birthday;


        }
        public override void RefreshData()
        {
            try
            {
                Addr.Clear();
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    Addr.Add(new Address());
                    Addr[i].Init();
                    Addr[i].ReadFromDB(Convert.ToInt32(tbl.Rows[i]["address_id"]));
                }
                //if (tbl.Rows.Count > 0)
                //{
                //    id = Convert.ToInt32(tbl.Rows[0]["id"]);
                //    _address_id = Convert.ToInt32(tbl.Rows[0]["address_id"]);
                //    //_last_name = tbl.Rows[0]["last_name"].ToString();
                //    //_first_name = tbl.Rows[0]["first_name"].ToString();
                //    //_second_name = tbl.Rows[0]["second_name"].ToString();
                //    //if (tbl.Rows[0]["birthday"] == DBNull.Value)
                //    //    _birthday = null;
                //    //else
                //    //    _birthday = Convert.ToDateTime(tbl.Rows[0]["birthday"]);
                //}
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                throw new System.InvalidOperationException("Ошибка: " + ex.Message);
            }
            
        }
    }
}
