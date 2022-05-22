using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel
{
    public class OnOdemeliRez
    {
        public DateTime GirisTarihi;
        public DateTime BitisTarihi;
        public int CustomerId { get; set; }
        public int Ucret;
        public int RezID;
        public int RezType { get; set; } = 2;
        public string RezYap()
        {
            return "";
        }



        public int UcretHesapla()
        {
            Ucret = (int)DataBase.getInstance().executeScalar("SELECT TabanFiyat FROM RoomsPrice") * 75 / 100;
            return Ucret;
        }

    }
}
