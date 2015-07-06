using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StacksOfWax.DataAccess;
using StacksOfWax.Models;
using StacksOfWax.SimpleApi.Controllers;

namespace StacksOfWax.SimpleApi.Tests
{
    [TestClass]
    public class ArtistsControllerTests
    {
        [TestMethod]
        public void CanGetArtists()
        {
            using (var db = new StacksOfWaxDbContext())
            {
                // Arrange
                var controller = new ArtistsController(db);

                // Act
                var result = controller.GetArtists() as OkNegotiatedContentResult<List<Artist>>;

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Content);
                Assert.IsTrue(result.Content.Any());
            }
        }

        [TestMethod]
        public void CanGetArtist()
        {
            using (var db = new StacksOfWaxDbContext())
            {
                // Arrange
                var controller = new ArtistsController(db);

                // Act
                var result = controller.GetArtist(1) as OkNegotiatedContentResult<Artist>;

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Content);
                Assert.AreEqual(1, result.Content.ArtistId);
            }
        }
    }
}
