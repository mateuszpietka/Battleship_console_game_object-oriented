using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    /// <summary>
    /// Klasa Plansza inicjująca pola planszy.
    /// </summary>
    abstract class Plansza
    {
        private const int polaX = 11;
        private const int polaY = 11;
        protected string[,] polaPlanszy;
        protected int x = 2, y = 2;

        public int PolaX { get { return polaX; } }
        public int PolaY { get { return polaY; } }
        public string[,] PolaPlanszy { get { return polaPlanszy; } }

        public Plansza()
        {
            TworzeniePlanszy();
        }

        public abstract void Wyswietl();


        private void TworzeniePlanszy()
        {
            polaPlanszy = new string[polaX, polaY];
            for (int i = 0; i < polaX; i++)
            {
                for (int j = 0; j < polaY; j++)
                {
                    polaPlanszy[i, j] = ".";
                    if (i == 0)
                    {
                        polaPlanszy[i, j] = j.ToString() + " |";
                        if (j == 10) { polaPlanszy[i, j] = j.ToString() + "|"; }
                    }
                    if (j == 0)
                    {
                        polaPlanszy[i, j] = i.ToString() + " |";
                        if (i == 10) { polaPlanszy[i, j] = i.ToString() + "|"; }
                    }
                }
            }
        }
    }
}
