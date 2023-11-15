using APITests.Client.Constants;
using Models;
using Newtonsoft.Json;

namespace APITests.Tests
{
    public class PokemonTests : BaseTest
    {
        [TestCase("1000")]
        public async Task GetPokemonList_ReturnsExpectedResultCount(string expectedCount)
        {
            HttpResponseMessage response = await Client.GetAsync(RelativePaths.PokemonList + $"/limit={expectedCount}&offset=0");
            response.EnsureSuccessStatusCode();
            
            string content = await response.Content.ReadAsStringAsync();
            PokemonList pokemonList = JsonConvert.DeserializeObject<PokemonList>(content);

            Assert.That(pokemonList.Count, Is.GreaterThan(1));
        }
    }
}