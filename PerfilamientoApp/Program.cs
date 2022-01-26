// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text;
const int numberOfIterations = 100000;
var sw = new Stopwatch();
sw.Start();
Algorithm1();
sw.Stop();
Console.WriteLine(sw.Elapsed);

sw.Reset();
sw.Start();
Algorithm2();
sw.Stop();

Console.WriteLine(sw.Elapsed);
Console.WriteLine("Ready…");
Console.ReadLine();

static void Algorithm2()
{
    string result = "";
    for (int x = 0; x < numberOfIterations; x++)
    {
        result += 'a';
    }
}
static void Algorithm1()
{
    var sb = new StringBuilder();
    for (int x = 0; x < numberOfIterations; x++)
    {
        sb.Append('a');
    }
    string result = sb.ToString();
}
