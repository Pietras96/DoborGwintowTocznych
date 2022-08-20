using System;
using System.Collections.Generic;

namespace DobórGwintówTocznych
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("APLIKACJA DOBORU GWINTÓW TOCZNYCH");
            Console.WriteLine("Typ nakrętki: FSV");

            // Moduł pobierający dane od użytkownika
            var dane = new Dane();
            dane.PobierzDane();

            //Moduł wykonujący obliczenia Gwintów Tocznych
            var obliczeniaGwintyToczne = new ObliczeniaGwintyToczne(dane);
            obliczeniaGwintyToczne.WykonajObliczenia();
            Console.WriteLine(obliczeniaGwintyToczne);

            //Moduł dobierający mechanizm śrubowo-toczny z katalogu
            var mechanizm = new DoborMechanizmuSrubowoTocznego(obliczeniaGwintyToczne);
            var dobranyMechanizm = mechanizm.WstepnyDoborMechanizmu();
            obliczeniaGwintyToczne.dobranyMechanizm = dobranyMechanizm;
            obliczeniaGwintyToczne.ObliczSztywnoscMechanizmu();
            dobranyMechanizm = mechanizm.KoncowyDoborMechanizmu();
            Console.WriteLine(mechanizm);

            //Moduł wykonujący obliczenia oraz dobierający przekładnię do mechanizmu śrubowo-tocznego
            var danePrzekladnia = new DanePrzekladnia();
            danePrzekladnia.PobierzDane();
            var obliczeniaPrzekladnia = new ObliczeniaPrzekladnia(dane, danePrzekladnia, obliczeniaGwintyToczne, dobranyMechanizm);
            obliczeniaPrzekladnia.WykonajObliczenia();
            Console.WriteLine(obliczeniaPrzekladnia);
        }
    }
}
