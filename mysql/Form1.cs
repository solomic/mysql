using Mig.Entity;
using Mig.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Contact con;
        private void button1_Click(object sender, EventArgs e)
        {
            AllTables.Init();
            con = new Contact();
            con.ReadFromDB(1);
            textBox1.Text = con.id.ToString();
            textBox2.Text = con.last_name;
            dateTimePicker1.Value = Convert.ToDateTime(con.birthday);
          
            dataGridView1.DataSource = con.GetContactDataTable();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.last_name = textBox2.Text;
                con.first_name = "кошка";
                con.birthday = dateTimePicker1.Value;
                con.Validate();
                con.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
