using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Services
{
    public class DnD5eMonsterApi : IMonsterApi
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private const string _baseUrl = "http://www.dnd5eapi.co";

        public async Task<List<Monster>> GetAllMonsters()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("/api/monsters");
                    if (response.IsSuccessStatusCode)
                    {
                        string rawJSON = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<MonsterContainer>(rawJSON);
                        return data.Results;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return null;
        }

        public async Task<Monster> GetMonster(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    name = name.ToLower()
                        .Replace(" form", "")
                        .Replace(" ", "-")
                        .Replace("/", "-")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("'", "")
                        .Replace(",", "");
                    HttpResponseMessage response = await client.GetAsync("/api/monsters/" + name);
                    if (response.IsSuccessStatusCode)
                    {
                        string rawJSON = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Monster>(rawJSON);
                        return data;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return default(Monster);
        }


        //**************************************************\\
        //****************** Nested Class ******************\\
        //**************************************************\\
        private class MonsterContainer
        {
            public MonsterContainer(int count, List<Monster> results)
            {
                Count = count;
                Results = results;
            }

            public int Count { get; set; }
            public List<Monster> Results { get; set; }
        }
    }
}
