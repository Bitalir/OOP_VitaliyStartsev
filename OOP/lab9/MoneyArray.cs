using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab9
{
    public class MoneyArray
    {
        private Money[] arr;
        private static int count;
        public static int Count
        {
            get { return count; }
        }
        public int Length
        {
            get { return arr.Length; }
        }
        public MoneyArray() : this(0) { }
        public MoneyArray(int size)
        {
            arr = new Money[size];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Money(random.Next(0, 100), random.Next(0, 100));
            }
            count++;
        }
        public MoneyArray(int size, InputOutput io)
        {
            arr = new Money[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = io.ReadMoney();
            }
            count++;
        }
        public void Print(InputOutput io)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                io.Write($"Элемент {i}: {arr[i]}");
            }
        }
        public Money this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new ArgumentException("Индекс вне границы массива");
                }
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new ArgumentException("Индекс вне границы массива");
                }
                arr[index] = value;
            }
        }
    }
}
