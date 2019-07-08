using System.Net.Http;
using System.Threading.Tasks;
using testLoginet.Models.Interfaces;

namespace testLoginet.Models
{
    public class UsersDao : IUsersDao
    {
        private readonly IHttpClientFactory _clientFactory;


        public UsersDao(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Task<string> GetAllUsersAsync()
        {
            var client = _clientFactory.CreateClient("httpClient");
            return client.GetStringAsync("users");
        }

        public Task<string> GetUserByIdAsync(long id)
        {
            var client = _clientFactory.CreateClient("httpClient");
            return client.GetStringAsync("users/" + id);
        }

        public Task<string> getAlbumsByUserIdAsync(long id)
        {
            var client = _clientFactory.CreateClient("httpClient");
            return client.GetStringAsync("users/" + id + "/albums");
        }

    }
}
