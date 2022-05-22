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
    public partial class AdminRaporSayfasi : Form
    {
        public AdminRaporSayfasi()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            label8.Text = "1";
            this.bunifuCustomDataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bunifuCustomDataGrid1.DataSource = DataBase.getInstance().executeDataTable("Select R.rezEntryDate , R.rezReleaseDate,RT.rezType From Reservation R INNER JOIN ReservationType RT on R.rezTypeId=RT.rezTypeId Group by R.rezTypeId,R.rezEntryDate,R.rezReleaseDate,RT.rezType HAVING R.rezEntryDate < GETDATE() + 30");
            label7.Text = Convert.ToString(DataBase.getInstance().executeScalar("SELECT COUNT(R.rezId) FROM Reservation R WHERE R.rezEntryDate < GETDATE() + 30"));
        }

        private void AdminRaporSayfasi_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            label8.Text = "2";
            bunifuCustomDataGrid1.DataSource = null;
            
            bunifuCustomDataGrid1.DataSource = DataBase.getInstance().executeDataTable("exec BeklenenOdaGelirRaporu");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Clabiri", 14);
            SolidBrush firca = new SolidBrush(Color.Black);
            e.Graphics.DrawString($"Tarih:{DateTime.Now.ToString()}", font, firca, 60, 25);
            e.Graphics.DrawString("Beklenen Dololuk Raporu", font, firca, 350, 70);


            e.Graphics.DrawString("Rez Entry Date", font, firca, 60, 180);
            e.Graphics.DrawString("Rez Release Date", font, firca, 280, 180);
            e.Graphics.DrawString("Rez Type", font, firca, 500, 180);
            int i = 0;
            int y = 210;
            while(i<=bunifuCustomDataGrid1.Rows.Count-2)
            {
                font = new Font("Arial", 14);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[0].Value.ToString(), font,firca,60,y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString(), font, firca, 280, y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[2].Value.ToString(), font, firca, 500, y);
                y = y+40;
                i = i+1;
            }

        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

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


            e.Graphics.DrawString("gUN ", font, firca, 60, 180);
            e.Graphics.DrawString("Toplam Gelir (1 AYLIK)", font, firca, 280, 180);
            e.Graphics.DrawString("Ortalama Gelir Musteri/ToplamFiyat", font, firca, 500, 180);
            int i = 0;
            int y = 210;
            while (i <= bunifuCustomDataGrid1.Rows.Count - 2)
            {
                font = new Font("Arial", 14);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[0].Value.ToString(), font, firca, 60, y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[1].Value.ToString(), font, firca, 280, y);
                e.Graphics.DrawString(bunifuCustomDataGrid1.Rows[i].Cells[2].Value.ToString(), font, firca, 500, y);
                y = y + 40;
                i = i + 1;
            }
        }
    }
}
