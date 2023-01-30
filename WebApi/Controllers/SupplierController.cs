using Domain.Dtos;
using Domain.Response;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class SupplierConroller : ControllerBase
    {
        private SupplierService _supplierService;

        public SupplierConroller(SupplierService supplierService)
        {
            _supplierService= supplierService;
        }
        [HttpGet("GetSupplier")]
        public async Task<Response<List<SupplierDto>>> Get()
        {
            return await _supplierService.GetSupplier();

        }
        [HttpPost("AddSupplier")]
        public async Task<Response<SupplierDto>> AddSupplier([FromBody] SupplierDto supplierDto)
        {
            if (ModelState.IsValid)
            {
                return  await _supplierService.Add(supplierDto);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return new Response<SupplierDto>(HttpStatusCode.BadRequest, errors);
            }
        }


        [HttpPut("UpdateSupplier")]
        public async Task<Response<SupplierDto>> Put([FromBody] SupplierDto supplierDto) => await _supplierService.Update(supplierDto);

        [HttpDelete("DeleteSupplier")]
        public async Task<Response<string>>  Delete(int id) => await _supplierService.Delete(id);
    }

}
