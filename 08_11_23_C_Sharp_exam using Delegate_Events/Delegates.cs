using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
}

public class Customer
{
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
}

public class Order
{
    public int OrderID { get; set; }
    public DateTime OrderDateTime { get; set; }
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }

    public event Action<Order> OrderProcessed;

    public void ProcessOrder()
    {
        Console.WriteLine($"Processing order {OrderID}...");
        // Логика обработки заказа
        OrderProcessed?.Invoke(this);
    }
}

public class Store
{
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        orders.Add(order);
    }

    public List<Order> ProcessOrders()
    {
        Console.WriteLine("Processing orders:");
        foreach (var order in orders)
        {
            order.ProcessOrder();
        }
        return orders;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Создание товаров
        var product1 = new Product { ProductID = 1, ProductName = "Товар 1", ProductPrice = 10.99m };
        var product2 = new Product { ProductID = 2, ProductName = "Товар 2", ProductPrice = 20.49m };
        var product3 = new Product { ProductID = 3, ProductName = "Товар 3", ProductPrice = 15.0m };

        // Создание клиентов
        var customer1 = new Customer { CustomerID = 1, CustomerName = "Иванов", CustomerAddress = "Москва" };
        var customer2 = new Customer { CustomerID = 2, CustomerName = "Петров", CustomerAddress = "Санкт-Петербург" };

        // Создание заказов
        var order1 = new Order { OrderID = 1, OrderDateTime = DateTime.Now, Customer = customer1 };
        var order2 = new Order { OrderID = 2, OrderDateTime = DateTime.Now, Customer = customer2 };

        order1.Products = new List<Product> { product1, product2 };
        order2.Products = new List<Product> { product2, product3 };

        // Создание магазина и добавление заказов
        var store = new Store();
        store.AddOrder(order1);
        store.AddOrder(order2);

        // Обработка заказов
        store.ProcessOrders();

        // Подписка на событие обработки заказов
        order1.OrderProcessed += OrderProcessedHandler;
        order2.OrderProcessed += OrderProcessedHandler;

        // Обработка заказов с использованием LINQ
        var processedOrders = store.ProcessOrders().Where(o => o.OrderDateTime.Year == DateTime.Now.Year);
        foreach (var order in processedOrders)
        {
            Console.WriteLine($"Processed order: {order.OrderID}, Customer: {order.Customer.CustomerName}");
        }
    }

    private static void OrderProcessedHandler(Order order)
    {
        Console.WriteLine($"Order {order.OrderID} processed successfully.");
    }
}
