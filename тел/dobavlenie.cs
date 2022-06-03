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
    public partial class dobavlenie : Form
    {
        public dobavlenie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection(); // открытие соединения
            if(textBox1.Text != null && textBox1.Text != "" && textBox2.Text != null && textBox2.Text != "" && textBox3.Text != null
                && textBox3.Text != "" && textBox4.Text != null && textBox4.Text != "" && textBox5.Text != null && textBox5.Text != "")
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO `magistral` (`Название`, `Частота`, `Коэффициент затухания`, `Технология передачи данных`, `Улица`) VALUE ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}')", db.getConnection()); // обновление таблицы tovar в БД
                int i = command.ExecuteNonQuery(); // возврат количества строк
                if (i != 0)
                {
                    MessageBox.Show("Оборудование добавлено");
                    db.closeConnection();
                    kontrol d = new kontrol();
                    d.Update();
                    Close();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Введите данные для добавления");
            }
            
        }
    }
}
