
using Lab2;
// 2.3 zrobione
UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();
var fruits = new List<Fruit>();
for (int i = 0; i < 15; i++)
{
	fruits.Add(Fruit.Create());
}
fruits = fruits.Where(f => f.IsSweet).OrderByDescending(f => f.Price).ToList();
foreach (var fruit in fruits)
{
	Console.WriteLine(fruit.ToString());
}
