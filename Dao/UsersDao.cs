﻿using System.Net.Http;
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

        public string GetUserById(long id)
        {
            return GetStringResponse("users/" + id);
        }

        public string getAlbumsByUserId(long id)
        {
            return GetStringResponse("users/" + id + "/albums");
//            return GetStringResponse("albums?userId=" + id);
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
