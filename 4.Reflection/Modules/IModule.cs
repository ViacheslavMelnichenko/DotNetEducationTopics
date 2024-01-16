namespace _4.Reflection.Modules;

public interface IModule
{
    static abstract void AddServices(IServiceCollection services);
}