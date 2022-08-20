using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    class DanePrzekladnia: Dane
    {
        public const double wspTarciaProwadnicy = 0.2;
        public const double momentLozyska = 0.1;
        public const double wspolczynnikSprawnosci = 0.8;
        public const double ciezarWlasciwyStali = 7850;

        public double silaOsiowa { get; set; }


        private double ciezarStolu;

        public double CiezarStolu
        {
            get { return ciezarStolu; }
            set { if (value > 0) ciezarStolu = value; }
        }

        private double ciezarPrzedmiotu;

        public double CiezarPrzedmiotu
        {
            get { return ciezarPrzedmiotu; }
            set { if (value > 0) ciezarPrzedmiotu = value; }
        }

        private int przyspieszenie;

        public int Przyspieszenie
        {
            get { return przyspieszenie; }
            set { if (value > 0) przyspieszenie = value; }
        }
        

        private int srednicaSilnika;

        public int SrednicaSilnika
        {
            get { return srednicaSilnika; }
            set { srednicaSilnika = value; }
        }

        private int dlugoscSilnika;

        public int DlugoscSilnika
        {
            get { return dlugoscSilnika; }
            set { dlugoscSilnika = value; }
        }
        private int srednicaG1;

        public int SrednicaG1
        {
            get { return srednicaG1; }
            set { srednicaG1 = value; }
        }
        private int srednicaG2;

        public int SrednicaG2
        {
            get { return srednicaG2; }
            set { srednicaG2 = value; }
        }
        private int szerokoscKola;

        public int SzerokoscKola
        {
            get { return szerokoscKola; }
            set { szerokoscKola = value; }
        }

        private int liczbaZebowG1;

        public int LiczbaZebowG1
        {
            get { return liczbaZebowG1; }
            set { liczbaZebowG1 = value; }
        }
        private int liczbaZebowG2;

        public int LiczbaZebowG2
        {
            get { return liczbaZebowG2; }
            set { liczbaZebowG2 = value; }
        }
        public void PobierzDane()
        {
            Console.WriteLine("\n ETAP DOBORU UKŁADU NAPĘDOWEGO \n");
            ciezarStolu = PobierzDane(DaneKomunikaty.ciezarStolu);
            ciezarPrzedmiotu = PobierzDane(DaneKomunikaty.CiezarPrzedmiotu);
            przyspieszenie = PobierzDane(DaneKomunikaty.przyspieszenie);
            silaOsiowa = (ciezarPrzedmiotu + ciezarStolu) * 10;
            srednicaSilnika = PobierzDane(DaneKomunikaty.srednicaSilnika);
            dlugoscSilnika = PobierzDane(DaneKomunikaty.dlugoscSilnika);
            srednicaG1 = PobierzDane(DaneKomunikaty.srednicaG1);
            srednicaG2 = PobierzDane(DaneKomunikaty.srednicaG2);
            szerokoscKola = PobierzDane(DaneKomunikaty.szerokoscKola);
            liczbaZebowG1 = PobierzDane(DaneKomunikaty.liczbaZebowG1);
            liczbaZebowG2 = PobierzDane(DaneKomunikaty.liczbaZebowG2);
        }




    }
}
