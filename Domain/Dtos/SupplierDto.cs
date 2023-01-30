using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class SupplierDto
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "CompanyName should not be empty"), MaxLength(50)] 
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Phone should not be empty"), MaxLength(50)]
        public int Phone { get; set; } 
        public SupplierDto()
        {

        }
        public SupplierDto(int id, string companyName, int phone)
        {
            Id = id;
            CompanyName = companyName;
            Phone = phone;

        }
    }
}
