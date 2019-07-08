using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testLoginet.Interfaces;
using testLoginet.Models;

namespace testLoginet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }

        // Получение списка всех альбомов
        // GET api/albums
        [HttpGet]
        public async Task<IEnumerable<Album>> GetAsync()
        {
            IEnumerable<Album> albums = await _albumsService.getAllAlbumsAsync();

            if (albums == null)
                return Enumerable.Empty<Album>();

            return albums;
        }

        // Получение альбома по id
        // GET api/albums/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAsync(long id)
        {
            if (id < 0)
                return BadRequest();

            Album album = await _albumsService.getAlbumByIdAsync(id);

            if (album == null)
                return NotFound();

            return Ok(album);
        }
    }
}