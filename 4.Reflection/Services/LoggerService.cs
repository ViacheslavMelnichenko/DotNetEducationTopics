using _4.Reflection.Attributes;

namespace _4.Reflection.Services;

[AutoRegister(nameof(LoggerService), ServiceLifetime.Transient)]
public class LoggerService
{
    public void DoLogging()
    {
        Console.WriteLine("Doing logging");
    }
}