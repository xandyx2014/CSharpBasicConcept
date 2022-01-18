// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;
/*List<string> sites = new() { "http://www.microsoft.com", "http://www.google.com", "http://www.msn.com" };
List<Task<string>> tasks = new();
foreach (string site in sites)
{
    tasks.Add(DownloadContent(site));
}
// esperar cualquiera
int index = Task.WaitAny(tasks.ToArray());
Task<string> completedTask = tasks.ToArray()[index];
Console.WriteLine($"El sitio que respondió primero fue: {completedTask.Result} ");
static async Task<string> DownloadContent(string url)
{
    using HttpClient client = new HttpClient();
    string result = await client.GetStringAsync(url);
    return url;
}*/
// BlokingCollection


/*BlockingCollection<string> col = new BlockingCollection<string>();

Task read = Task.Run(() =>
{
    foreach (string item in col.GetConsumingEnumerable())
    {
        Console.WriteLine(item);
    }
});

Task write = Task.Run(() =>
{
    while (true)
    {
        string? s = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(s))
            break;
        col.Add(s);
    }
});

write.Wait();*/

// Concurrentbag
/*ConcurrentBag<int> bag = new ConcurrentBag<int>();
Task.Run(() =>
{
    bag.Add(42);
    Thread.Sleep(1000);
    bag.Add(21);
});
Task.Run(() =>
{
    foreach (int i in bag)
        Console.WriteLine(i);
}).Wait();
Console.Read();*/

// ConcurrentDictionary
/*var dict = new ConcurrentDictionary<string, int>();

if (dict.TryAdd("k1", 42))
{
    Console.WriteLine("Added");
}

if (dict.TryUpdate("k1", 21, 42))
{
    Console.WriteLine("42 updated to 21");
}

dict["k1"] = 42;
int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
int r2 = dict.GetOrAdd("k2", 3);

Console.Read();*/
// ConcurrentQueue
/*ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
queue.Enqueue(42);

int result;
if (queue.TryDequeue(out result))
    Console.WriteLine($"Dequeued: {result}");

Console.Read();*/
// ConcurrentStack
/*ConcurrentStack<int> stack = new ConcurrentStack<int>();
stack.Push(42);

int result;
if (stack.TryPop(out result))
    Console.WriteLine($"Popped: {result}");

stack.PushRange(new int[] { 1, 2, 3 });

int[] values = new int[2];
stack.TryPopRange(values);

foreach (int i in values)
    Console.WriteLine(i);

Console.Read();*/

// Cancelation Token
CancellationTokenSource cancellationTokenSource = new();
CancellationToken token = cancellationTokenSource.Token;
int counter = 0;
Console.WriteLine("Presiona una tecla para iniciar el contador y vuelve a presionar otra tecla para cancelarlo.");
Console.ReadLine();
Task task = Task.Run(() =>
{
    while (!token.IsCancellationRequested)
    {
        counter++;
        Console.Write($"{counter} ");
        Thread.Sleep(500);
    }
}, token).ContinueWith((task) =>
{
    Console.WriteLine($"Has canselado la tarea total: {counter}");
    return task;
}, TaskContinuationOptions.OnlyOnCanceled);

Console.WriteLine("Presiona ENTER para cancelar la tarea.");
Console.ReadLine();
cancellationTokenSource.Cancel();

Console.WriteLine("Presiona ENTER para terminar la aplicación.");
Console.ReadLine();
