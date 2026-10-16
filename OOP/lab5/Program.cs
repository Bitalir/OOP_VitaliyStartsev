using LabUtils;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            bool running = true;
            Random rnd = new Random();
            while (running)
            {
                Console.Clear();
                PrintMainMenu();

                int choice = ConsoleInput.Read<int>("Ваш выбор: ");

                switch (choice)
                {
                    case 1: 
                        RunMatrixMenu(rnd);
                        break;
                    case 2:
                        RunJaggedMenu(rnd);
                        break;
                    case 3:
                        RunStringMenu();
                        break;
                    case 4:
                        Console.Clear();
                        Tests.RunAll();
                        Pause();
                        break;
                    case 0:
                        running = false;
                        break;
                }
            }

            Console.WriteLine("Программа завершена.");
        }

        static void PrintMainMenu()
        {
            Console.WriteLine("1. Двумерный массив");
            Console.WriteLine("2. Рваный массив");
            Console.WriteLine("3. Строка");
            Console.WriteLine("4. Автотесты");
            Console.WriteLine("0. Выход");
            Console.WriteLine();
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.Write("Нажмите Enter для продолжения...");
            Console.ReadLine();
        }

        static void RunMatrixMenu(Random rnd)
        {
            int[,]? matrix = null;
            bool inMenu = true;

            while (inMenu)
            {
                Console.Clear();
                PrintMatrixMenu();

                int choice = ConsoleInput.Read<int>("Ваш выбор: ");

                switch (choice)
                {
                    case 1:
                        CreateMatrix(ref matrix, rnd);
                        Pause();
                        break;

                    case 2:
                        if (matrix == null)
                            Console.WriteLine("Массив ещё не создан.");
                        else
                            ArrayUtils.Print(matrix, "Текущий массив");
                        Pause();
                        break;

                    case 3:
                        ExecuteMatrixTask(matrix);
                        Pause();
                        break;

                    case 4:
                        inMenu = false;
                        break;
                }
            }
        }
        static void PrintMatrixMenu()
        {
            Console.WriteLine("=== Двумерный массив ===");
            Console.WriteLine("1. Создать массив");
            Console.WriteLine("2. Вывести массив");
            Console.WriteLine("3. Удалить строки с нулями");
            Console.WriteLine("4. Назад");
            Console.WriteLine();
        }
        static void CreateMatrix(ref int[,]? matrix, Random rnd)
        {
            int rows = ConsoleInput.Read<int>("Количество строк: ");
            int cols = ConsoleInput.Read<int>("Количество столбцов: ");

            Console.WriteLine("Способ заполнения:");
            Console.WriteLine("  1. Вручную");
            Console.WriteLine("  2. Случайно");
            int method = ConsoleInput.Read<int>("Ваш выбор: ");

            try
            {
                if (method == 1)
                {
                    matrix = ArrayUtils.FillManual(rows, cols);
                }
                else
                {
                    int min = ConsoleInput.Read<int>("Минимум: ");
                    int max = ConsoleInput.Read<int>("Максимум: ");
                    matrix = ArrayUtils.FillRandom(rows, cols, min, max, rnd);
                }

                Console.WriteLine("Массив создан.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static void ExecuteMatrixTask(int[,]? matrix)
        {
            if (matrix == null)
            {
                Console.WriteLine("Массив ещё не создан.");
                return;
            }

            try
            {
                int[,] result = MatrixTasks.RemoveRowsWithZero(matrix);
                ArrayUtils.Print(result, "Результат");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static void PrintJaggedMenu()
        {
            Console.WriteLine("=== Рваный массив ===");
            Console.WriteLine("1. Создать массив");
            Console.WriteLine("2. Вывести массив");
            Console.WriteLine("3. Добавить K строк в конец");
            Console.WriteLine("4. Назад");
            Console.WriteLine();
        }
        static void RunJaggedMenu(Random rnd)
        {
            int[][]? jagged = null;
            bool inMenu = true;

            while (inMenu)
            {
                Console.Clear();
                PrintJaggedMenu();

                int choice = ConsoleInput.Read<int>("Ваш выбор: ");

                switch (choice)
                {
                    case 1:
                        CreateJagged(ref jagged, rnd);
                        Pause();
                        break;

                    case 2:
                        if (jagged == null)
                        {
                            Console.WriteLine("Массив ещё не создан.");
                        }
                        else
                        {
                            ArrayUtils.Print(jagged, "Текущий массив");
                        }
                        Pause();
                        break;

                    case 3:
                        ExecuteJaggedTask(ref jagged, rnd);
                        Pause();
                        break;

                    case 4:
                        inMenu = false;
                        break;
                }
            }
        }
        static void CreateJagged(ref int[][]? jagged, Random rnd)
        {
            int rows = ConsoleInput.Read<int>("Количество строк: ");

            Console.WriteLine("Способ заполнения:");
            Console.WriteLine("  1. Вручную");
            Console.WriteLine("  2. Случайно");
            int method = ConsoleInput.Read<int>("Ваш выбор: ");

            try
            {
                if (method == 1)
                {
                    jagged = ArrayUtils.FillManualJagged(rows);
                }
                else
                {
                    int minLen = ConsoleInput.Read<int>("Минимальная длина строки: ");
                    int maxLen = ConsoleInput.Read<int>("Максимальная длина строки: ");
                    int min = ConsoleInput.Read<int>("Минимум элемента: ");
                    int max = ConsoleInput.Read<int>("Максимум элемента: ");

                    jagged = ArrayUtils.FillRandomJagged(rows, minLen, maxLen, min, max, rnd);
                }

                Console.WriteLine("Массив создан.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static void ExecuteJaggedTask(ref int[][]? jagged, Random rnd)
        {
            if (jagged == null)
            {
                Console.WriteLine("Массив ещё не создан.");
                return;
            }

            int k = ConsoleInput.Read<int>("Сколько строк добавить: ");

            Console.WriteLine("Способ заполнения новых строк:");
            Console.WriteLine("  1. Вручную");
            Console.WriteLine("  2. Случайно");
            int method = ConsoleInput.Read<int>("Ваш выбор: ");

            try
            {
                if (method == 1)
                {
                    JaggedTasks.AddKRowsToEnd(ref jagged, k);
                }
                else
                {
                    int minLen = ConsoleInput.Read<int>("Минимальная длина строки: ");
                    int maxLen = ConsoleInput.Read<int>("Максимальная длина строки: ");
                    int min = ConsoleInput.Read<int>("Минимум элемента: ");
                    int max = ConsoleInput.Read<int>("Максимум элемента: ");

                    JaggedTasks.AddKRowsToEnd(ref jagged, k, minLen, maxLen, min, max, rnd);
                }

                ArrayUtils.Print(jagged, "Результат");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static void PrintStringMenu()
        {
            Console.WriteLine("=== Строка ===");
            Console.WriteLine("1. Ввести строку с клавиатуры");
            Console.WriteLine("2. Взять тестовую строку");
            Console.WriteLine("3. Обработать");
            Console.WriteLine("4. Вывести исходную и результат");
            Console.WriteLine("5. Назад");
            Console.WriteLine();
        }
        static void RunStringMenu()
        {
            string? text = null;
            string? processed = null;
            bool inMenu = true;

            while (inMenu)
            {
                Console.Clear();
                PrintStringMenu();

                int choice = ConsoleInput.Read<int>("Ваш выбор: ");

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите строку: ");
                        text = Console.ReadLine() ?? "";
                        processed = null;
                        Pause();
                        break;

                    case 2:
                        text = ChooseTestString();
                        processed = null;
                        Pause();
                        break;

                    case 3:
                        if (text == null)
                        {
                            Console.WriteLine("Строка ещё не введена.");
                        }
                        else
                        {
                            try
                            {
                                processed = StringTasks.ShiftWords(text);
                                Console.WriteLine("Обработка выполнена.");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}");
                            }
                        }
                        Pause();
                        break;

                    case 4:
                        PrintStrings(text, processed);
                        Pause();
                        break;

                    case 5:
                        inMenu = false;
                        break;
                }
            }
        }
        static string ChooseTestString()
        {
            Console.WriteLine("Тестовые строки:");
            for (int i = 0; i < StringTasks.TestStrings.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {StringTasks.TestStrings[i]}");
            }

            int idx = ConsoleInput.Read<int>("Номер: ") - 1;

            if (idx < 0 || idx >= StringTasks.TestStrings.Length)
            {
                Console.WriteLine("Неверный номер. Берётся первая.");
                idx = 0;
            }

            return StringTasks.TestStrings[idx];
        }
        static void PrintStrings(string? text, string? processed)
        {
            if (text == null)
            {
                Console.WriteLine("Исходная строка пуста.");
            }
            else
            {
                Console.WriteLine("Исходная строка:");
                Console.WriteLine(text);
            }

            if (processed == null)
            {
                Console.WriteLine("Результат не получен.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Результат:");
                Console.WriteLine(processed);
            }
        }
    }
    public static class MatrixTasks
    {
        public static int[,] RemoveRowsWithZero(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 0 || cols == 0)
            {
                throw new InvalidOperationException("Массив пуст.");
            }

            bool[] keep = new bool[rows];
            int keepCount = 0;

            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }

                keep[i] = !hasZero;
                if (keep[i])
                { 
                    keepCount++;
                }
            }

            if (keepCount == rows)
            {
                return matrix;
            }

            if (keepCount == 0)
            {
                return new int[0, cols];
            }

            int[,] result = new int[keepCount, cols];
            int newRow = 0;

            for (int i = 0; i < rows; i++)
            {
                if (!keep[i])
                {
                    continue;
                }

                for (int j = 0; j < cols; j++)
                    result[newRow, j] = matrix[i, j];

                newRow++;
            }

            return result;
        }
    }
    public static class JaggedTasks
    {
        public static void AddKRowsToEnd(ref int[][] jagged, int k)
        {
            if (jagged == null)
            {
                throw new InvalidOperationException("Массив ещё не создан.");
            }

            if (k < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(k), "K должно быть больше нуля.");
            }

            int oldLength = jagged.Length;
            Array.Resize(ref jagged, oldLength + k);
            for (int i = oldLength; i < oldLength + k; i++)
            {
                int length;
                do
                {
                    length = ConsoleInput.Read<int>($"Длина строки [{i}]: ");
                    if (length <= 0)
                    {
                        Console.WriteLine("Длина должна быть больше нуля.");
                    }
                } while (length <= 0);
                jagged[i] = new int[length];
                for (int j = 0; j < length; j++)
                {
                    jagged[i][j] = ConsoleInput.Read<int>($"Элемент [{i}][{j}]: ");
                }
            }
        }
        public static void AddKRowsToEnd(ref int[][] jagged, int k, int minLen, int maxLen, int min, int max, Random rnd)
        {
            if (jagged == null)
            {
                throw new InvalidOperationException("Массив ещё не создан.");
            }

            if (k < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(k), "K должно быть больше нуля.");
            }

            if (minLen <= 0)
            {
                throw new ArgumentException("Минимальная длина строки должна быть больше нуля.", nameof(minLen));
            }

            if (maxLen < minLen)
            {
                throw new ArgumentException("Максимальная длина не может быть меньше минимальной.", nameof(maxLen));
            }

            if (min >= max)
            {
                throw new ArgumentException("Минимум должен быть меньше максимума.", nameof(min));
            }

            if (rnd == null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            int oldLength = jagged.Length;
            Array.Resize(ref jagged, oldLength + k);
            for (int i = oldLength; i < oldLength + k; i++)
            {
                int length = rnd.Next(minLen, maxLen + 1);
                jagged[i] = new int[length];
                for (int j = 0; j < length; j++)
                {
                    jagged[i][j] = rnd.Next(min, max + 1);
                }
            }
        }
    }
    public static class StringTasks
    {
        public static readonly string[] TestStrings = new string[]
        {
            "В лесу родилась елочка. В лесу она росла. Зимой и летом стройная, зеленая была.",
            "Привет мир! Как дела?",
            "Один."
        };

        public static string ShiftWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new InvalidOperationException("Строка пуста.");
            }

            MatchCollection sentences = Regex.Matches(text, @"[^.!?]+[.!?]?");

            StringBuilder result = new StringBuilder();

            foreach (Match sentenceMatch in sentences)
            {
                string sentence = sentenceMatch.Value;
                int wordNumber = 0;

                string processed = Regex.Replace(
                    sentence,
                    @"[A-Za-zА-Яа-яЁё]+",
                    match =>
                    {
                        wordNumber++;
                        return ShiftLeft(match.Value, wordNumber);
                    });

                result.Append(processed);
            }

            return result.ToString();
        }

        private static string ShiftLeft(string word, int shift)
        {
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }

            bool wasUpper = char.IsUpper(word[0]);

            shift %= word.Length;
            string shifted = word.Substring(shift) + word.Substring(0, shift);

            shifted = shifted.ToLower();

            if (wasUpper)
            {
                shifted = char.ToUpper(shifted[0]) + shifted.Substring(1);
            }

            return shifted;
        }
    }
    public static class Tests
    {
        private static int passed = 0;
        private static int failed = 0;

        private static void Check(bool condition, string message)
        {
            if (condition)
            {
                Console.WriteLine($"  PASS: {message}");
                passed++;
            }
            else
            {
                Console.WriteLine($"  FAIL: {message}");
                failed++;
            }
        }

        private static bool MatricesEqual(int[,] a, int[,] b)
        {
            if (a == null || b == null)
            {
                return a == b;
            }

            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void RunAll()
        {
            passed = 0;
            failed = 0;

            Console.WriteLine("=== Автотесты ===");
            Console.WriteLine();

            TestRemoveRowsWithZero();
            TestAddKRowsToEnd();
            TestShiftWords();

            Console.WriteLine();
            Console.WriteLine($"Итог: пройдено {passed}, провалено {failed}.");
        }

        private static void TestRemoveRowsWithZero()
        {
            Console.WriteLine("MatrixTasks.RemoveRowsWithZero:");

            int[,] input1 = { { 1, 2 }, { 3, 4 } };
            int[,] result1 = MatrixTasks.RemoveRowsWithZero(input1);
            Check(MatricesEqual(result1, input1), "матрица без нулей не меняется");

            int[,] input2 = { { 1, 0 }, { 3, 4 } };
            int[,] expected2 = { { 3, 4 } };
            int[,] result2 = MatrixTasks.RemoveRowsWithZero(input2);
            Check(MatricesEqual(result2, expected2), "строка с нулём удаляется");

            int[,] input3 = { { 0, 0 }, { 0, 0 } };
            int[,] result3 = MatrixTasks.RemoveRowsWithZero(input3);
            Check(result3.GetLength(0) == 0 && result3.GetLength(1) == 2,
                "все строки с нулями → 0 строк, 2 столбца");

            try
            {
                MatrixTasks.RemoveRowsWithZero(null!);
                Check(false, "null должен бросать ArgumentNullException");
            }
            catch (ArgumentNullException)
            {
                Check(true, "null бросает ArgumentNullException");
            }

            try
            {
                MatrixTasks.RemoveRowsWithZero(new int[0, 0]);
                Check(false, "пустая матрица должна бросать InvalidOperationException");
            }
            catch (InvalidOperationException)
            {
                Check(true, "пустая матрица бросает InvalidOperationException");
            }

            Console.WriteLine();
        }

        private static void TestAddKRowsToEnd()
        {
            Console.WriteLine("JaggedTasks.AddKRowsToEnd (случайная перегрузка):");

            Random rnd = new Random(42);

            int[][] jagged1 = new int[][]
            {
            new int[] { 1, 2 },
            new int[] { 3 },
            new int[] { 4, 5, 6 }
            };

            JaggedTasks.AddKRowsToEnd(ref jagged1, 2, 1, 3, -5, 5, rnd);

            Check(jagged1.Length == 5, "после добавления 2 строк длина равна 5");
            Check(jagged1[3] != null && jagged1[3].Length >= 1 && jagged1[3].Length <= 3,
                "новая строка [3] не null и её длина в [1, 3]");
            Check(jagged1[4] != null && jagged1[4].Length >= 1 && jagged1[4].Length <= 3,
                "новая строка [4] не null и её длина в [1, 3]");

            int[][] jagged2 = { new int[] { 1 } };
            try
            {
                JaggedTasks.AddKRowsToEnd(ref jagged2, 0, 1, 2, -5, 5, rnd);
                Check(false, "k = 0 должен бросать ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                Check(true, "k = 0 бросает ArgumentOutOfRangeException");
            }

            try
            {
                JaggedTasks.AddKRowsToEnd(ref jagged2, -1, 1, 2, -5, 5, rnd);
                Check(false, "k = -1 должен бросать ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                Check(true, "k = -1 бросает ArgumentOutOfRangeException");
            }

            int[][]? jaggedNull = null;
            try
            {
                JaggedTasks.AddKRowsToEnd(ref jaggedNull!, 2, 1, 2, -5, 5, rnd);
                Check(false, "null должен бросать InvalidOperationException");
            }
            catch (InvalidOperationException)
            {
                Check(true, "null бросает InvalidOperationException");
            }

            int[][] jagged3 = { new int[] { 1 } };
            try
            {
                JaggedTasks.AddKRowsToEnd(ref jagged3, 1, 5, 2, -5, 5, rnd);
                Check(false, "minLen > maxLen должен бросать ArgumentException");
            }
            catch (ArgumentException)
            {
                Check(true, "minLen > maxLen бросает ArgumentException");
            }

            Console.WriteLine();
        }

        private static void TestShiftWords()
        {
            Console.WriteLine("StringTasks.ShiftWords:");

            string input1 = "В лесу родилась елочка. В лесу она росла. Зимой и летом стройная, зеленая была.";
            string expected1 = "В суле иласьрод каелоч. В суле она аросл. Имойз и омлет йнаястро, аязелен лабы.";
            string result1 = StringTasks.ShiftWords(input1);
            Check(result1 == expected1, "строка из примера варианта 17 совпадает с эталоном");

            try
            {
                StringTasks.ShiftWords("");
                Check(false, "пустая строка должна бросать InvalidOperationException");
            }
            catch (InvalidOperationException)
            {
                Check(true, "пустая строка бросает InvalidOperationException");
            }

            try
            {
                StringTasks.ShiftWords("   ");
                Check(false, "строка из пробелов должна бросать InvalidOperationException");
            }
            catch (InvalidOperationException)
            {
                Check(true, "строка из пробелов бросает InvalidOperationException");
            }

            string result3 = StringTasks.ShiftWords("Привет мир! Как дела?");
            Check(result3.Contains("!") && result3.Contains("?"),
                "знаки ! и ? сохраняются в результате");

            Console.WriteLine();
        }
    }
}