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
        private readonly HttpClient _httpClient;

        public AlbumsDao(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetAlbumById(long id)
        {
            return GetStringResponse("albums/" + id);
        }

        public string GetAllAlbums()
        {
            return GetStringResponse("albums");
        }


        private string GetStringResponse(string path)
        {
            Task<HttpResponseMessage> response = _httpClient.GetAsync(path);
            response.Wait();

            if (!response.Result.IsSuccessStatusCode)
            {
                return null;
            }

            Task<string> a = response.Result.Content.ReadAsStringAsync();
            a.Wait();
            //Console.WriteLine(a.Result);
            return a.Result;
        }
    }
}
