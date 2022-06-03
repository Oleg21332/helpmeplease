using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class infoclient : Form
    {
        public infoclient()
        {
            InitializeComponent();
        }

        private void callme_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Телефон для заказа номера : 8-800-555-35-35 Телефон администратора : 8-800-1000-800");

        }

        private void pronnumber_Click(object sender, EventArgs e)
        {
            addclient all = new addclient();
            all.Show();
        }
    }
}
