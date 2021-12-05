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

namespace FanficMobileVersion.Services
{
    public class ApiServices
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

        private JsonSerializer _serializer = new JsonSerializer();
        private HttpClient client;


        public ApiServices()
        {
            client = new HttpClient();
            //Change your base address here
            client.BaseAddress = new Uri("https://fanfic-itra.herokuapp.com/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<LoginApiResponseModel> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                LoginApiRequestModel loginRequestModel = new LoginApiRequestModel()
                {
                    username = username,
                    password = password

                };
                var content = new StringContent(JsonConvert.SerializeObject(loginRequestModel), Encoding.UTF8, "application/json");
                //Change your base address tail part here and post it. 

                //var response = await client.PostAsync("auth/login/", content);
                var response = await client.PostAsync("auth/login/", content);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                //using (var stream = await response.Content.ReadAsStreamAsync())
                var stream = await response.Content.ReadAsStringAsync();


                var jsoncontent = JsonConvert.DeserializeObject<LoginApiResponseModel>(stream);

                int i = 0;
                response.EnsureSuccessStatusCode();                
                //using (var reader = new StreamReader(stream))
                 //var jsoncontent = _serializer.Deserialize<LoginApiResponseModel>(json);
                 Preferences.Set("accessToken", jsoncontent.accessToken);
                 return jsoncontent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
