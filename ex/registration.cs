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
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db bd = new db();
            var loginuser = lg.Text;
            var passuser = lp.Text;

            string querystring = $"insert into users(login, password )values('{loginuser}','{passuser}')";
            SqlCommand command = new SqlCommand(querystring, bd.getConnection());
            bd.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно зарегистрированы");
                this.Hide();
                enter al = new enter();
                al.Show();

            }
            else
            {
                MessageBox.Show("Ошибка.Попробуйте ещё раз.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            enter al = new enter();
            al.Show();
        }
    }
}


