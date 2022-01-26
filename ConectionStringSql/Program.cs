// See https://aka.ms/new-console-template for more information
using System.Configuration;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=Northwind;server=(local)";
using (var connection = new SqlConnection(connectionString))
{
    connection.Open();
    // Aquí ejecutaremos operacion con la Base de Datos

} // <-Automáticamente se cierra la Base de Datos

var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = @"(localdb)\v11.0";
sqlConnectionStringBuilder.InitialCatalog = "MyCatalog";
connectionString = sqlConnectionStringBuilder.ToString();
/*string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;
using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
}*/


/*static async Task UpdateRows()
{
    string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand("UPDATE People SET middlename = 'Jorge' WHERE id=3", connection);
        await connection.OpenAsync();
        int numberOfUpdatedRows = await command.ExecuteNonQueryAsync();
        Console.WriteLine("Updated {0} rows", numberOfUpdatedRows);
    }
}*/
/*static async Task InsertRowWithParameterizedQuery()
{
    string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand("INSERT INTO People([FirstName], [LastName], [MiddleName]) VALUES(@firstName, @lastName, @middleName)", connection);
        await connection.OpenAsync();

        command.Parameters.AddWithValue("@firstName", "Alejandro");
        command.Parameters.AddWithValue("@lastName", "Ramírez");
        command.Parameters.AddWithValue("@middleName", "Pablo");
        int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
        Console.WriteLine($"Inserted {numberOfInsertedRows} rows");
    }
}*/
// transaction scope
/*string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        SqlCommand command1 = new SqlCommand("INSERT INTO People([firstname], [lastname], [middlename]) VALUES('Pablo', 'Morales', null)", connection);
        SqlCommand command2 = new SqlCommand("INSERT INTO People([firstname], [lastname], [middlename]) VALUES('Janna', 'García', null)", connection);
        command1.ExecuteNonQuery();
        throw new ApplicationException("Mi error...");
        command2.ExecuteNonQuery();
    }
    transactionScope.Complete();
}*/
// first code
// ORM
/*using (PetsContext ctx = new PetsContext())
{
    ctx.Pets.Add(new Pet() { Id = 2, Name = "Canelo", Breed = "Sin Raza" });
    ctx.SaveChanges();
}
Console.ReadKey();*/
/* class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Type { get; set; }
}

 class PetsContext : DbContext
{
    public IDbSet<Pet> Pets { get; set; }
    public PetsContext() : base(@"Server=LAPTOP-3NTIOCKV\SQLEXPRESS;Database=MyDataBase;Trusted_Connection=True;")
    {
    }
}*/