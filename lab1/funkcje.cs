using lab1;
using System.Text.Json;

public static class Funkcje
{
    public static void zad3()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("Fizzbuz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
    public static void zad4()
    {
        var rand = new Random();
        var value = rand.Next(1, 101);

        // Console.WriteLine(value);
        while (true)
        {
            Console.WriteLine("podaj liczbę: ");
            int guess = Convert.ToInt32(Console.ReadLine());
            if (guess > value)
            {
                Console.WriteLine("Twoja liczba jest za duża");
            }
            else if (guess < value)
            {
                Console.WriteLine("Twoja liczba jest za mała");
            }
            else
            {
                Console.WriteLine("gratulacje zgadłeś");
                break;
            }
        }
    }
    public static void zad5()
    {
        var rand = new Random();
        var value = rand.Next(1, 101);
        var trials = 0;
        // Console.WriteLine(value);
        while (true)
        {
            Console.WriteLine("podaj liczbę: ");
            int guess = Convert.ToInt32(Console.ReadLine());
            if (guess > value)
            {
                Console.WriteLine("Twoja liczba jest za duża");
                trials++;
            }
            else if (guess < value)
            {
                Console.WriteLine("Twoja liczba jest za mała");
                trials++;
            }
            else
            {
                Console.WriteLine("gratulacje zgadłeś");
                trials++;
                Console.WriteLine("potrzebowałeś " + trials + " prób");
                break;
            }
        }
    }
    public static void zad6()
    {
        List<HighScore> highScores;
        const string FileName = "highscores.json";
        if (File.Exists(FileName))
        {
            highScores = JsonSerializer.Deserialize<List<HighScore>>(File.ReadAllText(FileName));
        }
        else
        {
            highScores = new List<HighScore>();
        }
        var rand = new Random();
        var value = rand.Next(1, 101);
        var trials = 0;
        // Console.WriteLine(value);

        while (true)
        {
            Console.WriteLine("podaj liczbę: ");
            int guess = Convert.ToInt32(Console.ReadLine());
            if (guess > value)
            {
                Console.WriteLine("Twoja liczba jest za duża");
                trials++;
            }
            else if (guess < value)
            {
                Console.WriteLine("Twoja liczba jest za mała");
                trials++;
            }
            else
            {
                Console.WriteLine("gratulacje zgadłeś");
                trials++;
                Console.WriteLine("potrzebowałeś " + trials + " prób");
                break;
            }
        }
        Console.WriteLine("podaj swoja nazwe:");
        string name = Console.ReadLine();
        var hs = new HighScore { Name = name, Trials = trials };
        highScores.Add(hs);
        File.WriteAllText(FileName, JsonSerializer.Serialize(highScores));
        
        highScores.Sort((a, b) => a.Trials.CompareTo(b.Trials));

        foreach (var item in highScores)
        {
            Console.WriteLine($"{item.Name} -- {item.Trials} prób");
        }
    }
}
