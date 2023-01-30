using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitites
{
    public class Address
    {
        public int Id { get; set; }
        [Required, MaxLength (50)] 
        public string Address1 { get; set; }
        [Required, MaxLength (50)]
        public string Address2 { get; set; }
        [Required, MaxLength (50)]
        public int CityId { get; set; }
        [Required, MaxLength (50)]
        public int PostalCode { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
      
    }
}
