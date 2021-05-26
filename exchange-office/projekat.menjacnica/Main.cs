using System;

namespace menjacnica
{
    class MainClass
    {

        public class menjacnica
        {

            private static int brojac; //statička promenljiva. statička promenljiva važi ZA SVE OBJEKTE. Služi da prebroji sve transakcije
            private decimal isplata, uplata;
            private decimal provjen, provdol, provfun, provev; //privatne promenljive, dakle mogu samo iZ OVE KLASE biti promenjene
            private decimal evro, jen, dolar, funta, konisplata; //konisplata = KONAČNA ISPLATA

            public menjacnica() //defaultni konstruktor postavlja početne vrednosti
            {
                isplata = 0;
                uplata = 0;
                evro = 0;
                jen = 0;
                konisplata = 0;
                dolar = 0;
                funta = 0;
                provjen = provdol = provfun = provev = 0;

            }

            public menjacnica(decimal evro, decimal jen, decimal dolar, decimal funta, decimal provjen, decimal provdol, decimal provfun, decimal provev, decimal konisplata) //Preoptereceni konstruktor, sa vrednostima koje prima
            {//opterećeni konstruktor prihvata unos vrednosti sa tastature
                this.evro = evro;
                this.funta = funta;
                this.jen = jen;
                this.dolar = dolar;
                this.provev = provev;
                this.provjen = provjen; //ključna reč THIS vezuje vrednost za SVAKI OBJEKAT
                this.provdol = provdol;
                this.provfun = provfun;
                this.konisplata = konisplata;
                brojac++;			//povećava se za 1 kad se unese objekat. njom brojim dnevni broj transakcija
            }//public znači da je ta metoda dostupna I VAN KLASE U KOJOJ JE DEFINISANA

            static menjacnica() //defaultni statički konstruktor koji postavlja vrednost brojača dnevnih transakcija na 0.
            // mora biti STATIČKI KONSTRUKTOR ako postavlja vrednost za STATIČKE PROMENLJIVE
            {
                brojac = 0;
            }

            public void pocetni() //glavni meni koji se vidi
            {
                char radnja = 'e';
                if (brojac == 0)
                {
                    Console.WriteLine("DOBAR DAN");
                    Console.WriteLine("UNESI DEVIZNE KURSEVE I PROVIZIJE ZA DANASNJI DAN");//obavezan unos kursa svakog jutra
                    Console.WriteLine("");
                    brojac++;
                    unoskursa();

                }
                else if (brojac > 0)
                {
                    Console.WriteLine("ODABERITE");
                    Console.WriteLine("M - MENJACNICA");
                    Console.WriteLine("K - UNOS KURSEVA I PROVIZIJA");
                    Console.WriteLine("L - LISTANJE KURSEVA");
                    Console.WriteLine("P - LISTANJE PROVIZIJA");
                    Console.WriteLine("I - IZLAZ");
                    radnja = Convert.ToChar(Console.ReadLine().ToLower());
                    if (radnja == 'm')
                    {
                        if ((this.evro == 0) && (this.funta == 0) && (this.jen == 0) && (this.dolar == 0))
                        { //kurs MORA da bude podešen na neku vrednost
                            Console.WriteLine("MOLIMO VAS DA PRVO UNESETE KURSEVE I PROVIZIJE!");
                            System.Threading.Thread.Sleep(1500); //pauzira izvršavanje na 1500 milisekundi (1.5 sekunda)
                            Console.Clear();
                            pocetni(); //poziva metodu početni meni

                        }
                        else if (radnja == 'm')

                            prodajadeviza(); //metoda prodaja deviza
                    }
                    else if (radnja == 'k')
                        unoskursa();
                    else if (radnja == 'l')
                        ispiskursa();
                    else if (radnja == 'p')
                        ispisprovizija();
                    else if (radnja == 'i')
                        Environment.Exit(0); //izlazi iz programa
                }

            }

