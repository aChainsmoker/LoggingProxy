using CustomLogger.Logging;
using LogginProxy;

namespace LogginProxy;

class Program
{
    static void Main(string[] args)
    {
        var logger = new Logger();
        var test = new TestClass();

        var proxy = LoggingProxy<ITest>.CreateInstance(test, logger);

        proxy.Add(5, 3);
        proxy.Multiply(4, 7);
        Console.WriteLine(proxy.TestProperty);
        proxy.TestProperty = "World";
        Console.WriteLine(proxy.TestProperty);
    }
}

public interface ITest
{
    public string TestProperty { get; set; }
    int Add(int a, int b);
    int Multiply(int a, int b);
}

public class TestClass : ITest
{
    public string TestProperty { get; set; } = "Hello";
    public int Add(int a, int b) => a + b;
    public int Multiply(int a, int b) => a * b;
}