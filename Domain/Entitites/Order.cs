using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitites
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Customer> Customers { get; set; }

        public Order()
        {

        }
        public Order(int id, int cutomerId, DateTime ordeDate, decimal totalAmount)
        {
            Id = id;
            CustomerId = cutomerId;
            OrderDate = ordeDate;
            TotalAmount = totalAmount;
        }

    }
}
