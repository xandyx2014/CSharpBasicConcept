/*byte byteValue = 16;
short shortValue = -1024;
int intValue = -1034000;
long longValue = 1152921504606846976;

decimal decimalValue;

decimalValue = byteValue;
Console.WriteLine($"Despues de asignar un valor {byteValue.GetType().Name}, el valor decimal es {decimalValue}.");

decimalValue = shortValue;
Console.WriteLine($"Despues de asignar un valor {shortValue.GetType().Name}, el valor decimal es {decimalValue}.");

decimalValue = intValue;
Console.WriteLine($"Despues de asignar un valor {intValue.GetType().Name}, el valor decimal es {decimalValue}.");

decimalValue = longValue;
Console.WriteLine($"Despues de asignar un valor {longValue.GetType().Name}, el valor decimal es {decimalValue}.");

Console.Read();
int integerValue = 12534;
decimal decimalValue2 = Convert.ToDecimal(integerValue);
Console.WriteLine($"Convertiendo el valor {integerValue} del tipo {integerValue.GetType().Name} al valor {decimalValue:N2} del tipo {decimalValue.GetType().Name}");

// Convert a Double value to an Int32 value (a narrowing conversion).
double doubleValue = 16.32513e12;
try
{
    long longValue2 = Convert.ToInt64(doubleValue);
    Console.WriteLine($"Convertiendo el valor {doubleValue:E} del tipo {doubleValue.GetType().Name} al valor {longValue2:N0} del tipo {longValue2.GetType().Name}");
}
catch (OverflowException)
{
    Console.WriteLine($"No se puede convertir tipo {doubleValue.GetType().Name} valor {doubleValue}");
}

SByte sbyteValue = -16;

try
{
    byteValue = Convert.ToByte(sbyteValue);
    Console.WriteLine($"Convertiendo el valor {sbyteValue} del tipo {sbyteValue.GetType().Name} al valor {byteValue:G} del tipo {byteValue.GetType().Name}");
}
catch (OverflowException)
{
    Console.WriteLine($"No se puede convertir valor {sbyteValue} del tipo {sbyteValue.GetType().Name} al tipo {byteValue.GetType().Name}");
}

Console.Read();
*/

Console.WriteLine("Bienvenido al generador de números aleatorios");
Console.WriteLine("Deberás proporcionar un rango entre el cual estará el valor aleatorio");
Console.WriteLine("¿Cuál es el valor mínimo del rango? Debe ser entero");
string? minRange = Console.ReadLine();
Console.WriteLine("¿Cuál es el valor máximo del rango? Debe ser entero");
string? maxRange = Console.ReadLine();

Random random = new();
try
{
    Console.ForegroundColor = ConsoleColor.Green;
    int result = random.Next(Convert.ToInt16(minRange), Convert.ToInt16(maxRange));
    Console.WriteLine($"Tu número aleatorio es: {result}");
}
catch (FormatException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Los datos proporcionados no tienen el formato correcto, deben ser números enteros.");
}
catch (OverflowException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Algún dato proporcionado es muy grande.");
}
Console.Read();