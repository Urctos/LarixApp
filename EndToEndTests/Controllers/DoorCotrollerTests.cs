using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;


namespace EndToEndTests.Controllers
{
    public class DoorCotrollerTests: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public DoorCotrollerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            //Arrange

        }
        [Fact]
        public async Task Fetching_door_should_return_not_empty_collection()
        {
            //Act
            var response = await _client.GetAsync(@"api/door");
 
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeEmpty();
        }
    }
}
