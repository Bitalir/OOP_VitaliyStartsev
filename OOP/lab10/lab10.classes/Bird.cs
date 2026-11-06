using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.classes
{
    public class Bird : Animal
    {
        protected double wingspan; // размах крыльев
        protected bool canFly;

        public double Wingspan
        {
            get { return wingspan; }
            set
            {
                if (value <= 0)
                {
                    wingspan = 1.0;
                }
                else
                {
                    wingspan = value;
                }
            }
        }
        public bool CanFly
        {
            get { return canFly; }
            set { canFly = value; }
        }
        public Bird() : base()
        {
            Wingspan = 1.0;
            CanFly = true;
        }
        public Bird(string name, double weight, int age, double wingspan, bool canFly) : base(name, weight, age)
        {
            Wingspan = wingspan;
            CanFly = canFly;
        }
        public Bird(Bird other) : base(other)
        {
            Wingspan = other.Wingspan;
            CanFly = other.CanFly;
        }

        public override void Show()
        {
            Console.WriteLine($"{base.ToString()}, размах крыльев: {Wingspan:F2} м, умеет летать: {(CanFly ? "Да" : "Нет")}");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Wingspan = Math.Round(rnd.NextDouble() * 3.3 + 0.2, 2);
            CanFly = rnd.Next(10) < 8;
        }

    }
}
