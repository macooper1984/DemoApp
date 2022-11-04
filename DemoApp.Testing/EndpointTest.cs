using DemoApp.Api;
using DemoApp.Application.Interfaces;
using DemoApp.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoApp.Testing
{
    public class EndpointTest
    {
        private TestServer _testServer;

        IClientRepository clientRepo;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            clientRepo = Substitute.For<IClientRepository>();

            _testServer = new TestServer(
                new WebHostBuilder()
                    .UseStartup<Startup>()
                    .ConfigureTestServices(
                        services =>
                        {
                            services.AddSingleton(typeof(IClientRepository), clientRepo);
                        })
                );
        }

        [SetUp]
        public void Setup()
        {
            clientRepo.ClearReceivedCalls();
        }

        [Test]
        public async Task GetClientByIdentifier_ClientIsReturned()
        {
            clientRepo.GetClient(Arg.Any<string>()).Returns(TestData);

            var response = await CallEndpoint("AO");
            Assert.IsTrue(response.IsSuccessStatusCode);

            var data = await GetResponseData(response);
            Assert.NotNull(data);
            Assert.AreEqual("AO", data.Identifier);
            Assert.AreEqual("AO.com", data.Name);
        }

        private async Task<HttpResponseMessage> CallEndpoint(string clientIdentifier)
        {
            var url = $"api/clients/{clientIdentifier}";

            using (var client = _testServer.CreateClient())
            {
                var response = await client.GetAsync(url);
                return response;
            }
        }

        private Client TestData 
        { get
            {
                return new Client("AO", "AO.com");
            } 
        }

        private async Task<Client> GetResponseData(HttpResponseMessage response)
        {
            var asString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Client>(asString);
            return result;
        }
    }
}
