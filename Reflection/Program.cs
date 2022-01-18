// example 1
using System.Diagnostics;
ConditionalAttribute[] conditionalAttribute = (ConditionalAttribute[])Attribute.GetCustomAttributes(typeof(ConditionalClass), typeof(ConditionalAttribute));
Console.WriteLine(conditionalAttribute[0].ConditionString); // returns CONDITION1
Console.WriteLine(conditionalAttribute[1].ConditionString); // returns CONDITION2
Console.Read();
if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
{
    Console.WriteLine("Person tiene definido el atributo 'Serializable'.");
    Console.Read();
}

[Serializable]
class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}


// example 2
[Conditional("CONDITION1"), Conditional("CONDITION2")]
class ConditionalClass : Attribute
{

}
// example 2
[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
public class AuthorAttribute : System.Attribute
{
    private string name;
    public double version;

    public AuthorAttribute(string name)
    {
        this.name = name;
        version = 1.0;
    }
}

[Author("Sergio Pérez", version = 1.1)]
class SampleClass
{
    // Aqui código de Sergio Pérez...  
}
// example 3
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class MyMethodAndParameterAttribute : Attribute { }


[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
class MyMultipleUsageAttribute : Attribute { }


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
class CompleteCustomAttribute : Attribute
{
    public CompleteCustomAttribute(string description)
    {
        Description = description;
    }
    public string Description { get; set; }
}
// example 4
