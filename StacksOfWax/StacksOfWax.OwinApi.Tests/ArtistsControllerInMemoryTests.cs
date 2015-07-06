using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksOfWax.Models;

namespace StacksOfWax.OwinApi.Tests
{
    /// <summary>
    /// These unit tests demonstrate in-memory testing of an OWIN enabled Web API.
    /// </summary>
    [TestClass]
    public class ArtistsControllerInMemoryTests
    {
        private static TestServer _server;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            // Arrange
            _server = TestServer.Create<Startup>();
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _server.Dispose();
        }

        [TestMethod]
        public void CanGetArtists()
        {
            // Act
            var response = _server.HttpClient.GetAsync("api/artists").Result;
            response.EnsureSuccessStatusCode();
            var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;

            // Assert
            Assert.IsNotNull(artists);
            Assert.IsTrue(artists.Any());
        }

        [TestMethod]
        public async Task CanGetArtistsAsync()
        {
            // Act
            var response = await _server.HttpClient.GetAsync("api/artists");
            response.EnsureSuccessStatusCode();
            var artists = await response.Content.ReadAsAsync<IEnumerable<Artist>>();

            // Assert
            Assert.IsNotNull(artists);
            Assert.IsTrue(artists.Any());
        }
    }
}