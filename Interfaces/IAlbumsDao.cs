using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testLoginet.Interfaces
{
    public interface IAlbumsDao
    {
        Task<string> GetAllAlbumsAsync();

        Task<string> GetAlbumByIdAsync(long id);
    }
}
