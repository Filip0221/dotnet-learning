using System.Globalization;
namespace Lab2
{
    public class Fruit
    {
        public string Name { get; set; }
        public bool IsSweet { get; set; }
        public double Price { get; set; }
        public double UsdPrice => Price / UsdCourse.Current;
        public static Fruit Create()
        {
            var random = new System.Random();
            string[] names = { "Apple", "Banana", "Cherry", "Durian", "Edelberry", "Grape", "Jackfruit" };
            return new Fruit
            {
                Name = names[random.Next(names.Length)],
                IsSweet = random.NextDouble() > 0.5,
                Price = random.NextDouble() * 10
            };
        }
        public override string ToString()
        {
            return $"Nazwa: {Name}, Słodki: {IsSweet}, Cena: {Price.ToString("C2")}, Cena w USD: {FormatUsdPrice(UsdPrice)}";
        }
        public static string FormatUsdPrice(double price)
        {
            var usc = new CultureInfo("en-us");
            return price.ToString("C2", usc);
        }
    }
}