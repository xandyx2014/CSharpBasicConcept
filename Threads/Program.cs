// See https://aka.ms/new-console-template for more information
/* EXAMPLE I: ThreadStart
 * Console.WriteLine("Hello, World!");
Thread t = new Thread(new ThreadStart(ThreadMethod));
t.Start();
for (int i = 0; i < 4; i++)
{
    Console.WriteLine("Hilo principal: Trabajando...");
    Thread.Sleep(0);
}
Console.Read();
static void ThreadMethod()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Proceso de hilo: {i}");
        Thread.Sleep(0);
    }
}*/
/*bool stopped = false;
Thread t = new(new ThreadStart(() =>
{
    while (!stopped)
    {
        Console.WriteLine("Corriendo Hilo");
        Thread.Sleep(1000);
    }

}));
t.Start();
Console.WriteLine("Presione una tecla apra salir");
Console.ReadKey();
stopped = true;
// Join hace que la aplicacion de consola espera asta hilo deje de ejecutarse
t.Join();*/
// EXAMPLE II : THREADSTATIC
/*var example = new ThreadStaticAttributeExample();
class ThreadStaticAttributeExample
{
    // El hilo tendra su propia pila de llamada y este sera con diferente datos 
    // en cada hilo este tendra un diferente valor
    // por cada hilo este tendra una asignacion diferente

    public static int field;

    public ThreadStaticAttributeExample()
    {
        new Thread(() =>
        {
            for (int x = 0; x < 10; x++)
            {
                field++;
                Console.WriteLine($"Hilo A: {field}");
            }
        }).Start();
        new Thread(() =>
        {
            for (int x = 0; x < 10; x++)
            {
                field++;
                Console.WriteLine($"Hilo B: {field}");
            }
        }).Start();
        Console.ReadKey();
    }
}*/
// EXAMPLE IV ThreadLocal
/*ThreadLocal<int> _field = new ThreadLocal<int>(() =>
{
    // Solicita informacion sobre el hilo que se esta ejecutando
    // ManagedThreadId te agrega el proceso
    return Thread.CurrentThread.ManagedThreadId;
});
new Thread(() =>
{
    for (int x = 0; x < _field.Value; x++)
    {
        Console.WriteLine($"Hilo A: {x}");
    }
}).Start();

new Thread(() =>
{
    for (int x = 0; x < _field.Value; x++)
    {
        Console.WriteLine($"Hilo B: {x}");
    }
}).Start();

Console.ReadKey();*/

// EXERCISE
/*bool stopped = false;
Thread t = new(new ThreadStart(ThreadMethod));
t.Start();
Console.WriteLine("Presione una tecla apra salir");
Console.ReadKey();
stopped = true;
// Join hace que la aplicacion de consola espera asta hilo deje de ejecutarse
t.Join();
void ThreadMethod()
{
    int index = 0;
    while (!stopped || index == int.MaxValue)
    {
        index++;
        Console.WriteLine($"Veces que se ha ejecutado: {index}");
        Thread.Sleep(3000);
    }
}*/
// EXAMPLE: ThreadPool
ThreadPool.QueueUserWorkItem((s) =>
{
    Console.WriteLine("Trabajando un hilo desde un ThreadPool");
});
Console.ReadLine();
