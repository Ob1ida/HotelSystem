using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel
{
    public class KlasikRez 
    {
        public DateTime GirisTarihi;
        public DateTime BitisTarihi;
        public int Ucret;
        
        public int CustomerId { get; set; }
        public int RezType { get; set; } = 1;
        public Odeme odeme;
        public string RezYap()
        {
            odeme = new Odeme();
            return "klasik";
        }



        public void UcretHesapla()
        {
           
              Ucret = (int)DataBase.getInstance().executeScalar("SELECT TabanFiyat FROM RoomsPrice");
            
            
        }
    }
}
