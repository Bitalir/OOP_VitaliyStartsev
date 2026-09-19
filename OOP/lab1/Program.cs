using System;

namespace Lab1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== Меню ===");
                Console.WriteLine("0 - Выход из программы");
                Console.WriteLine("1 - Выполнить задание 1");
                Console.WriteLine("2 - Выполнить задание 2");
                Console.WriteLine("3 - Выполнить задание 3");
                Console.Write("Выберите пункт (0-3): ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Выход из программы. Пока!");
                        return;

                    case "1":
                        Run1();
                        break;

                    case "2":
                        Run2();
                        break;
                    case "3":
                        Run3();
                        break;
                    default:
                        Console.WriteLine("Ошибка: введите цифру от 0 до 9.");
                        break;
                }
            }
        }
        static void Run1()
        {
            Console.Write("Введите число n: ");
            var i1 = Console.ReadLine();
            Console.Write("Введите число m: ");
            var i2 = Console.ReadLine();
            Console.Write("Введите число x: ");
            var i3 = Console.ReadLine();

            if (double.TryParse(i1, out double n) && double.TryParse(i2, out double m) && double.TryParse(i3, out double x))
            {
                double mfunck1 = (n++) + (m--);
                Console.WriteLine($"Вывод первой операции (n+++m--): {mfunck1}");

                bool mfunck2 = (n * m) < n++;
                Console.WriteLine($"Вывод второй операции (n*m<n++): {mfunck2}");

                bool mfunck3 = (n--) > ++m;
                Console.WriteLine($"Вывод третьей операции (n-->++m): {mfunck3}");

                double funcdop = x + Math.Pow(x, 2);
                if (-1 <= funcdop && 1 >= funcdop)
                {
                    double mfunck4 = Math.Asin(funcdop);
                    Console.WriteLine($"Вывод четвёртой операции: {mfunck4}");
                }
                else
                {
                    Console.WriteLine("Ошибка: arcsin может быть при значении агрумента функции в диапазоне [-1; 1]");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: пожалуйста, введите корректные числа.");
            }
        }
        static void Run2()
        {
            Console.Write("Введите координату X1: ");
            var ix = Console.ReadLine();
            Console.Write("Введите координату Y1: ");
            var iy = Console.ReadLine();

            if (double.TryParse(ix, out double x1) && double.TryParse(iy, out double y1))
            {
                bool isInside = (x1 >= -7 && x1 <= 0 && y1 >= -5 && y1 <= -3) ||
                                (x1 >= 0 && x1 <= 7 && y1 >= 2 && y1 <= 5);

                if (isInside)
                {
                    Console.WriteLine("Точка принадлежит заштрихованной области.");
                }
                else
                {
                    Console.WriteLine("Точка не принадлежит заштрихованной области.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: пожалуйста, введите корректные числа.");
            }
        }
        static void Run3()
        {
            double a = 1000;
            double b = 0.0001;
            double mfunc = Math.Pow((a - b), 4) - (Math.Pow(a, 4) + 6 * Math.Pow(a, 2) * Math.Pow(b, 2) - 4 * a * Math.Pow(b, 3)) / (Math.Pow(b, 4) - 4 * Math.Pow(a, 3) * b);
            Console.WriteLine($"Вывод операции при a = 1000, b = 0.0001: {mfunc}");
        }
    }
}
