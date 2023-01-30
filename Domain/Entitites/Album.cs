using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitites
{
    public class Album
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public List<Product> Product { get; set; }
        public string AlbumName { get; set; }
        public  string ArtistName { get; set; }
        public string Gende { get; set; }
        public int NumberOfSongs { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Album()
        {

        }
        public Album(int id, int productId, string albumName, string artistName, string gende, int numberOfSongs, DateTime releaseDate)
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
