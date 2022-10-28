using Microsoft.EntityFrameworkCore;
using MusicApi.Model;

namespace MusicApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Song>().HasData(
        //        new Song
        //        {
        //            Id = 1,
        //            Title = "Willow",
        //            Language = "English",
        //            Duration = "4:35",
        //            ImageURL = ""
        //        },
        //        new Song
        //        {
        //            Id = 2,
        //            Title = "Yellow",
        //            Language = "English",
        //            Duration = "5:15",
        //            ImageURL = ""
        //        }
        //       );
        //}
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
