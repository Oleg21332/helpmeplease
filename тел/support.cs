using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Телеком
{
    public partial class support : Form
    {
        public support()
        {
            InitializeComponent();
        }

        private void support_Load(object sender, EventArgs e)
        {
            disp_data1();
        }
        private void disp_data1()
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `zayavks`", db.getConnection()); // выборка всех строк из таблицы 
            adapter.Fill(table); // возврат всех успешно добавленных строк
            dataGridView1.DataSource = table; // отображение БД в datagridview (таблице)
        }
        private void exit_Click(object sender, EventArgs e)
        {
            menu mn = new menu();
            mn.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int first = dataGridView1.CurrentCell.RowIndex;
            int second = dataGridView1.Columns.Count;
            string[] value = new string[second];
            for (int i = 0; i < second; i++)
            {
                value[i] = dataGridView1.Rows[first].Cells[i].Value.ToString();
            }
            panel1.Visible = true;
            label18.Text = value[1];
            DATA.text1 = value[1];
            label24.Text = value[2];
            label19.Text = value[3];
            DATA.text2 = value[3];
            label20.Text = value[4];
            label22.Text = value[5];
            label23.Text = value[6];
            DATA.text3 = value[7];
            DATA.text4 = value[9];
            button2.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DATA.type_problem = label20.Text;
            viezd vz = new viezd();
            vz.Show();
            Hide();
        }
    }
}
