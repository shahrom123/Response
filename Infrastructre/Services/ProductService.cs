using AutoMapper;
using Domain.Dtos;
using Domain.Entitites;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructre.Services
{
    public class ProductService
    {
        private readonly DataContext _context;
          
        private readonly IMapper _mapper;
        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }
        public async Task<Response<List<ProductDto>>> GetProduct()
        {
            try
            {
                var result = _context.Products.ToList();
                var mapped = _mapper.Map<List<ProductDto>>(result);
                return new Response<List<ProductDto>>(mapped);
            }
            catch (Exception ex)
            {
                return new Response<List<ProductDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
            }
        }


        public async Task<Response<ProductDto>> Add(ProductDto productDto)
        {
            try
            {
                var added = _mapper.Map<Product>(productDto);
                await _context.Products.AddAsync(added);
                await _context.SaveChangesAsync();
                return new Response<ProductDto>(productDto);
            }
            catch (Exception e)
            {
                return new Response<ProductDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
            }
        }

        public async Task<Response<ProductDto>> Update(ProductDto productDto)
        {
            try
            {
                var existing = await _context.Products.Where(x => x.Id == productDto.Id).AsNoTracking().FirstOrDefaultAsync();
                if (existing == null) return new Response<ProductDto>(HttpStatusCode.BadRequest, new List<string>() { "Product not Found" });

                var mapped = _mapper.Map<Product>(productDto);
                _context.Products.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<ProductDto>(productDto);
            }
            catch (Exception ex)
            {
                return new Response<ProductDto>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });
            }
        }
        public async Task<Response<string>> Delete(int id)
        {
            var axisting = await _context.Products.FindAsync(id);
            if (axisting == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found" });

            _context.Products.Remove(axisting);
            await _context.SaveChangesAsync();
            return new Response<string>("Deleted successfully");
        }
    }
}
