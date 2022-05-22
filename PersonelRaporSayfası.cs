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
    public partial class PersonelRaporSayfası : Form
    {
        public PersonelRaporSayfası()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            label8.Text = "1";
            bunifuCustomDataGrid1.DataSource = DataBase.getInstance().executeDataTable("exec gunlukDolulukOraniRaporuu");
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            label8.Text = "2";
            bunifuCustomDataGrid1.DataSource = DataBase.getInstance().executeDataTable("exec gunlukGelenlerRaporu");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Clabiri", 14);
            SolidBrush firca = new SolidBrush(Color.Black);
            e.Graphics.DrawString($"Tarih:{DateTime.Now.ToString()}", font, firca, 60, 25);
            e.Graphics.DrawString("Beklenen Dololuk Raporu", font, firca, 350, 70);


            e.Graphics.DrawString("RoomId ", font, firca, 60, 180);
            e.Graphics.DrawString("RommNumber", font, firca, 280, 180);
            e.Graphics.DrawString("customerName", font, firca, 500, 180);
            e.Graphics.DrawString("customer SurName", font, firca, 700,180);
            int i = 0;
            int y = 210;
            while (i <= bunifuCustomDataGrid1.Rows.Count - 2)
            {
                font = new Font("Arial", 14);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[0].Value.ToString(), font, firca, 60, y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString(), font, firca, 280, y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[2].Value.ToString(), font, firca, 500, y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[3].Value.ToString(), font, firca, 650, y);
                y = y + 40;
                i = i + 1;
            }

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (label8.Text == "1")
                printDocument1.Print();
            else if (label8.Text == "2")
                printDocument2.Print();
            else
                MessageBox.Show("Rapaor Seciniz");
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Clabiri", 14);
            SolidBrush firca = new SolidBrush(Color.Black);
            e.Graphics.DrawString($"Tarih:{DateTime.Now.ToString()}", font, firca, 60, 25);
            e.Graphics.DrawString("Beklenen Dololuk Raporu", font, firca, 350, 70);


            e.Graphics.DrawString("customerId ", font, firca, 60, 180);
            e.Graphics.DrawString("rezTypeId", font, firca, 280, 180);
            e.Graphics.DrawString("roomId", font, firca, 500, 180);
            e.Graphics.DrawString("rezEntryDate", font, firca, 650, 180);
            int i = 0;
            int y = 210;
            while (i <= bunifuCustomDataGrid1.Rows.Count - 2)
            {
                font = new Font("Arial", 14);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[0].Value.ToString(), font, firca, 60, y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString(), font, firca, 280, y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[2].Value.ToString(), font, firca, 500, y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[3].Value.ToString(), font, firca, 650, y);
                y = y + 40;
                i = i + 1;
            }
        }
    }
}
