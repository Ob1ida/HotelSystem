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
    public partial class MyRezervasyon : Form
    {
       public Customer customer = new Customer();
        public MyRezervasyon()
        {
            InitializeComponent();
        }

        private void MyRezervasyon_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = DataBase.getInstance().executeDataTable(String.Format("SELECT * FROM Reservation WHERE customerId = '{0}' ", customer.CustomerId));
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (label6.Text == "0")
            {
                MessageBox.Show("Rezervasyon Seciniz");
                return;
            }
            else
            {
                DataBase.getInstance().executeNonQuery(String.Format("DELETE FROM Reservation WHERE rezId = '{0}'", label6.Text));
            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           label6.Text = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
