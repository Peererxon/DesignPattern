namespace DesingPatterns;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var singleton = Singleton.Singleton.Instance;
    }
}

