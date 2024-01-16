// Practice: 
// Create a generic interface for all classes that want to implement Singleton pattern.
// The API for this interface should look like following property call:
// var instance = MyClass.Instance;

// where MyClass - implements ISingleton<T> interface and Instance - is a static get-only property
// b. Add another interface IIdentity with single property Id if type Guid.
// c. Add a method that will be able to work with any type that implements both ISingleton<> and IIdentity and will print the value of IIdentity Id on the console.

using _2.InterfaceMembers;

PrintIdentity<MyClass>();

static void PrintIdentity<T>() where T : ISingleton<T>, IIdentity
{
    Console.WriteLine($"Identity Id: {T.Instance.Id}");
}