// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int index = 7;
Console.WriteLine($"Index antes de llamar Sum4: { index}");
Console.WriteLine($"Sum4: {Sum4(index)}");
Console.WriteLine($"Index después de llamar Sum4: {index}");
Console.ReadLine();

Person person = new()
{
    Name = "andy",
    Age = 21
};


Console.WriteLine($"Person Name: {person.Name}");
ChangeName(person);
Console.WriteLine($"Person Name: {person.Name}");
Console.Read();
static int Sum4(int number)
{
    number = number + 4;
    return number;
}
static void ChangeName(Person p)
{
    p.Name = p.Name + " Change";
}
class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
}