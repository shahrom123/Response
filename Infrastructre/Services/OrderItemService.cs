using AutoMapper;
using Domain.Dtos;
using Domain.Entitites;
using Infrastructure.Data;

namespace Infrastructre.Services
{
    public class OrderItemService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        public OrderItemService(DataContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public async Task<List<OrderItemDto>> GetOrderItem()
        {
            var result = _context.OrderItems.ToList();
            return _mapper.Map<List<OrderItemDto>>(result);
        }
        public async Task<OrderItemDto> AddOrderItem(OrderItemDto orderItemDto)
        {
            var mapped = _mapper.Map<OrderItem>(orderItemDto);
            await _context.OrderItems.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return orderItemDto;
        }

        public OrderItemDto UpdateOrderItem(OrderItemDto orderItemDto)
        {
            var orderItem = _context.OrderItems.Find(orderItemDto.Quantity);
            orderItem.OrderId = orderItemDto.OrderId;
            orderItem.ProductId = orderItemDto.ProductId;
            orderItem.Quantity = orderItemDto.Quantity;
            _context.SaveChanges(); 
            return orderItemDto;
        }
        public bool DeleteOrderItem(int id)
        {
            var orderItem = _context.OrderItems.Find(id);
            if (orderItem == null) return false;
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges(); 
            return true;
        }
    }
}
