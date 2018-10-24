using Mig.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mig.Entity
{
    public partial class Address : EntityBase
    {
       // int _id;
        string _full_address;
        int _address_id;
        string _kladr_code;
        string _obl;
        string _rayon;
        string _town;
        string _street;
        string _house;
        string _corp;
        string _stroenie;
        string _flat;
        string _socr_obl;
        string _socr_rayon;
        string _socr_town;
        string _socr_street;
        string _pin;
        bool _deleted;
        
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
        public string full_address
        {
            get
            {
                return _full_address;
            }
            set
            {
                _full_address = value;
                change.Add("full_address='" + _full_address + "',");
            }
        }
    }
}
