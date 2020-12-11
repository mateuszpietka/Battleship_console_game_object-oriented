using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Statek
    {
        private int x, y;
        private int rozmiar;
        private int orientacja;
        private int[] zycia;

        public int Wielkosc { get { return rozmiar; } set { if (value > 0) { rozmiar = value; } } }
        public int X { get { return x; } set { if (value >= 1 && value < 11) { x = value; } } }
        public int Y { get { return y; } set { if (value >= 1 && value < 11) { y = value; } } }
        public int Orientacja { get { return orientacja; } set { if (value == 1 || value == 0) { orientacja = value; } } }


        //Konstruktor utworzony na potrzeby metody.
        private Statek()
        {
            rozmiar = 0;
        }

        //Konstrukto publiczny
        public Statek(int rozmiar)
        {
            this.rozmiar = rozmiar;
            zycia = new int[rozmiar];
        }

        /// <summary>
        /// Metoda klonowania listy obiektów typu Statek.
        /// </summary>
        /// <param name="lista"></param>
        /// <returns>Zwraca nową Liste obiektów typu Statek</returns>
        public List<Statek> KopiowanieKolekcji(List<Statek> lista)
        {
            List<Statek> kopiaListy = new List<Statek>();
            for (int i = 0; i < lista.Count; i++)
            {
                Statek kopia = new Statek();
                kopia.rozmiar = lista[i].rozmiar;
                kopia.zycia = new int[kopia.rozmiar];
                kopiaListy.Add(kopia);
            }
            return kopiaListy;
        }

        public void UstawienieZyc()
        {
            if (orientacja == 0)
            {
                for (int i = 0; i < zycia.Length; i++)
                {
                    zycia[i] = x * 10 + (y + i);
                }
            }
            else
            {
                for (int i = 0; i < zycia.Length; i++)
                {
                    zycia[i] = (x * 10 + i * 10) + y;
                }
            }

        }

        public void ZmniejszenieZycia(int x, int y)
        {
            for (int i = 0; i < zycia.Length; i++)
            {
                if (zycia[i] == (x * 10 + y))
                {
                    zycia[i] = 0;
                }
            }
        }

        public bool CzyZatopiony()
        {
            for (int i = 0; i < zycia.Length; i++)
            {
                if (zycia[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
