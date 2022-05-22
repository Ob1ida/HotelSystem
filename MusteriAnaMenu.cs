using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel
{
    public partial class MusteriAnaMenu : Form
    {
        public Customer customer = new Customer();
        public MusteriAnaMenu()
        {
            InitializeComponent();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            MusteriRez2 MusForm = new MusteriRez2();
            MusForm.customer = customer;
            this.Hide();
            MusForm.Show();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            customer.CustomerId = (int)DataBase.getInstance().executeScalar(string.Format("SELECT customerId FROM Customer WHERE customerUserName = '{0}' and customerPw = '{1}'", customer.UserName, customer.Password));
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            MyRezervasyon rez = new MyRezervasyon();
            rez.customer = customer;
            rez.Show();
            this.Hide();
        }
    }
}
