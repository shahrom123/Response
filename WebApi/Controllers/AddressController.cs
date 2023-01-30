using Domain.Dtos;
using Domain.Response;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class AddressController : ControllerBase
    {
        private AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet("GetAddress")]
        public async Task<Response<List<AddressDto>>> GetAddress()
        {
            return await _addressService.GetAddres();

        }
        [HttpPost("AddAddress")]
        public async Task<Response<AddressDto>> Add(AddressDto addressDto)
        {
            if (ModelState.IsValid)
            {
                return await _addressService.AddAddress(addressDto);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return new Response<AddressDto>(HttpStatusCode.BadRequest, errors); 
            }
        }

        [HttpPut("UpdateAddress")]
        public async Task<Response<AddressDto>> Put([FromBody] AddressDto addressDto) => await _addressService.UpdateAddress(addressDto);

        [HttpDelete("DeleteAddress")]
        public async Task<Response<string>> Delete(int id) => await _addressService.DeleteAddress(id);
    }

}
