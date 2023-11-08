
/*
 \\\\\\\\\\\\\\\\\\\\
Подготовка к экзамену использование ивентов использования делегата
\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
 В C# делегаты используются для создания объектов, представляющих собой функции или методы. 
Это позволяет передавать методы как аргументы другим методам или использовать их в качестве элементов коллекции.
....................
Вот пример использования делегата:
.......................

// Создаем делегат, который будет принимать два int параметра и возвращать void
delegate void MyDelegate(int a, int b);

// Определяем метод, который делегат будет представлять
void MyMethod(int a, int b)
{
    // тело метода
}

// Создаем экземпляр делегата, передавая ссылку на метод
MyDelegate del = new MyDelegate(MyMethod);

// Вызываем делегат
del(2, 3);
Ивенты в C# используются для реализации событийного программирования.
Они позволяют разработчикам уведомлять другие объекты об изменении состояния или возникновении определенных событий.
..........................
Пример использования ивентов:
..........................

public class Publisher
{
    public event EventHandler MyEvent; // Объявляем событие

    public void Publish()
    {
        if (MyEvent != null)
            MyEvent(this, new EventArgs()); // Вызываем событие, если есть подписчики
Продолжи   
}
}

public class Subscriber
{
private Publisher publisher;

public Subscriber(Publisher pub)
{
    publisher = pub;
    publisher.MyEvent += HandleEvent; // Добавляем обработчик события
}

private void HandleEvent(object sender, EventArgs e)
{
    // Обрабатываем событие
}
}```
 */

/*
 Задание:
На С# решить с помощъю использования delegate и Events  Проверит в Main()
Вам предлагается создать простую систему учета заказов для виртуального магазина.
Система должна иметь следующие функциональности:
Создать класс "Заказ" (Order), который должен содержать:
Идентификатор заказа (OrderID)
Дату и время размещения заказа (OrderDateTime)
Клиента, разместившего заказ (Customer)
Список товаров в заказе (List of Products)

Создать класс "Товар" (Product), который должен содержать:
Идентификатор товара (ProductID)
Название товара (ProductName)
Цену товара (ProductPrice)

Создать класс "Клиент" (Customer), который должен содержать:
Идентификатор клиента (CustomerID)
Имя клиента (CustomerName)
Адрес клиента (CustomerAddress)
В классе "Заказ" создать событие (Event) "ЗаказОбработан" (OrderProcessed),

которое будет вызываться, когда заказ будет обработан.
В классе "Магазин" (Store) создать методы:
ДобавитьЗаказ (AddOrder), который будет добавлять новый заказ в систему.
ОбработатьЗаказы (ProcessOrders), который будет обрабатывать все заказы в системе и вызывать
событие "ЗаказОбработан" для каждого заказа.

В главной функции программы (Main) создать несколько объектов классов "Товар", "Клиент" и "Заказ".
Добавить эти заказы в систему магазина с помощью метода "ДобавитьЗаказ". 
Затем вызвать метод "ОбработатьЗаказы" для обработки заказов.
При каждой успешной обработке заказа выводить информацию о заказе в консоль.
Вам необходимо реализовать все необходимые классы и методы, а также обработку события "ЗаказОбработан".
Используйте методы LINQ для манипуляции данными, например, для фильтрации, сортировки или выборки нужных заказов или товаров.
 */

namespace _08_11_23_C_Sharp_exam_using_Delegate_Events
{
    public class Program
    {

        public static List<Car> cars = new List<Car>();

        public Program()
        {            
            cars = new List<Car>();
        }

        public static void AddNewCar()
        {
            Car newCar = new Car();
            Console.Write("Enter brand: ");
            newCar.Brand = Console.ReadLine();

            Console.Write("Enter model: ");
            newCar.Model = Console.ReadLine();

            Console.Write("Enter year: ");
            newCar.Year = int.Parse(Console.ReadLine());

            Console.Write("Enter color: ");
            newCar.Color = Console.ReadLine();

            Console.Write("Enter price: ");
            newCar.Price = decimal.Parse(Console.ReadLine());

            cars.Add(newCar);
        }

