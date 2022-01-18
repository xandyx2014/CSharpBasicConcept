Employee? person = new Employee()
{
    FullName = "andy jesus",
    Age = 21,
    EmployedId = 123

};
person.GetData();
public class Person
{
    public string? FullName { get; set; }
    public int Age { get; set; }
    public virtual void GetData()
    {
        Console.WriteLine($"Full Name: {FullName}");
        Console.WriteLine($"Age: {FullName}");
    }
}
public class Employee : Person
{
    public int EmployedId { get; set; }
    public override void GetData()
    {
        base.GetData();
        Console.WriteLine($"EmployedId: {EmployedId}");


    }
}
