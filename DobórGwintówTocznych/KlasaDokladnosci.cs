using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    public class KlasaDokladnosci
    {
        public int srednicaZewnetrzna { get; set; }
        public string klasaDokladnosci { get; set; }
        public int dlugoscMechanizmu { get; set; }

        public static List<KlasaDokladnosci> klasyDokladnosci = new List<KlasaDokladnosci>
        {
            new KlasaDokladnosci {srednicaZewnetrzna = 10, dlugoscMechanizmu = 300, klasaDokladnosci = "C0"},
            new KlasaDokladnosci {srednicaZewnetrzna = 10, dlugoscMechanizmu = 400, klasaDokladnosci = "C1"},
            new KlasaDokladnosci {srednicaZewnetrzna = 12, dlugoscMechanizmu = 400, klasaDokladnosci = "C0"},
            new KlasaDokladnosci {srednicaZewnetrzna = 12, dlugoscMechanizmu = 500, klasaDokladnosci = "C1"},
            new KlasaDokladnosci {srednicaZewnetrzna = 16, dlugoscMechanizmu = 600, klasaDokladnosci = "C0"},
            new KlasaDokladnosci {srednicaZewnetrzna = 16, dlugoscMechanizmu = 720, klasaDokladnosci = "C1"},
        };
    }
}
