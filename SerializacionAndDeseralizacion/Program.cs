// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
Console.WriteLine("Hello, World!");
// using XML Serializer
/*XmlSerializer? serializer = new(typeof(Person));
string xml;
using (var stringWriter = new StringWriter())
{
    var p = new Person
    {
        FirstName = "Sergio",
        LastName = "Pérez",
        Age = 42
    };
    serializer.Serialize(stringWriter, p);
    xml = stringWriter.ToString();
}
Console.WriteLine(xml);
Console.ReadKey();

using (StringReader stringReader = new(xml))
{
    Person? p = serializer.Deserialize(stringReader) as Person;
    Console.WriteLine($"{p?.FirstName} {p?.LastName} tiene {p?.Age} años");
}
Console.ReadKey();
[Serializable]
class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
}*/
// 2.- Binari serializer
/*Person person = new Person
{
    Id = 1,
    Name = "Sergio Pérez"
};
IFormatter? formatter = new BinaryFormatter();
using (Stream stream = new FileStream(@"C:\Temp\data.bin", FileMode.Create))
{
    formatter?.Serialize(stream, person);
}
Console.WriteLine("Se serializó objeto en el archivo data.bin");
Console.ReadKey();

using (Stream stream = new FileStream(@"C:\Temp\data.bin", FileMode.Open))
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    Person deserializePerson = formatter.Deserialize(stream) as Person;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    Console.WriteLine($"Se deserializó objeto Person ID={deserializePerson.Id} Name={deserializePerson.Name}");
    Console.ReadKey();
}

PersonComplex personcomplex = new PersonComplex
{
    Id = 1,
    Name = "Sergio Pérez"
};
formatter = new BinaryFormatter();
using (Stream stream = new FileStream(@"C:\Temp\data.bin", FileMode.Create))
{
    formatter.Serialize(stream, personcomplex);
}
Console.WriteLine("Se serializó objeto en el archivo data.bin");
Console.ReadKey();

using (Stream stream = new FileStream(@"C:\Temp\data.bin", FileMode.Open))
{
    PersonComplex deserializePersonComplex = (PersonComplex)formatter.Deserialize(stream);
    Console.WriteLine($"Se deserializó objeto Person ID={deserializePersonComplex.Id} Name={deserializePersonComplex.Name}");
    Console.ReadKey();
}
[Serializable]
class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [NonSerialized]
    private bool isDirty = false;
    [OnSerializing()]
    internal void OnSerializingMethod(StreamingContext context)
    {
        Console.WriteLine("Serializando objeto.");
    }
    [OnSerialized()]
    internal void OnSerializedMethod(StreamingContext context)
    {
        Console.WriteLine("Objeto serializado.");
    }
    [OnDeserializing()]
    internal void OnDeserializingMethod(StreamingContext context)
    {
        Console.WriteLine("Deserializando objeto.");
    }
    [OnDeserialized()]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        Console.WriteLine("Objeto deserializado.");
    }
}
// le dice que propiedades puede serialziar y cuales no
[Serializable]
class PersonComplex : ISerializable
{
    public int Id { get; set; }
    public string Name { get; set; }
    private bool isDirty = false;
    public PersonComplex() { }
    protected PersonComplex(SerializationInfo info, StreamingContext context)
    {
        Id = info.GetInt32("Value1");
        Name = info.GetString("Value2") ?? "";
        isDirty = info.GetBoolean("Value3");
    }
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Value1", Id);
        info.AddValue("Value2", Name);
        info.AddValue("Value3", isDirty);
    }
}*/
// DataContract
var person = new PersonDataContract
{
    Id = 1,
    Name = "Sergio Pérez"
};

using (Stream stream = new FileStream(@"C:\Temp\data.xml", FileMode.Create))
{
    DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(PersonDataContract));
    dataContractSerializer.WriteObject(stream, person);
}
Console.WriteLine("Se serializó objeto en el archivo data.xml");
Console.ReadKey();

using (Stream stream = new FileStream(@"C:\Temp\data.xml", FileMode.Open))
{
    DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(PersonDataContract));
    PersonDataContract deserializePerson = (PersonDataContract)dataContractSerializer.ReadObject(stream);
    Console.WriteLine($"Se deserializó objeto Person ID={deserializePerson.Id} Name={deserializePerson.Name}");
    Console.ReadKey();
}
[DataContract]
class PersonDataContract
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Name { get; set; }
    private readonly bool isDirty = false;
}