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
        public const string CHARACTER_SEARCH_ENDPOINT = "people/?search={0}";
        public const string STARSHIP_SEARCH_ENDPOINT = "starships/?search={0}";
        public const string PLANET_SEARCH_ENDPOINT = "planets/?search={0}";
        public const string CHAR_ENDPOINT = "people/{0}/";
        public const string STARSHIP_ENDPOINT = "starships/{0}/";
        public const string PLANET_ENDPOINT = "planets/[0]/";



        public static async Task<List<Character>> GetCharacters(string query)
        {
            List<Character> characters = new List<Character>();

            string url = BASE_URL + string.Format(CHARACTER_SEARCH_ENDPOINT, query);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                int arrayStartIndex = json.IndexOf('[');

                //cut off first part of json response
                string jsonCut = json.Substring(arrayStartIndex);

                //cut off final curly bracket as well from end of response
                int finalCurlyBracketPosition = jsonCut.LastIndexOf('}');
                string jsonFullyCut = jsonCut.Remove(finalCurlyBracketPosition);

                characters = JsonConvert.DeserializeObject<List<Character>>(jsonFullyCut);
            }

            return characters;
        }

        public static async Task<List<Starship>> GetStarships(string query)
        {
            List<Starship> starships = new List<Starship>();

            string url = BASE_URL + string.Format(STARSHIP_SEARCH_ENDPOINT, query);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                int arrayStartIndex = json.IndexOf('[');
                string jsonCut = json.Substring(arrayStartIndex);
                int finalCurlyBracketPosition = jsonCut.LastIndexOf('}');
                string jsonFullyCut = jsonCut.Remove(finalCurlyBracketPosition);

                starships = JsonConvert.DeserializeObject<List<Starship>>(jsonFullyCut);
            }

            return starships;
        }

        public static async Task<List<Planet>> GetPlanets(string query)
        {
            List<Planet> planets = new List<Planet>();

            string url = BASE_URL + string.Format(PLANET_SEARCH_ENDPOINT, query);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                int arrayStartIndex = json.IndexOf('[');
                string jsonCut = json.Substring(arrayStartIndex);
                int finalCurlyBracketPosition = jsonCut.LastIndexOf('}');
                string jsonFullyCut = jsonCut.Remove(finalCurlyBracketPosition);

                planets = JsonConvert.DeserializeObject<List<Planet>>(jsonFullyCut);
            }

            return planets;
        }




        public static async Task<Character> GetCharacterInfo (string charUrl)
        {
            Character characterInfo = new Character();

            string url = charUrl;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                string jsonAsArray = "[" + json + "]";

                characterInfo = JsonConvert.DeserializeObject<List<Character>>(jsonAsArray).FirstOrDefault();
            }

            return characterInfo;

        }

        public static async Task<Starship> GetStarshipInfo (string shipUrl)
        {
            Starship starshipInfo = new Starship();

            string url = shipUrl;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                string jsonAsArray = "[" + json + "]";

                starshipInfo = JsonConvert.DeserializeObject<List<Starship>>(jsonAsArray).FirstOrDefault();
            }

            return starshipInfo;
        }

        public static async Task<Planet> GetPlanetInfo (string planetUrl)
        {
            Planet planetInfo = new Planet();

            string url = planetUrl;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                string jsonArray = "[" + json + "]";

                planetInfo = JsonConvert.DeserializeObject<List<Planet>>(jsonArray).FirstOrDefault();
            }

            return planetInfo;
        }


    }
}
