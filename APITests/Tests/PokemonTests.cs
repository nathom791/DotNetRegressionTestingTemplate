using APITests.Client.Constants;
using Models;

namespace APITests.Tests
{
    public class PokemonTests : BaseTest
    {
        [TestCase("10")]
        [TestCase("1")]
        public async Task GetPokemonList_ReturnsExpectedResultCount(string expectedCount)
        {
            HttpResponseMessage response = await Client.GetAsync(RelativePaths.PokemonList + $"?limit={expectedCount}&offset=0");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            PokemonList responseContent = JsonConvert.DeserializeObject<PokemonList>(content);

            Assert.That(responseContent.Results.Count, Is.EqualTo(int.Parse(expectedCount)));
        }
    }
}