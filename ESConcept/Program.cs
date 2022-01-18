
try
{
    string path = @"D:\MyTest.txt";
    string? line;
    Console.WriteLine("Proporciona texto para agregar al archivo (Presiona 'Q' para salir) ");
    List<string> lines = new();
    do
    {
        line = Console.ReadLine();
        lines.Add($"{line}" ?? "");
    } while (line?.ToLower() != "q");
    lines.Add(Environment.NewLine);
    File.AppendAllLines(path, lines);
}
catch (IOException ex)
{
    Console.WriteLine($"{ex.Message}");
}