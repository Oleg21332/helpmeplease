using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Телеком
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            role.TextAlign = ContentAlignment.TopRight;
        }

        private void menu_Load(object sender, EventArgs e)
        {
            disp_data();
            panel2.AutoScroll = true;



            string hai = DATA.text;
            DB db = new DB(); // подключение к БД
            db.openConnection();

            MySqlCommand command = new MySqlCommand
            ($"SELECT `lastname` FROM `client` WHERE `Email` = '{hai}'", db.getConnection());
            object name = command.ExecuteScalar();
            string name1 = Convert.ToString(name);
            FIO.Text = name1;
            command.CommandText = $"SELECT `Firstname` FROM `client` WHERE `Email` = '{hai}'";
            object name2 = command.ExecuteScalar();
            string name22 = Convert.ToString(name2);
            FIO.Text += " " + name22;

            command.CommandText = $"SELECT `Patronymic` FROM `client` WHERE `Email` = '{hai}'";
            object name3 = command.ExecuteScalar();
            string name33 = Convert.ToString(name3);
            FIO.Text += " " + name33;
            db.closeConnection();
            db.openConnection();
            command.CommandText = $"SELECT `role` FROM `client` WHERE `Email` = '{hai}'";
            object name4 = command.ExecuteScalar();
            string name44 = Convert.ToString(name4);
            role.Text = name44;
            db.closeConnection();


            if (role.Text == "Руководитель отдела по работе с клиентами")
            {
                button3.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
            }
            if (role.Text == "Менеджер по работе с клиентами")
            {
                button3.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button2.Visible = false;
            }
            if (role.Text == "Технический департамент")
            {
                button3.Visible = false;
                button2.Visible = false;
            }
            if (role.Text == "Руководитель отдела технической поддержки")
            {
                button2.Visible = false;
                button5.Visible = false;
            }
            if (role.Text == "Специалист технической поддержки")
            {
                button2.Visible = false;
                button5.Visible = false;
            }
            if (role.Text == "Бухгалтер")
            {
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;

            }
        }
        public void disp_data()
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `abonents`", db.getConnection()); // выборка всех строк из таблицы 
            adapter.Fill(table); // возврат всех успешно добавленных строк
            dataGridView1.DataSource = table; // отображение БД в datagridview (таблице)
        }
        public void disp_data1()
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `oborydovanie`", db.getConnection()); // выборка всех строк из таблицы 
            adapter.Fill(table); // возврат всех успешно добавленных строк
            dataGridView1.DataSource = table; // отображение БД в datagridview (таблице)
        }
        public void disp_data2()
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `crm`", db.getConnection()); // выборка всех строк из таблицы 
            adapter.Fill(table); // возврат всех успешно добавленных строк
            dataGridView1.DataSource = table; // отображение БД в datagridview (таблице)
        }
        public void disp_data3()
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `activs`", db.getConnection()); // выборка всех строк из таблицы 
            adapter.Fill(table); // возврат всех успешно добавленных строк
            dataGridView1.DataSource = table; // отображение БД в datagridview (таблице)
        }

        private void button6_Click(object sender, EventArgs e)
        {
            disp_data1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disp_data();
            active.Visible = true;
            passive.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            disp_data2();
            active.Visible = false;
            passive.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            disp_data3();
            active.Visible = false;
            passive.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            support sp = new support();
            sp.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Authorization auth = new Authorization();
            this.Close();
            auth.Show();         
        }

        private void active_CheckedChanged(object sender, EventArgs e)
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `abonents` WHERE `status` = '1'", db.getConnection());
            adapter.Fill(table);
            dataGridView1.DataSource = table; 
        }

        private void passive_CheckedChanged(object sender, EventArgs e)
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `abonents` WHERE `status` = '0'", db.getConnection());
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            var values = textBox1.Text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                foreach (string value in values)
                {
                    var row = dataGridView1.Rows[i];

                    if (row.Cells["ФИО"].Value.ToString().Contains(value) ||
                        row.Cells["Лицевой счёт"].Value.ToString().Contains(value) || 
                        row.Cells["Адрес прописки"].Value.ToString().Contains(value) || 
                        row.Cells["Адрес проживания"].Value.ToString().Contains(value))
                    {
                        row.Selected = true;
                    }
                }
            }
        }
    }
}
