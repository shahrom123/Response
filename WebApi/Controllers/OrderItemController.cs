using Domain.Dtos;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class OrderItemConroller : ControllerBase 
    {
        private OrderItemService _customerService;

        public OrderItemConroller(OrderItemService orderItemService)
        {
            _customerService = orderItemService;
        }
        [HttpGet("GetOrderItem")]
        public async Task<List<OrderItemDto>> Get()
        {
            return await _customerService.GetOrderItem();

        }
        [HttpPost("AddOrderItem")]
        public async Task<OrderItemDto> AddOrderItem([FromBody] OrderItemDto orderItemDto)
        {
            return await _customerService.AddOrderItem(orderItemDto);
        }


        [HttpPut("UpdateOrderItem")]
        public OrderItemDto Put([FromBody] OrderItemDto orderItemDto) => _customerService.UpdateOrderItem(orderItemDto);

        [HttpDelete("DeleteOrderItem")]
        public bool Delete(int id) => _customerService.DeleteOrderItem(id);
    }

}
