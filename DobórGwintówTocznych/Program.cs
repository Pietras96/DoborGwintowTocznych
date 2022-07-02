using System;

namespace DobórGwintówTocznych
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("APLIKACJA DOBORU GWINTÓW TOCZNYCH");
            Console.Write("Proszę wybrać sposób łożyskowania (11 - pojedyncze łożyskowanie, 22 - podwójne łożyskowanie): ");
            int idLoz = Convert.ToInt32(Console.ReadLine());
            int wspLozyskowania = ParametryObliczeniowe.slowWspLozyskowania[idLoz];
            Dane.UtworzDane();








        }

        
    }
}
