namespace LabUlits
{
    public static class ConsoleInput
    {
        public static T ReadNumber<T>(string prompt) where T : IParsable<T>
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
