using System.Dynamic;
using System.Globalization;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CsvHelper;

namespace _3.Dynamics;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class Extensions
{
    private static string[] Input => File.ReadAllLines("inputs.csv");


    [Benchmark]
    public string ConvertToJsonStrongTyping()
    {
        var users = Input
            .Skip(1)
            .Select(x =>
            {
                var values = x.Split(',');
                return
                    new User
                    {
                        Name = values[0],
                        Email = values[1],
                        Age = int.Parse(values[2]),
                        AddressCountry = values[3],
                        AddressStreet = values[4],
                        AddressDistrict = values[5],
                        AddressCity = values[6]
                    };
            }).ToArray();

        return Serialize(users);
    }

    [Benchmark]
    public string ConvertToJsonExpando()
    {
        var properties = Input[0].Split(',');

        var users = new List<object>();
        foreach (var line in Input.Skip(1))
        {
            IDictionary<string, object> propertiesObjects = new ExpandoObject() as IDictionary<string, object>;

            var values = line.Split(',');
            for (var i = 0; i < values.Length; i++)
            {
                propertiesObjects.Add(properties[i], values[i]);
            }

            users.Add(propertiesObjects);
        }

        return Serialize(users);
    }

    [Benchmark]
    public string ConvertToJsonDynamic()
    {
        var properties = Input[0].Split(',');

        var users = new List<object>();
        foreach (var line in Input.Skip(1))
        {
            var propertiesObjects = new Dynamic();

            var values = line.Split(',');
            for (var i = 0; i < values.Length; i++)
            {
                propertiesObjects.AddProperty(properties[i], values[i]);
            }

            users.Add(propertiesObjects);
        }

        return Serialize(users);
    }

    [Benchmark]
    public string ConvertToJsonCsvHelper()
    {
        using var reader = new StreamReader("inputs.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<dynamic>().ToList();
        return Serialize(records);
    }

    private string Serialize(object input)
    {
        return JsonSerializer.Serialize(input, new JsonSerializerOptions {WriteIndented = true});
    }

    private class Dynamic : DynamicObject
    {
        private readonly IDictionary<string, object> _properties = new Dictionary<string, object>();

        public void AddProperty(string property, string value)
        {
            _properties.TryAdd(property, value);
        }
    }
}