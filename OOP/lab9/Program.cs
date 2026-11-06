using OOP_lab9;
using System;
using LabUtils;

InputOutput io = new InputOutput();
bool f = true;

while (f)
{
    int choice = ConsoleInput.Read<int>("\nВыберите часть для проверки (1, 2, 3) или 0 для выхода: ");

    switch (choice)
    {
        case 1:
            {
                Console.WriteLine("\n--- ЧАСТЬ 1 ---");
                Money m1 = new Money();
                Money m2 = new Money(10, 50);
                Money m3 = io.ReadMoney();
                io.Write(m1);
                io.Write(m2);
                io.Write(m3);
                io.Write($"Создано объектов: {Money.Count}");
                Money res1 = Money.SubtractKopeks(m2, 60);
                Money res2 = m2.SubtractKopeks(100);
                io.Write(res1);
                io.Write(res2);
                try
                {
                    m1.SubtractKopeks(10);
                }
                catch (ArgumentException ex)
                {
                    io.Write(ex.Message);
                }
                break;
            }
        case 2:
            {
                Console.WriteLine("\n--- ЧАСТЬ 2 ---");
                io.Write("--- Унарные операторы ---");
                Money m1 = new Money(5, 99);
                m1++;
                io.Write($"m1++ (было 5.99): {m1}");

                Money m2 = new Money(5, 0);
                m2--;
                io.Write($"m2-- (было 5.00): {m2}");

                io.Write("\n--- Приведение типов ---");
                int rubles = (int)m1;
                io.Write($"Целых рублей в m1: {rubles}");

                if (m2)
                {
                    io.Write("m2 не равно нулю (true)");
                }
                else
                {
                    io.Write("m2 равно нулю (false)");
                }
                io.Write("\n--- Бинарные операторы ---");
                Money m3 = new Money(10, 0);
                Money m4 = new Money(3, 50);

                io.Write($"10.00 - 50 копеек = {m3 - 50}");
                io.Write($"1000 копеек - 3.50 = {1000 - m4}");
                io.Write($"10.00 - 3.50 = {m3 - m4}");

                io.Write("\n--- Проверка исключения ---");
                try
                {
                    Money badRes = m4 - m3;
                }
                catch (ArgumentException ex)
                {
                    io.Write($"Поймали ошибку: {ex.Message}");
                }
                break;
            }
        case 3:
            {
                Console.WriteLine("\n--- ЧАСТЬ 3 ---");
                MoneyArray a1 = new MoneyArray();
                io.Write("Пустая коллекция создана. Ее длина: " + a1.Length);

                MoneyArray a2 = new MoneyArray(5);
                io.Write("\nСлучайная коллекция:");
                a2.Print(io);

                io.Write("\nВведите элементы для коллекции с клавиатуры:");
                MoneyArray a3 = new MoneyArray(3, io);
                io.Write("\nКоллекция с клавиатуры:");
                a3.Print(io);

                io.Write($"\nСреднее арифметическое случайной коллекции: {GetAverage(a2)}");

                io.Write("\n--- Проверка индексатора (выход за границы) ---");
                try
                {
                    Money bad = a2[10];
                }
                catch (ArgumentException ex)
                {
                    io.Write($"Поймали ошибку: {ex.Message}");
                }
                io.Write($"\nВсего создано коллекций MoneyArray: {MoneyArray.Count}");

                break;
            }
        case 0:
            {
                Console.WriteLine("Пока");
                f = false;
                break;
            }
        default:
            {
                Console.WriteLine("Такой части нет. Попробуйте еще раз.");
                break;
            }
    }
}

Money GetAverage(MoneyArray array)
{
    if (array.Length == 0)
    {
        return new Money(0, 0);
    }

    long totalKopeks = 0;
    for (int i = 0; i < array.Length; i++)
    {
        totalKopeks += array[i].Rubles * 100 + array[i].Kopeks;
    }
    long averageKopeks = totalKopeks / array.Length;
    return new Money((int)(averageKopeks / 100), (int)(averageKopeks % 100));
}