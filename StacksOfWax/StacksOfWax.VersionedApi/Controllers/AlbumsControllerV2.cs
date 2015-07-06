using System.Linq;
using System.Web.Http;
using StacksOfWax.DataAccess;

namespace StacksOfWax.VersionedApi.Controllers
{
    public class AlbumsControllerV2 : ApiController
    {
        private readonly StacksOfWaxDbContext _dbContext;

        public AlbumsControllerV2()
        {
            _dbContext = new StacksOfWaxDbContext();
        }

        public IHttpActionResult GetAlbums()
        {
            var albums = _dbContext.Albums.ToList();
            return Ok(albums);
        }

        public IHttpActionResult GetAlbums(int id)
        {
            var album = _dbContext.Albums.SingleOrDefault(x => x.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }
    }
}