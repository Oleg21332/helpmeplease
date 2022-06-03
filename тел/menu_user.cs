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
    public partial class menu_user : Form
    {
        public menu_user()
        {
            InitializeComponent();
            comboBox1.KeyPress += (sender, e) => e.Handled = true;
            comboBox2.KeyPress += (sender, e) => e.Handled = true;
            comboBox3.KeyPress += (sender, e) => e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection(); // открытие соединения
            if (textBox1.Text != null && textBox1.Text != "" && textBox2.Text != null && textBox2.Text != "" && comboBox3.Text != null
               && comboBox3.Text != "" && comboBox1.Text != null && comboBox1.Text != "" && comboBox2.Text != null && comboBox2.Text != "")
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO `zayavks` (`fio`, `address`, `yslyga`, `problem`, `oboryd`, `opisanie`, `Дата`, `Дата приезда`, `Время`)" +
                    $" VALUE ('{textBox1.Text}','{textBox2.Text}','{comboBox1.Text}','{comboBox2.Text}','{comboBox3.Text}','{richTextBox1.Text}', '{DateTime.Today.ToString("d")}', '{monthCalendar1.SelectionStart.Date.ToString("d")}', '{comboBox4.Text}')", db.getConnection());
                
                int i = command.ExecuteNonQuery(); // возврат количества строк
                if (i != 0)
                {
                    MessageBox.Show("Заявка отправлена");
                    db.closeConnection();
                   
                }
                else
                {
                    MessageBox.Show("Произошла ошибка");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Введите данные для отправления заявки");
            }
        }

        private void menu_user_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
