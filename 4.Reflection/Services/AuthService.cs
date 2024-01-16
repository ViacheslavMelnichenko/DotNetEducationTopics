using _4.Reflection.Attributes;

namespace _4.Reflection.Services;

[AutoRegister]
public class AuthService
{
    public void DoAuth()
    {
        Console.WriteLine("Doing Auth");
    }
}