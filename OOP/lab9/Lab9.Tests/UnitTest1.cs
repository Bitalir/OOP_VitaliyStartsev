using Xunit;
using OOP_lab9;
using System;

namespace Lab9.Tests
{
    public class MoneyTests
    {
        [Fact]
        public void Constructor_ThrowsException_WhenRublesNegative()
        {
            Assert.Throws<ArgumentException>(() => new Money(-1, 0));
        }

        [Fact]
        public void Constructor_ThrowsException_WhenKopeksMoreThan99()
        {
            Assert.Throws<ArgumentException>(() => new Money(10, 100));
        }

        [Fact]
        public void SubtractKopeks_WorksCorrectly()
        {
            Money m = new Money(5, 30);
            Money result = m.SubtractKopeks(45);
            Assert.Equal(4, result.Rubles);
            Assert.Equal(85, result.Kopeks);
        }

        [Fact]
        public void Operators_WorkCorrectly()
        {
            Money m = new Money(5, 99);
            m++;
            Assert.Equal(6, m.Rubles);
            Assert.Equal(0, m.Kopeks);

            int rub = (int)m;
            Assert.Equal(6, rub);
        }

        [Fact]
        public void Indexer_ThrowsException_WhenIndexOutOfBounds()
        {
            MoneyArray arr = new MoneyArray(3);
            Assert.Throws<ArgumentException>(() => arr[5]);
        }
    }
}