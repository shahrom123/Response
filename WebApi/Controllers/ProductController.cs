using Domain.Dtos;
using Domain.Response;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class ProductConroller : ControllerBase
    {
        private ProductService _productService;

        public ProductConroller(ProductService customerService)
        {
            _productService = customerService;
        }
        [HttpGet("GetProduct")]
        public async Task<Response<List<ProductDto>>> Get()
        {
            return await _productService.GetProduct();

        }
        [HttpPost("AddProduct")]
        public async Task<Response<ProductDto>>  AddProduct([FromBody] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                return await _productService.Add(productDto);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return new Response<ProductDto>(HttpStatusCode.BadRequest, errors);
            }
        }


        [HttpPut("UpdateProduct")]
        public async Task<Response<ProductDto>> Put([FromBody] ProductDto productDto) => await _productService.Update(productDto);

        [HttpDelete("DeleteProduct")]
        public async Task<Response<string>> Delete(int id) => await _productService.Delete(id);
    }

}
