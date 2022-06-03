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
    public partial class addpersonal : Form
    {
        public addpersonal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            client ag = new client();
            ag.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db bd = new db();
            string querystring = $"insert into personal(Firstpersonal, Middlepersonal, Numberpersonal, Cashpersonal) values ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}')";
            SqlCommand command = new SqlCommand(querystring, bd.getConnection());
            bd.openConnection();
            command.ExecuteNonQuery();
            MessageBox.Show("Персонал успешно добавлкен", "Сообщение");
            this.Hide();
            client ag = new client();
            ag.Show();
        }
    }
}
