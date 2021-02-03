using Autofac;
using Demo2020.Biz.Commons.Services;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Services
{
    //**************************************************\\
    //********************* Notes **********************\\
    //**************************************************\\\
    /* I anticipate there could be a pain point here in the
     * future due to the hard dependency on the Monster class.
     * 
     * The difficulty I am encountering is due to the
     * conflicting nature of serialization and dependency
     * injection with AutoFac. JSON wants a concrete object
     * to deserialize into. With AutoFac I would like to
     * eliminate as many concrete dependencies as possible.
     * 
     * One solution was to create a custom IContractResolver
     * and pass it into the JsonDeserializer.JsonSerializerSettings.
     * 
     * The problem with this approach then becomes the custom
     * IContractResolver has a dependency on the container to
     * resolve the interface into a concrete object, effectively
     * punting the problem to a new class.
     * 
     * Instead of spening any more time discovering a better
     * solution I will move on for now and commit these notes
     * so my future self can solve this problem if it comes
     * up again.
     * 
     * Effectively, I am punting this problem to future me.
     * Good luck.
     */

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
                        //var data = JsonConvert.DeserializeObject<IMonster>(rawJSON, new JsonSerializerSettings 
                        //{
                        //    ContractResolver = // ??
                        //});
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
        //******************* Properties *******************\\
        //**************************************************\\
        public IContractResolver ContractResolver { get; set; }


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
