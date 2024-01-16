namespace _2.InterfaceMembers;

public interface ISingleton<T> //where T : ISingleton<T>
{
    public static abstract T Instance { get; }
}