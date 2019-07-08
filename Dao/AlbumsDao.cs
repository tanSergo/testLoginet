using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using testLoginet.Interfaces;

namespace testLoginet.Dao
{
    public class AlbumsDao : IAlbumsDao
    {
        private readonly IHttpClientFactory _clientFactory;

        public AlbumsDao(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Task<string> GetAlbumByIdAsync(long id)
        {
            var client = _clientFactory.CreateClient("httpClient");
            return client.GetStringAsync("albums/" + id);
        }

        public Task<string> GetAllAlbumsAsync()
        {
            var client = _clientFactory.CreateClient("httpClient");
            return client.GetStringAsync("albums");
        }

    }
}
