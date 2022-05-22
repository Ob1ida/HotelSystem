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
    public partial class PersonelLogin : Form
    {
        public PersonelLogin()
        {
            InitializeComponent();
        }

        private void PersonelLogin_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (TxtStuffUserName.Text == "" || TxtstuffPassword.Text == "")
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun");
                return;
            }
            if (DataBase.getInstance().Login(TxtStuffUserName.Text, TxtstuffPassword.Text, "Personel"))
            {

                MessageBox.Show("HosGeldiniz");
            }
            else
            {
                MessageBox.Show("Basarisiz Giris");
                return;
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (TxtAdminUserName.Text == "" || TxtAdminPass.Text == "")
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun");
                return;
            }
            if (DataBase.getInstance().Login(TxtAdminUserName.Text, TxtAdminPass.Text, "Admin"))
            {
                Admin adminn = new Admin();
                adminn.UserName = TxtAdminUserName.Text;
                adminn.Password = TxtAdminPass.Text;
                AdminMenu Menu = new AdminMenu();
                Menu.admin = adminn;
                MessageBox.Show("HosGeldiniz");
                this.Hide();
                Menu.Show();
            }
            else
            {
                MessageBox.Show("Basarisiz Giris");
                return;
            }
        }
    }
}
