using Domain.Dtos;
using Domain.Response;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class CustomerConroller:ControllerBase
    {
        private CustomerService _customerService;

        public CustomerConroller(CustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("GetCustomer")]
         public async Task<Response<List<CustomerDto>>> GetCustomer()
        {
            return await _customerService.GetCustomer();  

        }
        [HttpPost("AddCustomer")]
        public async Task<Response<CustomerDto>> AddCustomer(CustomerDto customerDto) 
        {
            if(ModelState.IsValid)
            {
                return await _customerService.AddCustomer(customerDto);
            } 
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return new Response<CustomerDto>(HttpStatusCode.BadRequest, errors); 
            }
        }
    

        [HttpPut("UpdateCustomer")]
        public async Task<Response<CustomerDto>> Put([FromBody] CustomerDto customerDto) => await _customerService.Update(customerDto);

        [HttpDelete("Delete")]
        public async Task<Response<string>> Delete(int id) => await  _customerService.Delete(id);
    }

}
