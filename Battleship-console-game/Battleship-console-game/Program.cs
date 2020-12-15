using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    class Program
    {
        static void Main(string[] args)
        {
            Gra gra = new Gra();
            gra.InfoStartowe();

            List<Statek> statkiGracza1 = new List<Statek>(); //Tworzenie statków jako obiektów i spakowanie ich do listy.    
            Statek statek = new Statek(4);
            statkiGracza1.Add(statek);
            statek = new Statek(4);
            statkiGracza1.Add(statek);
            statek = new Statek(3);
            statkiGracza1.Add(statek);
            statek = new Statek(3);
            statkiGracza1.Add(statek);
            statek = new Statek(2);
            statkiGracza1.Add(statek);
            statek = new Statek(2);
            statkiGracza1.Add(statek);
            statek = new Statek(1);
            statkiGracza1.Add(statek);
            statek = new Statek(1);
            statkiGracza1.Add(statek);

            List<Statek> statkiGracza2 = statek.KopiowanieKolekcji(statkiGracza1); //Utworzenie listy i klonowanie obiektów

            PlanszaStatkow planszaGracz1 = new PlanszaStatkow();//Tworzenie indywidualnej planszy i rozstawienie statków dla każdego gracza. 
            planszaGracz1.UstawStatki(ref statkiGracza1);

            PlanszaStatkow planszaGracz2 = new PlanszaStatkow();
            planszaGracz2.Wyswietl();
            planszaGracz2.UstawStatki(ref statkiGracza2);
          
            gra.Start(planszaGracz1, statkiGracza1, planszaGracz2, statkiGracza2);
        }
    }
}
