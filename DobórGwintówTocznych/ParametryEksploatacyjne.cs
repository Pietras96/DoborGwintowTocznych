using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    class ParametryEksploatacyjne
    {
        public int klasaDokladnosciGwintu;
        public float dopuszczalnyLuzOsiowy = 0.02f;
        public float temperaturaPracy;
        public int maksymalnaPredkoscObrotowa;

        // do sprawdzenia
        public float momentOporowyNapieciaWstepnego;
        public float sztywnosc;
       

        enum AgresywnoscSrodowiska
        {
            Neutralne = 1, Agresywne = 1
        }
        enum RodzajSmarowania
        {
            Smar_Staly = 1, Olej = 2
        }
        

    }
}
