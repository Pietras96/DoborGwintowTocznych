using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobórGwintówTocznych
{
    class Dane
    {
        public Dane(int srednicaNominalna, float skokGwintu, float dlugoscCalkowitaSruby, float dlugoscGwintuSruby, string kierZwoju)
        {
            SrednicaNominalna = srednicaNominalna;
            SkokGwintu = skokGwintu;
            DlugoscCalkowitaSruby = dlugoscCalkowitaSruby;
            DlugoscGwintuSruby = dlugoscGwintuSruby;
            kierunekZwoju = kierZwoju;
        }


        string kierunekZwoju;
        private int srednicaNominalna;

        public int SrednicaNominalna
        {
            get { return srednicaNominalna; }
            set { if (value == 16 || value == 20 || value == 25) srednicaNominalna = value; }
        }

        private float skokGwintu;

        public float SkokGwintu
        {
            get { return skokGwintu; }
            set { if (value > 0) skokGwintu = value; }
        }
        private float dlugoscCalkowitaSruby;

        public float DlugoscCalkowitaSruby
        {
            get { return dlugoscCalkowitaSruby; }
            set { if (value > 0) dlugoscCalkowitaSruby = value; }
        }
        private float dlugoscGwintuSruby;

        public float DlugoscGwintuSruby
        {
            get { return dlugoscGwintuSruby; }
            set { if (value > 0) dlugoscGwintuSruby = value; }
        }
        //K1 - nakretka pojedyncza z luzem osiowym, K2 - nakretka pojedyncza z napięciem wstępnym, K3 - nakrętka podwójna z napięciem wstępnym
        enum TypNakretki
        {
            K1 = 1, K2 = 2, K3 = 3
        }

        public static Dane UtworzDane()
        {
            int srednicaNom = OdczytajInt(DaneKomunikaty.SrednicaNom);
            int skokGw = OdczytajInt(DaneKomunikaty.SkokGwintu);
            char kierunekZwojuKlucz = OdczytajChar(DaneKomunikaty.KierunekZwoju);
            string kierunekZwoju = ParametryObliczeniowe.slowKierZwoju[kierunekZwojuKlucz].ToString();
            int dlGwintu = OdczytajInt(DaneKomunikaty.DlugoscGwintu);
            int dlugoscCalk = OdczytajInt(DaneKomunikaty.DlugoscCalkowita);

            return new Dane(srednicaNom, skokGw, dlugoscCalk, dlGwintu, kierunekZwoju);
        }
        public static int OdczytajInt(string komunikat)
        {
            Console.Write(komunikat);
            return Convert.ToInt32(Console.ReadLine());
        }


        public static char OdczytajChar(string komunikat)
        {
            Console.Write(komunikat);
            return Convert.ToChar(Console.ReadLine().ToUpper());
        }

    }

    public static class DaneKomunikaty
    {
        public static string SrednicaNom { get { return "Proszę podać średnicę nominalną gwintu: "; } }
        public static string SkokGwintu { get { return "Proszę podać skok nominalny gwintu: "; } }
        public static string KierunekZwoju { get { return "Proszę podać kierunek obrotu (L - lewy gwint, P - prawy gwint): "; } }
        public static string DlugoscGwintu { get { return "Proszę podać długość gwintu śruby: "; } }
        public static string DlugoscCalkowita { get { return "Proszę podać długość całkowitą śruby: "; } }
    }
}


