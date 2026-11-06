using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.classes
{
    public class Mammal : Animal
    {
        protected string furColor;
        protected bool isPredator;

        public string FurColor
        {
            get { return furColor; }
            set
            {
                if (value == null)
                {
                    furColor = "Неизвестно";
                }
                else
                {
                    furColor = value;
                }
            }
        }
        public bool IsPredator
        {
            get { return isPredator; }
            set { isPredator = value; }
        }
        public Mammal() : base()
        {
            FurColor = "Неизвестно";
            IsPredator = false;
        }
        public Mammal(string name, double weight, int age, string furColor, bool isPredator) : base(name, weight, age)
        {
            FurColor = furColor;
            IsPredator = isPredator;
        }
        public Mammal(Mammal other) : base(other)
        {
            FurColor = other.FurColor;
            IsPredator = other.IsPredator;
        }

        public override void Show()
        {
            Console.WriteLine($"{base.ToString()}, окрас: {FurColor}, хищник: {(IsPredator ? "Да" : "Нет")}");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            string[] colors = { "Серый", "Белый", "Чёрный", "Рыжий", "Разноцветный" };
            FurColor = colors[rnd.Next(colors.Length)];
            IsPredator = rnd.Next(2) == 1;
        }

    }
}
