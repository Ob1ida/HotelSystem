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
    public partial class MusteriRez2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4T09HNO;Initial Catalog=Hootel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        public MusteriRez2()
        {
            InitializeComponent();
        }
        public Customer customer = new Customer();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MusteriRez2_Load(object sender, EventArgs e)
        {
            
            MessageBox.Show(t1.ToString());
            timer1.Enabled = true;
        }
        DateTime t1;
        DateTime t2;
        public string RezTipi;
        private void timer1_Tick(object sender, EventArgs e)
        {
            t1 = DateGiris.Value;
            t2 = DateCikis.Value;
            if((t1-DateTime.Now).Days >=60 && (t1 - DateTime.Now).Days<90)
            {
                RezTipi = "AltmisGun";
            }
            else if((t1-DateTime.Now).Days<=30)
            {
                RezTipi = "klasik";
            }
            else if((t1-DateTime.Now).Days >=90)
            {
                RezTipi = "OnOdemeli";
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MessageBox.Show(RezTipi);
            if(RezTipi == "klasik")
            {
                cmd = new SqlCommand("SELECT dbo.DololukOrani(@giris,@Cikis)",conn);
                cmd.Parameters.AddWithValue("@giris", t1);
                cmd.Parameters.AddWithValue("@Cikis", t2);
                conn.Open();
                object obj1 = (object)cmd.ExecuteScalar();
               int iTransactionID = Convert.ToInt32(obj1);
                if (iTransactionID < 22)
                {
                    RezTipi = "Tesvik";
                    TesvikRez tesvik = new TesvikRez();
                    tesvik.GirisTarihi = t1;
                    tesvik.BitisTarihi = t2;
                    tesvik.UcretHesapla();
                    MessageBox.Show(tesvik.GirisTarihi.ToString());
                    tesvik.CustomerId = customer.CustomerId;
                    tesvik.RezType = 4;

                    OdemeFormu ode = new OdemeFormu();
                    ode.tesvik = tesvik;
                    ode.customer = customer;
                    ode.RezType = RezTipi;
                    ode.Show();
                    this.Hide();
                    return;

                }
                else
                {
                    KlasikRez klasik = new KlasikRez();
                    klasik.GirisTarihi = t1;
                    klasik.BitisTarihi = t2;
                    klasik.UcretHesapla();
                    MessageBox.Show(klasik.Ucret.ToString());
                    klasik.CustomerId = customer.CustomerId;
                    klasik.RezType = 1;

                    OdemeFormu ode = new OdemeFormu();
                    ode.klasik = klasik;
                    ode.customer = customer;
                    ode.RezType = RezTipi;
                    ode.Show();
                    this.Hide();
                }
               

                 
            }
            else if(RezTipi == "OnOdemeli")
            {
                OnOdemeliRez onodemeli = new OnOdemeliRez();
                onodemeli.GirisTarihi = t1;
                onodemeli.BitisTarihi = t2;
                onodemeli.UcretHesapla();
                MessageBox.Show(onodemeli.Ucret.ToString());
                onodemeli.CustomerId = customer.CustomerId;
                onodemeli.RezType = 2;
                OdemeFormu ode = new OdemeFormu();
                ode.onodemeli = onodemeli;
                ode.customer = customer;
                ode.RezType = RezTipi;
                ode.Show();
                this.Hide();

            }
            else if(RezTipi == "AltmisGun")
            {
                AltmisGunOnceRez altmis = new AltmisGunOnceRez();
                altmis.GirisTarihi = t1;
                altmis.BitisTarihi = t2;
                altmis.UcretHesapla();
                MessageBox.Show(altmis.Ucret.ToString());
                altmis.CustomerId = customer.CustomerId;
                altmis.RezType = 3;

                OnayFormu onay = new OnayFormu();
                onay.Altmis = altmis;
                onay.RezType = RezTipi;
                onay.Show();
                this.Hide();
            }
            
            

            
            
        }
    }
}
