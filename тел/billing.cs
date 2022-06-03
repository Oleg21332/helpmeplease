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
    public partial class billing : Form
    {
        public billing()
        {
            InitializeComponent();
        }

        private void billing_Load(object sender, EventArgs e)
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `platezh`", db.getConnection()); // выборка всех строк из таблицы 
            adapter.Fill(table); // возврат всех успешно добавленных строк
            dataGridView2.DataSource = table; // отображение БД в datagridview (таблице)
        }
    }
}
