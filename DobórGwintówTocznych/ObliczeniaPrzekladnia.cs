using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    class ObliczeniaPrzekladnia: ObliczeniaGwintyToczne
    {
        private Dane dane;
        private MechanizmySrubowoToczne dobranyMechanizm;
        private ObliczeniaGwintyToczne obliczeniaGT;
        private DanePrzekladnia danePrzekladnia;


        public ObliczeniaPrzekladnia(Dane dane, DanePrzekladnia danePrzekladnia, ObliczeniaGwintyToczne ogt, MechanizmySrubowoToczne dbr) : base(dane)
        {
            this.dane = dane;
            this.danePrzekladnia = danePrzekladnia;
            this.obliczeniaGT = ogt;
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
        public double calkowityMomentSilnika = 0;
        public double mocNapedowaSilnika = 0;
        public double obciazenieRobocze = 0;
        public double silaOsiowa = 0;
        public double maxMomentNapedowy = 0;
        public double kwadratPrzelozenia => Math.Pow((double)danePrzekladnia.LiczbaZebowG1 / (double)danePrzekladnia.LiczbaZebowG2, 2);

        public void WykonajObliczenia()
        {
            ObliczObciazenieRobocze();
            ObliczOsiowaSilePosuwowa();
            ObliczNormalnyMomentNapedowySilnika();
            ObliczMomentTarciaNakretki();
            ObliczMomentNapedowySilnika();
            bezwladnoscSilnika = ObliczMomentBezwladnosci(danePrzekladnia.SrednicaSilnika / 2, danePrzekladnia.DlugoscSilnika);
            bezwladnoscKolaG1 = ObliczMomentBezwladnosci(danePrzekladnia.SrednicaG1 / 2, danePrzekladnia.SzerokoscKola);
            bezwladnoscKolaG2 = ObliczMomentBezwladnosci(danePrzekladnia.SrednicaG2 / 2, danePrzekladnia.SzerokoscKola);
            ObliczBezwladnoscPrzekladni();
            bezwladnoscMechanizmu = ObliczMomentBezwladnosci(dobranyMechanizm.srednicaZnam / 2, obliczeniaGT.dlugoscCalkowita)*kwadratPrzelozenia;
            ObliczBezwlasnoscObciazenia();
            ObliczCalkowitaBezwladnoscMechanizmu();
            ObliczCalkowityMomentSilnika();
            ObliczMocNapedowaSilnika();
        }
        public double ObliczObciazenieRobocze()
        {
           obciazenieRobocze = obliczeniaGT.obciazenie + DanePrzekladnia.wspTarciaProwadnicy * (danePrzekladnia.CiezarPrzedmiotu + danePrzekladnia.CiezarStolu);
            return obciazenieRobocze;
        }

        public double ObliczOsiowaSilePosuwowa()
        {
            silaOsiowa = Math.Round((danePrzekladnia.CiezarPrzedmiotu + danePrzekladnia.CiezarStolu) * 10 / 2.8, 2); 
            return silaOsiowa;
        }

        public double ObliczNormalnyMomentNapedowySilnika()
        {
            napedNormalnySilnika = Math.Round((obciazenieRobocze * dane.SkokGwintu) / (2000 * Math.PI * DanePrzekladnia.wspolczynnikSprawnosci),2);
            return napedNormalnySilnika;
        }

        public double ObliczMomentTarciaNakretki()
        {
            momentTarciaNakretki = Math.Round((DanePrzekladnia.wspTarciaProwadnicy * silaOsiowa * dane.SkokGwintu) / (2000 * Math.PI),2);
            return momentTarciaNakretki;
        }
        
        public double ObliczMomentNapedowySilnika()
        {
            momentNapedowySilnika = Math.Round((napedNormalnySilnika + momentTarciaNakretki + DanePrzekladnia.momentLozyska) * danePrzekladnia.LiczbaZebowG1 / danePrzekladnia.LiczbaZebowG2, 2);
            return momentNapedowySilnika;
        }

        public double ObliczMomentBezwladnosci(double promien, double dlugosc)
        {
            double wynik;
            wynik = 0.5 * Math.PI * DanePrzekladnia.ciezarWlasciwyStali * Math.Pow(promien, 4) * dlugosc * Math.Pow(10, -15);
            return wynik;
        }
        public double ObliczBezwlasnoscObciazenia()
        {
            bezwladnoscObciazenia = (danePrzekladnia.CiezarPrzedmiotu + danePrzekladnia.CiezarStolu) * Math.Pow(dobranyMechanizm.skokGwintu / (2000 * Math.PI),2) * kwadratPrzelozenia;
            return bezwladnoscObciazenia;
        }
        public double ObliczCalkowitaBezwladnoscMechanizmu()
        {
            calkowitaBezwladnoscMechanizmu = bezwladnoscSilnika + bezwladnoscPrzekladni + bezwladnoscMechanizmu + bezwladnoscObciazenia;
            return calkowitaBezwladnoscMechanizmu;
        }

        public double ObliczCalkowityMomentSilnika()
        {
            calkowityMomentSilnika = Math.Round((calkowitaBezwladnoscMechanizmu * danePrzekladnia.Przyspieszenie) + momentNapedowySilnika,2);
            maxMomentNapedowy = Math.Round(2 * calkowityMomentSilnika, 2);
            return calkowityMomentSilnika;
        }
        public double ObliczMocNapedowaSilnika()
        {
            mocNapedowaSilnika = Math.Ceiling((2 * calkowityMomentSilnika * dane.SredniaPredkoscObrotowa) / 9.55);
            return mocNapedowaSilnika;
        }

        public double ObliczBezwladnoscPrzekladni()
        {
            bezwladnoscPrzekladni = bezwladnoscKolaG1 + bezwladnoscKolaG2 * kwadratPrzelozenia ;
            return bezwladnoscPrzekladni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("Specyfikacja silnika: ");
            sb.AppendLine($"    Typ silnika: silnik prądu stałego z momentem znamionowym > {1.5 * momentNapedowySilnika} [Nm]");
            sb.AppendLine($"    Maksymalny moment silnika: > {Math.Round(1.5 * maxMomentNapedowy), 1} [Nm]");
            sb.AppendLine($"    Moc minimalna: >{mocNapedowaSilnika} [W]");
            sb.AppendLine($"    Moment minimalny: >{calkowityMomentSilnika} [Nm]");
            sb.AppendLine($"    Prędkość obrotowa: >={dane.SredniaPredkoscObrotowa} [obr/min]");
            sb.AppendLine($"    Moment bezwladnosci silnika: {string.Format("{0:#.##E+00}", bezwladnoscSilnika)} [kgm^2]");
            return sb.ToString();
        }
    }
}
