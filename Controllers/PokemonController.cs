using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SuperHeroApp.Models;
using System.Net.Http;

namespace SuperHeroApp.Controllers
{
    public class PokemonController : Controller
    {
        private static readonly HttpClient httpClient = new();

        public async Task<IActionResult> Index()
        {
            const string apiUrl = "https://pokeapi.co/api/v2/pokemon?limit=20&offset=0";
            var response = await httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return Content(
                    $"❌ Error al llamar a la PokeAPI:\nCódigo: {response.StatusCode}\n{errorContent}"
                );
            }

            var json = await response.Content.ReadAsStringAsync();
            var parsed = JObject.Parse(json)["results"];
            var pokemons = new List<Pokemon>();

            foreach (var item in parsed)
            {
                var name = item["name"]?.ToString();
                var detailUrl = item["url"]?.ToString();
                if (string.IsNullOrEmpty(detailUrl)) continue;

                var detailResp = await httpClient.GetAsync(detailUrl);
                if (!detailResp.IsSuccessStatusCode) continue;

                var detailJson = await detailResp.Content.ReadAsStringAsync();
                var detailParsed = JObject.Parse(detailJson);

                var image = detailParsed["sprites"]?["front_default"]?.ToString();
                var type = detailParsed["types"]?.First()?["type"]?["name"]?.ToString();

                pokemons.Add(new Pokemon
                {
                    Name = name ?? "",
                    ImageUrl = image ?? "",
                    Type = type ?? ""
                });
            }

            return View(pokemons);
        }
    }
}
