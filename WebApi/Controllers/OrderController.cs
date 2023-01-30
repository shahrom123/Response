using Domain.Dtos;
using Domain.Response;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class OrderConroller:ControllerBase
    {
        private OrderService _orderService;

        public OrderConroller(OrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("GetOrder")]
        public async Task<Response<List<OrderDto>>> Get()
        {
            return await _orderService.GetOrder();

        }
        [HttpPost("AddOrder")]
        public async Task<Response<OrderDto>> Add([FromBody] OrderDto orderDto)
        {
            if (ModelState.IsValid)
            {
                return await _orderService.AddOrder(orderDto);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return new Response<OrderDto>(HttpStatusCode.BadRequest, errors);
            }
        }
    

        [HttpPut("UpdateOrder")]
        public async Task<Response<OrderDto>> Put([FromBody] OrderDto orderDto) =>
          await   _orderService.Update(orderDto);

        [HttpDelete("DeleteOrder")]
        public async Task<Response<string>> Delete(int id) => await _orderService.Delete(id);
    }

}
