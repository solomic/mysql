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
        string _SQL_ROW ;
        public virtual string SQL_ROW
            {
                get { return _SQL_ROW; }
                set { _SQL_ROW = value; }
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

        public virtual void Init()
        {
            tbl = new DataTable();
            change = new List<string>();
        }
        public EntityBase()
        {
            Init();
            mode = "default";
        }
        public EntityBase(string pMode)
        {
            Init();
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
            rw_tmp = DBUtils.MySqlGetData(SQL_ROW, new List<object> { Row_id });
            if (rw_tmp.HasError)
            {
                LastErrorMessage = rw_tmp.ErrorText;
                throw new System.InvalidOperationException("Ошибка чтения из БД!");
            }
            /*Обновляем внутренние переменные*/
            tbl = rw_tmp.ResultTbl;
        }

        }
}
