// See https://aka.ms/new-console-template for more information

using _3.Dynamics;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Extensions>();



//var ext = new Extensions();
// Console.WriteLine(ext.ConvertToJsonStrongTyping());
// Console.WriteLine(ext.ConvertToJsonExpando());
// Console.WriteLine(ext.ConvertToJsonDynamic());
// Console.WriteLine(ext.ConvertToJsonCsvHelper());