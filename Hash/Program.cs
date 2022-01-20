// Hash  es un algoritmo matematico que convierte una serie de caracteres fija


using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/*var mySet = new Set<string>();
mySet.Insert("Mi string 1");
mySet.Insert("Mi string 2");
mySet.Insert("Mi string 1");

var byteConverter = new UnicodeEncoding();
SHA256 sha256 = SHA256.Create();
string data = "A paragraph of text";
byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));
data = "A paragraph of changed text";
byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));
data = "A paragraph of text";
byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));
Console.WriteLine(hashA.SequenceEqual(hashB)); // Displays: false
Console.WriteLine(hashA.SequenceEqual(hashC)); // Displays: true
Console.ReadKey();
class Set<T>
{
    private readonly List<T>[] buckets = new List<T>[100];
    public void Insert(T item)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        int bucket = GetBucket(item.GetHashCode());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        if (Contains(item, bucket))
            return;
        if (buckets[bucket] == null)
            buckets[bucket] = new List<T>();
        buckets[bucket].Add(item);
    }
    public bool Contains(T item)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return Contains(item, GetBucket(item.GetHashCode()));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
    private int GetBucket(int hashcode)
    {
        // A Hash code can be negative. To make sure that you end up with a positive
        // value cast the value to an unsigned int. The unchecked block makes sure that
        // you can cast a value larger then int to an int safely.
        unchecked
        {
            return (int)((uint)hashcode % (uint)buckets.Length);
        }
    }
    private bool Contains(T item, int bucket)
    {
        if (buckets[bucket] != null)
            foreach (T member in buckets[bucket])
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (member.Equals(item))
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    return true;
        return false;
    }
}*/
using (var ss = new SecureString())
{
    Console.Write("Proporcione la contraseña: ");
    while (true)
    {
        ConsoleKeyInfo cki = Console.ReadKey(true);
        if (cki.Key == ConsoleKey.Enter) break;
        ss.AppendChar(cki.KeyChar);
        Console.Write("*");
    }
    ss.MakeReadOnly();
    ConvertToUnsecureString(ss);
}
Console.ReadKey();
static void ConvertToUnsecureString(SecureString securePassword)
{
    IntPtr unmanagedString = IntPtr.Zero;
    try
    {
        unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
        Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
    }
    finally
    {
        Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
    }
}