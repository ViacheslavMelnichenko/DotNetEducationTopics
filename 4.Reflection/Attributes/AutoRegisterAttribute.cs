namespace _4.Reflection.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class AutoRegisterAttribute(string? name = default, ServiceLifetime lifetime = ServiceLifetime.Scoped) : Attribute
{
    public string Name { get; } = name ?? string.Empty;
    public ServiceLifetime Lifetime { get; } = lifetime;
}