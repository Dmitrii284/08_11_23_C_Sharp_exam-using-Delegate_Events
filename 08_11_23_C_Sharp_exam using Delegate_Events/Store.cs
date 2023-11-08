using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_11_23_C_Sharp_exam_using_Delegate_Events
{
    public class Store
    {
        public List<Order> Orders { get; set; }
        public Store() 
        {
            Orders = new List<Order>();
        }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
        public void ProcessOrder()
        {
            foreach (Order order in Orders)
            {
                order.ProcessOrder();
            }
        }
    }
}
