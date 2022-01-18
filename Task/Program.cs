// See https://aka.ms/new-console-template for more information
// Task es igual que las promise en JS
// Las tareas no son bloqueantes como los hilos.
/*Task t = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        Console.WriteLine("*");
    }
});
t.Wait();*/

/*Task<int> t = Task.Run(() =>
{
    int index = 0;
    for (int i = 0; i < 1000; i++)
    {
        index++;
    }
    return index;
});
// este result es bloqueante y hace que el hilo actual se bloquee esperando 
Console.WriteLine(t.Result);*/
/*Task<int> t = Task.Run(() =>
{
    int index = 0;
    for (int i = 0; i < 1000; i++)
    {
        index++;
    }
    return index;
}).ContinueWith((resultPrevius) =>
{
    return resultPrevius.Result * 2;
});
// este result es bloqueante y hace que el hilo actual se bloquee esperando 
Console.WriteLine(t.Result);*/
/*Task<int> t = Task.Run(() =>
{
    return 22;
});

t.ContinueWith((i) =>
{
    Console.WriteLine("CANCELADO");
}, TaskContinuationOptions.OnlyOnCanceled);

t.ContinueWith((i) =>
{
    Console.WriteLine("FALLADO");
}, TaskContinuationOptions.OnlyOnFaulted);

var completedTask = t.ContinueWith((i) =>
{
    Console.WriteLine("COMPLETADO");
}, TaskContinuationOptions.OnlyOnRanToCompletion);

completedTask.Wait();

Console.Read();*/
// Example TaskFactory
/*Task<int[]> parent = Task.Run(() =>
{
    var results = new int[3];
    TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);
    tf.StartNew(() => results[0] = 0);
    tf.StartNew(() => results[1] = 1);
    tf.StartNew(() => results[2] = 2);

    return results;
});
var finalTask = parent.ContinueWith(parentTask =>
{
    foreach (int i in parentTask.Result)
        Console.WriteLine(i);
});

finalTask.Wait();
Console.Read();*/
/*Task<int[]> parent = Task.Run(() =>
{
    int[] results = new int[3];

    new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
    new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
    new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

    return results;
});
Task finalTask = parent.ContinueWith(parentTask =>
{
    foreach (int i in parentTask.Result)
        Console.WriteLine(i);
});
finalTask.Wait();
Console.Read();*/
// Example WaitAll
/*Task[] tasks = new Task[3];

tasks[0] = Task.Run(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("1");
    return 1;
});

tasks[1] = Task.Run(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("2");
    return 2;
});

tasks[2] = Task.Run(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("3");
    return 3;
}
);

Task.WaitAll(tasks);
Console.Read();*/
/*
Task<int>[] tasks = new Task<int>[3];
tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });
while (tasks.Length > 0)
{
    int i = Task.WaitAny(tasks);
    Task<int> completedTask = tasks[i];
    Console.WriteLine(completedTask.Result);
    var temp = tasks.ToList();
    temp.RemoveAt(i);
    tasks = temp.ToArray();
}
Console.Read();*/
Task<int> task1 = Task.Run(() => Sleep(11000));
Task Continuation1 = task1.ContinueWith((task) =>
{
    Console.WriteLine($"Terminé de dormir. Dormí por {task.Result} segundos.");
});

Task<int> task2 = Task.Run(() => Sleep(7000));
Task Continuation2 = task2.ContinueWith((task) =>
{
    Console.WriteLine($"Terminé de dormir. Dormí por {task.Result} segundos");
});

Task<int> task3 = Task.Run(() => Sleep(4000));
Task Continuation3 = task3.ContinueWith((task) =>
{
    Console.WriteLine($"Terminé de dormir. Dormí por {task.Result} segundos");
});

Continuation1.Wait();
Continuation2.Wait();
Continuation3.Wait();
Console.WriteLine("Adiós");
Console.Read();
static int Sleep(int miliseconds)
{
    Thread.Sleep(miliseconds);
    return miliseconds / 1000;
}