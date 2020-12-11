using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    abstract class Mechanika
    {
        public void InfoStartowe()
        {
            Console.SetCursorPosition(7, 0);
            Console.WriteLine("Witaj w grze morskiej!");
            Console.SetCursorPosition(7, 1);
            Console.WriteLine("Oto twoje pole bitwy:\n");
            PustaPlansza pustaPlansza = new PustaPlansza();
            pustaPlansza.Wyswietl();
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("\nBy kontynuować wciśnij dowolny klawisz\n");
            Console.ReadKey();
        }

        protected int Ostrzal(int x, int y, ref PlanszaStatkow plansza, ref List<Statek> statki)
        {
            if (plansza.PolaPlanszy[x, y] == "S")
            {
                plansza.PolaPlanszy[x, y] = "X";
                for (int i = 0; i < statki.Count; i++)
                {
                    statki[i].ZmniejszenieZycia(x, y);
                    if (statki[i].CzyZatopiony())
                    {
                        OtoczenieZatopionego(i, ref plansza, ref statki);
                    }
                }
                return 1;
            }
            else
            {
                if (plansza.PolaPlanszy[x, y] == ".")
                {
                    plansza.PolaPlanszy[x, y] = "*";
                }
                return 0;
            }
        }

        protected int SprWygranej(PlanszaStatkow plansza)
        {
            for (int i = 0; i < plansza.PolaX; i++)
            {
                for (int j = 0; j < plansza.PolaY; j++)
                {
                    if (plansza.PolaPlanszy[i, j] == "S")
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }

        private void OtoczenieZatopionego(int i, ref PlanszaStatkow plansza, ref List<Statek> statki)
        {
            if (statki[i].Orientacja == 0)
            {
                for (int j = statki[i].X - 1; j <= statki[i].X + 1; j++)
                {
                    for (int k = statki[i].Y - 1; k <= statki[i].Y + statki[i].Wielkosc; k++)
                    {
                        if (j > 0 && j < plansza.PolaX && k > 0 && k < plansza.PolaY)
                        {
                            if (plansza.PolaPlanszy[j, k] == ".")
                            {
                                plansza.PolaPlanszy[j, k] = "*";
                            }
                        }
                    }
                }
            }
            else
            {
                for (int j = statki[i].X - 1; j <= statki[i].X + statki[i].Wielkosc; j++)
                {
                    for (int k = statki[i].Y - 1; k <= statki[i].Y + 1; k++)
                    {
                        if (j > 0 && j < plansza.PolaX && k > 0 && k < plansza.PolaY)
                        {
                            if (plansza.PolaPlanszy[j, k] == ".")
                            {
                                plansza.PolaPlanszy[j, k] = "*";
                            }
                        }
                    }
                }
            }
        }
    }
}
