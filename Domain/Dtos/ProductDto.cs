using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ProductName should not be empty"), MaxLength(50)] 

        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage = "TotalAmount should not be empty"), MaxLength(50)] 
        public string TotalAmount { get; set; }
        public ProductDto()
        {

        }
        public ProductDto(int id, string productName, int supplierId, DateTime dateTime, string totalAmount)
        {
            Id = id;
            ProductName = productName;
            SupplierId = supplierId;
            DateTime = dateTime;
            TotalAmount = totalAmount;


        }
    }
}
