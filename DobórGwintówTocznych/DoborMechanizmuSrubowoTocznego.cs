using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    public class DoborMechanizmuSrubowoTocznego : IDobor
    {
        public DoborMechanizmuSrubowoTocznego(ObliczeniaGwintyToczne obliczenia)
        {
            Obliczenia = obliczenia;
        }

        private MechaniznySrubowoToczne dobranyMechanizm { get; set; }

        public MechaniznySrubowoToczne WstepnyDoborMechanizmu()
        {
            dobranyMechanizm = ListaMechanizmowFSV.Select(x => x).Where(x => x.skokGwintu == Obliczenia.SkokGwintu && Obliczenia.nosnoscDynamiczna < x.nosnoscDynamiczna).FirstOrDefault();
            return dobranyMechanizm;
        }
        public MechaniznySrubowoToczne KoncowyDoborMechanizmu()
        {
            dobranyMechanizm = ListaMechanizmowFSV.Select(x => x).Where(x => x.skokGwintu == Obliczenia.SkokGwintu && Obliczenia.nosnoscDynamiczna < x.nosnoscDynamiczna && Obliczenia.sztywnoscMechanizmu < x.sztywnosc).FirstOrDefault();
            return dobranyMechanizm;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Dobrano mechanizm: ");
            sb.AppendLine($"model: {dobranyMechanizm.model}, srednica znamionowa: {dobranyMechanizm.srednicaZnam} [mm]");
            sb.AppendLine($"skok gwintu: {dobranyMechanizm.skokGwintu} [mm], srednica kulki: {dobranyMechanizm.sredKulki} [mm]");
            sb.AppendLine($"obieg: {dobranyMechanizm.obiegi}, sztywność mechanizmu: {dobranyMechanizm.sztywnosc} [N/um]");
            sb.AppendLine($"nośność dynamiczna: {dobranyMechanizm.nosnoscDynamiczna} [N]");
            return sb.ToString();
        }

        
        public List<MechaniznySrubowoToczne> ListaMechanizmowFSV = new List<MechaniznySrubowoToczne>
        {
            new MechaniznySrubowoToczne {model = "16-5B1", srednicaZnam = 16, skokGwintu = 5, sredKulki = 2.381, obiegi = "2,5x1", sztywnosc = 160, nosnoscDynamiczna = 7630},
            new MechaniznySrubowoToczne {model = "16-10B1", srednicaZnam = 16, skokGwintu = 10, sredKulki = 3.175, obiegi = "2,5x1", sztywnosc = 160, nosnoscDynamiczna = 7630},
            new MechaniznySrubowoToczne {model = "20-5B1", srednicaZnam = 20, skokGwintu = 5, sredKulki = 3.175, obiegi = "2,5x1", sztywnosc = 190, nosnoscDynamiczna = 8370},
            new MechaniznySrubowoToczne {model = "20-20A1", srednicaZnam = 20, skokGwintu = 20, sredKulki = 3.969, obiegi = "1,5x1", sztywnosc = 130, nosnoscDynamiczna = 7190},
            new MechaniznySrubowoToczne {model = "25-5B2", srednicaZnam = 25, skokGwintu = 5, sredKulki = 3.175, obiegi = "2,5x2", sztywnosc = 460, nosnoscDynamiczna = 17040},
            new MechaniznySrubowoToczne {model = "25-10B1", srednicaZnam = 25, skokGwintu = 10, sredKulki = 4.763, obiegi = "2,5x1", sztywnosc = 250, nosnoscDynamiczna = 15920},
            new MechaniznySrubowoToczne {model = "25-16B1", srednicaZnam = 25, skokGwintu = 16, sredKulki = 4.763, obiegi = "2,5x1", sztywnosc = 280, nosnoscDynamiczna = 15920},
        };

        public ObliczeniaGwintyToczne Obliczenia { get; }
    }
}
