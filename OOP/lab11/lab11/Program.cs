using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using lab10.classes;

namespace lab11
{
    internal class Program
    {
        static Random rnd = new Random();

        static Animal CreateRandomAnimal()
        {
            int type = rnd.Next(3);
            Animal a;

            switch (type)
            {
                case 0: a = new Bird(); break;
                case 1: a = new Mammal(); break;
                default: a = new Artiodactyl(); break;
            }

            a.RandomInit();
            return a;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Лабораторная работа №11. Коллекции (вариант 17) ===");
                Console.WriteLine("1 - Задание 1 (ArrayList, необобщённая)");
                Console.WriteLine("2 - Задание 2 (SortedDictionary<int, Animal>, обобщённая)");
                Console.WriteLine("3 - Задание 3 (TestCollections: LinkedList<T> и SortedDictionary<K,T>)");
                Console.WriteLine("0 - Выход");
                Console.Write("Выбор: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный выбор"); break;
                }
            }
        }

        static void Task1()
        {
            ArrayList list = new ArrayList();

            for (int i = 0; i < 5; i++)
                list.Add(CreateRandomAnimal());

            while (true)
            {
                Console.WriteLine("\n--- Задание 1: ArrayList ---");
                Console.WriteLine("1. Добавить случайное животное");
                Console.WriteLine("2. Удалить элемент по индексу");
                Console.WriteLine("3. Показать все элементы (foreach)");
                Console.WriteLine("4. Запрос 1: количество Artiodactyl");
                Console.WriteLine("5. Запрос 2: печать всех Bird");
                Console.WriteLine("6. Запрос 3: средний вес всех животных");
                Console.WriteLine("7. Клонировать коллекцию");
                Console.WriteLine("8. Отсортировать по весу");
                Console.WriteLine("9. Поиск элемента (по имени и весу)");
                Console.WriteLine("0. Назад");
                Console.Write("Выбор: ");

                string? choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        list.Add(CreateRandomAnimal());
                        Console.WriteLine("Добавлено.");
                        break;
                    case "2":
                        Console.Write("Введите индекс для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < list.Count)
                        {
                            list.RemoveAt(idx);
                            Console.WriteLine("Удалено.");
                        }
                        else Console.WriteLine("Неверный индекс.");
                        break;
                    case "3":
                        Console.WriteLine("Элементы ArrayList:");
                        foreach (Animal a in list) Console.WriteLine(a);
                        break;
                    case "4":
                        int artCount = 0;
                        foreach (Animal a in list) if (a is Artiodactyl) artCount++;
                        Console.WriteLine($"Количество Artiodactyl: {artCount}");
                        break;
                    case "5":
                        Console.WriteLine("Птицы:");
                        foreach (Animal a in list) if (a is Bird bird) bird.Show();
                        break;
                    case "6":
                        if (list.Count == 0) { Console.WriteLine("Коллекция пуста."); break; }
                        double sum = 0;
                        foreach (Animal a in list) sum += a.Weight;
                        Console.WriteLine($"Средний вес: {sum / list.Count:F2}");
                        break;
                    case "7":
                        ArrayList clone = (ArrayList)list.Clone();
                        Console.WriteLine($"Клон создан. Элементов в клоне: {clone.Count}");
                        break;
                    case "8":
                        list.Sort();
                        Console.WriteLine("Отсортировано по весу.");
                        break;
                    case "9":
                        Console.Write("Введите имя: ");
                        string? name = Console.ReadLine();
                        Console.Write("Введите вес: ");
                        double weight = Convert.ToDouble(Console.ReadLine());
                        Animal temp = new Mammal(name ?? "", weight, 0, "", false);
                        bool found = list.Contains(temp);
                        Console.WriteLine(found ? "Элемент найден." : "Элемент не найден.");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }

        static void Task2()
        {
            SortedDictionary<int, Animal> dict = new SortedDictionary<int, Animal>();
            int nextId = 1;

            for (int i = 0; i < 5; i++)
                dict.Add(nextId++, CreateRandomAnimal());

            while (true)
            {
                Console.WriteLine("\n--- Задание 2: SortedDictionary<int, Animal> ---");
                Console.WriteLine("1. Добавить случайное животное");
                Console.WriteLine("2. Удалить по ключу");
                Console.WriteLine("3. Показать все элементы (foreach)");
                Console.WriteLine("4. Запрос 1: количество Bird");
                Console.WriteLine("5. Запрос 2: печать всех хищников (Mammal.IsPredator)");
                Console.WriteLine("6. Запрос 3: средний вес Artiodactyl");
                Console.WriteLine("7. Клонировать коллекцию");
                Console.WriteLine("8. Показать коллекцию, отсортированную по весу");
                Console.WriteLine("9. Поиск по ключу");
                Console.WriteLine("0. Назад");
                Console.Write("Выбор: ");

                string? choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        dict.Add(nextId++, CreateRandomAnimal());
                        Console.WriteLine("Добавлено.");
                        break;
                    case "2":
                        Console.Write("Введите ключ для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int key))
                        {
                            if (dict.Remove(key)) Console.WriteLine("Удалено.");
                            else Console.WriteLine("Ключ не найден.");
                        }
                        else Console.WriteLine("Неверный ключ.");
                        break;
                    case "3":
                        Console.WriteLine("Элементы SortedDictionary (по ключу):");
                        foreach (KeyValuePair<int, Animal> kv in dict)
                            Console.WriteLine($"Ключ {kv.Key}: {kv.Value}");
                        break;
                    case "4":
                        int birdCount = 0;
                        foreach (var v in dict.Values) if (v is Bird) birdCount++;
                        Console.WriteLine($"Количество Bird: {birdCount}");
                        break;
                    case "5":
                        Console.WriteLine("Хищники:");
                        foreach (var v in dict.Values) if (v is Mammal m && m.IsPredator) m.Show();
                        break;
                    case "6":
                        var artList = dict.Values.OfType<Artiodactyl>().ToList();
                        if (artList.Count == 0) { Console.WriteLine("Нет Artiodactyl."); break; }
                        Console.WriteLine($"Средний вес Artiodactyl: {artList.Average(x => x.Weight):F2}");
                        break;
                    case "7":
                        SortedDictionary<int, Animal> clone = new SortedDictionary<int, Animal>(dict);
                        Console.WriteLine($"Клон создан. Элементов: {clone.Count}");
                        break;
                    case "8":
                        var sorted = dict.OrderBy(kv => kv.Value.Weight).ToList();
                        Console.WriteLine("Отсортировано по весу:");
                        foreach (var kv in sorted)
                            Console.WriteLine($"Ключ {kv.Key}: {kv.Value}");
                        break;
                    case "9":
                        Console.Write("Введите ключ: ");
                        if (int.TryParse(Console.ReadLine(), out int searchKey))
                            Console.WriteLine(dict.ContainsKey(searchKey) ? "Ключ найден." : "Ключ не найден.");
                        else Console.WriteLine("Неверный ключ.");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }

        static void Task3()
        {
            Console.WriteLine("\n--- Задание 3: TestCollections ---");
            TestCollections ts = new TestCollections(1000);

            Console.WriteLine("Создано 1000 элементов в каждой коллекции.");
            Console.WriteLine($"Collection1 (LinkedList<Artiodactyl>): {ts.Collection1.Count}");
            Console.WriteLine($"Collection1String (LinkedList<string>): {ts.Collection1String.Count}");
            Console.WriteLine($"Collection2 (SortedDictionary<Mammal, Artiodactyl>): {ts.Collection2.Count}");
            Console.WriteLine($"Collection2String (SortedDictionary<string, Artiodactyl>): {ts.Collection2String.Count}");

            ts.MeasureSearch();

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }
    }
}