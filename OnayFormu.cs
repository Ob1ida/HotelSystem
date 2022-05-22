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
    public partial class OnayFormu : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4T09HNO;Initial Catalog=Hootel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
       public Customer customer = new Customer();
       public KlasikRez klasik = new KlasikRez();
        public OnOdemeliRez onodemeli = new OnOdemeliRez();
        public AltmisGunOnceRez Altmis = new AltmisGunOnceRez();
        public TesvikRez tesvik = new TesvikRez();
        SqlCommand cmd;
       public string RezType;
        public OnayFormu()
        {
            InitializeComponent();
        }

        private void OnayFormu_Load(object sender, EventArgs e)
        {
            MessageBox.Show(tesvik.GirisTarihi.ToString());
            if(RezType == "klasik")
            {
                LblGiris.Text = klasik.GirisTarihi.ToString();
                LblCikis.Text = klasik.BitisTarihi.ToString();
                LblRezDate.Text = DateTime.Now.ToString();
                LblRezUcret.Text = ((klasik.BitisTarihi - klasik.GirisTarihi).Days * klasik.Ucret).ToString();
                LblUserName.Text = customer.UserName;

            }
            else if(RezType == "OnOdemeli")
            {
                LblGiris.Text = onodemeli.GirisTarihi.ToString();
                LblCikis.Text = onodemeli.BitisTarihi.ToString();
                LblRezDate.Text = DateTime.Now.ToString();
                LblRezUcret.Text = ((onodemeli.BitisTarihi - onodemeli.GirisTarihi).Days * onodemeli.Ucret).ToString();
                LblUserName.Text = customer.UserName;
            }
            else if(RezType == "AltmisGun")
            {
                LblGiris.Text = Altmis.GirisTarihi.ToString();
                LblCikis.Text = Altmis.BitisTarihi.ToString();
                LblRezDate.Text = DateTime.Now.ToString();
                LblRezUcret.Text = ((Altmis.BitisTarihi - Altmis.GirisTarihi).Days * Altmis.Ucret).ToString();
                LblUserName.Text = customer.UserName;
            }
            else if(RezType == "Tesvik")
            {
                LblGiris.Text = tesvik.GirisTarihi.ToString();
                LblCikis.Text = tesvik.BitisTarihi.ToString();
                LblRezDate.Text = DateTime.Now.ToString();
                LblRezUcret.Text = ((tesvik.BitisTarihi - tesvik.GirisTarihi).Days * tesvik.Ucret).ToString();
                LblUserName.Text = customer.UserName;
            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(RezType == "klasik")
            {
                cmd = new SqlCommand("INSERT INTO Reservation (rezTypeId,rezPrice,rezEntryDate,rezReleaseDate,rezDate,customerId,rezSumPrice) VALUES (@rezType,@rezPrice,@rezEntryDate,@rezReleaseDate,@rezDate,@customerId,@rezSumPrice)", conn);

                //DataBase.getInstance().executeNonQuery(String.Format("exec MakeReservation '{0}','{1}','{2}','{3}','{4}'", klasik.RezType, klasik.Ucret,klasik.GirisTarihi,klasik.BitisTarihi.ToString() , klasik.CustomerId));

                cmd.Parameters.AddWithValue("@rezType", klasik.RezType);
                cmd.Parameters.AddWithValue("@rezPrice", klasik.Ucret);
                cmd.Parameters.AddWithValue("@rezEntryDate", klasik.GirisTarihi);
                cmd.Parameters.AddWithValue("@rezReleaseDate", klasik.BitisTarihi);
                cmd.Parameters.AddWithValue("@rezDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@customerId", klasik.CustomerId);
                cmd.Parameters.AddWithValue("@rezSumPrice", LblRezUcret.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else if(RezType == "OnOdemeli")
            {
                cmd = new SqlCommand("INSERT INTO Reservation (rezTypeId,rezPrice,rezEntryDate,rezReleaseDate,rezDate,customerId,rezSumPrice) VALUES (@rezType,@rezPrice,@rezEntryDate,@rezReleaseDate,@rezDate,@customerId,@rezSumPrice)", conn);

                //DataBase.getInstance().executeNonQuery(String.Format("exec MakeReservation '{0}','{1}','{2}','{3}','{4}'", klasik.RezType, klasik.Ucret,klasik.GirisTarihi,klasik.BitisTarihi.ToString() , klasik.CustomerId));

                cmd.Parameters.AddWithValue("@rezType", onodemeli.RezType);
                cmd.Parameters.AddWithValue("@rezPrice", onodemeli.Ucret);
                cmd.Parameters.AddWithValue("@rezEntryDate", onodemeli.GirisTarihi);
                cmd.Parameters.AddWithValue("@rezReleaseDate", onodemeli.BitisTarihi);
                cmd.Parameters.AddWithValue("@rezDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@customerId", onodemeli.CustomerId);
                cmd.Parameters.AddWithValue("@rezSumPrice", LblRezUcret.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else if(RezType == "AltmisGun")
            {
                cmd = new SqlCommand("INSERT INTO Reservation (rezTypeId,rezPrice,rezEntryDate,rezReleaseDate,rezDate,customerId,rezSumPrice) VALUES (@rezType,@rezPrice,@rezEntryDate,@rezReleaseDate,@rezDate,@customerId,@rezSumPrice)", conn);

                //DataBase.getInstance().executeNonQuery(String.Format("exec MakeReservation '{0}','{1}','{2}','{3}','{4}'", klasik.RezType, klasik.Ucret,klasik.GirisTarihi,klasik.BitisTarihi.ToString() , klasik.CustomerId));

                cmd.Parameters.AddWithValue("@rezType", Altmis.RezType);
                cmd.Parameters.AddWithValue("@rezPrice", Altmis.Ucret);
                cmd.Parameters.AddWithValue("@rezEntryDate", Altmis.GirisTarihi);
                cmd.Parameters.AddWithValue("@rezReleaseDate", Altmis.BitisTarihi);
                cmd.Parameters.AddWithValue("@rezDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@customerId", Altmis.CustomerId);
                cmd.Parameters.AddWithValue("@rezSumPrice", LblRezUcret.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            else if(RezType == "Tesvik")
            {
                cmd = new SqlCommand("INSERT INTO Reservation (rezTypeId,rezPrice,rezEntryDate,rezReleaseDate,rezDate,customerId,rezSumPrice) VALUES (@rezType,@rezPrice,@rezEntryDate,@rezReleaseDate,@rezDate,@customerId,@rezSumPrice)", conn);

                //DataBase.getInstance().executeNonQuery(String.Format("exec MakeReservation '{0}','{1}','{2}','{3}','{4}'", klasik.RezType, klasik.Ucret,klasik.GirisTarihi,klasik.BitisTarihi.ToString() , klasik.CustomerId));

                cmd.Parameters.AddWithValue("@rezType", tesvik.RezType);
                cmd.Parameters.AddWithValue("@rezPrice", tesvik.Ucret);
                cmd.Parameters.AddWithValue("@rezEntryDate", tesvik.GirisTarihi);
                cmd.Parameters.AddWithValue("@rezReleaseDate", tesvik.BitisTarihi);
                cmd.Parameters.AddWithValue("@rezDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@customerId", tesvik.CustomerId);
                cmd.Parameters.AddWithValue("@rezSumPrice", LblRezUcret.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MusteriAnaMenu menu = new MusteriAnaMenu();
            menu.customer = customer;
            menu.Show();
            this.Hide();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
