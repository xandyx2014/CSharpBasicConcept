/*// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Ejecutar un for async que no se ejecute bloque por bloque
Parallel.For(0, 10, i =>
{
    Thread.Sleep(1000);
    Console.WriteLine($"Iteracción {i} del FOR.");
});

var numbers = Enumerable.Range(0, 10);
Parallel.ForEach(numbers, i =>
{
    Thread.Sleep(1000);
    Console.WriteLine($"Iteracción {i} del FOREACH.");
});
Console.Read();*/
// ParallelLoopResult es para interrumpit y stop
ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
           {
               if (i == 500)
               {
                   Console.WriteLine("Interrupiendo el bucle...");
                   loopState.Break();
               }
               return;
           });

Console.WriteLine($"LowestBreakIteration: {result.LowestBreakIteration}");
Console.WriteLine($"IsCompleted: {result.IsCompleted}");
Console.Read();
