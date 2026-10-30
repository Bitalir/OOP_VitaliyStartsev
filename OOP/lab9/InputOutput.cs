using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabUtils;

namespace OOP_lab9
{
    public class InputOutput
    {
        public Money ReadMoney()
        {
            int rubles = ConsoleInput.Read<int>("Введите количество рублей: ");
            int kopeks = ConsoleInput.Read<int>("Введите количество копеек: ");
            return new Money(rubles, kopeks);
        }
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
        public void Write(Money m)
        {
            Console.WriteLine(m.ToString());
        }
    }
}
