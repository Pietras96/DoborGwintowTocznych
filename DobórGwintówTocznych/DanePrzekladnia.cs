using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    class DanePrzekladnia: Dane
    {

        public DanePrzekladnia()
        {
            ciezarStolu = OdczytajInt(DaneKomunikaty.ciezarStolu);
            CiezarPrzedmiotu = OdczytajInt(DaneKomunikaty.CiezarPrzedmiotu);
            przyspieszenie = OdczytajInt(DaneKomunikaty.przyspieszenie);
            silaOsiowa = (ciezarPrzedmiotu + ciezarStolu)*10;
            srednicaSilnika = OdczytajInt(DaneKomunikaty.srednicaSilnika);
            dlugoscSilnika = OdczytajInt(DaneKomunikaty.dlugoscSilnika);
            srednicaG1 = OdczytajInt(DaneKomunikaty.srednicaG1);
            srednicaG2 = OdczytajInt(DaneKomunikaty.srednicaG2);
            szerokoscKola = OdczytajInt(DaneKomunikaty.szerokoscKola);
            liczbaZebowG1 = OdczytajInt(DaneKomunikaty.liczbaZebowG1);
            liczbaZebowG2 = OdczytajInt(DaneKomunikaty.liczbaZebowG2);

        }
        public const double wspTarciaProwadnicy = 0.2;
        public const double momentLozyska = 0.1;
        public const double wspolczynnikSprawnosci = 0.8;
        public const double ciezarWlasciwyStali = 7850;
        public int obciazenieRobocze = 0;
        public int silaOsiowa = 0;

        private int ciezarStolu;

        public int CiezarStolu
        {
            get { return ciezarStolu; }
            set { if (value > 0) ciezarStolu = value; }
        }

        private int ciezarPrzedmiotu;

        public int CiezarPrzedmiotu
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

       
        


    }
}
