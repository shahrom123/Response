using AutoMapper;
using Domain.Dtos;
using Domain.Entitites;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructre.Services
{
    public class OrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OrderService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Response<List<OrderDto>>> GetOrder()
        {
            try
            {
                var result = _context.Orders.ToList();
                var mapped = _mapper.Map<List<OrderDto>>(result);
                return new Response<List<OrderDto>>(mapped);
            }
            catch (Exception ex)
            {
                return new Response<List<OrderDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
            }
        }
        public async Task<Response<OrderDto>> AddOrder(OrderDto orderDto)
        {
            try
            {
                var added = _mapper.Map<Order>(orderDto);
                await _context.Orders.AddAsync(added);
                await _context.SaveChangesAsync();
                return new Response<OrderDto>(orderDto);
            }
            catch (Exception e)
            {
                return new Response<OrderDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
            }
        }
        public async Task<Response<OrderDto>> Update(OrderDto orderDto)
        {
            try
            {
                var existing = await _context.Orders.Where(x => x.Id == orderDto.Id).AsNoTracking().FirstOrDefaultAsync();
                if (existing == null) return new Response<OrderDto>(HttpStatusCode.BadRequest, new List<string>() { "Order not Found" });

                var mapped = _mapper.Map<Order>(orderDto);
                _context.Orders.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<OrderDto>(orderDto);
            }
            catch (Exception ex)
            {
                return new Response<OrderDto>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });
            }
        }
        public async Task<Response<string>> Delete(int id)
        {
            var existing = await _context.Orders.FindAsync(id);
            if (existing == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found" });

            _context.Orders.Remove(existing);
            await _context.SaveChangesAsync();
            return new Response<string>("Deleted successfully"); 
        }
    }
}

