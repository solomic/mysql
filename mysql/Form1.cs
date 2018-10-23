using Mig.Entity;
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
            try
            {
                con = new Contact();
                con.Init();
                con.ReadFromDB(1);
                textBox1.Text = con.id.ToString();
                textBox2.Text = con.last_name;
                if(con.birthday != null)
                    dateTimePicker1.Value = Convert.ToDateTime(con.birthday);

                dataGridView1.DataSource = con.GetDataTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.last_name = textBox1.Text;
                con.first_name = textBox2.Text;
                con.birthday = dateTimePicker1.Value;
                con.Validate();
                con.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contact new_con = new Contact();
            new_con.Init();
            new_con.Add();
            new_con.last_name = "sdfsdfsdfsdf";
            new_con.first_name = "2222";
            new_con.Save();
        }
    }
}
