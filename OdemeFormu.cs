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
    public partial class OdemeFormu : Form
    {
       public KlasikRez klasik = new KlasikRez();
       public Customer customer = new Customer();
        public OnOdemeliRez onodemeli = new OnOdemeliRez();
        public TesvikRez tesvik = new TesvikRez();
       public string RezType;

        public OdemeFormu()
        {
            InitializeComponent();
        }

        private void OdemeFormu_Load(object sender, EventArgs e)
        {
            MessageBox.Show(tesvik.GirisTarihi.ToString());
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            
            DataBase.getInstance().executeNonQuery(String.Format("INSERT INTO Payment (customerId,customerCvc,customerCardNumber) VALUES ('{0}','{1}','{2}') ",customer.CustomerId, textBox4.Text, textBox2.Text));

            if(RezType == "klasik")
            {
                OnayFormu onay = new OnayFormu();
                onay.klasik = klasik;
                onay.customer = customer;
                onay.RezType = RezType;
                onay.Show();
                this.Hide();
            }
            else if(RezType == "OnOdemeli")
            {
                OnayFormu onay = new OnayFormu();
                onay.onodemeli = onodemeli;
                onay.customer = customer;
                onay.RezType = RezType;
                onay.Show();
                this.Hide();
            }
            else if(RezType == "Tesvik")
            {
                OnayFormu onay = new OnayFormu();
                MessageBox.Show(tesvik.GirisTarihi.ToString());
                onay.tesvik = tesvik;
                onay.customer = customer;
                onay.RezType = RezType;
                onay.Show();
                this.Hide();
            }

        }
    }
}
