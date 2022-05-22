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
    public partial class OtelBilgileri : Form
    {
        public OtelBilgileri()
        {
            InitializeComponent();
        }

        private void OtelBilgileri_Load(object sender, EventArgs e)
        {
         bunifuCustomDataGrid1.DataSource =    DataBase.getInstance().executeDataTable("SELECT * FROM TableHotel");
        }
    }
}
