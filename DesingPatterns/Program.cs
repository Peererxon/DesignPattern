namespace DesingPatterns;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var singleton = Singleton.Singleton.Instance;
        var singleton2 = Singleton.Singleton.Instance;
        var log = Singleton.Log.Instance;
        log.Save("a");
        log.Save("hellou!");
    }
}

