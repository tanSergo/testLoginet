using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testLoginet.Models;

namespace testLoginet.Interfaces
{
    public interface IAlbumsService
    {
        //Task<Album[]> getAllAlbumsAsync();

        Task<Album> getAlbumByIdAsync(long id);

        Task<Album[]> getAllAlbumsAsync();
    }
}
