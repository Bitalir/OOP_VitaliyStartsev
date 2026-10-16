using System.Xml.Serialization;

namespace LabUtils
{
    public static class ConsoleInput
    {
        public static T Read<T>(string prompt) where T : IParsable<T>
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
    public static class ArrayUtils
    {
        public static void Print(int[,] matrix, string title = "Матрица")
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                Console.WriteLine($"{title}: пусто");
                return;
            }
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            Console.WriteLine($"{title}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }
        public static int[,] FillRandom(int rows, int cols, int min, int max, Random rnd)
        {
            if (rows <= 0)
                throw new ArgumentException("Количество строк должно быть больше нуля.", nameof(rows));

            if (cols <= 0)
                throw new ArgumentException("Количество столбцов должно быть больше нуля.", nameof(cols));

            if (min >= max)
                throw new ArgumentException("Минимум должен быть меньше максимума.", nameof(min));

            if (rnd == null)
                throw new ArgumentNullException(nameof(rnd));

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = rnd.Next(min, max + 1);
                }
            }

            return result;
        }
        public static int[,] FillManual(int rows, int cols)
        {
            if (rows <= 0)
                throw new ArgumentException("Количество строк должно быть больше нуля.", nameof(rows));

            if (cols <= 0)
                throw new ArgumentException("Количество столбцов должно быть больше нуля.", nameof(cols));

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = ConsoleInput.Read<int>($"Элемент [{i}, {j}]: ");
                }
            }

            return result;
        }
        public static void Print(int[][] jagged, string title = "Рваный массив")
        {
            if (jagged == null || jagged.Length == 0)
            {
                Console.WriteLine($"{title}: пусто.");
                return;
            }

            Console.WriteLine($"{title}:");

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.Write($"[{i}] ");

                if (jagged[i] == null)
                {
                    Console.WriteLine("null");
                    continue;
                }

                if (jagged[i].Length == 0)
                {
                    Console.WriteLine("(пустая строка)");
                    continue;
                }

                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j],5}");
                }

                Console.WriteLine();
            }
        }
        public static int[][] FillRandomJagged(int rows, int minLen, int maxLen, int min, int max, Random rnd)
        {
            if (rows <= 0)
            {
                throw new ArgumentException("Количество строк должно быть больше нуля.", nameof(rows));
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

            int[][] result = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int length = rnd.Next(minLen, maxLen + 1);
                result[i] = new int[length];

                for (int j = 0; j < length; j++)
                {
                    result[i][j] = rnd.Next(min, max + 1);
                }
            }

            return result;
        }
        public static int[][] FillManualJagged(int rows)
        {
            if (rows <= 0) {
                throw new ArgumentException("Количество строк должно быть больше нуля.", nameof(rows));
            }

            int[][] result = new int[rows][];

            for (int i = 0; i < rows; i++)
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

                result[i] = new int[length];

                for (int j = 0; j < length; j++)
                {
                    result[i][j] = ConsoleInput.Read<int>($"Элемент [{i}][{j}]: ");
                }
            }
            return result;
        }

    }
}
