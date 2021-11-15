using FanficMobileVersion.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FanficMobileVersion.Repositories
{
    internal class CategoryRepository
    {
        const string Url = "https://fanfic-itra.herokuapp.com/api";

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
        };

        // получение всех категорий (список (главная страница))
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + "/categories/all/";
            string result = await client.GetStringAsync(_url);
            //result = result.Replace("[", "{").Replace("]", "}");
            result = result.Replace("{\"info\":", "");
            result = result.Replace("},", ",").Replace("}}", "}");
            IEnumerable<Category> categories_list = JsonSerializer.Deserialize<IEnumerable<Category>>(result, options);
            return categories_list;
        }

        // получение названий всех категорий
        public async Task<List<string>> GetAllName()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + "/categories/allNames/";
            string result = await client.GetStringAsync(_url);
            IEnumerable<Category> categories_list = JsonSerializer.Deserialize<IEnumerable<Category>>(result, options);
            List<string> categiries_name = new List<string>();
            foreach (Category categories in categories_list)
            {
                categiries_name.Add(categories.name);
            }
            return categiries_name;
        }

        // получение категории по id (без доп полей)
        public async Task<Category> GetCategorieById(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + $"/categories/{id}/";
            string result = await client.GetStringAsync(_url);
            const string V = "category\":";
            string[] subs = result.Split(V, '}');
            string u = subs[1].Substring(0, subs[1].IndexOf('}')) + "}";
            Category some_cat = JsonSerializer.Deserialize<Category>(u, options);
            return some_cat;
        }

        // получение всех фанфиков в категории
        public async Task<IEnumerable<Fanfic>> GetAllFanficsInCategory(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + $"/categories/{id}/fanfics";
            string result = await client.GetStringAsync(_url);
            IEnumerable<Fanfic> fanficsList = JsonSerializer.Deserialize<IEnumerable<Fanfic>>(result, options);
            return fanficsList;
        }
    }
}
