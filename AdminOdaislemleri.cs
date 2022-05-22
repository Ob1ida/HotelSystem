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
    public partial class AdminOdaislemleri : Form
    {
        public Admin admin = new Admin();
        public AdminOdaislemleri()
        {
            InitializeComponent();
        }

        private void bunifuSeparator3_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminOdaislemleri_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            bunifuCustomDataGrid1.DataSource = DataBase.getInstance().executeDataTable("SELECT * FROM Rooms");
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomId.Text = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtRoomNumber.Text = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtRoomCapacity.Text = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase.getInstance().executeNonQuery(string.Format("INSERT INTO Rooms (roomNumber,roomCapacity,roomId) VALUES ('{0}','{1}','{2}')", txtRoomNumber.Text, txtRoomCapacity.Text, txtRoomId.Text));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Execption",MessageBoxButtons.OK);               
            }
            //DataBase.getInstance().executeNonQuery(string.Format("INSERT INTO Rooms (roomNumber,roomCapacity,roomId) VALUES ('{0}','{1}','{2}')", txtRoomNumber.Text, txtRoomCapacity.Text,txtRoomId.Text));
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase.getInstance().executeNonQuery(string.Format("UPDATE Rooms SET roomNumber = '{0}',roomCapacity = '{1}' WHERE roomId = '{2}'", txtRoomNumber.Text, txtRoomCapacity.Text, txtRoomId.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("You Cant Change the Room ID");
                throw;
            }
            //DataBase.getInstance().executeNonQuery(string.Format("UPDATE Rooms SET roomNumber = '{0}',roomCapacity = '{1}' WHERE roomId = '{2}'", txtRoomNumber.Text, txtRoomCapacity.Text, txtRoomId.Text));
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            DataBase.getInstance().executeNonQuery(string.Format("DELETE FROM Rooms WHERE roomId = '{0}'", txtRoomId.Text));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(bunifuCustomDataGrid1.DataSource != null)
            {
                bunifuCustomDataGrid1.DataSource = null;
            }
            if(radioButton1.Checked)
            {
               bunifuCustomDataGrid1.DataSource = DataBase.getInstance().executeDataTable(string.Format("SELECT * FROM Rooms WHERE roomId = '{0}'", textBox1.Text));
            }
            else if(radioButton3.Checked)
            {
                bunifuCustomDataGrid1.DataSource = DataBase.getInstance().executeDataTable(string.Format("SELECT * FROM Rooms WHERE roomNumber = '{0}'", textBox1.Text));
            }
            else if(radioButton2.Checked)
            {
                bunifuCustomDataGrid1.DataSource = DataBase.getInstance().executeDataTable(string.Format("SELECT * FROM Rooms WHERE roomCapacity = '{0}'", textBox1.Text));
            }
        }
    }
}
