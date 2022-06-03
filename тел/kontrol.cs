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
    public partial class kontrol : Form
    {
        public kontrol()
        {
            InitializeComponent();
        }

        private void kontrol_Load(object sender, EventArgs e)
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `seti_dostupa`", db.getConnection());
            adapter.Fill(table);
            dataGridView2.DataSource = table;
            DataTable table2 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter("SELECT * FROM `magistral`", db.getConnection());
            adapter1.Fill(table2);
            dataGridView1.DataSource = table2;
            DataTable table3 = new DataTable();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT * FROM `abonentskoe_oboryd`", db.getConnection());
            adapter2.Fill(table3);
            dataGridView3.DataSource = table3;
            db.closeConnection();
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

                    if (row.Cells["Название"].Value.ToString().Contains(value) ||
                        row.Cells["Улица"].Value.ToString().Contains(value))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();

            if (string.IsNullOrWhiteSpace(textBox2.Text))
                return;

            var values = textBox2.Text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                foreach (string value in values)
                {
                    var row = dataGridView2.Rows[i];

                    if (row.Cells["Наименование"].Value.ToString().Contains(value) ||
                        row.Cells["Место расположения"].Value.ToString().Contains(value))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dobavlenie dob = new dobavlenie();
            dob.ShowDialog();
        }
    }
}