            public void unoskursa() //PUBLIC znači da je metoda vezana za objekte i DA MOŽE biti pozvana u drugoj klasi MAIN
            {
                char izborkurs = 'd';

                if ((this.evro != 0) && (this.funta != 0) && (this.jen != 0) && (this.dolar != 0))
                { //provera kod menjanja kursa, upozorenje da je već podešen
                    Console.WriteLine("KURS JE VEĆ PODEŠEN. DA LI ŽELITE DA UNESETE NOVI KURS? D / N");
                    izborkurs = Convert.ToChar(Console.ReadLine().ToLower());//prihvata unos sa tastature, prebacuje ga U MALA SLOVA i prebacuje u CHAR
                }
                if (izborkurs == 'd')
                {
                    do //izvrši se barem jednom, a svaki put dok je kurs == 0
                    {
                        Console.WriteLine("UNESITE DANAŠNJI KURS EVRA:");
                        evro = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("UNESITE DANAŠNJU PROVIZIJU ZA EVRE:");
                        provev = Convert.ToDecimal(Console.ReadLine());
                        if (evro == 0)
                        {
                            Console.WriteLine("KURS NE MOŽE BITI 0!");
                            System.Threading.Thread.Sleep(1500); //sačeka 1.5 sekund (1500 milisekundi)
                            Console.Clear(); //obriše slova sa ekrana
                        }
                    } while (evro == 0);

                    Console.Clear();
                    do
                    {
                        Console.WriteLine("UNESITE DANAŠNJI KURS DOLARA:");
                        dolar = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("UNESITE DANAŠNJU PROVIZIJU ZA DOLARE:");
                        provdol = Convert.ToDecimal(Console.ReadLine());
                        if (dolar == 0)
                        {
                            Console.WriteLine("KURS NE MOŽE BITI 0!");
                            System.Threading.Thread.Sleep(1500);
                            Console.Clear();
                        }
                    } while (dolar == 0);
                    Console.Clear();
                    do
                    {
                        Console.WriteLine("UNESITE DANAŠNJI KURS JENA:");
                        jen = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("UNESITE DANAŠNJU PROVIZIJU ZA JENE:");
                        provjen = Convert.ToDecimal(Console.ReadLine());
                        if (jen == 0)
                        {
                            Console.WriteLine("KURS NE MOŽE BITI 0!");
                            System.Threading.Thread.Sleep(1500);
                            Console.Clear();
                        }
                    } while (jen == 0);
                    Console.Clear();
                    do
                    {
                        Console.WriteLine("UNESITE DANAŠNJI KURS FUNTE:");
                        funta = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("UNESITE DANAŠNJU PROVIZIJU ZA FUNTE:");
                        provfun = Convert.ToDecimal(Console.ReadLine());
                        if (funta == 0)
                        {
                            Console.WriteLine("KURS NE MOŽE BITI 0!");
                            System.Threading.Thread.Sleep(1500);
                            Console.Clear();
                        }
                    } while (funta == 0);
                }
                Console.Clear();
                pocetni();//poziva početni meni
            }

            public void ispiskursa()
            {
                Console.Clear();
                Console.WriteLine("TRENUTNI KURSEVI SU:");
                Console.WriteLine("1 EVRO: " + evro + " DINARA.");
                Console.WriteLine("1 DOLAR: " + dolar + " DINARA.");
                Console.WriteLine("1 JEN: " + jen + " DINARA.");
                Console.WriteLine("1 FUNTA: " + funta + " DINARA.");
                Console.WriteLine("PRITISNI NEŠTO ZA POVRATAK NA IZBOR");
                Console.ReadKey(true);//traži BILO KOJI unos sa tastature da nastavi
                Console.Clear();//briše sadržaj konzole
                pocetni();


            }

            public void ispisprovizija()
            {
                Console.Clear();
                Console.WriteLine("TRENUTNI KURSEVI SU:");
                Console.WriteLine("NA EVRO: " + provev);
                Console.WriteLine("NA DOLAR: " + provdol);
                Console.WriteLine("NA JEN: " + provjen);
                Console.WriteLine("NA FUNTU: " + provfun);
                Console.WriteLine("PRITISNI NEŠTO ZA POVRATAK NA IZBOR");
                Console.ReadKey(true);
                Console.Clear();
                pocetni();


            }

