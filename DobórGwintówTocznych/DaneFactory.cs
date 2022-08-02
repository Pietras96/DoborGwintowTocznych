using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    public class DaneFactory
    {
        public static Dane UtworzDane()
        {
            var dane = new Dane();

            //dane.SkokGwintu = OdczytajInt(DaneKomunikaty.SkokGwintu);
            //dane.DlugoscGwintuSruby = OdczytajInt(DaneKomunikaty.DlugoscGwintu);
            //dane.DlugoscCzopaLozyskowego = OdczytajInt(DaneKomunikaty.DlugoscCzopa);
            dane.SredniaPredkoscObrotowa = OdczytajInt(DaneKomunikaty.SredniaPredkoscObrotowa);
            dane.ZakladanyOkresUzytkowania = OdczytajInt(DaneKomunikaty.OkresUzytkowania);

            int i = 0;
            
            do
            {
                var obc = new ObciazenieRobocze();
                dane.ListaObciazeniaRobocze.Add(obc);
                Console.WriteLine("Podaj wartosc PropObciazenieRobocze");
                dane.ListaObciazeniaRobocze[i].PropObciazenieRobocze = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("PropUdzialCzasowyObciazenia");
                dane.ListaObciazeniaRobocze[i].PropUdzialCzasowyObciazenia = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Czy chcesz dodać kolejny zestaw danych? Jeśli nie kliknij przycisk End");
                ++i;
            }
            while (Console.ReadKey().Key != ConsoleKey.End);

            return dane;
        }

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
}
