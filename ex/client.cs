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
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }

        private void client_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotelDataSet1.personal". При необходимости она может быть перемещена или удалена.
            this.personalTableAdapter1.Fill(this.hotelDataSet1.personal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotelDataSet.personal". При необходимости она может быть перемещена или удалена.
            this.personalTableAdapter.Fill(this.hotelDataSet.personal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotelDataSet.number". При необходимости она может быть перемещена или удалена.
            this.numberTableAdapter.Fill(this.hotelDataSet.number);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotelDataSet.client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.hotelDataSet.client);

        }

  
    private void ReadSingleRow(DataGridView dgw , IDataRecord record)
    {
        dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), RowState.ModifiedNew);
    }
    private void RefreshDataGrid(DataGridView dgw)
    {
       /*     db bd = new db();
            dgw.Rows.Clear();
            string queryString = $"select * from Hotel";
            SqlCommand command = new SqlCommand(queryString, bd.getConnection());
            bd.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();*/
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            addclient ar = new addclient();
            ar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            db bd = new db();
            bd.openConnection();//соединение с бд

            SqlCommand command1 = new SqlCommand($"DELETE FROM client where id_client =@id", bd.getConnection());
            SqlCommand command2 = new SqlCommand($"DELETE FROM number where id_client =@id", bd.getConnection());
            command1.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            command2.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            bd.openConnection();
            command2.ExecuteNonQuery();//выполнение команды
            command1.ExecuteNonQuery();//выполнение команды
            MessageBox.Show("Запись успешно удалена", "Информация");
            this.Hide();
            client ag = new client();
            ag.Show();
        }
/*        private void Search(DataGridView dgw)*/
      /*  {
            db bd = new db();
            dgw.Rows.Clear();
            string searchstring = $"select * from Hotel where client(firstname, middlename, lastname, date, serpass, kempass, nampass, datepass) like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchstring, bd.getConnection());
            bd.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while(read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();
        }*/
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         /*   Search(dataGridView1);*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox2.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            addpersonal af = new addpersonal();
            af.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            db bd = new db();
            SqlCommand command2 = new SqlCommand($"DELETE FROM personal where id_personal =@id", bd.getConnection());
            command2.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
            bd.openConnection();
            command2.ExecuteNonQuery();//выполнение команды
            MessageBox.Show("Запись успешно удалена", "Информация");
            this.Hide();
            client ag = new client();
            ag.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ag = new Form1();
            ag.Show();
        }
    }
}