            public void prodajadeviza() //glavna metoda koja radi sav posao
            {

                decimal suma = 0; //koristim decimal jer ima kraći ispis od double (decimal 1/3 = 0.33 a double 1/3 = 0.33333333)
                bool devize = true;
                char izbordevize = 'a';
                char izbor2 = 'd';
                decimal zarada = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("KUPOVINA ILI PRODAJA DEVIZA K / P");
                    izbordevize = Convert.ToChar(Console.ReadLine().ToLower());
                    if (izbordevize == 'k')
                        devize = true;
                    else
                        devize = false;

                    if (devize == true)
                    {
                        Console.WriteLine("KOLIKI IZNOS KUPUJETE?");
                    }
                    else
                        Console.WriteLine("KOLIKI IZNOS PRODAJETE?");
                    this.uplata = Convert.ToDecimal(Console.ReadLine());

                    char izbor = 'e';
                    if (devize == true)
                    {
                        Console.WriteLine("KOJU VALUTU KUPUJETE?");
                    }
                    else
                        Console.WriteLine("KOJU VALUTU PRODAJETE?");
                    Console.WriteLine("E - EVRO");
                    Console.WriteLine("J - JEN");
                    Console.WriteLine("D - DOLAR");
                    Console.WriteLine("F - FUNTA");
                    izbor = Convert.ToChar(Console.ReadLine().ToLower());


                    if ((izbor == 'f') && (devize == true))
                    {
                        isplata = funta * uplata;
                        konisplata = isplata * provfun + isplata;
                        Console.WriteLine("ZA UPLATU: " + konisplata + " DINARA.");
                        zarada = zarada + konisplata - isplata;
                        suma = suma + konisplata;
                        brojac++;
                    }
                    else if ((izbor == 'f') && (devize == false))
                    {
                        isplata = funta * uplata;
                        konisplata = isplata - isplata * provfun;
                        zarada = zarada + isplata - konisplata;
                        suma = suma + konisplata + zarada;
                        Console.WriteLine("ZA ISPLATU: " + konisplata + " DINARA");


                        brojac++;
                    }

                    if ((izbor == 'd') && (devize == true))
                    {
                        isplata = dolar * uplata;
                        konisplata = isplata * provdol + isplata;
                        Console.WriteLine("ZA UPLATU: " + konisplata + " DINARA.");
                        zarada = zarada + konisplata - isplata;
                        suma = suma + konisplata;
                        brojac++;
                    }
                    else if ((izbor == 'd') && (devize == false))
                    {
                        isplata = dolar * uplata;
                        konisplata = isplata - isplata * provdol;
                        zarada = zarada + isplata - konisplata;
                        suma = suma + konisplata + zarada;
                        Console.WriteLine("ZA ISPLATU: " + konisplata + " DINARA");


                        brojac++;
                    }

                    if ((izbor == 'j') && (devize == true))
                    {
                        isplata = jen * uplata;
                        konisplata = isplata * provjen + isplata;
                        Console.WriteLine("ZA UPLATU: " + konisplata + " DINARA.");
                        zarada = zarada + konisplata - isplata;
                        suma = suma + konisplata;
                        brojac++;

                    }
                    else if ((izbor == 'j') && (devize == false))
                    {
                        isplata = jen * uplata;
                        konisplata = isplata - isplata * provjen;
                        zarada = zarada + isplata - konisplata;
                        suma = suma + konisplata + zarada;
                        Console.WriteLine("ZA ISPLATU: " + konisplata + " DINARA");


                        brojac++;
                    }

                    if ((izbor == 'e') && (devize == true))
                    {
                        isplata = evro * uplata;
                        konisplata = isplata * provev + isplata;//konačna isplata
                        Console.WriteLine("ZA UPLATU: " + konisplata + " DINARA.");
                        zarada = zarada + konisplata - isplata;//konisplata - isplata = provizija
                        suma = suma + konisplata;
                        brojac++;
                    }
                    else if ((izbor == 'e') && (devize == false))
                    {
                        isplata = evro * uplata;
                        konisplata = isplata - isplata * provev;
                        zarada = zarada + isplata - konisplata;
                        suma = suma + konisplata + zarada;
                        Console.WriteLine("ZA ISPLATU: " + konisplata + " DINARA");                       

                        brojac++;
                    }

                    Console.WriteLine("ŽELITE LI NOVU TRANSAKCIJU? D/N");
                    izbor2 = Convert.ToChar(Console.ReadLine().ToLower());
                    Console.Clear();
                } while (izbor2 != 'n');


                Console.WriteLine("UKUPAN IZNOS TRANSAKCIJA: " + suma + " DINARA.");
                Console.WriteLine("");
                Console.WriteLine("UKUPNA ZARADA:            " + zarada + " DINARA.");
                Console.WriteLine("");
                brojanje();
            }

            public static void brojanje()
            {
                brojac = brojac - 1;
                Console.WriteLine("BROJ TRANSAKCIJA:         " + brojac); //broj obavljenih transakcija tokom dana
            }

        }


        public static void Main(string[] args)
        {

            menjacnica menjanje = new menjacnica(); // pravim objekat menjanje od klase menjacnica po formuli IMEKLASE IMEOBJEKTA = NEW IMEKLASE
            menjanje.pocetni(); // poziva metodu pocetni za objekat menjanje
            Console.WriteLine("");
            Console.WriteLine("PRITISNI NEŠTO DA IZAĐEŠ");
            Console.ReadKey(true);


        }
    }
}