        public static void EditCar()
        {
            Console.WriteLine("Enter index of car to edit: ");
            int index = int.Parse(Console.ReadLine());
            Console.Write("Enter new brand: ");
            cars[index].Brand = Console.ReadLine();

            Console.Write("Enter new model: ");
            cars[index].Model = Console.ReadLine();

            Console.Write("Enter new year: ");
            cars[index].Year = int.Parse(Console.ReadLine());

            Console.Write("Enter new color: ");
            cars[index].Color = Console.ReadLine();

            Console.Write("Enter new price: ");
            cars[index].Price = decimal.Parse(Console.ReadLine());            
        }
        static void ViewAllCars()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i}. {cars[i].Brand} {cars[i].Model} ({cars[i].Year}), {cars[i].Color}, {cars[i].Price:C}");
            }
            static void DeleteCar()
            {
                ViewAllCars();
                Console.Write("Enter index of car to delete: ");
                int index = int.Parse(Console.ReadLine());
                cars.RemoveAt(index);
            }

        }

        static void Main(string[] args)
        {
            //Task_1 
            Console.WriteLine("Hello, World!");
            // Создание объектов товаров, клиентов и заказов
            Product product1 = new Product { ProductID = 1, ProductName = "Product 1", ProductPrice = 10.00m };
            Product product2 = new Product { ProductID = 2, ProductName = "Product 2", ProductPrice = 20.00m };

            Customer customer1 = new Customer { CustomerID = 1, CustomerName = "Customer 1", CustomerAddress = "Address 1" };
            Customer customer2 = new Customer { CustomerID = 2, CustomerName = "Customer 2", CustomerAddress = "Address 2" };

            Order order1 = new Order { OrderID = 1, OrderDateTime = DateTime.Now, Customer = customer1, Products = new List<Product> { product1, product2 } };
            Order order2 = new Order { OrderID = 2, OrderDateTime = DateTime.Now, Customer = customer2, Products = new List<Product> { product2 } };

            // Создание магазина и добавление заказов
            Store store = new Store();
            store.AddOrder(order1);
            store.AddOrder(order2);

            // Обработка заказов
            store.ProcessOrder();

            //Task_2

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("1. Add new car");
                Console.WriteLine("2. Edit existing car");
                Console.WriteLine("3. Delete car");
                Console.WriteLine("4. View all cars");
                Console.WriteLine("5. Search by brand");
                Console.WriteLine("6. Search by color");
                Console.WriteLine("7. Search by price range");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddNewCar();
                        break;
                    case 2:
                        EditCar();
                        break;
                    case 3:
                        DeleteCar();
                        break;
                    case 4:
                        ViewAllCars();
                        break;
                    case 5:
                        SearchByBrand();
                        break;
                    case 6:
                        SearchByColor();
                        break;
                    case 7:
                        SearchByPriceRange();
                        break;
                    case 8:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }         
    }
}

/*
 В C# события (events) используются для реализации асинхронного и синхронного событийного-ориентированного программирования.
События позволяют классам предоставлять уведомления другим классам или объектам о каких-либо происходящих
изменениях состояния или выполнении действий.

Когда вы объявляете событие в классе, вы создаете его “слугу” (hanlder), который вызывается при наступлении этого события.
Этот слуга является делегатом, который может быть связан с одним или несколькими методами обратного вызова.

Вот пример использования и регистрации делегата для события:

// Класс, который будет обрабатывать событие
public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Обработка заказа...
    }
}

// Класс с событием
public class MyClass
{
    // Объявление делегата события
    public delegate void EventHandler(Order order);
    
    public event EventHandler OrderProcessed;

    public MyClass()
    {
        OrderProcessor processor = new OrderProcessor();

        // Регистрация делегата события с методом обратного вызова
        OrderProcessed += (order) => { processor.
*/

