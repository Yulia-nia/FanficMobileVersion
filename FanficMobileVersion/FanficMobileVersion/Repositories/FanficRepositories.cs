﻿using FanficMobileVersion.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FanficMobileVersion.Repositories
{
    internal class FanficRepository
    {
        const string Url = "https://fanfic-itra.herokuapp.com/api";

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
        };

        // получить информацию о фанфике (один)
        public async Task<Fanfic> GetFanfic(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + $"/fanfics/{id}/info/";
            string result = await client.GetStringAsync(_url);
            Fanfic fanfic = JsonSerializer.Deserialize<Fanfic>(result, options);
            return fanfic;
        }

        // получить главы фанфика
        public async Task<IEnumerable<Chapter>> GetAllChaptersInFanfic(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + $"/fanfics/{id}/chapters";
            string result = await client.GetStringAsync(_url);
            IEnumerable<Chapter> chaptersList = JsonSerializer.Deserialize<IEnumerable<Chapter>>(result, options);

            foreach (Chapter cc in chaptersList)
            {
                cc.fanficId = id;
            }

            return chaptersList;
        }

        // получить комменты фанфика (по id) с userId
        public async Task<List<Comment>> GetAllCommentsInFanfic(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + $"/fanfics/{id}/comments/";
            string result = await client.GetStringAsync(_url);
            string[] subs = result.Split('{', '}');
            string s = "[";
            string u = "[";
            for (int i = 2; i < subs.Length; i += 6)
            {
                s = s + '{' + subs[i] + "},";
                u = u + '{' + subs[i + 2] + "},";
            }
            s += "]";
            u += "]";
            s = s.Replace("},]", "}]");
            u = u.Replace("},]", "}]");
            List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(s, options);
            List<User> user = JsonSerializer.Deserialize<List<User>>(u, options);
            for (int i = 0; i < comments.Count; i++)
            {
                comments[i].userId = user[i].id;
            }
            return comments;
        }

        // получить список тегов 
        public async Task<IEnumerable<Tag>> GetTegs(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + $"/fanfics/{id}/";
            string result = await client.GetStringAsync(_url);
            const string V = "tags\":";
            string[] subs = result.Split(V, ']');
            string u = subs[1].Substring(0, subs[1].IndexOf(']')) + "]";
            IEnumerable<Tag> tags = JsonSerializer.Deserialize<List<Tag>>(u, options);
            foreach (Tag tag in tags)
            {
                tag.fanficId = id;
            }
            return tags;
        }

        public async Task<Category> GetCategory(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + $"/fanfics/{id}/";
            string result = await client.GetStringAsync(_url);
            const string V = "category\":";
            string[] subs = result.Split(V, '}');
            string u = subs[1].Substring(0, subs[1].IndexOf('}')) + "}";
            Category c = JsonSerializer.Deserialize<Category>(u, options);
            return c;
        }

        public async Task<int> GetUserId(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + $"/fanfics/{id}/";
            string result = await client.GetStringAsync(_url);
            const string V = "user\":";
            string[] subs = result.Split(V, '}');
            string u = subs[1].Substring(0, subs[1].IndexOf('}')) + "}";
            User c = JsonSerializer.Deserialize<User>(u, options);
            return c.id;
        }

        public async Task<User> GetUserFanfic(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string _url = Url + $"/fanfics/{id}/";
            string result = await client.GetStringAsync(_url);
            const string V = "user\":";
            string[] subs = result.Split(V, '}');
            string u = subs[1].Substring(0, subs[1].IndexOf('}')) + "}";
            User c = JsonSerializer.Deserialize<User>(u, options);
            return c;
        }
    }
}