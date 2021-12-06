using FanficMobileVersion.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace FanficMobileVersion.Services
{
    public class ProfileService
    {
        private static ApiServices _ServiceClientInstance;
        public static ApiServices ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ApiServices();
                return _ServiceClientInstance;
            }
        }

        //private JsonSerializer _serializer = new JsonSerializer();
        private HttpClient _client;

      
        public ProfileService()
        {
            _client = new HttpClient();
            //Change your base address here
            //client.BaseAddress = new Uri("https://fanfic-itra.herokuapp.com/api/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
        };

        public async Task<IEnumerable<FavoriteFan>> GetFanList(string accessToken, int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Change your base address tail part here and post it. 
                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);
                string _url = "https://fanfic-itra.herokuapp.com/api/" + $"authors/{id}/fanfics";
                string result = await client.GetStringAsync(_url);
                IEnumerable<FavoriteFan> chaptersList = JsonSerializer.Deserialize<IEnumerable<FavoriteFan>>(result, options);
                foreach(FavoriteFan fan in chaptersList)
                {
                    fan.id = fan.info.id;
                }
                return chaptersList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<FavoriteFan>> GetWorkList(string accessToken, int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Change your base address tail part here and post it. 
                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);
                string _url = "https://fanfic-itra.herokuapp.com/api/" + $"authors/{id}/likedFanfics";
                string result = await client.GetStringAsync(_url);
                IEnumerable<FavoriteFan> chaptersList = JsonSerializer.Deserialize<IEnumerable<FavoriteFan>>(result, options);
                foreach (FavoriteFan fan in chaptersList)
                {
                    fan.id = fan.info.id;
                }
                return chaptersList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<IEnumerable<User>> GetAllUsers(string accessToken)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Change your base address tail part here and post it. 
                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);
                string _url = "https://fanfic-itra.herokuapp.com/api/" + $"authors/all";
                string result = await client.GetStringAsync(_url);
                IEnumerable<User> chaptersList = JsonSerializer.Deserialize<IEnumerable<User>>(result, options);
               
                return chaptersList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}

