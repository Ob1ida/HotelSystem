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

namespace Otel
{
    
    public partial class Login : Form
    {
      
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (TxtUserName.Text == "" || TxtPassword.Text == "")
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun");
                    return;
            }
            if (DataBase.getInstance().Login(TxtUserName.Text, TxtPassword.Text, "Customer"))
            {
                Customer customerr = new Customer();
                customerr.UserName = TxtUserName.Text;
                customerr.Password = TxtPassword.Text;
                MusteriAnaMenu Menu = new MusteriAnaMenu();
                Menu.customer = customerr;
                this.Hide();
                Menu.Show();
                MessageBox.Show("HosGeldiniz");
            }
            else
            {
                MessageBox.Show("Basarisiz Giris");
                return;
            }
            
        }

        private void bunifuSeparator2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            PersonelLogin formP = new PersonelLogin();
            formP.Show();
            this.Hide();
        }

        private void CheckBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckBoxPassword.Checked)
            {
                TxtPassword.UseSystemPasswordChar = true;
              
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = false;
                
            }
        }
    }
}
