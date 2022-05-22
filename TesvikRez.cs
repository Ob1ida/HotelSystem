using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//حساب مجموع الغرف ب التريغر--
namespace Otel
{
    public class TesvikRez : KlasikRez
    {

        
        public void Indirim()
        {
            Ucret = Ucret * 80 / 100;
        }
    }
}
