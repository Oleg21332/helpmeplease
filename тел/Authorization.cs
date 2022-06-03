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
using System.Net;
using System.Net.Mail;

namespace Телеком
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string use = this.email.Text;
            string b = this.password.Text;
            DB db = new DB(); // подключение к БД
            db.openConnection();
            DataTable table = new DataTable(); // представляет одну таблицу данных в памяти

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand
            ("SELECT * FROM `client` WHERE `Email` = @uL AND `Password` = @uP", db.getConnection()); // выборка всех полей из таблицы 
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = use; // присвоение значений
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = b;
            command.CommandText = "SELECT `status` FROM `client` WHERE `Email` = @uL AND `Password` = @uP";
            object name = command.ExecuteScalar();
            string status = Convert.ToString(name);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                if (returned.text == code.Text)
                {
                    if(status == "0")
                    {
                        menu_user me = new menu_user();
                        me.Show();
                        Hide();
                    }
                    else 
                    if(status == "1")
                    {
                        DATA.text = email.Text;
                        menu menu = new menu();
                        menu.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Введите код");
                }
            }
            else
            {
                MessageBox.Show("Аккаунт не найден, проверьте пароль и логин");
            }
            db.closeConnection();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            returned.text = new String(stringChars);

            string adressTo = email.Text; //адрес пользователя
            string messageText = new String(stringChars); //текст
            SendMessage(adressTo, messageText);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            email.Text = "";
            password.Text = "";
            code.Text = "";
        }
        static void SendMessage(string adressTo, string messageText)
        {

            string from = "treshkrek@mail.ru"; // адреса отправителя
            string pass = "jdcRQkWrvKJD3xSy8sEB"; // пароль отправителя

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from); // Адрес отправителя
            mail.To.Add(new MailAddress(adressTo)); // Адрес получателя
            mail.Body = messageText; // Текст

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(from, pass);
            client.Host = "smtp.mail.ru";
            client.Port = 25;
            client.EnableSsl = true;
            client.Send(mail);

            MessageBox.Show("Код отправлен вам на почту.");
        }

    }
}