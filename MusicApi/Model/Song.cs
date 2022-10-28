using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Model
{
    public class Song
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public DateTime? UploadedDate { get; set; }
        public bool IsFeatured { get; set; }
        public string AudioURL { get; set; }

        //[NotMapped]
        //public IFormFile Image { get; set; }
        //public IFormFile AudioFile { get; set; }
        public string ImageURL { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
    }
}
//[Required(ErrorMessage = "Title cannot be null or empty")]
//public string Title { get; set; }
//[Required(ErrorMessage = "Lenguage cannot be null or empty")]
//public string Language { get; set; }
//[Required(ErrorMessage = "Kindly provider the song duration")]
//public string Duration { get; set; }

//[NotMapped]
//public IFormFile Image { get; set; }