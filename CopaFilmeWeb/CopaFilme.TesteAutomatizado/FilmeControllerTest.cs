using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CopaFilme.TesteAutomatizado
{
    public class FilmeControllerTest : IClassFixture<WebApplicationFactory<CopaFilmeWeb.Startup>>
    {
        private readonly WebApplicationFactory<CopaFilmeWeb.Startup> _factory;
        public FilmeControllerTest(WebApplicationFactory<CopaFilmeWeb.Startup> factory)
        {
            _factory = factory;
        }


        [Theory]
        [InlineData("/api/filmes")]
        public async Task GetEndpointsReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/api/filmes/copaInitial", 
            new string[] { "tt3799232", "tt5834262", "tt5164214", "tt0317705", "tt1825683", "tt2854926", "tt6499752", "tt4154756" })]
        public async Task PostEndpointsReturnSuccess(string url, object dados)
        {

            var postRequest = new
            {
                Url = url,
                Body = dados
            };
            
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync(url, ContentHelper.GetStringContent(postRequest.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
