using AutoMapper;
using System.Net;
using Domain.Dtos;
using Domain.Entitites;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructre.Services
{
    public class CustomerService
    {
        private readonly  DataContext _context;

        private readonly IMapper _mapper;
        public CustomerService(DataContext context, IMapper mapper ) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<List<CustomerDto>>> GetCustomer()
        {
            try
            {
                var result =  _context.Customers.ToList();
                var mapped = _mapper.Map<List<CustomerDto>>(result);
                return new Response<List<CustomerDto>>(mapped); 
            } 
            catch (Exception ex)
            {
                return new Response<List<CustomerDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<Response<CustomerDto>> AddCustomer(CustomerDto model)
        {
            try
            {
                var existingCustomer = _context.Customers.Where(x => x.FirstName == model.FirstName).FirstOrDefault();
                if (existingCustomer != null) 
                {
                    return new Response<CustomerDto>(HttpStatusCode.BadRequest,
                        new List<string>() { "Customer with this FirstName already exists" });
                }
                var mapped = _mapper.Map<Customer>(model);
                await _context.Customers.AddAsync(mapped);
                await _context.SaveChangesAsync();
                return new Response<CustomerDto>(model);
            }
            catch (Exception e)
            {
                return new Response<CustomerDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
            }
        }
        public async Task<Response<CustomerDto>> Update(CustomerDto customerDto)
        {
            try
            {
                var existing = await _context.Customers.Where(x => x.Id == customerDto.Id).AsNoTracking().FirstOrDefaultAsync();
                if (existing == null) return new Response<CustomerDto>(HttpStatusCode.BadRequest, new List<string>() { "Customer not Found" });

                var mapped = _mapper.Map<Customer>(customerDto);
                _context.Customers.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<CustomerDto>(customerDto);
            }
            catch (Exception ex)
            {
                return new Response<CustomerDto>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });

            }
        }



        public async Task<Response<string>> Delete(int id) 
        {
            var existing = await _context.Customers.FindAsync(id);
            if (existing == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found" });

            _context.Customers.Remove(existing);
            await _context.SaveChangesAsync();
            return new Response<string>("Deleted successfully");
        }
    }
}
