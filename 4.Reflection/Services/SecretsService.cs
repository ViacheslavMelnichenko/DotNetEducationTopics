using _4.Reflection.Attributes;

namespace _4.Reflection.Services;

[AutoRegister(lifetime: ServiceLifetime.Singleton)]
public class SecretsService
{
    public void SetSecrets()
    {
        Console.WriteLine("Setting secrets");
    }
}