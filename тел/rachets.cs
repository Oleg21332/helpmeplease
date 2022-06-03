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
    public partial class rachets : Form
    {
        public string stats;
        public string stats0;
        public char[] stats3;
        public string[] stats2;
        public char[] stats1;
        public rachets()
        {
            InitializeComponent();
        }

        private void raschets_Click(object sender, EventArgs e)
        {
            stats = stats.Replace(", "," ");
            stats2 = stats.Split(' ');
            string stats0 = null;
            for (int i = 0; i < stats2.Length; i++)
            {
                stats0 += stats2[i];
            }
            stats1 = stats0.ToCharArray().Distinct().ToArray();
            if (stats1.Length > 3)
            {
                MessageBox.Show("Вы ввели слишком много станций для кластера" + Environment.NewLine + "Программа уберёт станций для ввода новых");
                stats = null;
                return;
            }
            if (stats1.Length < 3)
            {
                MessageBox.Show("Вы ввели слишком мало станций для кластера" + Environment.NewLine + "Программа уберёт станций для ввода новых");
                stats = null;
                return;
            }

            if(ploshad_obslujivaniya.Text == "")
            {
                MessageBox.Show("Введите площадь обслуживания");
                return;
            }
            if (ploshad_pokritiya.Text == "")
            {
                MessageBox.Show("Введите площадь покрытия");
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите коэффициент");
                return;
            }
            double s = Convert.ToDouble(ploshad_obslujivaniya.Text.Replace(".",","));
            double R = Math.Sqrt(Convert.ToDouble(ploshad_pokritiya.Text.Replace(".", ",")) / Math.PI);
            double K = Convert.ToDouble(comboBox1.Text.Replace(".", ","));
            ploshad_rayona.Text = Math.Sqrt(s/Math.PI).ToString();
            double L = (K * Math.Pow(s/R, Convert.ToDouble(2)));
            chislo_sot.Text = L.ToString();


            DB db = new DB();
            db.openConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `Площадь зоны покрытия, кв.км` FROM `bs` WHERE `ИД базовой станции` = '{stats1[0]}'", db.getConnection());
            object name = command.ExecuteScalar();
            string name1 = Convert.ToString(name);
            double D1 = Convert.ToDouble(name1);
            command.CommandText = $"SELECT `Площадь зоны покрытия, кв.км` FROM `bs` WHERE `ИД базовой станции` = '{stats1[1]}'";
            name = command.ExecuteScalar();
            name1 = Convert.ToString(name);
            double D2 = Convert.ToDouble(name1);
            command.CommandText = $"SELECT `Площадь зоны покрытия, кв.км` FROM `bs` WHERE `ИД базовой станции` = '{stats1[2]}'";
            name = command.ExecuteScalar();
            name1 = Convert.ToString(name);
            double D3 = Convert.ToDouble(name1);
            double C = (Math.Pow(D1, 5/2) + Math.Pow(D2, 5 / 2) + Math.Pow(D3, 5 / 2));
            Klaster.Text = C.ToString();


            double n = C / L;
            base_stations.Text = n.ToString();
            db.closeConnection();
        }

        private void rachets_Load(object sender, EventArgs e)
        {
            DB db = new DB(); // подключение к БД

            DataTable table = new DataTable();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `bs`", db.getConnection());
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void b1_Click(object sender, EventArgs e)
        {
            stats += "1, ";
            stats = stats.Replace(", ", " ");
            stats2 = stats.Split(' ');
            stats1 = stats.ToCharArray().Distinct().ToArray();
            label10.Text = null;
            for (int i = 0; i < stats1.Length; i++)
            {
                label10.Text += stats1[i] + " ";
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            stats += "2, ";
            stats = stats.Replace(", ", " ");
            stats2 = stats.Split(' ');
            stats1 = stats.ToCharArray().Distinct().ToArray();
            label10.Text = null;
            for (int i = 0; i < stats1.Length; i++)
            {
                label10.Text += stats1[i] + " ";
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            stats += "3, ";
            stats = stats.Replace(", ", " ");
            stats2 = stats.Split(' ');
            stats1 = stats.ToCharArray().Distinct().ToArray();
            label10.Text = null;
            for (int i = 0; i < stats1.Length; i++)
            {
                label10.Text += stats1[i] + " ";
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            stats += "4, ";
            stats = stats.Replace(", ", " ");
            stats2 = stats.Split(' ');
            stats1 = stats.ToCharArray().Distinct().ToArray();
            label10.Text = null;
            for (int i = 0; i < stats1.Length; i++)
            {
                label10.Text += stats1[i] + " ";
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            stats += "5, ";
            stats = stats.Replace(", ", " ");
            stats2 = stats.Split(' ');
            stats1 = stats.ToCharArray().Distinct().ToArray();
            label10.Text = null;
            for (int i = 0; i < stats1.Length; i++)
            {
                label10.Text += stats1[i] + " ";
            }
        }
    }
}
