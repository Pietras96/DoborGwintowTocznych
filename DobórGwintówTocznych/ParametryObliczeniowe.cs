using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    public static class ParametryObliczeniowe
    {
        public static List<KlasaDokladnosci> klasyDokladnosci = new List<KlasaDokladnosci>
        {
            new KlasaDokladnosci {srednicaZewnetrzna = 10, dlugoscMechanizmu = 300, klasaDokladnosci = "C0"},
            new KlasaDokladnosci {srednicaZewnetrzna = 10, dlugoscMechanizmu = 400, klasaDokladnosci = "C1"},
            new KlasaDokladnosci {srednicaZewnetrzna = 12, dlugoscMechanizmu = 400, klasaDokladnosci = "C0"},
            new KlasaDokladnosci {srednicaZewnetrzna = 12, dlugoscMechanizmu = 500, klasaDokladnosci = "C1"},
            new KlasaDokladnosci {srednicaZewnetrzna = 16, dlugoscMechanizmu = 600, klasaDokladnosci = "C0"},
            new KlasaDokladnosci {srednicaZewnetrzna = 16, dlugoscMechanizmu = 720, klasaDokladnosci = "C1"},
        };
        public static Dictionary<int, int> slowWspLozyskowania = new Dictionary<int, int>()
        {
            {11, 10*(int)Math.Pow(10, 3)},
            {22, 40*(int)Math.Pow(10, 3)}
        };
        public static Dictionary<char, string> slowKierZwoju = new Dictionary<char, string>()
        {
            {'L', "Lewy"},
            {'P', "Prawy"}
        };

    }
}
