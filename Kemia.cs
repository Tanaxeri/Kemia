using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kemia
{
    class Kemia
    {
        static List<Felfedezesek> felfede = new List<Felfedezesek>();

        static void Main(string[] args)
        {
            Console.WriteLine("Program kezdődik...");

            //*2. feladat
            Beolvas("felfedezesek.csv");

            //*3. feladat
            feladat03(felfede);

            //*4. feladat
            feladat04(felfede);

            //*5. feladat
            string vegyjel = feladat05();

            //*6. feladat
            Console.WriteLine("6. feladat: Keresés");
            feladat06(felfede, vegyjel);

            //*7. feladat
            feladat07(felfede);

            //*8. feladat
            Console.WriteLine("8. feladat: ");
            feladat08(felfede);

            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        private static void feladat08(List<Felfedezesek> felfede)
        {

            int megvizsgaltido = 0;

            List<int> Felfedezesido = new List<int>();
            List<int> Felfedezesidohossz = new List<int>();

            for (int i = 0; i < felfede.Count; i++)
            {

                if (int.TryParse(felfede[i].Ev ,out megvizsgaltido))
                {

                    Felfedezesido.Add(megvizsgaltido);

                }

            }

            Felfedezesidohossz = Felfedezesido.Distinct().ToList();

            foreach (var Felfedezesid in Felfedezesidohossz)
            {

                int felfedezesszam = 0;

                for (int i = 1; i < felfede.Count; i++)
                {

                    if (felfede[i].Ev == Felfedezesid.ToString())
                    {

                        felfedezesszam++;

                    }

                }

                if (felfedezesszam >= 4)
                {

                    Console.WriteLine($"\t{Felfedezesid}:  {felfedezesszam}  db");

                }

            }

        }

        private static void feladat07(List<Felfedezesek> felfede)
        {

            List<int> ido = new List<int>();
            int megvizsgaltido = 0;
            int elozoido = 0;

            for (int i = 0; i < felfede.Count; i++)
            {

                if (int.TryParse(felfede[i].Ev, out megvizsgaltido) && int.TryParse(felfede[i-1].Ev, out elozoido))
                {

                    ido.Add(megvizsgaltido - elozoido);

                }

            }

            int Maxido = 0;

            for (int i = 0; i < ido.Count; i++)
            {

                if (ido[i] > Maxido)
                {

                    Maxido = ido[i];

                }

            }

            Console.WriteLine("7. feldat: " + Maxido + " év volt a leghosszabb időszak két elem felfedezése között.");

        }

        private static void feladat06(List<Felfedezesek> felfede, string vegyjel)
        {

            bool vegyvan = false;
            for (int i = 0; i < felfede.Count; i++)
            {
                if (felfede[i].Vegyjel.ToUpper() == vegyjel.ToUpper())
                {
                    Console.WriteLine("\tAz elem vegyjele: " + felfede[i].Vegyjel);
                    Console.WriteLine("\tAz elem neve: " + felfede[i].Elem);
                    Console.WriteLine("\tRendszáma: " + felfede[i].Rendszam);
                    Console.WriteLine("\tFelfedezés éve: " + felfede[i].Ev);
                    Console.WriteLine("\tFelfedező: " + felfede[i].Felfedezo);
                }
                else
                {

                    vegyvan = false;

                }
            }

            if (!vegyvan)
            {
                Console.WriteLine("Nincs ilyen elem az adatbázisban!");
            }

        }

        private static string feladat05()
        {
            string sablon = @"^[a-zA-Z]+$";
            Regex rx = new Regex(sablon);
            Match egyezik;

            string vegyjel;

            do
            {

                Console.WriteLine($"5. feladat: Kérek egy vegyjelet: ");
                vegyjel = Console.ReadLine();

                egyezik = rx.Match(vegyjel);
            }
            while (!(vegyjel.Length == 1 || vegyjel.Length == 2) && egyezik.Success);


            return vegyjel;
        }

        private static void feladat04(List<Felfedezesek> felfede)
        {

            int Okorszam = 0;

            foreach (var felfedezesek in felfede)
            {

                if (felfedezesek.Ev == "Ókor")
                {

                    Okorszam++;

                }

            }

            Console.WriteLine($"4. feldat: Felfedezések száma az ókorban: " + Okorszam);

        }

        private static void feladat03(List<Felfedezesek> felfede)
        {

            Console.WriteLine($"3. feladat: Elemek száma: {felfede.Count}");

        }

        private static void Beolvas(string adatFile)
        {

            if (!File.Exists(adatFile))
            {

                Console.WriteLine("A forrás adatok hiányoznak!");
                Console.ReadLine();

                Environment.Exit(0);
            }

            using (StreamReader sr = new StreamReader(adatFile, Encoding.Default))
            {
                string fejlec = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    felfede.Add(new Felfedezesek(sr.ReadLine()));
                }

            }

        }
    }
}
