using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StacksOfWax.DataAccess.Tests
{
    [TestClass]
    public class InitializeTests
    {
        [TestMethod]
        public void can_initialize()
        {
            using (var dbContext = new StacksOfWaxDbContext())
            {
                Assert.IsTrue(dbContext.Artists.Any());
            }
        }
    }
}
