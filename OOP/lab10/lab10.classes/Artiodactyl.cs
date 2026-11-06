using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.classes
{
    public class Artiodactyl : Mammal
    {
        protected int hoofCount; // колво копыт
        protected bool hasHorns; // рога

        public int HoofCount
        {
            get { return hoofCount; }
            set
            {
                if (value % 2 == 0 && value >= 2)
                {
                    hoofCount = value;
                }
                else
                {
                    hoofCount = 2;
                }
            }
        }
        public bool HasHorns
        {
            get { return hasHorns; }
            set { hasHorns = value; }
        }

        public Artiodactyl() : base()
        {
            HoofCount = 2;
            HasHorns = true;
        }
        public Artiodactyl(string name, double weight, int age, string furColor, bool isPredator, int hoofCount, bool hasHorns) : base(name, weight, age, furColor, isPredator)
        {
            HoofCount = hoofCount;
            HasHorns = hasHorns;
        }
        public Artiodactyl(Artiodactyl other) : base(other)
        {
            HoofCount= other.HoofCount;
            HasHorns = other.HasHorns;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"   Копыт: {HoofCount}, Рога: {(HasHorns ? "Да" : "Нет")}");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            HoofCount = rnd.Next(1, 3) * 2; 
            HasHorns = rnd.Next(2) == 1;
        }
    }
}
