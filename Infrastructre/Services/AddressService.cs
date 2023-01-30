using AutoMapper;
using Domain.Dtos;
using Domain.Entitites;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructre.Services
{
    public class AddressService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        public AddressService(DataContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }
        public async Task<Response<List<AddressDto>>> GetAddres()
        {
            try  
            {
                var result = _context.Addresses.ToList();
                var mapped = _mapper.Map<List<AddressDto>>(result);
                return new Response<List<AddressDto>>(mapped); 
            } 
            catch (Exception ex)
            {
                return new Response<List<AddressDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
            }
        }
    
        public async Task<Response<AddressDto>> AddAddress(AddressDto addressDto)
        {
            try
            {
                var address = _mapper.Map<Address>(addressDto);
              await  _context.Addresses.AddAsync(address);
               await  _context.SaveChangesAsync();
                return new Response<AddressDto>(addressDto); 
            }
            catch (Exception e)
            {
                return new Response<AddressDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
            } 
        }

        public async Task<Response<AddressDto>> UpdateAddress(AddressDto addressDto)
        {
            try
            {
                var existing = await _context.Addresses.Where(x => x.Id == addressDto.Id).AsNoTracking().FirstOrDefaultAsync();
                if (existing == null) return new Response<AddressDto>(HttpStatusCode.BadRequest,new List<string>() {"Address not Found"});
                
                var mapped = _mapper.Map<Address>(addressDto);
                _context.Addresses.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddressDto>(addressDto);
            } 
            catch (Exception ex)
            {
                return new Response<AddressDto>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });
            }     
        }
        public async Task<Response<string>> DeleteAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>() {"Not Found"});

            _context.Addresses.Remove(address);
           await  _context.SaveChangesAsync();
            return new Response<string>("Deleted successfully");
        }
    }
}




