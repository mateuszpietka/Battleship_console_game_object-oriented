using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class PustaPlansza : Plansza
    {
        public override void Wyswietl()
        {
            Console.SetCursorPosition(pozycjaKursoraX, pozycjaKursoraY);
            for (int i = 0; i < PolaX; i++)
            {
                Console.SetCursorPosition(pozycjaKursoraX, pozycjaKursoraY + i);
                Console.Write("|");
                for (int j = 0; j < PolaY; j++)
                {
                    if (i > 0 && j > 0)
                    {
                        Console.Write(polaPlanszy[i, j] + " |");
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
    }
}
