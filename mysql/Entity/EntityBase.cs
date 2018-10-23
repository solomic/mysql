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
        string _SQL_SEL;
        string _SQL_UPD ;
        public virtual string SQL_SEL
        {
                get { return _SQL_SEL; }
                set { _SQL_SEL = value; }
        }
        public virtual string SQL_UPD
        {
            get { return _SQL_UPD; }
            set { _SQL_UPD = value; }
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
        }
        public EntityBase()
        {
            //Init();
            mode = "default";
        }
        public EntityBase(string pMode)
        {
            //Init();
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
            rw_tmp = DBUtils.MySqlGetData(SQL_SEL, new List<object> { Row_id });
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
                
                string statement = SQL_UPD;
                /*собрать Update*/
                foreach (string st in change)
                {
                    statement += st;
                }
                statement += ("updated='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',");
                statement += ("updated_by='" + "ARUDENKO" + "' ");
                statement += "where (id=" + id.ToString() + ")";
                /*чистим изменения*/
                change.Clear();
                /*обновляем*/
                MySqlResultUpdate rs = new MySqlResultUpdate();
                rs = MySqlUpdateData(statement, null);
                if (rs.HasError)
                {
                    LastErrorMessage = rs.ErrorText;
                    throw new System.InvalidOperationException("Ошибка при обновлении контакта!");
                }

            }
        }

    }
}
