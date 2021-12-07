using System;
using System.Collections.Generic;
using System.Text;
using FanficMobileVersion.Models.Login;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.IO;
using FanficMobileVersion.Models;

namespace FanficMobileVersion.Repositories
{
    public class LikeService
    {

        private static LikeService _ServiceClientInstance;
        public static LikeService ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new LikeService();
                return _ServiceClientInstance;
            }
        }

        private JsonSerializer _serializer = new JsonSerializer();
        private HttpClient client;


        public LikeService()
        {
            client = new HttpClient();
            //Change your base address here
            client.BaseAddress = new Uri("https://fanfic-itra.herokuapp.com/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task AddLike(int uId, int fId, string accessToken)
        {
            
                LikeFunction loginRequestModel = new LikeFunction()
                {
                    fanficId = fId,
                    userId = uId                    

                };

            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent(JsonConvert.SerializeObject(loginRequestModel), Encoding.UTF8, "application/json");
                //Change your base address tail part here and post it. 

                //var response = await client.PostAsync("auth/login/", content);
                var response = await client.PostAsync("likes/setLike/", content);               
                //using (var stream = await response.Content.ReadAsStreamAsync())
                var stream = await response.Content.ReadAsStringAsync();
                var jsoncontent = JsonConvert.DeserializeObject<LoginApiResponseModel>(stream);
                int i = 0;
                response.EnsureSuccessStatusCode();
                //using (var reader = new StreamReader(stream))
                //var jsoncontent = _serializer.Deserialize<LoginApiResponseModel>(json);
                //Preferences.Set("accessToken", jsoncontent.accessToken);    
        }

        public async Task DeleteLike(int uId, int fId, string accessToken)
        {

            LikeFunction loginRequestModel = new LikeFunction()
            {
                fanficId = fId,
                userId = uId

            };

            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent(JsonConvert.SerializeObject(loginRequestModel), Encoding.UTF8, "application/json");
            //Change your base address tail part here and post it. 

            //var response = await client.PostAsync("auth/login/", content);
            var response = await client.PostAsync("likes/removeLike/", content);
            //using (var stream = await response.Content.ReadAsStreamAsync())
            var stream = await response.Content.ReadAsStringAsync();
            var jsoncontent = JsonConvert.DeserializeObject<LoginApiResponseModel>(stream);
            response.EnsureSuccessStatusCode();
            //using (var reader = new StreamReader(stream))
            //var jsoncontent = _serializer.Deserialize<LoginApiResponseModel>(json);
            //Preferences.Set("accessToken", jsoncontent.accessToken);    
        }


        public async Task<bool> CheckLike(int uId, int fId, string accessToken)
        {

            LikeFunction loginRequestModel = new LikeFunction()
            {
                fanficId = fId,
                userId = uId

            };

            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent(JsonConvert.SerializeObject(loginRequestModel), Encoding.UTF8, "application/json");
            //Change your base address tail part here and post it. 

            //var response = await client.PostAsync("auth/login/", content);
            var response = await client.PostAsync("likes/isUserLikesCategory/", content);
            //using (var stream = await response.Content.ReadAsStreamAsync())
            var stream = await response.Content.ReadAsStringAsync();
            //var jsoncontent = JsonConvert.DeserializeObject<LoginApiResponseModel>(stream);
            if (stream == "true") { 
                return true; 
            }
            else { 
                return false; 
            }
            //response.EnsureSuccessStatusCode();
            //using (var reader = new StreamReader(stream))
            //var jsoncontent = _serializer.Deserialize<LoginApiResponseModel>(json);
            //Preferences.Set("accessToken", jsoncontent.accessToken);    
            //return Convert.ToBoolean(stream);
        }

    }
}
