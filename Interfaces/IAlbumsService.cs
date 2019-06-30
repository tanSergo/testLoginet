using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testLoginet.Models;

namespace testLoginet.Interfaces
{
    public interface IAlbumsService
    {
        Album[] getAllAlbums();

        Album getAlbumById(long id);
    }
}
