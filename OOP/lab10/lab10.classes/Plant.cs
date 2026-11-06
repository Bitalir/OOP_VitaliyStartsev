using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.classes
{
    public class Plant : IInit
    {
        protected string species; 
        protected double height;  

        public string Species
        {
            get { return species; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    species = "Неизвестное растение";
                }
                else
                {
                    species = value;
                }
            }
        }
        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    height = 1.0;
                }
                else
                {
                    height = value;
                }
            }
        }

        public Plant()
        {
            Species = "Неизвестное растение";
            Height = 10.0;
        }
        public Plant(string species, double height)
        {
            Species = species;
            Height = height;
        }
        public void Init()
        {
            Console.WriteLine("Введите вид растения:");
            Species = Console.ReadLine();
            Console.WriteLine("Введите высоту (см):");
            Height = Convert.ToDouble(Console.ReadLine());
        }
        public void RandomInit()
        {
            string[] plantNames = { "Ромашка", "Дуб", "Кактус", "Роза", "Папоротник" };
            Random rnd = new Random();
            Species = plantNames[rnd.Next(plantNames.Length)];
            Height = Math.Round(rnd.NextDouble() * 200 + 5, 1); 
        }
        public override string ToString()
        {
            return $"Растение: {Species}, высота: {Height} см";
        }
    }
}
