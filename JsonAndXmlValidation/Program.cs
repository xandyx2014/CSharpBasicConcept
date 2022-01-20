// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.WriteLine("Hello, World!");
var json = "[{\"userId\": 1,\"id\": 1,\"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\",\"body\": \"qo\"}]";
var myJson = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);
Console.WriteLine(myJson);
Console.Read();