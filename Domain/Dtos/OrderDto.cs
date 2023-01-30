using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "CustomerId should not be empty"), MaxLength(50)] 
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "TotalAmount should not be empty"), MaxLength(50)]
        public decimal TotalAmount { get; set; }

        public OrderDto()
        {

        }
        public OrderDto(int id, int cutomerId, DateTime ordeDate, decimal totalAmount )
        {
            Id = id;
            CustomerId = cutomerId;
            OrderDate = ordeDate;
            TotalAmount = totalAmount;        
        }
    }

}
