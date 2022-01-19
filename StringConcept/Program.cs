/*string s = string.Empty;

for (int i = 0; i < 10000; i++)
{
    s += "x";
}
Console.WriteLine($"Terminé con s = {s}");
Console.Read();*/
using System.Xml;
using System.Globalization;
using System.Text.RegularExpressions;

/*var s = new String('X', 10000);
Console.WriteLine($"s = {s}");
Console.Read();*/
// example 1: Create xml
/*var stringWriter = new StringWriter();
using (XmlWriter writer = XmlWriter.Create(stringWriter))
{
    writer.WriteStartElement("book");
    writer.WriteElementString("price", "19.95");
    writer.WriteEndElement();
    writer.Flush();
}
string xml = stringWriter.ToString();
Console.Write(xml);
Console.ReadLine();

var stringReader = new StringReader(xml);
using (XmlReader reader = XmlReader.Create(stringReader))
{
    reader.ReadToFollowing("price");
    decimal price = decimal.Parse(reader.ReadInnerXml(), new CultureInfo("es-MX"));
    Console.Write($"price = {price}");
}

Console.Read();*/
// search string
/*string value = "My Sample Value";
int indexOfp = value.IndexOf('p'); // returns 6
int lastIndexOfm = value.LastIndexOf('m'); // returns 5
Console.WriteLine($"IndexOf p = {indexOfp}");
Console.WriteLine($"LastIndexOf m = {lastIndexOfm}");
Console.ReadKey();

value = "< mycustominput >";
if (value.StartsWith("<"))
{
    Console.WriteLine($"La cadena '{value}' inicia con '<'");
}
if (value.EndsWith(">"))
{
    Console.WriteLine($"La cadena '{value}' inicia con '<'");
}
Console.ReadKey();

value = "My Sample Value";
string subString = value.Substring(3, 6); // Returns ‘Sample’
Console.WriteLine($"SubString(3,6) = '{subString}'");
Console.ReadKey();

string pattern = "(Ms.? |Mr.? | Miss | Mrs.?)";
string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };
foreach (string name in names)
    Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
Console.ReadKey();

value = "My Custom Value";
foreach (char c in value)
    Console.WriteLine(c);
Console.ReadKey();

foreach (string word in "My sentence separated by spaces".Split(' '))
{
    Console.WriteLine(word);

}
Console.ReadKey();*/
/*string words = "z|sdfciwh|ewf|oñierug|e";
string[] wordArray = words.Split("|");
List<string> wordList = new List<string>(wordArray);
wordList.Sort();
foreach (string word in wordList)
{
    Console.WriteLine($"{word.ToUpper()}");
}*/
/*var p = new Person("Sergio", "Pérez");
Console.ReadKey();*/

double cost = 1234.56;
Console.WriteLine(cost.ToString("C", new System.Globalization.CultureInfo("en-US")));// Displays $1,234.56
Console.ReadKey();

var d = new DateTime(2013, 4, 22);
var provider = new CultureInfo("es-MX");
Console.WriteLine(d.ToString("d", provider)); // Displays 4/22/2013
Console.WriteLine(d.ToString("D", provider)); // Displays Monday, April 22, 2013
Console.WriteLine(d.ToString("M", provider)); // Displays April 22
Console.ReadKey();

int a = 1;
int b = 2;
string result = $"a: {a}, b: {b}";
Console.WriteLine(result); // Displays ‘a: 1, b: 2’
Console.ReadKey();
class Person
{
    public Person(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
    public string ToString(string format)
    {
        if (string.IsNullOrWhiteSpace(format) || format == "G")
            format = "FL";

        format = format.Trim().ToUpperInvariant();
        return format switch
        {
            "FL" => FirstName + " " + LastName,
            "LF" => LastName + " " + FirstName,
            "FSL" => FirstName + ", " + LastName,
            "LSF" => LastName + ", " + FirstName,
            _ => throw new FormatException($"{format}"),
        };
    }
}
class Temperature : IFormattable
{
    private readonly decimal temp;
    public decimal Celsius
    {
        get { return temp; }
    }

    public decimal Fahrenheit
    {
        get { return temp * 9 / 5 + 32; }
    }

    public decimal Kelvin
    {
        get { return temp + 273.15m; }
    }
    public Temperature(decimal temperature)
    {
        if (temperature < -273.15m)
            throw new ArgumentOutOfRangeException($"{temperature} es menor que el cero absoluto.");
        this.temp = temperature;
    }
    public string ToString(string? format, IFormatProvider? provider)
    {
        if (String.IsNullOrEmpty(format))
            format = "G";
        if (provider == null)
            provider = CultureInfo.CurrentCulture;

        return format.ToUpperInvariant() switch
        {
            "G" or "C" => Celsius.ToString("F2", provider) + " °C",
            "F" => Fahrenheit.ToString("F2", provider) + " °F",
            "K" => Kelvin.ToString("F2", provider) + " K",
            _ => throw new FormatException($"{format} no es soportado."),
        };
    }
    public override string ToString()
    {
        return this.ToString("G", CultureInfo.CurrentCulture);
    }

    public string ToString(string format)
    {
        return this.ToString(format, CultureInfo.CurrentCulture);
    }
}