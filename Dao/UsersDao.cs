using System.Net.Http;
using System.Threading.Tasks;
using testLoginet.Models.Interfaces;

namespace testLoginet.Models
{
    public class UsersDao : IUsersDao
    {
        private readonly HttpClient _httpClient;


        public UsersDao(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetAllUsers()
        {
            return GetStringResponse("users");
        }

        private string GetStringResponse(string path)
        {
            Task<HttpResponseMessage> response = _httpClient.GetAsync(path);
            response.Wait();
            response.Result.EnsureSuccessStatusCode();
            Task<string> a = response.Result.Content.ReadAsStringAsync();
            a.Wait();
            //Console.WriteLine(a.Result);
            return a.Result;
        }
           
             

    }
}
