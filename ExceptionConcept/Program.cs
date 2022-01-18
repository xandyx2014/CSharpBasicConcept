// 


static void Divide(string num)
{
    try
    {
        int number = int.Parse(num);
    }
    catch (Exception ex) when (ex is FormatException)
    {
        throw new FormatException($"Se ha generado una excption del FORMAT: {ex.GetType()}");
    }
    catch (Exception ex)
    {
        throw new ApplicationException($"Se ha generado una excption ApplicationException {ex.GetType()}");
    }
}
try
{
    Console.WriteLine("Hello, World!");
    Divide(Console.ReadLine() ?? "");
}
catch (Exception ex)
{

    throw new FormatException($"Se ha generado una excption del FORMAT: {ex.GetType()}");
}

