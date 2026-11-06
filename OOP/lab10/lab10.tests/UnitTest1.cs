using System;
using Xunit;
using lab10.classes;

namespace lab10.tests
{
    public class AnimalTests
    {
        [Fact]
        public void Test_Name_Validation()
        {
            Mammal m = new Mammal();
            m.Name = "";
            Assert.Equal("Без имени", m.Name);
        }

        [Fact]
        public void Test_Weight_Validation()
        {
            Bird b = new Bird();
            b.Weight = -5;
            Assert.Equal(1.0, b.Weight);
        }

        [Fact]
        public void Test_HoofCount_Validation()
        {
            Artiodactyl a = new Artiodactyl();
            a.HoofCount = 3; // Нечетное!
            Assert.Equal(2, a.HoofCount);
        }

        [Fact]
        public void Test_Equals_Method()
        {
            Mammal m1 = new Mammal("Тигр", 100.5, 5, "Рыжий", true);
            Mammal m2 = new Mammal("Тигр", 100.5, 8, "Белый", false);

            Assert.True(m1.Equals(m2));
        }
    }
}