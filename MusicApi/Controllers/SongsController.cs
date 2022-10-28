using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Model;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //POST api/<SongController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song Songs)
        {
            Songs.UploadedDate = DateTime.Now;
            await _dbContext.Songs.AddAsync(Songs);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSongs()
        {
            var AllSongs = await (from songs in _dbContext.Songs
                                  select new
                                  {
                                      Id = songs.Id,
                                      Title = songs.Title,
                                      Duration = songs.Duration,
                                      Image = songs.ImageURL,
                                      Audio = songs.AudioURL,
                                  }).ToListAsync();
            return Ok(AllSongs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FeatureSongs()
        {
            var AllSongs = await (from songs in _dbContext.Songs
                                  where songs.IsFeatured == true
                                  select new
                                  {
                                      Id = songs.Id,
                                      Title = songs.Title,
                                      Duration = songs.Duration,
                                      Image = songs.ImageURL,
                                      Audio = songs.AudioURL,
                                  }).ToListAsync();
            return Ok(AllSongs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NewSongs()
        {
            var newSongs = await (from songs in _dbContext.Songs
                                  orderby songs.UploadedDate descending
                                  select new
                                  {
                                      Id = songs.Id,
                                      Title = songs.Title,
                                      Duration = songs.Duration,
                                      Image = songs.ImageURL,
                                      Audio = songs.AudioURL,
                                  }).Take(3).ToListAsync();          // .Take reemplaza al top en sql
            return Ok(newSongs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SerchSongs(string SongsName)
        {
            var serchSongs = await (from songs in _dbContext.Songs
                                  where songs.Title.StartsWith(SongsName)
                                  select new
                                  {
                                      Id = songs.Id,
                                      Title = songs.Title,
                                      Duration = songs.Duration,
                                      Image = songs.ImageURL,
                                      Audio = songs.AudioURL,
                                  }).ToListAsync();          
            return Ok(serchSongs);
        }
    }
}
