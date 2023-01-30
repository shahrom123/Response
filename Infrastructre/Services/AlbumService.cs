using AutoMapper;
using Domain.Dtos;
using Domain.Entitites;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructre.Services
{
    public class AlbumService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AlbumService(DataContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Response<List<AlbumDto>>> GetAlbum()
        {
            try
            {
                var result = _context.Albums.ToList();
                var mapped = _mapper.Map<List<AlbumDto>>(result);
                return new Response<List<AlbumDto>>(mapped);
            }
            catch (Exception ex)
            {
                return new Response<List<AlbumDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<Response<AlbumDto>> AddAlbum(AlbumDto albumDto)
        {
            try
            {
                var address = _mapper.Map<Album>(albumDto);
                await _context.Albums.AddAsync(address);
                await _context.SaveChangesAsync();
                return new Response<AlbumDto>(albumDto);
            }
            catch (Exception e)
            {
                return new Response<AlbumDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
            }
        }

        public async Task<Response<AlbumDto>> UpdateAlbum(AlbumDto albumDto)
        {
            try
            {
                var existing = await _context.Albums.Where(x => x.Id == albumDto.Id).AsNoTracking().FirstOrDefaultAsync();
                if (existing == null) return new Response<AlbumDto>(HttpStatusCode.BadRequest, new List<string>() { "Album not Found" });

                var mapped = _mapper.Map<Album>(albumDto);
                _context.Albums.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AlbumDto>(albumDto);
            }
            catch (Exception ex)
            {
                return new Response<AlbumDto>(HttpStatusCode.InternalServerError, new List<string> { ex.Message });

            }
        }
        public async Task<Response<string>> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found" });

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return new Response<string>("Deleted successfully");
        }
    }
}
