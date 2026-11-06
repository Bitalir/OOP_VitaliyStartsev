using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab9
{
    public class Money
    {
        private int rubles;
        private int kopeks;
        private static int count;

        public int Rubles
        {
            get { return rubles; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Количество рублей не может быть меньше 0");
                }
                rubles = value;
            }
        }
        public int Kopeks
        {
            get { return kopeks; }
            set
            {
                if (value < 0 || value > 99)
                {
                    throw new ArgumentException("Количесвто копеек не может быть меньше 0 и блольше 99");
                }
                kopeks = value;
            }
        }
        public static int Count
        {
            get { return count; }
        }
        public Money() : this(0, 0) { }
        public Money(int r, int k)
        {
            Rubles = r;
            Kopeks = k;
            count++;
        }
        public override string ToString()
        {
            return $"{Rubles}.{Kopeks:D2}";
        }
        public static Money SubtractKopeks(Money m, int amount)
        {
            int total = m.Rubles * 100 + m.Kopeks - amount;
            if (total < 0)
            {
                throw new ArgumentException("Такой суммы нет");
            }
            return new Money(total / 100, total % 100);
        }
        public Money SubtractKopeks(int amount)
        {
            return Money.SubtractKopeks(this, amount);
        }
        public static Money operator ++(Money m)
        {
            if (m.kopeks == 99)
            {
                m.kopeks = 0;
                m.rubles++;
            }
            else
            {
                m.kopeks++;
            }
            return m;
        }
        public static Money operator --(Money m)
        {
            if (m.rubles == 0 && m.kopeks == 0)
            {
                throw new ArgumentException("0.00");
            }
            if (m.kopeks == 0)
            {
                m.kopeks = 99;
                m.rubles--;
            }
            else
            {
                m.kopeks--;
            }
            return m;
        }

        public static explicit operator int(Money m) // явный
        {
            return m.rubles;
        }
        public static implicit operator bool(Money m) // неявный
        {
            return m.rubles != 0 || m.kopeks !=0;
        }
        
        public static Money operator -(Money m, int amount)
        {
            return m.SubtractKopeks(amount);
        }
        public static Money operator -(int amount, Money m)
        {
            int Kopeks_ = m.rubles * 100 + m.Kopeks;
            int result = amount - Kopeks_;
            if (result < 0)
            {
                throw new ArgumentException("Результат меньше 0");
            }
            return new Money(result / 100, result % 100);
        }
        public static Money operator -(Money m1, Money m2)
        {
            int Kopeks_m1 = m1.rubles * 100 + m1.Kopeks;
            int Kopeks_m2 = m2.rubles * 100 + m2.Kopeks;
            int result = Kopeks_m1 - Kopeks_m2;
            if (result < 0)
            {
                throw new ArgumentException("Результат меньше 0");
            }
            return new Money(result / 100, result % 100);
        }
    }
}
