//  parse con boolean
using System.Globalization;
using System.Text.RegularExpressions;

string valueboolean = "true";
bool b = bool.Parse(valueboolean);
Console.WriteLine(b);
string valueNumber = "1";
int result = 0;
bool success = int.TryParse(valueNumber, out result);
if (success)
{
    Console.WriteLine($"{valueNumber} es un entero valido");
}
else
{
    Console.WriteLine($"{valueNumber} not is a valid number");
}
var spanish = new CultureInfo("es-MX");
var dutch = new CultureInfo("nl-NL");
string valueMoney = "€19,95";
decimal d = decimal.Parse(valueMoney, NumberStyles.Currency, dutch);
Console.WriteLine(d.ToString(spanish));
// Convert devuelve un valor por defecto si este no se puede parsear
int integer = Convert.ToInt32("123123");

// expresiones regulares
Match match = Regex.Match("1234 AB", @"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", RegexOptions.IgnoreCase);
Console.WriteLine(match.Success);
Console.WriteLine("Proporciona una fecha en formato telefono xxx-xxx-xxxx");
string pattern = @"^[2-9]\d{2}-\d{3}-\d{4}$";
string? input = "";
bool successPatter = true;
do
{
    input = Console.ReadLine();
    if (Regex.IsMatch(input ?? "", pattern))
    {
        successPatter = false;
    }
    else
    {
        Console.WriteLine("Formato no correcto xxx-xxx-xxxx");
        successPatter = true;
    }

} while (successPatter);
Console.WriteLine("exitoso");
