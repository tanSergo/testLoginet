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
        public IEnumerable<Album> Get()
        {
            Album[] albums = _albumsService.getAllAlbums();

            if (albums == null)
                return Enumerable.Empty<Album>();

            return albums;
        }

        // Получение альбома по id
        // GET api/albums/{id}
        [HttpGet("{id}")]
        public ActionResult<Album> Get(long id)
        {
            if (id < 0)
                return BadRequest();

            Album album = _albumsService.getAlbumById(id);

            if (album == null)
                return NotFound();

            return Ok(album);
        }
    }
}