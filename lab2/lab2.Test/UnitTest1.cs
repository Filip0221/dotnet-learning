using Lab2;
using Xunit;

namespace lab2.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var fruit = new Fruit { Name = "Apple", IsSweet = true, Price = 5.99 };
            var result = fruit.ToString();
            Assert.Contains("Nazwa: Apple", result);
            Assert.Contains("Słodki: True", result);
            Assert.Contains("Cena:", result);
        }
    }
}