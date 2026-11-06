using System;

namespace lab10.classes
{
    public abstract class Animal : IInit, IComparable, ICloneable
    {
        protected string name;
        protected double weight;
        protected int age;
        protected static Random rnd = new Random();

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    name = "Без имени";
                }
                else
                {
                    name = value;
                }
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value <= 0)
                {
                    weight = 1.0;
                }
                else
                {
                    weight = value;
                }
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    age = 0;
                }
                else
                {
                    age = value;
                }
            }
        }
        public Animal() { }
        public Animal(string name, double weight, int age)
        {
            Name = name;
            Weight = weight;
            Age = age;
        }
        public Animal(Animal other)
        {
            Name = other.Name;
            Weight = other.Weight;
            Age = other.Age;
        }
        public abstract void Show();
        public virtual void Init()
        {
            Console.WriteLine("Введите имя: ");
            Name = Console.ReadLine();
            Console.WriteLine("Введите вес:");
            Weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите возраст:");
            Age = Convert.ToInt32(Console.ReadLine());
        }
        public virtual void RandomInit()
        {
            string[] names = { "Барсик", "Шарик", "Кеша", "Василёк", "Мурка", "Плуто", "Бегемот" };
            Name = names[rnd.Next(names.Length)];
            Weight = Math.Round(rnd.NextDouble() * 100 + 0.5, 2);
            Age = rnd.Next(0, 31);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Animal other)
            {
                return this.Name == other.Name && Math.Abs(this.Weight - other.Weight) < 0.0001;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Weight);
        }
        public override string ToString()
        {
            return $"{Name}, вес: {Weight:F2} кг, возраст: {Age} лет";
        }

        public int CompareTo(object? obj)
        {
            if (obj is Animal other)
            {
                return this.Weight.CompareTo(other.Weight);
            }
            throw new ArgumentException("Объект не является Animal");
        }

        public object Clone() // глубокое
        {
            Animal clone = (Animal)this.MemberwiseClone();
            clone.Name = "Клон " + this.Name;
            return clone;
        }
        public Animal ShallowCopy()
        {
            return (Animal)this.MemberwiseClone();
        }
    } 
}
