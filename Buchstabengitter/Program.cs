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
            string line;
            while ((line = file.ReadLine()) != null) //sol, die file abgelesen wird, füllt er die wörter in die Liste
            {
                Woerterbuch.Add(line);

            }
            foreach (string wortLC in Woerterbuch)
            {
                string Wort = wortLC.ToUpper();
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
                                int Counter;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (Counter = 1; Counter < Wortlaenge; Counter++)
                                {
                                    
                                    jSpeicher = j + Counter;
                                    string RaetselBuchstabe = Tabelle[i, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(Counter, 1);

                                    if (RaetselBuchstabe == naechsterbuchstabe)
                                    {
                                        if (Counter == Wortlaenge - 1)
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
                                int Counter;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (Counter = 1; Counter < Wortlaenge; Counter++)
                                {
                                    
                                    jSpeicher = j - Counter;
                                    string TabelleBuchstabe = Tabelle[i, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(Counter, 1);

                                    if (TabelleBuchstabe == naechsterbuchstabe)
                                    {
                                        if (Counter == Wortlaenge - 1)
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
                                int Counter;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (Counter = 1; Counter < Wortlaenge; Counter++)
                                {

                                    iSpeicher = i - Counter;
                                    string TabelleBuchstabe = Tabelle[iSpeicher, j];
                                    naechsterbuchstabe = Wort.Substring(Counter, 1);

                                    if (TabelleBuchstabe == naechsterbuchstabe)
                                    {
                                        if (Counter == Wortlaenge - 1)
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
                                int Counter;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (Counter = 1; Counter < Wortlaenge; Counter++)
                                {

                                    iSpeicher = i + Counter;
                                    string TabelleBuchstabe = Tabelle[iSpeicher, j];
                                    naechsterbuchstabe = Wort.Substring(Counter, 1);
                                    if (TabelleBuchstabe == naechsterbuchstabe)
                                    {
                                        if (Counter == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (unten)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            int T_PlatzRechtsUnten = 0;//diagonalrechtsunten
                            int I_untenrechts = 8 - i; //wieviel nach rechts frei ist
                            int J_untenrechts = 11 - j; //wieviel nach unten frei ist
                            if (I_untenrechts < J_untenrechts) //kleinere = wieviel platz untenrechts ist
                            {
                                T_PlatzRechtsUnten = I_untenrechts;
                            }
                            else
                                T_PlatzRechtsUnten = J_untenrechts;
                            if (Wortlaenge <= T_PlatzRechtsUnten)//diagonalrechtsunten(abfrage) - checkt ob es reinpasst
                            {
                                int Counter;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (Counter = 1; Counter < Wortlaenge; Counter++)
                                {
                                    
                                    iSpeicher = i + Counter;
                                    jSpeicher = j + Counter;
                                    string TabelleBuchstabe = Tabelle[iSpeicher, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(Counter, 1);
                                    if (TabelleBuchstabe == naechsterbuchstabe)
                                    {
                                        if (Counter == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (untenrechts)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            int T_PlatzRechtsOben = 0;//diagonalrechtsoben
                            int I_obenrechts = i;
                            int J_obenrechts = 11 - j;
                            if (I_obenrechts < J_obenrechts)
                            {
                                T_PlatzRechtsOben = I_obenrechts;
                            }
                            else
                                T_PlatzRechtsOben = J_untenrechts;
                            if (Wortlaenge <= T_PlatzRechtsOben)//diagonalrechtsoben(abfrage)
                            {
                                int Counter;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (Counter = 1; Counter < Wortlaenge; Counter++)
                                {
                                    
                                    iSpeicher = i - Counter;
                                    jSpeicher = j + Counter;
                                    string TabelleBuchstabe = Tabelle[iSpeicher, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(Counter, 1);
                                    if (TabelleBuchstabe == naechsterbuchstabe)
                                    {
                                        if (Counter == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (obenrechts)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            int T_PlatzLinksOben = 0;//diagonallinkssoben
                            int I_obenlinks = i;
                            int J_obenlinks = j;
                            if (I_obenlinks < J_obenlinks)
                            {
                                T_PlatzLinksOben = I_obenlinks;
                            }
                            else
                                T_PlatzLinksOben = J_obenlinks;
                            if (Wortlaenge <= T_PlatzLinksOben)//diagonallinksoben(abfrage)
                            {
                                int Counter;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (Counter = 1; Counter < Wortlaenge; Counter++)
                                {
                                    
                                    iSpeicher = i - Counter;
                                    jSpeicher = j - Counter;
                                    string TabelleBuchstabe = Tabelle[iSpeicher, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(Counter, 1);
                                    if (TabelleBuchstabe == naechsterbuchstabe)
                                    {
                                        if (Counter == Wortlaenge - 1)
                                        {
                                            Woerterimgitter.Add(Wort + " (obenlinks)");
                                            SpaltenZeilen.Add(new Data(j + 1, i + 1));
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            int T_PlatzLinksUnten = 0;//diagonallinkssunten
                            int I_linksunten = 8 - i;
                            int J_linksunten = j;
                            if (I_linksunten < J_linksunten)
                            {
                                T_PlatzLinksUnten = I_linksunten;
                            }
                            else
                                T_PlatzLinksUnten = J_linksunten;
                            if (Wortlaenge <= T_PlatzLinksUnten)//diagonallinksunten(abfrage)
                            {
                                int Counter;
                                string naechsterbuchstabe;
                                int iSpeicher = i;
                                int jSpeicher = j;

                                for (Counter = 1; Counter < Wortlaenge; Counter++)
                                {
                                    
                                    iSpeicher = i + Counter;
                                    jSpeicher = j - Counter;
                                    string rechterBuchstabe = Tabelle[iSpeicher, jSpeicher];
                                    naechsterbuchstabe = Wort.Substring(Counter, 1);
                                    if (rechterBuchstabe == naechsterbuchstabe)
                                    {
                                        if (Counter == Wortlaenge - 1)
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