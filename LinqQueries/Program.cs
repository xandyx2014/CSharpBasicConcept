// See https://aka.ms/new-console-template for more information
/*
 *
 *
 *
 */
Console.WriteLine("Hello, World!");
int[] data = { 1, 2, 5, 8, 11 };
//var result = from d in data
//             where d % 2 == 0
//             select d;

var result = data.Where(d => d % 2 == 0);
foreach (int i in result)
{
    Console.WriteLine(i);
}
Console.ReadKey();

result = from d in data
         where d > 5
         orderby d descending
         select d;
Console.WriteLine(string.Join(", ", result));
Console.ReadKey();

int[] data1 = { 1, 2, 5 };
int[] data2 = { 2, 4, 6 };
result = from d1 in data1
         from d2 in data2
         select d1 * d2;
Console.WriteLine(string.Join(", ", result));
Console.ReadKey();
// declaration
var MyProductA = new Product
{
    Description = "A",
    Price = 1
};

var orders = new List<Order>
            {
                new Order
                {
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Product = MyProductA,
                            Amount = 3
                        },
                        new OrderLine
                        {
                            Product = MyProductA,
                            Amount = 7
                        },
                        new OrderLine
                        {
                            Product = new Product
                            {
                                Description = "B",
                                Price = 2
                            },
                            Amount = 3
                        }
                    }
                }
            };
var averageNumberOfOrderLines = orders.Average(o => o?.OrderLines?.Count);
Console.WriteLine($"El promedio de ORDERLINES es: {averageNumberOfOrderLines}");
Console.ReadKey();

var resultQuery = from o in orders
                  from l in o.OrderLines
                  group l by l.Product into p
                  select new
                  {
                      Product = p.Key,
                      Amount = p.Sum(x => x.Amount)
                  };

var products = new List<Product>
            {
                new Product
                {
                    Description = "A",
                    Price = 1
                },
                new Product
                {
                    Description = "B",
                    Price = 2
                },
                new Product
                {
                    Description = "C",
                    Price = 3
                }
            };
string[] popularProductNames = { "A", "B" };
var popularProducts = from p in products
                      join n in popularProductNames on p.Description equals n
                      select p;

int pageSize = 2;
int pageIndex = 2;
var pagedOrders = orders.Skip((pageIndex - 1) * pageSize).Take(pageSize);
class Product
{
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
class OrderLine
{
    public int Amount { get; set; }
    public Product? Product { get; set; }
}
class Order
{
    private List<OrderLine> orderLines = new();

    public List<OrderLine> OrderLines { get => orderLines; set => orderLines = value; }
}

// este retorna un Ienumarable 
/*static class LinqExtensions
{
    public static IEnumerable<TSource> Where<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        foreach (TSource item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
}*/