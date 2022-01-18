// un delegado es una firma de una metodo 
// SimpleDelegate calculator = new();
// calculator.UseDelegate();

// MulticastClass multicastClass = new();
// multicastClass.Multicast();
/*Covariance covariance = new();
covariance.UsingCovariance();*/
// ExampleMultiCast exampleMultiCast = new();
/*Action<int, int> calc = (x, y) =>
{
    Console.WriteLine(x + y);
};
calc(3, 4);

Console.Read();*/

class SimpleDelegate
{
    //  es una firma que tiene que seguir
    // un delegado es un objecto
    // se puede aumentar
    public delegate int Calculate(int x, int y);
    public int Add(int x, int y) { return x + y; }
    public int Multiply(int x, int y) { return x * y; }

    public void UseDelegate()
    {
        Calculate calc = Add;
        Console.WriteLine(calc(3, 4)); // Displays 7
        calc = Multiply;
        Console.WriteLine(calc(3, 4)); // Displays 12
    }
}


class MulticastClass
{
    protected delegate void Del();
    public void MethodOne()
    {
        Console.WriteLine("MethodOne");
    }
    public void MethodTwo()
    {
        Console.WriteLine("MethodTwo");
    }

    public void Multicast()
    {
        Del d = MethodOne;
        d += MethodTwo;
        d();
    }
}
//  Covarianza y contravarianza
// LA covarianza hace que tenga un tipo de retorno mas derivado  que definido en el Delegado
// La contravarianza permite que tenga un tipo de paramatro mas contravariado que definido en el Delegado
/*class Covariance
{
    public delegate TextWriter CovarianceDel();
    public StreamWriter? MethodStream() { return null; }
    public StringWriter? MethodString() { return null; }
    public void UsingCovariance()
    {
        CovarianceDel? del;
        del = MethodStream;
        del = MethodString;
    }
}*/
/*class Contravariance
{
    void DoSomething(TextWriter tw) { }
    public delegate void ContravarianceDel(StreamWriter tw);
    public void UsingContravariance()
    {
        ContravarianceDel del = DoSomething;
    }
}*/
class ExampleMultiCast
{
    delegate void MathCalculation(int value1, int value2);
    public ExampleMultiCast()
    {
        MathCalculation mathCalculationDelegate = AddNumbers;
        mathCalculationDelegate += SubtractNumbers;
        mathCalculationDelegate += MultiplyNumbers;
        mathCalculationDelegate += DivideNumbers;
        mathCalculationDelegate(4, 2);

    }

    public void AddNumbers(int value1, int value2)
    {
        Console.WriteLine($"{value1 + value2}");
    }
    public void SubtractNumbers(int value1, int value2)
    {
        Console.WriteLine($"{value1 - value2}");
    }
    public void MultiplyNumbers(int value1, int value2)
    {
        Console.WriteLine($"{value1 * value2}");
    }
    public void DivideNumbers(int value1, int value2)
    {
        Console.WriteLine($"{value1 / value2}");
    }

}

class FunctionExample
{
    public delegate int GetRandomNumberDelegate();
    public FunctionExample()
    {
        GetRandomNumberDelegate getRandomNumber = GetRandomNumber;
        Console.WriteLine(getRandomNumber());
        Func<int> getRandomFunction = () => getRandomNumber();
        Console.WriteLine(getRandomFunction());
        Console.ReadKey();
    }
    int GetRandomNumber()
    {
        return new Random().Next(1, 100);
    }
}