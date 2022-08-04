using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    public class ObliczeniaGwintyToczne: Dane
    {
        // Double, float czy decimal?
       
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


        public ObliczeniaGwintyToczne() : base()
        {

        }
        public void WykonajObliczenia()
        {
            ObliczDlugoscCalkowitaSruby();
            ObliczObciazenieRobocze();
            ObliczNaprezenieWstepne();
            ObliczOkresUzytkowania();
            ObliczSileOsiowa();
            ObliczNosnoscDynamiczna();
            Console.WriteLine($"Wyniki Obliczeń: \n długość całkowita śruby = {dlugoscCalkowita} [mm] \n obciążenie robocze = {obciazenie} [N] \n naprężenie wstępne = {naprezenie} [N]");
            Console.WriteLine($" zakładany okres użytkowania {string.Format("{0:#.##E+00}", okresUzytk)} [h] \n nośność dynamiczna: {nosnoscDynamiczna} [N]");
        }

        
        public double ObliczDlugoscCalkowitaSruby()
        {
            dlugoscCalkowita = DlugoscGwintuSruby + (2 * DlugoscCzopaLozyskowego);
            return dlugoscCalkowita;
        }
        //Przemek - jak pobrać dane z listy w klasie Program?
        public double ObliczObciazenieRobocze()
        {
            for (int i = 0; i < ListaObciazeniaRobocze.Count; i++)
            {
                obciazenie += Math.Pow(ListaObciazeniaRobocze[i].PropObciazenieRobocze,3) * ListaObciazeniaRobocze[i].PropUdzialCzasowyObciazenia/100 * Math.Pow(1.3,3);
                
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
            okresUzytk = ZakladanyOkresUzytkowania * SredniaPredkoscObrotowa * 60;
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
            sztywnoscSruby = 168 * (Math.Pow(srednicaRdzenia, 2) / DlugoscGwintuSruby);
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
            sztywnoscMechanizmu = (double)(1 / sztywnoscSruby) + (double)(1 / sztywnoscNakretki);
            return (double)(1 / sztywnoscMechanizmu);
        }



    }
}