/*
 > ChatGPT4 | OpenAI | ЧатГПТ | ChatGPT bot:
Пример реализации:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Car
{
public string Brand { get; set; }
public string Model { get; set; }
public int Year { get; set; }
public string Color { get; set; }
public decimal Price { get; set; }
}

class Program
{
static List<Car> cars = new List<Car>();

static void Main()
{
    bool running = true;

    while (running)
    {
        Console.Clear();
        Console.WriteLine("1. Add new car");
        Console.WriteLine("2. Edit existing car");
        Console.WriteLine("3. Delete car");
        Console.WriteLine("4. View all cars");
        Console.WriteLine("5. Search by brand");
        Console.WriteLine("6. Search by color");
        Console.WriteLine("7. Search by price range");
        Console.WriteLine("8. Exit");

        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddNewCar();
                break;
            case 2:
                EditCar();
                break;
            case 3:
                DeleteCar();
                break;
            case 4:
                ViewAllCars();
                break;
            case 5:
                SearchByBrand();
                break;
            case 6:
                SearchByColor();
                break;
            case 7:
                SearchByPriceRange();
                break;
            case 8:
                running = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

static void AddNewCar()
{
    Car newCar = new Car();

    Console.Write("Enter brand: ");
    newCar.Brand = Console.ReadLine();

    Console.Write("Enter model: ");
    newCar.Model = Console.ReadLine();

    Console.Write("Enter year: ");
    newCar.Year = int.Parse(Console.ReadLine());

    Console.Write("Enter color: ");
    newCar.Color = Console.ReadLine();

    Console.Write("Enter price: ");
    newCar.Price = decimal.Parse(Console.ReadLine());

    cars.Add(newCar);
}

static void EditCar()
{
    ViewAllCars();
    Console.Write("Enter index of car to edit: ");
    int index = int.Parse(Console.ReadLine());

    Console.Write("Enter new brand: ");
    cars[index].Brand = Console.ReadLine();

    Console.Write("Enter new model: ");
    cars[index].Model = Console.ReadLine();

    Console.Write("Enter new year: ");
    cars[index].Year = int.Parse(Console.ReadLine());

    Console.Write("Enter new color: ");
    cars[index].Color = Console.ReadLine();

    Console.Write("Enter new price: ");
    cars[index].Price = decimal.Parse(Console.ReadLine());
}

static void DeleteCar()
{
    ViewAllCars();
    Console.Write("Enter index of car to delete: ");
    int index = int.Parse(Console.ReadLine());
    cars.RemoveAt(index);
}

static void ViewAllCars()
{
    for (int i = 0; i < cars.Count; i++)
    {
        Console.WriteLine($"{i}. {cars[i].Brand} {cars[i].Model} ({cars[i].Year}), {cars[i].Color}, {cars[i].Price:C}");
    }
}

static void SearchByBrand()
{
    Console.Write("Enter brand to search for: ");
    string brand = Console.ReadLine();

    var result = cars.Where(car => car.Brand.ToLower() == brand.ToLower());

    Console.WriteLine("Search results:");
    foreach (var car in result)
    {
        Console.WriteLine($"{car.Brand} {car.Model} ({car.Year}), {car.Color}, {car.Price:C}");
    }
}

static void SearchByColor()
{
    Console.Write("Enter color to search for: ");
    string color = Console.ReadLin

> ChatGPT4 | OpenAI | ЧатГПТ | ChatGPT bot:
e();

    var result = cars.Where(car => car.Color.ToLower() == color.ToLower());

    Console.WriteLine("Search results:");
    foreach (var car in result)
    {
        Console.WriteLine($"{car.Brand} {car.Model} ({car.Year}), {car.Color}, {car.Price:C}");
    }
}

static void SearchByPriceRange()
{
    Console.Write("Enter minimum price: ");
    decimal minPrice = decimal.Parse(Console.ReadLine());

    Console.Write("Enter maximum price: ");
    decimal maxPrice = decimal.Parse(Console.ReadLine());

    var result = cars.Where(car => car.Price >= minPrice && car.Price <= maxPrice);

    Console.WriteLine("Search results:");
    foreach (var car in result)
    {
        Console.WriteLine($"{car.Brand} {car.Model} ({car.Year}), {car.Color}, {car.Price:C}");
    }
}
}
```

Это пример базового консольного приложения для управления коллекцией автомобилей на C#. 
Вы можете улучшить его добавлением обработки исключений, сохранением данных в файле, 
более сложным поиском и дополнительными функциями по вашему выбору.

 */