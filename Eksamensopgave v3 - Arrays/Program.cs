using System.Data;
using System.Linq;
using System.Reflection.Metadata;

namespace Eksamensopgave_v3___Arrays
{
    struct Registreringer()
    {
        public string navn;
        public int nr;
        public string formål;
        public string kontakt;
        public DateTime ankomst = new DateTime();        
        public string afgang;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int Antal = 1000;
            Registreringer[] medarbejdere = new Registreringer[Antal];
            int Kantal = 1000;
            Registreringer[] kunde = new Registreringer[Kantal];
            int Kamount = 0;
            int amount = 0;
            int valg;
            int valg2;
            bool repeat = true;
            int password = 1234;
            string Search;
            string Ksearch;
            bool found;
            bool admin = true;
            string input;
            do
            {
                Console.WriteLine("Velkommen til [Firma]");
                Console.WriteLine("(1) Tilføj medarbejder:");
                Console.WriteLine("(2) Tilføj besøgende");
                Console.WriteLine("(3) Administrator");
                Console.WriteLine("(0) Afslut Program");
                valg = int.Parse(Console.ReadLine());
                switch (valg)
                {
                    case 1: // Tilføj ny medarbejder
                        if (amount < Antal)
                        {
                            Console.Write("Godmorgen - Der er {0} mødte før dig.\n\nSkriv venligst dit navn: ", amount);
                            medarbejdere[amount].navn = Console.ReadLine();
                            Console.Write("Angiv venligst dit medarbejder Nr: ");
                            medarbejdere[amount].nr = int.Parse(Console.ReadLine());
                            medarbejdere[amount].ankomst = DateTime.Now;
                            Console.Write("Hvornår har du fyraften? (HH:mm): ");
                            medarbejdere[amount].afgang = Console.ReadLine();
                            amount++;
                            Console.WriteLine();
                        }
                        else
                            Console.WriteLine("Database er fuld.");
                        break;
                    case 2: // Tilføj ny kunde
                        if (Kamount < Kantal)
                        {
                            Console.Write("Velkommen\nSkriv venligst dit navn: ");
                            kunde[Kamount].navn = Console.ReadLine();
                            Console.Write("Angiv venligst dit kunde Nr: ");
                            kunde[Kamount].nr = int.Parse(Console.ReadLine());
                            kunde[Kamount].ankomst = DateTime.Now;
                            Console.Write("Hvem skal du møde? ");
                            kunde[Kamount].kontakt = Console.ReadLine();
                            Console.Write("Hvad er dit formål: ");
                            kunde[Kamount].formål = Console.ReadLine();
                            Kamount++;
                        }
                        else
                            Console.WriteLine("Database er fuld.");
                        break;
                    case 3: // Administrator
                        Console.Write("Password: ");
                        password = int.Parse(Console.ReadLine());
                        if (password == 1234)
                        {
                            do
                            {
                                Console.WriteLine("(1) Se fremmødte medarbejdere.");
                                Console.WriteLine("(2) Ret medarbejder.");
                                Console.WriteLine("(3) Se besøgende.");
                                Console.WriteLine("(4) Ret besøgende.");
                                Console.WriteLine("[0] Tilbage");
                                valg2 = int.Parse(Console.ReadLine());
                                switch (valg2)
                                {
                                    case 1: //se fremmødte medarbejdere
                                        if (amount == 0)
                                        {
                                            Console.WriteLine("Ingen data at søge efter.");
                                        }
                                        else
                                        {
                                            for (int i = 0; i < amount; i++)
                                                Console.WriteLine("{0}:\nNavn: {1} - Nr: {2}\nAnkomst: {3} - Afgang: {4}\n", i + 1, medarbejdere[i].navn, medarbejdere[i].nr, medarbejdere[i].ankomst, medarbejdere[i].afgang);
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 2: // Ret medarbejdere
                                        Console.Write("Hvem søges? ");
                                        Search = Console.ReadLine();
                                        Search = Search.ToUpper();
                                        found = false;
                                        for (int i = 0; i < amount; i++)
                                            if (medarbejdere[i].navn.ToUpper().Contains(Search))
                                            {
                                                Console.WriteLine("{0} Fundet\n", medarbejdere[i].navn);
                                                Console.Write("Skriv venligst dit navn: ");
                                                medarbejdere[i].navn = Console.ReadLine();
                                                Console.Write("Angiv venligst dit medarbejder Nr: ");
                                                medarbejdere[i].nr = int.Parse(Console.ReadLine());
                                                Console.Write("Hvornår mødte du? (HH:mm): ");
                                                input = Console.ReadLine();
                                                if (DateTime.TryParse(input, out medarbejdere[i].ankomst))
                                                {
                                                    
                                                }
                                                else
                                                {
                                                    medarbejdere[i].ankomst = DateTime.Now;
                                                    Console.WriteLine("Forkert format\nAnkomst gemt som: {0}", medarbejdere[i].ankomst);
                                                }
                                                Console.Write("Hvornår har du fyraften? (HH:mm): ");
                                                medarbejdere[i].afgang = Console.ReadLine();
                                                found = true;
                                            }
                                        Console.WriteLine();
                                        if (!found)
                                            Console.WriteLine("Medarbejder ikke fundet");
                                        break;
                                    case 3:// Se fremmødte gæster
                                        if (Kamount == 0)
                                        {
                                            Console.WriteLine("Der er ingen fremmødte gæster.");
                                        }
                                        else
                                        {
                                            for (int i = 0; i < Kamount; i++)
                                                Console.WriteLine("{0}\nNavn: {1}, Kunde Nr: {2}\nAnkomst: {3}\nKontakt: {4}\nFormål: {5}\n", i + 1, kunde[i].navn, kunde[i].nr, kunde[i].ankomst,kunde[i].kontakt, kunde[i].formål);
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 4: // Ret fremmødte
                                        Console.WriteLine("Hvem søges?");
                                        Ksearch = Console.ReadLine();
                                        Ksearch = Ksearch.ToUpper();
                                        found = false;
                                        for (int i = 0; i < Kamount; i++)
                                            if (kunde[i].navn.ToUpper().Contains(Ksearch))
                                            {
                                                Console.WriteLine("{0} fundet.\n", kunde[i].navn);
                                                Console.Write("Skriv venligst dit navn: ");
                                                kunde[i].navn = Console.ReadLine();
                                                Console.Write("Angiv venligst dit kunde Nr: ");
                                                kunde[i].nr = int.Parse(Console.ReadLine());
                                                Console.Write("Hvornår ankom du? (HH:mm):  ");
                                                input = Console.ReadLine();
                                                if (DateTime.TryParse(input, out kunde[i].ankomst))
                                                {

                                                }
                                                else
                                                {
                                                    kunde[i].ankomst = DateTime.Now;
                                                    Console.WriteLine("Forkert format\\nAnkomst gemt som: {0}", kunde[i].ankomst);
                                                }
                                                Console.Write("Hvem skal du møde? ");
                                                kunde[Kamount].kontakt = Console.ReadLine();
                                                Console.Write("Hvad er dit formål: ");
                                                kunde[i].formål = Console.ReadLine();
                                                found = true;
                                            }
                                        if (!found)
                                            Console.WriteLine("Kunde ikke fundet.");
                                        break;
                                    case 0:
                                        admin = false;
                                        break;
                                    default:
                                        Console.WriteLine();
                                        Console.WriteLine("Forkert valg, Prøv venligst igen\n");
                                        break;
                                }
                            } while (admin);                              
                        }
                        break;
                    case 0: //Afslut
                        Console.WriteLine("Lukker programmet");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Forkert valg, prøv venligst igen\n");
                        break;
                }
            } while (repeat);
        }
    }
}