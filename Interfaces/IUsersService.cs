using System.Threading.Tasks;
using testLoginet.Models;

namespace testLoginet.Controllers
{
    public interface IUsersService
    {
        Task<User[]> getAllUsersAsync();

        Task<User> getUserByIdAsync(long id);

        Task<Album[]> getAlbumsByUserIdAsync(long id);
    }
}