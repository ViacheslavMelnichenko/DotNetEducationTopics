namespace _2.InterfaceMembers;

public class MyClass : ISingleton<MyClass>, IIdentity
{
    private static MyClass? _instance;
    public MyClass()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public static MyClass Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MyClass();
            }

            return _instance;
        }
    }
}