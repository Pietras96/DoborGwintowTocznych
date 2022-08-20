using System;
using System.Text;


namespace DobórGwintówTocznych
{
    public class ObliczeniaGwintyToczne
    {
        public double obciazenie = 0;
        public double naprezenie = 0;
        public double dlugoscCalkowita = 0;
        public int okresUzytk = 0;
        public int nosnoscDynamiczna = 0;
        public int silaOsiowa =0;
        public double sztywnoscSruby = 0;
        public double sztywnoscNakretki = 0;
        public double srednicaRdzenia = 0;
        public int dlSrubyBezPodpory = 0;
        public double sztywnoscMechanizmu = 0;
        public MechanizmySrubowoToczne dobranyMechanizm;

        public Dane Dane { get; }

        public ObliczeniaGwintyToczne(Dane dane)
        {
            Dane = dane;
        }
        public void WykonajObliczenia()
        {
            ObliczDlugoscCalkowitaSruby();
            ObliczObciazenieRobocze();
            ObliczNaprezenieWstepne(); 
            ObliczOkresUzytkowania();
            ObliczSileOsiowa();
            ObliczNosnoscDynamiczna();
        }

        
        public double ObliczDlugoscCalkowitaSruby()
        {
            dlugoscCalkowita = Dane.DlugoscGwintuSruby + (2 * Dane.DlugoscCzopaLozyskowego);
            return dlugoscCalkowita;
        }

        public double ObliczObciazenieRobocze()
        {
            for (int i = 0; i < Dane.ListaObciazeniaRobocze.Count; i++)
            {
                obciazenie += Math.Pow(Dane.ListaObciazeniaRobocze[i].PropObciazenieRobocze,3) * Dane.ListaObciazeniaRobocze[i].PropUdzialCzasowyObciazenia/100 * Math.Pow(1.3,3);
                
            }
            obciazenie = Math.Ceiling(Math.Pow(obciazenie, (double)1 / 3));
            return obciazenie;
        }

        public double ObliczNaprezenieWstepne()
        {
            naprezenie = Math.Ceiling(obciazenie / 2.8);
            return naprezenie;
        }
        public int ObliczOkresUzytkowania()
        {
            okresUzytk = Dane.ZakladanyOkresUzytkowania * Dane.SredniaPredkoscObrotowa * 60;
            return okresUzytk;
        }

        public int ObliczSileOsiowa()
        {
            silaOsiowa = Convert.ToInt32(obciazenie + naprezenie);
            return silaOsiowa;
        }

        public int ObliczNosnoscDynamiczna()
        {
            nosnoscDynamiczna = Convert.ToInt32(silaOsiowa * Math.Pow(okresUzytk / Math.Pow(10, 6), (double)1/3)); 
            return nosnoscDynamiczna;
        }

        public double ObliczSredniceRdzenia()
        {
            srednicaRdzenia = dobranyMechanizm.srednicaZnam - dobranyMechanizm.sredKulki;
            return srednicaRdzenia;
        }

        public double ObliczSztywnoscSruby()
        {
            sztywnoscSruby = 168 * (Math.Pow(srednicaRdzenia, 2) / Dane.DlugoscGwintuSruby);
            return sztywnoscSruby;
        }

        public double ObliczSztywnoscNakretki()
        {
            sztywnoscNakretki = 0.8 * dobranyMechanizm.sztywnosc * Math.Pow(naprezenie / (0.1 * dobranyMechanizm.nosnoscDynamiczna), (double)1/3);
            return sztywnoscNakretki;
        }

        public double ObliczSztywnoscMechanizmu()
        {
            ObliczSredniceRdzenia();
            ObliczSztywnoscNakretki();
            ObliczSztywnoscSruby();
            sztywnoscMechanizmu = (1.0 / sztywnoscSruby) + (1.0 / sztywnoscNakretki);
            return Math.Round((1.0 / sztywnoscMechanizmu),2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("Wyniki Obliczeń: ");
            sb.AppendLine($"    długość całkowita śruby = {dlugoscCalkowita} [mm]");
            sb.AppendLine($"    obciążenie robocze = {obciazenie} [N]");
            sb.AppendLine($"    naprężenie wstępne = {naprezenie} [N]");
            sb.AppendLine($"    zakładany okres użytkowania {string.Format("{0:#.##E+00}", okresUzytk)} [obr]");
            sb.AppendLine($"    nośność dynamiczna: {nosnoscDynamiczna} [N]");
            return sb.ToString();
        }
    }
}
