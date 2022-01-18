// See https://aka.ms/new-console-template for more information
// Ref el parametro que le estamos pasando se puede o no modificar
// in el parametro no puede modificar el parametro que estamos pasando
// out el metodo debe modificar el parametro que estamos pasando


int myIntegert = 1;
IncrementInteger(myIntegert);
int myIntegertRef = 1;
IncrementIntegerRef(ref myIntegertRef);
Console.WriteLine($"my integer ref is {myIntegertRef}");
Console.WriteLine($"My integer is {myIntegert}");

var person = new Person() { Name = "Andy", Age = 21 };
IncrementAgeRef(ref person);
Console.WriteLine($"person ref {person.Age}");
// El metodo no modifica el valor // ouput: 1
// El metodo es usado como tipo de valor
static int IncrementInteger(int value)
{
    return value++;
}
static int IncrementIntegerRef(ref int value)
{
    return value++;
}
static int IncrementAgeRef(ref Person person)
{
    return person.Age++;
}
class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
}