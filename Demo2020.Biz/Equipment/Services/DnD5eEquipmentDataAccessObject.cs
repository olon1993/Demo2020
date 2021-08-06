using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class DnD5eEquipmentApi : IEquipmentApi
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private const string _baseUrl = "http://www.dnd5eapi.co";

        public async Task<List<Models.Equipment>> GetAllEquipment()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("/api/equipment");
                    if (response.IsSuccessStatusCode)
                    {
                        string rawJSON = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<EquipmentContainer>(rawJSON);
                        return data.Results;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return null;
        }

        public async Task<Models.Equipment> GetEquipment(string name)
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
                        .Replace(":", "")
                        .Replace(",", "");
                    HttpResponseMessage response = await client.GetAsync("/api/equipment/" + name);
                    if (response.IsSuccessStatusCode)
                    {
                        string rawJSON = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Models.Equipment>(rawJSON);
                        return data;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return default(Models.Equipment);
        }


        //**************************************************\\
        //****************** Nested Class ******************\\
        //**************************************************\\
        private class EquipmentContainer
        {
            public EquipmentContainer(int count, List<Models.Equipment> results)
            {
                Count = count;
                Results = results;
            }

            public int Count { get; set; }
            public List<Models.Equipment> Results { get; set; }
        }
    }
}
