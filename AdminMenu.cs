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
    public partial class AdminMenu : Form
    {
       public Admin admin = new Admin();
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            AdminOdaislemleri frm = new AdminOdaislemleri();
            frm.admin = admin;
            this.Hide();
            frm.Show();
        }
    }
}
