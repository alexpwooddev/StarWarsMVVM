using Newtonsoft.Json;
using StarWarsCharsMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharsMVVM.ViewModel.Helpers
{
    public class SwapiHelper
    {
        public const string BASE_URL = "https://swapi.dev/api/";
        public const string SEARCH_ENDPOINT = "people/?search={0}";
        public const string CHAR_ENDPOINT = "people/{0}/";



        public static async Task<List<Character>> GetCharacters(string query)
        {
            List<Character> characters = new List<Character>();

            string url = BASE_URL + string.Format(SEARCH_ENDPOINT, query);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                characters = JsonConvert.DeserializeObject<List<Character>>(json);
            }

            return characters;
        }


        public static async Task<CharacterInfo> GetCharacterInfo (string charUrl)
        {
            CharacterInfo characterInfo = new CharacterInfo();

            string url = charUrl;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                characterInfo = (JsonConvert.DeserializeObject<List<CharacterInfo>>(json)).FirstOrDefault();
            }

            return characterInfo;

        }


    }
}
