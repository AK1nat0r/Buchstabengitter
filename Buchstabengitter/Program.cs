using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = System.Collections.Generic.KeyValuePair<int, int>;

namespace Projekt_Buchstabengitter
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            



            Console.WriteLine("B	I	T	P	A	P	U	B	L	I	C	M	\n \n \n \nI	Z	S	Y	V	F	W	O	I	P	K	O\n \n \n \nN	O	I	T	A	I	Z	O	S	S	A	D\n \n \n \nÄ	A	G	G	R	E	G	A	T	I	O	N\n \n \n \nR	R	R	I	I	I	M	D	E	R	W	A\n \n \n \nT	R	E	W	A	G	N	F	P	M	U	R\n \n \n \nR	A	H	C	B	J	Ã	G	E	L	S	E\n \n \n \nU	Y	C	E	L	B	U	O	D	W	H	Y\n \n \n \nE	D	A	T	E	I	N	R	U	T	E	R\n");


            string[,] Tabelle = new string[9, 12] { { "B", "I", "T", "P", "A", "P", "U", "B", "L", "I", "C", "M" },
                                                    { "I", "Z", "S", "Y", "V", "F", "W", "O", "I", "P", "K", "O"},
                                                    { "N", "O", "I", "T", "A", "I", "Z", "O", "S", "S", "A", "D"},
                                                    { "Ä", "A", "G", "G", "R", "E", "G", "A", "T", "I", "O", "N"},
                                                    { "R", "R", "R", "I", "I", "I", "M", "D", "E", "R", "W", "A"},
                                                    { "T", "R", "E", "W", "A", "G", "N", "F", "P", "M", "U", "R"},
                                                    { "R", "A", "H", "C", "B", "J", "Ä", "G", "E", "L", "S", "E"},
                                                    { "U", "Y", "C", "E", "L", "B", "U", "O", "D", "W", "H", "Y"},
                                                    { "E", "D", "A", "T", "E", "I", "N", "R", "U", "T", "E", "R"} };

            List<string> Woerterbuch = new List<string>();

            var SpaltenZeilen = new List<Data>();

            List<string> Woerterimgitter = new List<string>();
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\jaege\source\repos\Buchstabengitter\woerter.txt");
            while ((line = file.ReadLine()) != null)
            {
                Woerterbuch.Add(line);

            }
            foreach (string buch in Woerterbuch)
            {
                string Wort = buch.ToUpper();
                int Wortlaenge = Wort.Count();
                for (int i = 0; i < Tabelle.GetLength(0); i++) //Zeilen
                {
                    for (int j = 0; j < Tabelle.GetLength(1); j++)//Spalten
                    {
                        string Buchstabe = Wort.Substring(0, 1);
                        string raetselBuchstabe = Tabelle[i, j];

                        if (Buchstabe == raetselBuchstabe)//Buchstabe suchen
                        {

                            if (Wortlaenge <= 12 - j)//rechts - checkt ob das wort rechts passt
                            {
                                //Console.WriteLine("rechts: "+ Wort);
                                int x;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (x = 1; x < Wortlaenge; x++)
                                {
                                    int g = x;
                                    jSpeicher = j + x;
                                    string rechterBuchstabe = Tabelle[i, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(g, 1);

                                    if (rechterBuchstabe == naechsterbuchstabe)
                                    {
                                        if (x == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (rechts)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            if (Wortlaenge >= 12 - j)//links
                            {
                                //Console.WriteLine("links: " + Wort);
                                int x;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (x = 1; x < Wortlaenge; x++)
                                {
                                    int g = x;
                                    jSpeicher = j - x;
                                    string rechterBuchstabe = Tabelle[i, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(g, 1);

                                    if (rechterBuchstabe == naechsterbuchstabe)
                                    {
                                        if (x == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (links)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            if (Wortlaenge <= i)//oben
                            {
                                int x;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (x = 1; x < Wortlaenge; x++)
                                {
                                    int g = x;

                                    iSpeicher = i - x;
                                    
                                    string rechterBuchstabe = Tabelle[iSpeicher, j];
                                    
                                    naechsterbuchstabe = Wort.Substring(g, 1);

                                    if (rechterBuchstabe == naechsterbuchstabe)
                                    {
                                        if (x == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (oben)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            if (Wortlaenge <= 9 - i)//unten
                            {
                                int x;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (x = 1; x < Wortlaenge; x++)
                                {
                                    int g = x;
                                    iSpeicher = i + x;
                                    string rechterBuchstabe = Tabelle[iSpeicher, j];
                                    naechsterbuchstabe = Wort.Substring(g, 1);
                                    if (rechterBuchstabe == naechsterbuchstabe)
                                    {
                                        if (x == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (unten)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            int ioderjrechtsunten = 0;//diagonalrechtsunten
                            int idiagonaluntenrechtsspeicher = 8 - i;
                            int jdiagoanaluntenrechtsspeicher = 11 - j;
                            if (idiagonaluntenrechtsspeicher < jdiagoanaluntenrechtsspeicher)
                            {
                                ioderjrechtsunten = idiagonaluntenrechtsspeicher;
                            }
                            else
                                ioderjrechtsunten = jdiagoanaluntenrechtsspeicher;
                            if (Wortlaenge <= ioderjrechtsunten)//diagonalrechtsunten(abfrage)
                            {
                                int x;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (x = 1; x < Wortlaenge; x++)
                                {
                                    int g = x;
                                    iSpeicher = i + x;
                                    jSpeicher = j + x;
                                    string rechterBuchstabe = Tabelle[iSpeicher, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(g, 1);
                                    if (rechterBuchstabe == naechsterbuchstabe)
                                    {
                                        if (x == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (untenrechts)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            int ioderjrechtsoben = 0;//diagonalrechtsoben
                            int idiagonalobenrechtsspeicher = i;
                            int jdiagoanalobenrechtsspeicher = 11 - j;
                            if (idiagonalobenrechtsspeicher < jdiagoanalobenrechtsspeicher)
                            {
                                ioderjrechtsoben = idiagonalobenrechtsspeicher;
                            }
                            else
                                ioderjrechtsoben = jdiagoanaluntenrechtsspeicher;
                            if (Wortlaenge <= ioderjrechtsoben)//diagonalrechtsoben(abfrage)
                            {
                                int x;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (x = 1; x < Wortlaenge; x++)
                                {
                                    int g = x;
                                    iSpeicher = i - x;
                                    jSpeicher = j + x;
                                    string rechterBuchstabe = Tabelle[iSpeicher, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(g, 1);
                                    if (rechterBuchstabe == naechsterbuchstabe)
                                    {
                                        if (x == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (obenrechts)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            int ioderjlinksoben = 0;//diagonallinkssoben
                            int idiagonalobenlinksspeicher = i;
                            int jdiagoanalobenlinksspeicher = j;
                            if (idiagonalobenlinksspeicher < jdiagoanalobenlinksspeicher)
                            {
                                ioderjlinksoben = idiagonalobenlinksspeicher;
                            }
                            else
                                ioderjlinksoben = jdiagoanalobenlinksspeicher;
                            if (Wortlaenge <= ioderjlinksoben)//diagonallinksoben(abfrage)
                            {
                                int x;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (x = 1; x < Wortlaenge; x++)
                                {
                                    int g = x;
                                    iSpeicher = i - x;
                                    jSpeicher = j - x;
                                    string rechterBuchstabe = Tabelle[iSpeicher, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(g, 1);
                                    if (rechterBuchstabe == naechsterbuchstabe)
                                    {
                                        if (x == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (obenlinks)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            int ioderjlinksunten = 0;//diagonallinkssunten
                            int idiagonaluntenlinksspeicher = 8 - i;
                            int jdiagoanaluntenlinksspeicher = j;
                            if (idiagonaluntenlinksspeicher < jdiagoanaluntenlinksspeicher)
                            {
                                ioderjlinksunten = idiagonaluntenlinksspeicher;
                            }
                            else
                                ioderjlinksunten = jdiagoanaluntenlinksspeicher;
                            if (Wortlaenge <= ioderjlinksunten)//diagonallinksunten(abfrage)
                            {
                                int x;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (x = 1; x < Wortlaenge; x++)
                                {
                                    int g = x;
                                    iSpeicher = i + x;
                                    jSpeicher = j - x;
                                    string rechterBuchstabe = Tabelle[iSpeicher, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(g, 1);
                                    if (rechterBuchstabe == naechsterbuchstabe)
                                    {
                                        if (x == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (untenlinks)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            int AnzahlListe = Woerterimgitter.Count();

            for (int h = 0; h < AnzahlListe; h++)
            {
                Console.WriteLine("Das Wort " + Woerterimgitter[h] + " wurde gefunden.");
                Console.WriteLine("In Spalte und Zeile: " + SpaltenZeilen[h] + "\n");
            }
            Console.WriteLine("Diese Wörter wurden gefunden.");
            Console.ReadKey();

        }
    }
}