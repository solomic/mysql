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
                dataGridView1.DataSource = con.GetDataTable();
                con = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            Contact new_con = new Contact();
            new_con.Init();
            //new_con.BeginTransaction();
            new_con.Add();
            new_con.last_name = Guid.NewGuid().ToString();
            new_con.first_name = Guid.NewGuid().ToString();                
            new_con.Save();
                //new_con.RollbackTransaction();
                // new_con.CommitTransaction();
                new_con = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Address adr = new Address();
            adr.Init();
            adr.Add();
            
            adr.full_address = Guid.NewGuid().ToString();
            adr.Save();
            adr = null;
        }
    }
}
