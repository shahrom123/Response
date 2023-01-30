using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitites
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } 
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime DateTime { get; set; }
        public string TotalAmount { get; set; }

        public Product()
        {

        }
        public Product(int id, string productName, int supplierId, DateTime dateTime, string totalAmount)
        {
            Id = id;
            ProductName = productName;
            SupplierId = supplierId;
            DateTime = dateTime;
            TotalAmount = totalAmount;


        }
    }
}
