using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class PlanszaStatkow : Plansza
    {
        private static int instancje = 0;

        public PlanszaStatkow()
        {
            instancje++;
        }

        public void UstawStatki(ref List<Statek> statki)
        {
            for (int i = 0; i < statki.Count; i++)
            {
                int x, y, orientacja;
                bool warunek = false;
                int wielkosc = statki[i].Wielkosc;

                while (warunek == false)
                {
                    Console.WriteLine($"Rozmieść statki na planszy dla GRACZ{instancje}.\nPodaj współrzędne statku {wielkosc} masztowego. ");
                    Console.WriteLine("Współrzędna y: ");
                    Int32.TryParse(Console.ReadLine(), out x);
                    Console.WriteLine("Współrzędna x: ");
                    Int32.TryParse(Console.ReadLine(), out y);
                    Console.WriteLine("Podaj orientacje (0-poziomo/1-pionowo): ");
                    Int32.TryParse(Console.ReadLine(), out orientacja);

                    statki[i].X = x;
                    statki[i].Y = y;
                    statki[i].Orientacja = orientacja;
                    if (orientacja == 0 && (wielkosc + y) <= 11 && ((x != 0) && (y != 0)))
                    {
                        statki[i].UstawienieZyc();
                        polaPlanszy[x, y] = "S";
                        for (int j = 0; j < wielkosc; j++)
                        {
                            polaPlanszy[x, y + j] = "S";
                        }
                        warunek = true;
                    }
                    else if (orientacja == 1 && (wielkosc + x) <= 11 && ((x != 0) && (y != 0)))
                    {
                        statki[i].UstawienieZyc();
                        polaPlanszy[x, y] = "S";
                        for (int k = 0; k < wielkosc; k++)
                        {
                            polaPlanszy[x + k, y] = "S";
                        }
                        warunek = true;
                    }
                    else
                    {
                        Console.WriteLine("Złe umiejscowienie statku");
                    }
                }
                Console.Clear();
                Wyswietl();
            }
            if (instancje == 1)
            {
                Console.WriteLine($"ZAKOŃCZONO rozmieszczanie statków GRACZ{instancje}\nNaciśnij dowolny klawisz by ustawić statki GRACZ{instancje + 1}");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("ZAKOŃCZONO rozmieszczanie statków GRACZ2\n\nGRA ROZPOCZYNA SIĘ\nWciśnij dowolny klawisz");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public override void Wyswietl()
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < PolaX; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("|");
                for (int j = 0; j < PolaY; j++)
                {
                    if (polaPlanszy[i, j] == "S")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(polaPlanszy[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" |");
                    }
                    else if (i > 0 && j > 0)
                    {
                        if (polaPlanszy[i, j] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(polaPlanszy[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" |");
                        }
                        else if (polaPlanszy[i, j] == "*")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(polaPlanszy[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" |");
                        }
                        else
                        {
                            Console.Write(polaPlanszy[i, j] + " |");
                        }
                    }
                    if (i == 0)
                    {
                        Console.Write(polaPlanszy[i, j]);
                    }
                    else if (j == 0)
                    {
                        Console.Write(polaPlanszy[i, j]);
                    }
                }
                Console.WriteLine("\n");
            }
        }

        public void Wyswietl(PlanszaStatkow przeciwnik)
        {
            Wyswietl();
            Console.SetCursorPosition(10, 14);
            Console.WriteLine("Planasza Gracza");
            przeciwnik.x = 40;

            Console.SetCursorPosition(przeciwnik.x, przeciwnik.y);
            for (int i = 0; i < przeciwnik.PolaX; i++)
            {
                Console.SetCursorPosition(przeciwnik.x, przeciwnik.y + i);
                Console.Write("|");
                for (int j = 0; j < przeciwnik.PolaY; j++)
                {

                    if (przeciwnik.polaPlanszy[i, j] == "S")
                    {
                        Console.Write(".");
                        Console.Write(" |");
                    }
                    else if (i > 0 && j > 0)
                    {
                        if (przeciwnik.polaPlanszy[i, j] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(przeciwnik.polaPlanszy[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" |");
                        }
                        else if (przeciwnik.polaPlanszy[i, j] == "*")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(przeciwnik.polaPlanszy[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" |");
                        }
                        else
                        {
                            Console.Write(przeciwnik.polaPlanszy[i, j] + " |");
                        }
                    }

                    if (i == 0)
                    {
                        Console.Write(przeciwnik.polaPlanszy[i, j]);
                    }
                    else if (j == 0)
                    {
                        Console.Write(przeciwnik.polaPlanszy[i, j]);
                    }
                }
                Console.WriteLine("\n");
            }
            przeciwnik.x = 2;
            Console.SetCursorPosition(47, 14);
            Console.WriteLine("Plansza przeciwnika");
        }
    }
}
