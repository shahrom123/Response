using AutoMapper;
using Domain.Dtos;
using Domain.Entitites;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructre.Services
{
    public class SupplierService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        public SupplierService(DataContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public async Task<Response<List<SupplierDto>>> GetSupplier()
        {
            try
            {
                var result = _context.Suppliers.ToList();
                var mapped = _mapper.Map<List<SupplierDto>>(result);
                return new Response<List<SupplierDto>>(mapped);
            }
            catch (Exception ex)
            {
                return new Response<List<SupplierDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<Response<SupplierDto>> Add(SupplierDto supplierDto)
        {
            try
            {
                var added = _mapper.Map<Supplier>(supplierDto);
                await _context.Suppliers.AddAsync(added);
                await _context.SaveChangesAsync();
                return new Response<SupplierDto>(supplierDto);
            }
            catch (Exception e)
            {
                return new Response<SupplierDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
            }
        }

        public async Task<Response<SupplierDto>> Update(SupplierDto supplierDto)
        {
            try
            {
                var existing = await _context.Suppliers.Where(x => x.Id == supplierDto.Id).AsNoTracking().FirstOrDefaultAsync();
                if (existing == null) return new Response<SupplierDto>(HttpStatusCode.BadRequest, new List<string>() { "Order not Found" });

                var mapped = _mapper.Map<Supplier>(supplierDto);
                _context.Suppliers.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<SupplierDto>(supplierDto);
            }
            catch (Exception ex)
            {
                return new Response<SupplierDto>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });
            }
        }
        public async Task<Response<string>> Delete(int id)
        {
            var axisting = await _context.Suppliers.FindAsync(id);
            if (axisting == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found" });

            _context.Suppliers.Remove(axisting);
            await _context.SaveChangesAsync();
            return new Response<string>("Deleted successfully");
        }
    }
}
