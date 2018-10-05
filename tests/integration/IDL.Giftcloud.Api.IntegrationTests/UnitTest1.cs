using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

using Newtonsoft.Json.Linq;

using Xunit;

namespace IDL.Giftcloud.Api.IntegrationTests
{
    public class UnitTest1
    {
        private readonly TestServer _testServer;

        public UnitTest1()
        {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Fact]
        public async Task PostPasswordGrantTypeUsingFormUrlEncodedContentShouldReturnAccessToken()
        {
            // Arrange
            var client = _testServer.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "/connect/token")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["grant_type"] = "password",
                    ["username"] = "alice@example.com",
                    ["password"] = "Password123"
                })
            };

            // Act
            var response = await client.SendAsync(request);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();

            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

            payload["error"].Should().BeNull();
            payload["access_token"].Should().BeOfType<string>().Which.Should().NotBeNullOrWhiteSpace();
        }
    }
}
