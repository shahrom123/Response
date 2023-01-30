using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class AlbumDto
    {
      
            public int Id { get; set; }
        [Required(ErrorMessage = "CustomerId should not be empty"), MaxLength(50)]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "AlbumName should not be empty"), MaxLength(50)]

        public string AlbumName { get; set; }
        [Required(ErrorMessage = "ArtistName should not be empty"), MaxLength(50)]

        public string ArtistName { get; set; }
        [Required(ErrorMessage = "Gende should not be empty"), MaxLength(50)]

        public string Gende { get; set; }
        [Required(ErrorMessage = "NumberOfSongs should not be empty"), MaxLength(50)]

        public int NumberOfSongs { get; set; } 
        public DateTime ReleaseDate { get; set; }

        public AlbumDto()
        {

        }
        public AlbumDto(int id, int productId, string albumName, string artistName, string gende, int numberOfSongs , DateTime releaseDate)
        {
            Id = id;
            ProductId = productId;
            AlbumName = albumName;
            ArtistName = artistName;
            Gende = gende;
            NumberOfSongs = numberOfSongs;
            ReleaseDate = releaseDate;

        }
    }
}
