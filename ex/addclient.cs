using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Examen
{
    public partial class addclient : Form
    {
        public addclient()
        {
            InitializeComponent();
        }

        private void addclient_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db bd = new db();
            string querystring = $"insert into client(firstname, middlename, lastname, date, serpass, kempass, nampass, datepass) values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox7.Text}','{textBox9.Text}','{textBox8.Text}')";
            SqlCommand command = new SqlCommand(querystring, bd.getConnection());
            bd.openConnection(); 
            command.ExecuteNonQuery();
            int a = Convert.ToInt32(textBox13.Text);
            int b = Convert.ToInt32(textBox12.Text);
            int s;
            s = a * b * 1000;
            string add = $"insert into number(Type_numbers, Sleepbad, Daylive, Revelation, Cash) values('{textBox13.Text}','{textBox12.Text}','{textBox10.Text + "-" + textBox11.Text}','{textBox6.Text}','{s}')";
            SqlCommand command1 = new SqlCommand(add, bd.getConnection());
            bd.openConnection();
            command1.ExecuteNonQuery();
            MessageBox.Show("Заявка успешно добавлена");
            this.Hide();
            Form1 al = new Form1();
            al.Show();


        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
