using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Dtos 
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name should not be empty"),MaxLength(50)]  
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name should not be empty"), MaxLength(50)] 
        public string LastName { get; set; }
        [Required(ErrorMessage = "PhoneNumber should not be empty"), MaxLength(50)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email should not be empty"), MaxLength(50)] 
        public string Email { get; set; }

        public CustomerDto(){}
        public CustomerDto(int id, string firstName, string lastName, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
          
        }
    }

}
