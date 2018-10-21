using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mig.Tables
{
    static public class AllTables
    {
        public static DataTable t_Contact;
        public static string[] col_Contact = {"id","last_name","first_name"};

        public static void Init()
        {
            
            t_Contact = new DataTable();
            t_Contact.Columns.Add("id", typeof(int));
            t_Contact.Columns.Add("last_name", typeof(string));
            t_Contact.Columns.Add("first_name", typeof(string));
        }
    }
}
