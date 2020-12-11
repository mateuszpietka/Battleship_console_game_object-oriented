using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Gra : Mechanika
    {
        public PlanszaStatkow gracz1;
        public List<Statek> statkiGracza1;
        public PlanszaStatkow gracz2;
        public List<Statek> statkiGracza2;

        //Jawany kosntrukto bazowy.
        public Gra() { }

        public void Start()
        {
            int x, y, warunekTrafienia;
            bool warunekWpisania = true;
            Console.Clear();
            Console.SetCursorPosition(2, 0);
            Console.WriteLine("Rozpoczyna GRACZ1\n  Nacisnij kalwisz");
            Console.ReadKey();
            do
            {
                warunekTrafienia = 1;
                for (int i = 0; warunekTrafienia == 1 && SprWygranej(gracz2) == 0; i++)
                {
                    warunekWpisania = true;
                    Console.Clear();
                    Console.SetCursorPosition(35, 0);
                    Console.WriteLine("GRACZ1");
                    if (i == 0)
                    {
                        Console.WriteLine("Naciśnij klawisz");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("TRAFIONY");
                    }
                    gracz1.Wyswietl(gracz2);

                    while (warunekWpisania)
                    {
                        Console.WriteLine("\nPodaj współrzędne do ostrzału: ");
                        Console.WriteLine("Współrzędna y: ");
                        Int32.TryParse(Console.ReadLine(), out x);
                        Console.WriteLine("Współrzędna x: ");
                        Int32.TryParse(Console.ReadLine(), out y);
                        if (x > 0 && x < gracz1.PolaX && y > 0 && y < gracz1.PolaY)
                        {
                            warunekTrafienia = Ostrzal(x, y, ref gracz2, ref statkiGracza2);
                            warunekWpisania = false;
                        }
                    }
                }
                warunekTrafienia = 1;
                for (int i = 0; warunekTrafienia == 1 && SprWygranej(gracz1) == 0 && SprWygranej(gracz2) == 0; i++)
                {
                    warunekWpisania = true;
                    Console.Clear();
                    Console.SetCursorPosition(35, 0);
                    Console.WriteLine("GRACZ2");
                    if (i == 0)
                    {
                        Console.WriteLine("\nNaciśnij klawisz");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("TRAFIONY");
                    }
                    gracz2.Wyswietl(gracz1);
                    while (warunekWpisania)
                    {
                        Console.WriteLine("\nPodaj współrzędne do ostrzału: ");
                        Console.WriteLine("Współrzędna y: ");
                        Int32.TryParse(Console.ReadLine(), out x);
                        Console.WriteLine("Współrzędna x: ");
                        Int32.TryParse(Console.ReadLine(), out y);
                        if (x > 0 && x < gracz2.PolaX && y > 0 && y < gracz2.PolaY)
                        {
                            warunekTrafienia = Ostrzal(x, y, ref gracz1, ref statkiGracza1);
                            warunekWpisania = false;
                        }
                    }
                }
            } while (SprWygranej(gracz1) == 0 && SprWygranej(gracz2) == 0);

            Console.Clear();

            Console.WriteLine("KONIEC GRY");
            if (SprWygranej(gracz1) == 1) { Console.WriteLine("Wygrał GRACZ2"); }
            if (SprWygranej(gracz2) == 1) { Console.WriteLine("Wygrał GRACZ1"); }

            Console.ReadKey();
        }
    }
}
