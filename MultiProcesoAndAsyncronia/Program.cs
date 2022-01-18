static string ReverseString(string s)
{
    return new string(s.Reverse().ToArray());
}

Func<string, string> rev = ReverseString;

Console.WriteLine(rev("Una Cadena cualquiera."));

//delegate string Reverse(string s);
//string ReverseString(string s)
//{
//    return new string(s.Reverse().ToArray());
//}

//
//
// Reverse rev = ReverseString;
// Console.WriteLine(rev("Una Cadena cualquiera."));
// Console.Read();
//
// Existe vairos Delegatos, Funct, Action, Predicate

// Action Action<in T>(T obj)
// la action solo reciva
// Func<int T, out TResult>(T arg)
// public delegate bool Predicate<in T>(T obj)
