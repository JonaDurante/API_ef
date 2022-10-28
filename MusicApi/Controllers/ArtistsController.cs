using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Model;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public ArtistsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //POST api/<SongController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Artist Artists)  // Todas los metodos Async devuelven una tarea (Task) 
        {
            await _dbContext.Artists.AddAsync(Artists);                   // y debo especificar el "await" y el método Async que deseo utilizar. En este caso "AddAsync"
            await _dbContext.SaveChangesAsync();                          // SaveChangesAsunc
            return Ok();                                                  // NO consigo postear imagenes free, así que robo URLS y las pego en mi DB
        }


        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            var artists = await (from artist in _dbContext.Artists
                                 select new
                                 {
                                     Id = artist.Id,
                                     ArtistName = artist.Name,
                                     Image = artist.ImageURL,

                                 }).ToListAsync();
            return Ok(artists);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ArtistDetails(int artistId)
        {
            var artistsDetails = await _dbContext.Artists.Where(a=>a.Id == artistId). Include(a => a.Songs).ToListAsync();
            return Ok(artistsDetails);
        }
    }
}


//// POST CON IMAGEN                                        // NO voy a pagar us300 para usar Azure jiji
//[HttpPost]
//public async Task<IActionResult> Post([FromForm] Song song)  
//{
//    var ImageURL = await FileHelper.UploadImage(song.Image);        //el metodo se extrajo hacia Helppers para poder ser reutilizado
//    song.ImageURL = ImageURL;                                       //se le asigna el string devuelto a la imageurl

//    await _dbContext.Songs.AddAsync(song);
//    await _dbContext.SaveChangesAsync();
//    return StatusCode(StatusCodes.Status201Created);

//}