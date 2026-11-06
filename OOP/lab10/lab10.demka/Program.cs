using System;
using lab10.classes;

namespace lab10.demka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Animal[] animals = new Animal[10];

            Console.WriteLine("=== Заполнение массива случайными животными ===");

            for (int i = 0; i < animals.Length; i++)
            {
                switch (rnd.Next(3))
                {
                    case 0:
                        animals[i] = new Mammal();
                        break;
                    case 1:
                        animals[i] = new Bird();
                        break;
                    case 2:
                        animals[i] = new Artiodactyl();
                        break;
                }
                animals[i].RandomInit();
            }

            Console.WriteLine("\n=== Список животных в массиве ===");
            foreach (Animal a in animals)
            {
                a.Show();
            }
            Console.WriteLine("\n==========================================");
            Console.WriteLine("ЧАСТЬ 2: ЗАПРОСЫ К МАССИВУ");
            Console.WriteLine("==========================================");
            Console.WriteLine("\n1. Хищные млекопитающие:");
            foreach (Animal a in animals)
            {
                if (a is Mammal mammal)
                {
                    if (mammal.IsPredator)
                    {
                        Console.WriteLine($" - {mammal.Name} (Вес: {mammal.Weight} кг)");
                    }
                }
            }

            Console.Write("\n2. Введите минимальный размах крыльев (м) для поиска птиц: ");
            double minWingspan = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Птицы с размахом крыльев > {minWingspan} м:");
            foreach (Animal a in animals)
            {
                Bird bird = a as Bird;
                if (bird != null && bird.Wingspan > minWingspan)
                {
                    Console.WriteLine($" - {bird.Name} (Размах: {bird.Wingspan} м)");
                }
            }

            int hornedCount = 0;
            foreach (Animal a in animals)
            {
                if (a is Artiodactyl)
                {
                    Artiodactyl art = (Artiodactyl)a;
                    if (art.HasHorns)
                    {
                        hornedCount++;
                    }
                }
            }
            Console.WriteLine($"\n3. Количество парнокопытных с рогами в массиве: {hornedCount}");
            Console.WriteLine("\n==========================================");
            Console.WriteLine("ЧАСТЬ 3: МАССИВ ИНТЕРФЕЙСОВ IINIT");
            Console.WriteLine("==========================================");

            IInit[] initArray = new IInit[5];
            initArray[0] = new Bird();
            initArray[1] = new Artiodactyl();
            initArray[2] = new Plant();
            initArray[3] = new Mammal();
            initArray[4] = new Plant();

            Random myRnd = new Random();
            for (int i = 0; i < initArray.Length; i++)
            {
                initArray[i].RandomInit();
            }

            Console.WriteLine("Сгенерированные объекты (Животные и Растения):");
            foreach (IInit item in initArray)
            {
                if (item is Animal animal)
                {
                    animal.Show();
                }
                else if (item is Plant plant)
                {
                    Console.WriteLine(plant.ToString());
                }
            }
            Console.WriteLine("\n==========================================");
            Console.WriteLine("ЧАСТЬ 3: СОРТИРОВКА И ПОИСК");
            Console.WriteLine("==========================================");
            Console.WriteLine("\n1. Сортировка по весу (IComparable):");
            Array.Sort(animals);
            foreach (Animal a in animals)
            {
                Console.WriteLine($"{a.Name} - {a.Weight} кг");
            }

            Console.WriteLine("\n2. Сортировка по имени (IComparer):");
            Array.Sort(animals, new SOrtByName());
            foreach (Animal a in animals)
            {
                Console.WriteLine($"{a.Name} - {a.Weight} кг");
            }

            Console.WriteLine("\n3. Бинарный поиск по имени:");
            Console.Write("Введите имя животного для поиска: ");
            string searchName = Console.ReadLine();
            Mammal searchTarget = new Mammal();
            searchTarget.Name = searchName;
            int index = Array.BinarySearch(animals, searchTarget, new SOrtByName());
            if (index >= 0)
            {
                Console.WriteLine($"Животное найдено на позиции {index}!");
                animals[index].Show();
            }
            else
            {
                Console.WriteLine("Животное с таким именем не найдено.");
            }
            Console.WriteLine("\n==========================================");
            Console.WriteLine("ЧАСТЬ 3: КЛОНИРОВАНИЕ (ICLONEABLE)");
            Console.WriteLine("==========================================");
            Animal original = animals[0];
            Console.WriteLine("Оригинал: ");
            original.Show();

            Animal linkCopy = original;
            linkCopy.Name = "Измененный через ссылку";
            Console.WriteLine("\nПосле изменения ссылки, оригинал стал:");
            original.Show();
            original.Name = "Оригинал";

            Animal shallow = original.ShallowCopy();
            Console.WriteLine("\nПоверхностная копия (ShallowCopy):");
            shallow.Show();

            Animal deepClone = (Animal)original.Clone();
            Console.WriteLine("\nКлон (Clone):");
            deepClone.Show();
        }
    }
}