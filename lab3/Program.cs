using System;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            double a = 0.1;
            double b = 1.0;
            int n = 10;
            double Eps = 0.0001;
            double k = ReadNumber<double>("Введите число k: ");
            double h = (b-a)/k;
            for (int step = 0; step <= k; step++)
            {
                double x = a + step * h;
                double y = (Math.Exp(x) + Math.Exp(-x)) / 2.0;
                double SN = 1;
                double t = 1;
                for (int i = 1; i <= n; i++)
                {
                    t = t * x * x / ((2 * i - 1) * (2 * i));
                    SN += t;
                }
                double SE = 1;
                t = 1;
                int i2 = 1;
                while(Math.Abs(t) >= Eps)
                {
                    t = t * x * x / ((2 * i2 - 1) * (2 * i2));
                    SE += t;
                    i2++;
                }
                Console.WriteLine($"X={x} SN={SN} SE={SE} y={y}");
            }
        }
        static T ReadNumber<T>(string prompt) where T : IParsable<T>
        {
            while (true)
            {
                Console.Write(prompt);
                if (T.TryParse(Console.ReadLine(), null, out var value))
                    return value;
                Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
            }
        }
    }
}