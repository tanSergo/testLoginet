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

        public Album getAlbumById(long id)
        {
            string albumJson = _albumsDao.GetAlbumById(id);

            if (albumJson == null)
                return null;

            return JsonConvert.DeserializeObject<Album>(albumJson);
        }

        public Album[] getAllAlbums()
        {
            string albumsJson = _albumsDao.GetAllAlbums();

            if (albumsJson == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Album[]>(albumsJson);
        }
    }
}
