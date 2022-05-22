using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel
{
    public class AltmisGunOnceRez
    {
        public DateTime GirisTarihi;
        public DateTime BitisTarihi;
        public int RezType { get; set; } = 3;
        public int Ucret;
        public int CustomerId { get; set; }
        public int RezID;


        public string RezYap()
        {
            return "";
        }


        public int UcretHesapla()
        {
            Ucret = (int)DataBase.getInstance().executeScalar("SELECT TabanFiyat FROM RoomsPrice")*85/100;
            return Ucret;
        }
    }
}
