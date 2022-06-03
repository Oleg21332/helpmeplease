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
    public partial class viezd : Form
    {
        public viezd()
        {
            InitializeComponent();
        }

        private void viezd_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            label13.Text = DATA.text1;
            label14.Text = DATA.text2;
            label15.Text = DATA.text3;
            label16.Text = DATA.text4;


            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM `zayavks` WHERE `problem` = '{DATA.type_problem}'", db.getConnection()); // выборка всех строк из таблицы 
            adapter.Fill(table); // возврат всех успешно добавленных строк
            dataGridView1.DataSource = table; // отображение БД в datagridview (таблице)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            int u = 0;
            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1[j, i].Selected == true)
                    {
                        u++;
                    }
                }
            }
            if(u == dataGridView1.SelectedCells.Cast<DataGridViewCell>().Select(c => c.RowIndex).Distinct().Count())
            {
                MessageBox.Show("выделите ячейку");
                return;
            }
            db.closeConnection();
            int first = dataGridView1.CurrentCell.RowIndex;
            int second = dataGridView1.Columns.Count;
            string[] value = new string[second];
            for (int i = 0; i < second; i++)
            {
                value[i] = dataGridView1.Rows[first].Cells[i].Value.ToString();
            }
            if(comboBox1.Text == null || comboBox1.Text == "")
            {
                MessageBox.Show("Выберите инженера");
                return;
            }
            db.openConnection();
            MySqlCommand command = new MySqlCommand($"UPDATE `zayavks` SET `инженер` = '{comboBox1.Text}' WHERE `fio` = '{value[1]}'", db.getConnection());
            command.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show("Инженер назначен");
        }
    }
}
