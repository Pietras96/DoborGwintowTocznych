using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    class ObliczeniaGwintyToczne: Dane
    {
        // Double, float czy decimal?
        double obciazenie = 0;
        double naprezenie = 0;
        double dlugoscCalkowita = 0;
        int okresUzytk = 0;
        int nosnoscDyn = 0;
        int silaOsiowa=0;
        double sztywnoscSruby = 0;
        double sztywnoscNakretki = 0;
        double srednicaRdzenia = 0;
        int dlSrubyBezPodpory = 0;


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
            Console.WriteLine($" zakładany okres użytkowania {string.Format("{0:#.##E+00}", okresUzytk)} [h] \n nośność dynamiczna: {nosnoscDyn} [N]");
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
            nosnoscDyn = Convert.ToInt32((double)silaOsiowa * Math.Pow(okresUzytk / Math.Pow(10, 6), (double)1/3)); 
            return nosnoscDyn;
        }

        public double ObliczSztywnoscSruby()
        {
            sztywnoscSruby = 168 * ()
            return sztywnoscSruby;
        }

        public double ObliczSztywnoscNakretki()
        {
            return sztywnoscNakretki;
        }



    }
}
