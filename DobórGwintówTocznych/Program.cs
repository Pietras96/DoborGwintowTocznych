using System;

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
            //Dane.UtworzDane();


            Doo(out int d);
            int d2 = 3;
            Dooo(ref d2);
            Console.WriteLine(d);
            Console.WriteLine(d2);

            Int32.TryParse("10", out int c);
            Console.WriteLine(c);

        }

        static void Doo(out int cos)
        {
            cos = 4;
        }

        static void Dooo(ref int cos)
        {
            cos = 5;
        }


    }
}
