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
    public partial class Form2 : Form
    {
        string Conn = @"Data Source=DESKTOP-4T09HNO;Initial Catalog=Hootel;Integrated Security=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void TxtBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            using(SqlConnection sqlcCon = new SqlConnection(Conn))
            {
                if(TxtPassword.Text == "" || TxtBoxfirst.Text == "" || TxtUserName.Text == ""
                    || TxtBoxSurName.Text == "" || TxtTelefon.Text == "" || TxtEmail.Text == "")
                {
                    MessageBox.Show("Basarisiz Giris");
                    return;
                }
                sqlcCon.Open();
                SqlCommand cmd = new SqlCommand("UserADD", sqlcCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirtsName", TxtBoxfirst.Text.Trim());
                cmd.Parameters.AddWithValue("@SurName", TxtBoxSurName.Text.Trim());
                cmd.Parameters.AddWithValue("UserName", TxtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("TelefonNo", TxtTelefon.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TxtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", TxtPassword.Text.Trim());
                cmd.ExecuteNonQuery();
                sqlcCon.Close();            
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
             
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
