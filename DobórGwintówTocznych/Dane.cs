using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    public class Dane
    {
        ////1. klasa dokladnosci?
        //public Dane(float skokGwintu, float dlugoscGwintuSruby, float dlugoscCzopaLozyskowego, int sredniaPredkoscObrotowa, List<ObciazenieRobocze> obciazenia, int zakladanyOkresUzytkowania)
        //{      
        //    SkokGwintu = skokGwintu;
        //    DlugoscGwintuSruby = dlugoscGwintuSruby; 
        //    DlugoscCzopaLozyskowego = dlugoscCzopaLozyskowego;
        //    SredniaPredkoscObrotowa = sredniaPredkoscObrotowa;
        //    ZakladanyOkresUzytkowania = zakladanyOkresUzytkowania;
        //    ObciazeniaRobocze = obciazenia;

        //}


        public Dane()
        {
            SkokGwintu = OdczytajInt(DaneKomunikaty.SkokGwintu);
            DlugoscGwintuSruby = OdczytajInt(DaneKomunikaty.DlugoscGwintu);
            DlugoscCzopaLozyskowego = OdczytajInt(DaneKomunikaty.DlugoscCzopa);
            SredniaPredkoscObrotowa = OdczytajInt(DaneKomunikaty.SredniaPredkoscObrotowa);
            ZakladanyOkresUzytkowania = OdczytajInt(DaneKomunikaty.OkresUzytkowania);

            int i = 0;

            do
            {
                var obc = new ObciazenieRobocze();
                ListaObciazeniaRobocze.Add(obc);
                Console.WriteLine("Podaj wartosc PropObciazenieRobocze");
                ListaObciazeniaRobocze[i].PropObciazenieRobocze = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("PropUdzialCzasowyObciazenia");
                ListaObciazeniaRobocze[i].PropUdzialCzasowyObciazenia = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Czy chcesz dodać kolejny zestaw danych? Jeśli nie kliknij przycisk End");
                ++i;
            }
            while (Console.ReadKey().Key != ConsoleKey.End);

        }

        private float skokGwintu;

        public float SkokGwintu
        {
            get { return skokGwintu; }
            set { if (value > 0) skokGwintu = value; }
        }

        private float dlugoscGwintuSruby;

        public float DlugoscGwintuSruby
        {
            get { return dlugoscGwintuSruby; }
            set { if (value > 0 && value < 12000) dlugoscGwintuSruby = value; }
        }

        private float dlugoscCzopaLozyskowego;

        public float DlugoscCzopaLozyskowego
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

      




        //K1 - nakretka pojedyncza z luzem osiowym, K2 - nakretka pojedyncza z napięciem wstępnym, K3 - nakrętka podwójna z napięciem wstępnym
        //enum TypNakretki
        //{
        //    K1 = 1, K2 = 2, K3 = 3
        //}

        public static int OdczytajInt(string komunikat)
        {
            Console.Write(komunikat);
            return Convert.ToInt32(Console.ReadLine());
        }

        // Dodac zapytanie o klase dokladnosci
        public static char OdczytajChar(string komunikat)
        {
            Console.Write(komunikat);
            return Convert.ToChar(Console.ReadLine().ToUpper());
        }

    }


    public static class DaneKomunikaty
    {
        public static string SkokGwintu { get { return "Proszę podać skok nominalny gwintu: "; } }
        public static string DlugoscGwintu { get { return "Proszę podać długość gwintu śruby: "; } }
        public static string DlugoscCzopa { get { return "Proszę podać długość czopa łozyskowego: "; } }
        public static string SredniaPredkoscObrotowa { get { return "Proszę podać średnią prędkość obrotową mechanizmu: "; } }
        public static string OkresUzytkowania { get { return "Proszę podać zakładany okres użytkowania: "; } }
        public static string ciezarStolu { get { return "Proszę podać cieżar stołu: "; } }
        public static string CiezarPrzedmiotu { get { return "Proszę podać ciężar przedmiotu: "; } }
        public static string przyspieszenie { get { return "Proszę podać przyspieszenie kątowe: "; } }
        public static string srednicaSilnika { get { return "Proszę podać średnicę silnika: "; } }
        public static string dlugoscSilnika { get { return "Proszę podać długość silnika: "; } }
        public static string srednicaG1 { get { return "Proszę podać średnicę koła przekładni G1: "; } }
        public static string srednicaG2 { get { return "Proszę podać średnicę koła przekładni G2: "; } }
        public static string szerokoscKola { get { return "Proszę podać szerokość kół zębatych w przekładni: "; } }
        public static string liczbaZebowG1 { get { return "Proszę podać liczbę zębów koła G1: "; } }
        public static string liczbaZebowG2 { get { return "Proszę podać liczbę zębów koła G2: "; } }
    }
}


