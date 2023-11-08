
/*
 
На С# используя delegate и Events  Решить задачу.
Создать простую систему учета заказов для виртуального магазина.
Система должна :
Создать класс  (Order), содержит:
Идентификатор заказа (OrderID)
Дату и время размещения заказа (OrderDateTime)
Клиента, разместившего заказ (Customer)
Список товаров в заказе (List of Products)
Создать класс  (Product),содержит:
Идентификатор товара (ProductID)
Название товара (ProductName)
Цену товара (ProductPrice)
Создать класс "Клиент" (Customer), содержит:
Идентификатор клиента (CustomerID)
Имя клиента (CustomerName)
Адрес клиента (CustomerAddress)
В классе "Заказ" создать событие (Event)  (OrderProcessed),
которое будет вызываться, когда заказ будет обработан.
В классе (Store) создать методы:
ДобавитьЗаказ (AddOrder), который будет добавлять новый заказ в систему.
ОбработатьЗаказы (ProcessOrders), который будет обрабатывать все заказы в системе и вызывать
событие "ЗаказОбработан" для каждого заказа.
В  (Main) создать несколько объектов классов "Товар", "Клиент" и "Заказ".
Добавить эти заказы в систему магазина с помощью метода (AddOrder). 
Продемонстрировать работу .

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Создать класс "Заказ" (Order), который должен содержать:
Идентификатор заказа (OrderID)
Дату и время размещения заказа (OrderDateTime)
Клиента, разместившего заказ (Customer)
Список товаров в заказе (List of Products)

В классе "Заказ" создать событие (Event) "ЗаказОбработан" (OrderProcessed),

которое будет вызываться, когда заказ будет обработан.
В классе "Магазин" (Store) создать методы:
ДобавитьЗаказ (AddOrder), который будет добавлять новый заказ в систему.
ОбработатьЗаказы (ProcessOrders), который будет обрабатывать все заказы в системе и вызывать
событие "ЗаказОбработан" для каждого заказа.
 */
namespace _08_11_23_C_Sharp_exam_using_Delegate_Events
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }

        public event EventHandler OrderProcessed;

        protected virtual void OnOrderProcessed(EventArgs e)
        {
            OrderProcessed?.Invoke(this, e);
        }
        public void ProcessOrder()
        {
        Console.WriteLine("Processing order: " + OrderID);

            OnOrderProcessed(EventArgs.Empty);
        }        
    }
}
