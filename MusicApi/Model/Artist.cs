using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Model
{
    public class Artist
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ImageURL{ get; set; }
        
        //public IFormFile Image { get; set; }
        //[NotMapped]  // hace que no lo mapee al generar al leer la db
        public ICollection<Album>? Albums { get; set; } // 1 to many
        //[NotMapped]
        public ICollection<Song>? Songs { get; set; } // 1 to many
    }
}
