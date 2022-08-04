using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    class ObliczeniaPrzekladnia : DanePrzekladnia
    {
        private ObliczeniaGwintyToczne mechanizm;
        private MechanizmySrubowoToczne dobranyMechanizm;

        public ObliczeniaPrzekladnia(ObliczeniaGwintyToczne ogt, MechanizmySrubowoToczne dbr)
        {
            mechanizm = ogt;
            dobranyMechanizm = dbr;
        }


        public double momentNapedowySilnika = 0;
        public double momentTarciaNakretki = 0;
        public double napedNormalnySilnika = 0;
        public double bezwladnoscSilnika = 0;
        public double bezwladnoscKolaG1 = 0;
        public double bezwladnoscKolaG2 = 0;
        public double bezwladnoscPrzekladni = 0;
        public double bezwladnoscMechanizmu = 0;
        public double bezwladnoscObciazenia = 0;
        public double calkowitaBezwladnoscMechanizmu = 0;
        public double momentPrzyspieszeniaSilnika = 0;
        public double calkowityMomentSilnika = 0;
        public double mocNapedowaSilnika = 0;

        public void WykonajObliczenia()
        {
            ObliczObciazenieRobocze();
            ObliczMomentNapedowySilnika();
            ObliczMomentTarciaNakretki();
            ObliczCalkowityMomentSilnika();
            bezwladnoscSilnika = ObliczMomentBezwladnosci(SrednicaSilnika / 2, DlugoscSilnika);
            bezwladnoscKolaG1 = ObliczMomentBezwladnosci(SrednicaG1 / 2, SzerokoscKola);
            bezwladnoscKolaG2 = ObliczMomentBezwladnosci(SrednicaG2 / 2, SzerokoscKola);
            bezwladnoscPrzekladni = bezwladnoscKolaG1 + bezwladnoscKolaG2 * Math.Pow((LiczbaZebowG1 / LiczbaZebowG2), 2);
            bezwladnoscMechanizmu = ObliczMomentBezwladnosci(dobranyMechanizm.srednicaZnam / 2, mechanizm.dlugoscCalkowita);
            ObliczBezwlasnoscObciazenia();
            ObliczCalkowitaBezwladnoscMechanizmu();
            ObliczCalkowityMomentSilnika();
            ObliczMocNapedowaSilnika();
        }
        public double ObliczObciazenieRobocze()
        {
            obciazenieRobocze = Convert.ToInt32( mechanizm.obciazenie + wspTarciaProwadnicy * (CiezarPrzedmiotu + CiezarStolu));
            return obciazenieRobocze;
        }

        public double ObliczNormalnyMomentNapedowySilnika()
        {
            napedNormalnySilnika = (obciazenieRobocze * mechanizm.SkokGwintu) / (2000 * Math.PI * wspolczynnikSprawnosci);
            return napedNormalnySilnika;
        }

        public double ObliczMomentTarciaNakretki()
        {
            momentTarciaNakretki = (wspTarciaProwadnicy * mechanizm.naprezenie * mechanizm.SkokGwintu) / (2000 * Math.PI);
            return momentTarciaNakretki;
        }

        public double ObliczMomentNapedowySilnika()
        {
            momentNapedowySilnika = (napedNormalnySilnika + momentTarciaNakretki + momentLozyska) * (LiczbaZebowG1 / LiczbaZebowG2);
            return momentNapedowySilnika;
        }

        public double ObliczMomentBezwladnosci(double promien, double dlugosc)
        {
            double wynik;
            wynik = 0.5 * Math.PI * ciezarWlasciwyStali * Math.Pow(promien, 4) * dlugosc * Math.Pow(10, -15);
            return wynik;
        }
        public double ObliczBezwlasnoscObciazenia()
        {
            bezwladnoscObciazenia = (CiezarPrzedmiotu + CiezarStolu) * (dobranyMechanizm.skokGwintu / (2000 * Math.PI)) * Math.Pow(LiczbaZebowG1 / LiczbaZebowG2, 2);
            return bezwladnoscObciazenia;
        }
        public double ObliczCalkowitaBezwladnoscMechanizmu()
        {
            calkowitaBezwladnoscMechanizmu = bezwladnoscSilnika + bezwladnoscPrzekladni + bezwladnoscMechanizmu + bezwladnoscObciazenia;
            return calkowitaBezwladnoscMechanizmu;
        }

        public double ObliczCalkowityMomentSilnika()
        {
            calkowityMomentSilnika = (calkowitaBezwladnoscMechanizmu * Przyspieszenie) + momentNapedowySilnika;
            return calkowityMomentSilnika;
        }
        public double ObliczMocNapedowaSilnika()
        {
            mocNapedowaSilnika = (2 * calkowityMomentSilnika * mechanizm.SredniaPredkoscObrotowa) / 9.55;
            return mocNapedowaSilnika;
        }
    }
}
