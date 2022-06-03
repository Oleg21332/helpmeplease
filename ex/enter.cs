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
    public partial class enter : Form
    {
        public enter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db bd = new db();
            var loginuser = login.Text;
            var passuser = pass.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login, password from users where login ='{loginuser}' and password = '{passuser}'";
            SqlCommand command = new SqlCommand(querystring, bd.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно авторизовались");
                this.Hide();
                infoclient al = new infoclient();
                al.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.Повторите попытку.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            registration alt1 = new registration();
            this.Hide();
            alt1.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db bd = new db();
            var loginuser = login.Text;
            var passuser = pass.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login, password from users where login ='{loginuser}' and password = '{passuser}'";
            SqlCommand command = new SqlCommand(querystring, bd.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно авторизовались");
                this.Hide();
                client al = new client();
                al.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.Повторите попытку.");
            }
        }
    }
}
