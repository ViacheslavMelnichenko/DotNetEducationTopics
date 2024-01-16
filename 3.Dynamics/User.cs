namespace _3.Dynamics;

public sealed record User
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Age { get; set; }
    public string AddressCountry { get; set; } = null!;
    public string AddressStreet { get; set; } = null!;
    public string AddressDistrict { get; set; } = null!;
    public string AddressCity { get; set; } = null!;
}