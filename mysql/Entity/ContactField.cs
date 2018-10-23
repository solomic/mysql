using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mig.Entity
{
    public partial class Contact: EntityBase
    {

        /*Поля таблицы*/
        /*--------------------------------------------------------*/
        
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

                if (value != _last_name)
                {
                    _last_name = value==null?null:value.Trim();
                    change.Add("last_name='" + _last_name + "',");
                    fio="";                    
                }
              
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
                if (value != _first_name)
                {
                    _first_name = value == null ? null : value.Trim();
                    change.Add("first_name='" + _first_name + "',");
                    fio = "";
                }
                
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
                if (value != _second_name)
                {
                    _second_name = value == null ? null : value.Trim();
                    change.Add("second_name='" + _second_name + "',");
                    fio = "";
                }
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
                if (value != _birthday)
                {
                    _birthday = value;
                    change.Add("birthday='" + _birthday.Value.ToString("yyyy-MM-dd 00:00:00") + "',");
                }
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
                if (value != _birth_town)
                {
                    _birth_town = value == null ? null : value.Trim();
                    change.Add("birth_town='" + _birth_town + "',");
                }
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
                if (value != _sex)
                {
                    _sex = value == null ? null : value.Trim();
                    change.Add("sex='" + _sex + "',");
                }
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
                if (value != _comments)
                {
                    _comments = value == null ? null : value.Trim();
                    change.Add("comments='" + _comments + "',");
                }
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
                if (value != _date_entry_future)
                {
                    _date_entry_future = value;
                    change.Add("date_entry_future='" + _date_entry_future.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',");
                }
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
                if (value != _rf)
                {
                    _rf = value == null ? null : value.Trim();
                    change.Add("rf='" + _rf + "',");
                }
            }
        }
        /*--------------------------------------------------------*/
        int? _doc_state; //-- 1 - документы на визу отданы
        public int? doc_state
        {
            get
            {
                return _doc_state;
            }
            set
            {
                if (value != _doc_state)
                {
                    _doc_state = value == null ? null : value;
                    change.Add("doc_state=" + _doc_state + ",");
                }
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
               // change.Add("fio='"+ _fio + "',");
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
                if (value != _last_enu)
                {
                    _last_enu = value == null ? null : value.Trim();
                    change.Add("last_enu='" + _last_enu + "',");
                }
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
                if (value != _first_enu)
                {
                    _first_enu = value == null ? null : value.Trim();
                    change.Add("first_enu='" + _first_enu + "',");
                }
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
                if (value != _second_enu)
                {
                    _second_enu = value == null ? null : value.Trim();
                    change.Add("second_enu='" + _second_enu + "',");
                }
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
                if (value != _route)
                {
                    _route = value == null ? null : value.Trim();
                    change.Add("route='" + _route + "',");
                }
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
                if (value != _address_home)
                {
                    _address_home = value == null ? null : value.Trim();
                    change.Add("address_home='" + _address_home + "',");
                }
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
                if (value != _position_code)
                {
                    _position_code = value == null ? null : value.Trim();
                    change.Add("position_code='" + _position_code + "',");
                }
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
                if (value != _relatives)
                {
                    _relatives = value == null ? null : value.Trim();
                    change.Add("relatives='" + _relatives + "',");
                }
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
                if (value != _med)
                {
                    _med = value == null ? null : value.Trim();
                    change.Add("med='" + _med + "',");
                }
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
                if (value != _deduct)
                {
                    _deduct = value == null ? null : value.Trim();
                    change.Add("deduct='" + _deduct + "',");
                }
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
                if (value != _delivery_dt)
                {
                    _delivery_dt = value;
                    change.Add("delivery_dt='" + _delivery_dt.Value.ToString("yyyy-MM-dd 00:00:00") + "',");
                }
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
                if (value != _phone)
                {
                    _phone = value == null ? null : value.Trim();
                    change.Add("phone='" + _phone + "',");
                }
            }
        }
        /*--------------------------------------------------------*/
        int? _reg_extend;
        public int? reg_extend
        {
            get
            {
                return _reg_extend;
            }
            set
            {
                if (value != _reg_extend)
                {
                    _reg_extend = value == null ? null : value;
                    change.Add("reg_extend=" + _reg_extend + ",");
                }
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
                if (value != _type)
                {
                    _type = value == null ? null : value.Trim();
                    change.Add("type='" + _type + "',");
                }
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
                if (value != _delegate_last_name)
                {
                    _delegate_last_name = value == null ? null : value.Trim();
                    change.Add("delegate_last_name='" + _delegate_last_name + "',");
                }
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
                if (value != _delegate_first_name)
                {
                    _delegate_first_name = value == null ? null : value.Trim();
                    change.Add("delegate_first_name='" + _delegate_first_name + "',");
                }
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
                if (value != _delegate_second_name)
                {
                    _delegate_second_name = value == null ? null : value.Trim();
                    change.Add("delegate_second_name='" + _delegate_second_name + "',");
                }
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
                if (value != _delegate_ser)
                {
                    _delegate_ser = value == null ? null : value.Trim();
                    change.Add("delegate_ser='" + _delegate_ser + "',");
                }
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
                if (value != _delegate_num)
                {
                    _delegate_num = value == null ? null : value.Trim();
                    change.Add("delegate_num='" + _delegate_num + "',");
                }
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
                if (value != _delegate_dul_issue_dt)
                {
                    _delegate_dul_issue_dt = value;
                    change.Add("delegate_dul_issue_dt='" + _delegate_dul_issue_dt.Value.ToString("yyyy-MM-dd 00:00:00") + "',");
                }
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
                if (value != _delegate_dul_code)
                {
                    _delegate_dul_code = value == null ? null : value.Trim();
                    change.Add("delegate_dul_code='" + _delegate_dul_code + "',");
                }
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
                if (value != _status)
                {
                    _status = value == null ? null : value.Trim();
                    change.Add("status='" + _status + "',");
                }
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
                if (value != _birth_country)
                {
                    _birth_country = value == null ? null : value.Trim();
                    change.Add("birth_country='" + _birth_country + "',");
                }
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
                if (value != _nationality)
                {
                    _nationality = value == null ? null : value.Trim();
                    change.Add("nationality='" + _nationality + "',");
                }
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
                if (value != _delegate_country)
                {
                    _delegate_country = value == null ? null : value.Trim();
                    change.Add("delegate_country='" + _delegate_country + "',");
                }
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
                if (value != _delegate_nationality)
                {
                    _delegate_nationality = value == null ? null : value.Trim();
                    change.Add("delegate_nationality='" + _delegate_nationality + "',");
                }
            }
        }
    }
}
