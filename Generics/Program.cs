


// Restricciones del Where T
/*
 * where T: struct  El argumento del tipo debe ser un tipo de valor no se permite nullable
 * where T: class El argumento type debe ser un tipo de referencia Ej: clase, interfaz. delegado, array
 * where T: new() El tip[o debe tener un constructor publico predeterminado
 * where T: <baseClassMame> El argumento de tipo debe ser o derivar de la clase especificada
 * where T: <interfaceName> El argumento de tipo denbe ser o implementar la interfzar especificada. Se puede especificar varias rescriciones de interfaz, la interfaz restricita tambien puede ser generica
 * where T: U El argumento de tipo proporcionado para t debe ser o derivar del argumento proporcionado para U
 */
/*static List<T> GetInitalizedList<T>(T value, int lengh)
{
    List<T> list = new List<T>();
    for (int i = 0; i < lengh; i++)
    {
        list.Add(value);
    }
    return list;
}*/
enum Gender
{
    Male, Female
}
enum Days : byte
{
    Sat = 1,
    Sunday = 2,
    Monday = 3,
}
[Flags]
enum FlagDays
{
    None = 0x0,
    Sunday = 0x1,
    Monday = 0x2,
}
// extendiendo de tipos existentes
// 1.- Metodo de extension
class Product
{
    public decimal Price { get; set; }
}
// Clase de extension
static class MyExtensions
{
    public static decimal Discount(this Product product)
    {
        return product.Price * .9M;
    }
}
class Calculator
{
    public static decimal CalculateDiscount(Product p)
    {
        return p.Discount();
    }
}
class Base
{
    public virtual int MyMethod()
    {
        return 42;
    }
}
class Derived : Base
{
    public override int MyMethod()
    {
        return base.MyMethod() * 2;
    }
}
class Vehicle
{
    public double Distance { get; set; }
    public double Hour { get; set; }

    public Vehicle(double distance, double hour)
    {
        this.Distance = distance;
        this.Hour = hour;
    }

    public virtual void Speed()
    {
        double speed = Distance / Hour;
        Console.WriteLine($"La velocidad del vehículo es {speed:0.00} Km/H");
    }
}
class Car : Vehicle
{
    public Car(double distance, double hour) : base(distance, hour)
    {
    }
    public override void Speed()
    {
        double speed = Distance / Hour;
        Console.WriteLine($"La velocidad del carro es {speed:0.00} Km/H");
    }
}
class Bycicle : Vehicle
{
    public Bycicle(double distance, double hour) : base(distance, hour)
    {
    }
    public override void Speed()
    {
        double speed = Distance / Hour;
        Console.WriteLine($"La velocidad del bycicle es {speed:0.00} Km/H");
    }
}