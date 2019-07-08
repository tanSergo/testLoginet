using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testLoginet.Models.Interfaces
{
    public interface IUsersDao
    {
        Task<string> GetAllUsersAsync();

        Task<string> GetUserByIdAsync(long id);

        Task<string> getAlbumsByUserIdAsync(long id);
    }
}
