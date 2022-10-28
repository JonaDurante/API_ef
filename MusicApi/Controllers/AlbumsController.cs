using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Model;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public AlbumsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //POST api/<SongController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Album Albums)
        {
            await _dbContext.Albums.AddAsync(Albums);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await (from album in _dbContext.Albums
                                select new
                                {
                                    Id = album.Id,
                                    ArtistName = album.Name,
                                    Image = album.ImageURL,

                                }).ToListAsync();
            return Ok(albums);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AlbumDetails(int albumsId)
        {
            var albumsDetails = await _dbContext.Albums.Where(a => a.Id == albumsId).Include(a => a.Songs).ToListAsync();
            return Ok(albumsDetails);
        }

    }
}
