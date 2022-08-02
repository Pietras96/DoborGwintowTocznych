using System;
using System.Collections.Generic;

namespace DobórGwintówTocznych
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("APLIKACJA DOBORU GWINTÓW TOCZNYCH");
            //Console.Write("Proszę wybrać sposób łożyskowania (11 - pojedyncze łożyskowanie, 22 - podwójne łożyskowanie): ");
            //int idLoz = Convert.ToInt32(Console.ReadLine());
            //int wspLozyskowania = ParametryObliczeniowe.slowWspLozyskowania[idLoz];
            ObliczeniaGwintyToczne ogt = new ObliczeniaGwintyToczne();
            ogt.WykonajObliczenia();
            var mechanizm = new DoborMechanizmuSrubowoTocznego(ogt);
            var wynik = mechanizm.WstepnyDoborMechanizmu();
            ogt.dobranyMechanizm = wynik;
            var sztywnosc = ogt.ObliczSztywnoscMechanizmu();
            wynik = mechanizm.KoncowyDoborMechanizmu();
            Console.WriteLine(mechanizm);
            Console.WriteLine("ELO");



        }
    }
}
