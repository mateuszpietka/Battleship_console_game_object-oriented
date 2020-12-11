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
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < PolaX; i++)
            {
                Console.SetCursorPosition(x, y + i);
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
