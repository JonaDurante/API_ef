using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Model
{
    public class Album
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        //public IFormFile Image { get; set; }
        public int ArtistId { get; set; }
        //[NotMapped]
        public ICollection<Song>? Songs { get; set; }
    }
}
