// See https://aka.ms/new-console-template for more information
Pub p = new Pub();
p.OnChange += () => Console.WriteLine("Event raised to method 1");
p.OnChange += () => Console.WriteLine("Event raised to method 2");
p.Raise();
Console.Read();
class Pub
{
    public event Action OnChange = delegate { };
    public void Raise()
    {
        OnChange();
    }
}
class MyArgs : EventArgs
{
    public MyArgs(int value)
    {
        Value = value;
    }
    public int Value { get; set; }
}
class PubWhitEventHandler
{
    public event EventHandler<MyArgs> OnChange = delegate { };
    public void Raise()
    {
        OnChange(this, new MyArgs(42));
    }
}
class PubWhitLock
{
    private event EventHandler<MyArgs> onChange = delegate { };
    public event EventHandler<MyArgs> OnChange
    {
        add
        {
            lock (onChange)
            {
                onChange += value;
            }
        }
        remove
        {
            lock (onChange)
            {
                onChange -= value;
            }
        }
    }
    public void Raise()
    {
        onChange(this, new MyArgs(42));
    }
}
class PubWithException
{
    public event EventHandler OnChange = delegate { };
    public void Raise()
    {
        var exceptions = new List<Exception>();
        foreach (Delegate handler in OnChange.GetInvocationList())
        {
            try
            {
                handler.DynamicInvoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
        }
        if (exceptions.Any())
        {
            throw new AggregateException(exceptions);
        }
    }
}