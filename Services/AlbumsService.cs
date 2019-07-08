using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testLoginet.Interfaces;
using testLoginet.Models;

namespace testLoginet.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsDao _albumsDao;

        public AlbumsService(IAlbumsDao albumsDao)
        {
            _albumsDao = albumsDao;
        }

        public async Task<Album> getAlbumByIdAsync(long id)
        {
            string albumJson = await _albumsDao.GetAlbumByIdAsync(id);

            if (albumJson == null)
                return null;

            return JsonConvert.DeserializeObject<Album>(albumJson);
        }

        public async Task<Album[]> getAllAlbumsAsync()
        {
            string albumsJson = await _albumsDao.GetAllAlbumsAsync();

            if (albumsJson == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Album[]>(albumsJson);
        }
    }
}
