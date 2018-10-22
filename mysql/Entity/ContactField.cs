using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mig.Entity
{
    public partial class Contact
    {

        /*Поля таблицы*/
        /*--------------------------------------------------------*/
        int _id;
        public int id
        {
            get
            {
                return _id;
            }
        }
        /*--------------------------------------------------------*/
        int _contact_id;
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
        /*--------------------------------------------------------*/
        string _last_name;
        public string last_name
        {
            get
            {
                return _last_name;
            }
            set
            {
                _last_name = value.Trim();
                change.Add("last_name='"+ _last_name+"',");
              
            }
        }
        /*--------------------------------------------------------*/
        string _first_name;
        public string first_name
        {
            get
            {
                return _first_name;
            }
            set
            {
                _first_name = value.Trim();                    
                change.Add("first_name='"+ _first_name+"',");
                
            }
        }
        /*--------------------------------------------------------*/
        string _second_name;
        public string second_name
        {
            get
            {
                return _second_name;
            }
            set
            {
                _second_name = value.Trim();
                change.Add("second_name='"+ _second_name+"',");
            }
        }
        /*--------------------------------------------------------*/
        DateTime? _birthday;
        public DateTime? birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
                change.Add("birthday='"+ _birthday.Value.ToString( "yyyy-MM-dd 00:00:00")+"',");
            }
        }
        /*--------------------------------------------------------*/
        string _birth_town;
        public string birth_town
        {
            get
            {
                return _birth_town;
            }
            set
            {
                _birth_town = value.Trim();
                change.Add("birth_town='"+_birth_town + "',");
            }
        }
        /*--------------------------------------------------------*/
        DateTime _updated;
        public DateTime updated
        {
            get
            {
                return _updated;
            }
           
        }
        /*--------------------------------------------------------*/
        string _updated_by;
        public string updated_by
        {
            get
            {
                return _updated_by;
            }
           
        }
        /*--------------------------------------------------------*/
        string _sex;
        public string sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value.Trim();
                change.Add("sex='"+ _sex + "',");
            }
        }
        /*--------------------------------------------------------*/
        string _comments;
        public string comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value.Trim();
                change.Add("comments='"+ _comments + "',");
            }
        }
        /*--------------------------------------------------------*/
        DateTime? _date_entry_future;//-- поле Виза готова...
        public DateTime? date_entry_future
        {
            get
            {
                return _date_entry_future;
            }
            set
            {
                _date_entry_future = value;
                change.Add("date_entry_future='"+ _date_entry_future.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',");
            }
        }
        /*--------------------------------------------------------*/
        string _rf; //-- 1 - есть паспорт РФ 0 - иностранец
        public string rf
        {
            get
            {
                return _rf;
            }
            set
            {
                _rf = value.Trim();
                change.Add("rf='"+ _rf + "',");
            }
        }
        /*--------------------------------------------------------*/
        int _doc_state; //-- 1 - документы на визу отданы
        public int doc_state
        {
            get
            {
                return _doc_state;
            }
            set
            {
                _doc_state = value;
                change.Add("doc_state="+ _doc_state+",");
            }
        }
        /*--------------------------------------------------------*/
        string _fio;
        public string fio
        {
            get
            {
                return _last_name +
                       _last_name != "" ? (" " + _first_name) : "" +
                      _second_name != "" ? (" " + _second_name) : "";
            }
            set
            {
                _fio = _last_name +
                       _last_name != "" ? (" " + _first_name) : "" +
                      _second_name != "" ? (" " + _second_name) : "";
                change.Add("fio='"+ _fio + "',");
            }

        }
        /*--------------------------------------------------------*/
        string _last_enu;
        public string last_enu
        {
            get
            {
                return _last_enu;
            }
            set
            {
                _last_enu = value.Trim();
                change.Add("last_enu='"+ _last_enu + "',");
            }
        }
        /*--------------------------------------------------------*/
        string _first_enu;
        public string first_enu
        {
            get
            {
                return _first_enu;
            }
            set
            {
                _first_enu = value.Trim();
                change.Add("first_enu='"+ _first_enu + "',");
            }
        }
        /*--------------------------------------------------------*/
        string _second_enu;
        public string second_enu
        {
            get
            {
                return _second_enu;
            }
            set
            {
                _second_enu = value.Trim();
                change.Add("second_enu='"+ _second_enu+"',");
            }
        }
        /*--------------------------------------------------------*/
        string _route;
        public string route
        {
            get
            {
                return _route;
            }
            set
            {
                _route = value.Trim();
                change.Add("route='"+ _route+"',");
            }
        }
        /*--------------------------------------------------------*/
        string _address_home;
        public string address_home
        {
            get
            {
                return _address_home;
            }
            set
            {
                _address_home = value.Trim();
                change.Add("address_home='"+ _address_home+"',");
            }
        }
        /*--------------------------------------------------------*/
        string _position_code;
        public string position_code
        {
            get
            {
                return _position_code;
            }
            set
            {
                _position_code = value.Trim();
                change.Add("position_code='"+ _position_code+"',");
            }
        }
        /*--------------------------------------------------------*/
        string _relatives;
        public string relatives
        {
            get
            {
                return _relatives;
            }
            set
            {
                _relatives = value.Trim();
                change.Add("relatives='" + _relatives + "',");
            }
        }
        /*--------------------------------------------------------*/
        string _med;
        public string med
        {
            get
            {
                return _med;
            }
            set
            {
                _med = value.Trim();
                change.Add("med='"+ _med + "',");
            }
        }
        /*--------------------------------------------------------*/
        string _deduct;
        public string deduct
        {
            get
            {
                return _deduct;
            }
            set
            {
                _deduct = value.Trim();
                change.Add("deduct='"+ _deduct + "',");
            }
        }
        /*--------------------------------------------------------*/
        DateTime? _delivery_dt; //-- Дата сдачи документов по визе
        public DateTime? delivery_dt
        {
            get
            {
                return _delivery_dt;
            }
            set
            {
                _delivery_dt = value;
                change.Add("delivery_dt='" + _delivery_dt.Value.ToString("yyyy-MM-dd 00:00:00") + "',");
            }
        }
        /*--------------------------------------------------------*/
        string _phone;
        public string phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value.Trim();
                change.Add("phone='"+ _phone + "',");
            }
        }
        /*--------------------------------------------------------*/
        int _reg_extend;
        public int reg_extend
        {
            get
            {
                return _reg_extend;
            }
            set
            {
                _reg_extend = value;
                change.Add("reg_extend="+ _reg_extend + ",");
            }
        }
        /*--------------------------------------------------------*/
        string _type;
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value.Trim();
                change.Add("type");
            }
        }
        /*--------------------------------------------------------*/
        string _delegate_last_name;
        public string delegate_last_name
        {
            get
            {
                return _delegate_last_name;
            }
            set
            {
                _delegate_last_name = value.Trim();
                change.Add("delegate_last_name");
            }
        }
        /*--------------------------------------------------------*/
        string _delegate_first_name;
        public string delegate_first_name
        {
            get
            {
                return _delegate_first_name;
            }
            set
            {
                _delegate_first_name = value.Trim();
                change.Add("delegate_first_name");
            }
        }
        /*--------------------------------------------------------*/
        string _delegate_second_name;
        public string delegate_second_name
        {
            get
            {
                return _delegate_second_name;
            }
            set
            {
                _delegate_second_name = value.Trim();
                change.Add("delegate_second_name");
            }
        }
        /*--------------------------------------------------------*/
        string _delegate_ser;
        public string delegate_ser
        {
            get
            {
                return _delegate_ser;
            }
            set
            {
                _delegate_ser = value.Trim();
                change.Add("delegate_ser");
            }
        }
        /*--------------------------------------------------------*/
        string _delegate_num;
        public string delegate_num
        {
            get
            {
                return _delegate_num;
            }
            set
            {
                _delegate_num = value.Trim();
                change.Add("delegate_num");
            }
        }
        /*--------------------------------------------------------*/
        DateTime? _delegate_dul_issue_dt;
        public DateTime? delegate_dul_issue_dt
        {
            get
            {
                return _delegate_dul_issue_dt;
            }
            set
            {
                _delegate_dul_issue_dt = value;
                change.Add("delegate_dul_issue_dt");
            }
        }
        /*--------------------------------------------------------*/
        string _delegate_dul_code;
        public string delegate_dul_code
        {
            get
            {
                return _delegate_dul_code;
            }
            set
            {
                _delegate_dul_code = value.Trim();
                change.Add("delegate_dul_code");
            }
        }
        /*--------------------------------------------------------*/
        string _status;
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value.Trim();
                change.Add("status");
            }
        }
        /*--------------------------------------------------------*/
        string _birth_country;
        public string birth_country
        {
            get
            {
                return _birth_country;
            }
            set
            {
                _birth_country = value.Trim();
                change.Add("birth_country");
            }
        }
        /*--------------------------------------------------------*/
        string _nationality;
        public string nationality
        {
            get
            {
                return _nationality;
            }
            set
            {
                _nationality = value.Trim();
                change.Add("nationality='"+ _nationality+"',");
            }
        }
        /*--------------------------------------------------------*/
        string _delegate_country;
        public string delegate_country
        {
            get
            {
                return _delegate_country;
            }
            set
            {
                _delegate_country = value.Trim();
                change.Add("delegate_country='"+ _delegate_country+"',");
            }
        }
        /*--------------------------------------------------------*/
        string _delegate_nationality;
        public string delegate_nationality
        {
            get
            {
                return _delegate_nationality;
            }
            set
            {
                _delegate_nationality = value.Trim();
                change.Add("delegate_nationality='"+ _delegate_nationality +"',");
            }
        }
    }
}
