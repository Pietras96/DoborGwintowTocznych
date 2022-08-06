using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    public class Dane
    {
        private double skokGwintu;

        public double SkokGwintu
        {
            get { return skokGwintu; }
            set { if (value > 0) skokGwintu = value; }
        }

        private double dlugoscGwintuSruby;

        public double DlugoscGwintuSruby
        {
            get { return dlugoscGwintuSruby; }
            set { if (value > 0 && value < 12000) dlugoscGwintuSruby = value; }
        }

        private double dlugoscCzopaLozyskowego;

        public double DlugoscCzopaLozyskowego
        {
            get { return dlugoscCzopaLozyskowego; }
            set { if (value > 0) dlugoscCzopaLozyskowego = value; }
        }
        private int sredniaPredkoscObrotowa = 1000;

        public int SredniaPredkoscObrotowa
        {
            get { return sredniaPredkoscObrotowa; }
            set { if (value > 0) sredniaPredkoscObrotowa = value; }
        }

        private int zakladanyOkresUzytkowania = 2000;

        public int ZakladanyOkresUzytkowania
        {
            get { return zakladanyOkresUzytkowania; }
            set { if (value > 0) zakladanyOkresUzytkowania = value; }
        }

        public string typNakretki { get; } = "FSV";

        public List<ObciazenieRobocze> ListaObciazeniaRobocze = new List<ObciazenieRobocze>();


        public void PobierzDane()
        {
            SkokGwintu = 10;
            DlugoscGwintuSruby = 600;
            DlugoscCzopaLozyskowego = 60;
            SredniaPredkoscObrotowa = 1000;
            ZakladanyOkresUzytkowania = 2000;
            //SkokGwintu = PobierzDane(DaneKomunikaty.SkokGwintu);
            //DlugoscGwintuSruby = PobierzDane(DaneKomunikaty.DlugoscGwintu);
            //DlugoscCzopaLozyskowego = PobierzDane(DaneKomunikaty.DlugoscCzopa);
            //SredniaPredkoscObrotowa = PobierzDane(DaneKomunikaty.SredniaPredkoscObrotowa);
            //ZakladanyOkresUzytkowania = PobierzDane(DaneKomunikaty.OkresUzytkowania);

            int i = 0;
            bool status = true;

            while(status)
            {
                var przycisk = Console.ReadKey().Key;
                if (przycisk == ConsoleKey.Enter)
                {
                    status = true;
                    var obc = new ObciazenieRobocze();
                    ListaObciazeniaRobocze.Add(obc);
                    Console.WriteLine("Podaj wartosc PropObciazenieRobocze");
                    ListaObciazeniaRobocze[i].PropObciazenieRobocze = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("PropUdzialCzasowyObciazenia");
                    ListaObciazeniaRobocze[i].PropUdzialCzasowyObciazenia = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Czy chcesz dodać kolejny zestaw danych? Jeśli nie kliknij przycisk End");
                    ++i;
                }
                else if(przycisk == ConsoleKey.End){
                    status = false;
                }
            }

        }
        public static int PobierzDane(string komunikat)
        {
            Console.Write(komunikat);
            return Convert.ToInt32(Console.ReadLine());
        }


    }
}


