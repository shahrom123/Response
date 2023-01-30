using Domain.Dtos;
using Domain.Response;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class AlbumController : ControllerBase
    {
        private AlbumService _albumService;

        public AlbumController(AlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet("GetAlbum")]
        public async Task<Response<List<AlbumDto>>> Get()
        {
            return await _albumService.GetAlbum();

        }
        [HttpPost("AddAlbum")]
        public async Task<Response<AlbumDto>> AddAlbum([FromBody] AlbumDto albumDto)
        {
            if (ModelState.IsValid)
            {
                return await _albumService.AddAlbum(albumDto);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return new Response<AlbumDto>(HttpStatusCode.BadRequest, errors);
            }
        }


        [HttpPut("UpdateAlbum")]
        public async Task<Response<AlbumDto>> Put([FromBody] AlbumDto albumDto) =>
          await _albumService.UpdateAlbum(albumDto);

        [HttpDelete("DeleteAlbum")]
        public async Task<Response<string>>  Delete(int id) => await  _albumService.DeleteAlbum(id);
    } 

}
