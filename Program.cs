using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace catalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tytul = new List<string>();
            List<string> autor = new List<string>();
            List<int> iloscStron = new List<int>();
            List<int> rokWydania = new List<int>();
            string TYTUL;
            string AUTOR;
            int ILOSCSTRON;
            int ROKWYDANIA;
            string nazwaKatalogu;
            string nazwaPliku;
            Boolean apRun = true;
            Boolean cz4 = true;
            string nazwaKsiążki;
            int choice;
            int ileKsiążek = 0;
            while (apRun)
            {
                Console.WriteLine("A program that stores information about books in library catalogs");
                Console.WriteLine("Choose an option");
                Console.WriteLine("\n 1-Create new catalog \n 2-Save catalog to file \n 3-Read catalog from file \n 4-Search for books in the catalog \n 5-Quit");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice > 5 || choice < 1)
                {
                    Console.WriteLine("Choose option: 1-5. ");
                }
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            if (tytul.Count > 0)
                            {
                                for (int i = 0; i <= tytul.Count; i++)
                                {
                                    int j = tytul.Count - 1;
                                    tytul.RemoveAt(j);
                                    autor.RemoveAt(j);
                                    iloscStron.RemoveAt(j);
                                    rokWydania.RemoveAt(j);
                                }
                            }

                            Console.Write("Enter the number of books you want to add to the file: ");
                            while (!int.TryParse(Console.ReadLine(), out ileKsiążek) || ileKsiążek <= 0)
                            {
                                Console.WriteLine("The number must be greater than 0 !");
                            }
                            for (int i = 0; i < ileKsiążek; i++)
                            {
                                Console.WriteLine("Enter the Title of the " + (i + 1) + " book");
                                TYTUL = Console.ReadLine();
                                tytul.Add(TYTUL);
                                Console.WriteLine("Enter the Author of the " + (i + 1) + " book");
                                AUTOR = Console.ReadLine();
                                autor.Add(AUTOR);
                                Console.WriteLine("Enter the number of pages of the " + (i + 1) + " book");
                                while (!int.TryParse(Console.ReadLine(), out ILOSCSTRON) || ILOSCSTRON < 1 || ILOSCSTRON > 1000)
                                {
                                    Console.WriteLine("Enter the number of pages between 1-1000");
                                }
                                iloscStron.Add(ILOSCSTRON);
                                Console.WriteLine("enter the year of publication of the " + (i + 1) + " book");
                                while (!int.TryParse(Console.ReadLine(), out ROKWYDANIA) || ROKWYDANIA < 1 || ROKWYDANIA > 2200)
                                {
                                    Console.WriteLine("enter the year of publication between 1-2200");
                                }
                                rokWydania.Add(ROKWYDANIA);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            if (ileKsiążek < 1)
                            {
                                Console.WriteLine("There is no directory to save");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter the name of the dcatalog without .txt: ");
                                nazwaKatalogu = Console.ReadLine();
                                nazwaPliku = nazwaKatalogu + ".txt";
                                StreamWriter sw = new StreamWriter(nazwaPliku, true);
                                for (int i = 0; i < tytul.Count; i++)
                                {
                                    sw.WriteLine(tytul[i] + ", " + autor[i] + ", " + iloscStron[i] + ", " + rokWydania[i]);
                                }
                                sw.Close();
                            }

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the name of the dcatalog without .txt");
                            nazwaKatalogu = Console.ReadLine();
                            nazwaPliku = nazwaKatalogu + ".txt";
                            if (!File.Exists(nazwaPliku))
                            {
                                Console.WriteLine("not found");
                                break;
                            }
                            Console.WriteLine(" \nTytuł, Authors, Number of pages, Publication date");
                            StreamReader sr = new StreamReader(nazwaPliku);
                            Console.WriteLine(sr.ReadToEnd());
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            int wyniki = 0;
                            Console.WriteLine("Enter the name of the dcatalog without .txt");
                            nazwaKatalogu = Console.ReadLine();
                            nazwaPliku = nazwaKatalogu + ".txt";
                            if (!File.Exists(nazwaPliku))
                            {
                                Console.WriteLine("not found");
                                break;
                            }
                            while (cz4)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter the book title");
                                nazwaKsiążki = Console.ReadLine();
                                StreamReader sr = new StreamReader(nazwaPliku);
                                string calyTekst = sr.ReadToEnd();
                                string[] CALYTEKST = calyTekst.Split('\n');
                                foreach (string item in CALYTEKST)
                                {
                                    if (item.Contains(nazwaKsiążki))
                                    {
                                        wyniki += 1;
                                        string[] SinglePeaceOfData = item.Split(',');
                                        Console.WriteLine("{0} Result", wyniki);
                                        Console.WriteLine("Title: {0}\nAuthors: {1}\nNumber if pages: {2}\nYear of publication: {3}\n", SinglePeaceOfData[0], SinglePeaceOfData[1], SinglePeaceOfData[2], SinglePeaceOfData[3]);

                                        cz4 = false;
                                    }
                                }
                                if (cz4) Console.WriteLine("not found! ");
                            }
                            break;
                        }
                    case 5:
                        {
                            apRun = false;
                            Console.Clear();
                            break;
                        }


                }


            }


        }
    }
}