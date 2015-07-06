using System.Linq;
using System.Web.Http;
using StacksOfWax.DataAccess;

namespace StacksOfWax.OwinApi.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly StacksOfWaxDbContext _db;

        public ArtistsController() : this(new StacksOfWaxDbContext())
        {}

        public ArtistsController(StacksOfWaxDbContext db)
        {
            _db = db;
        }

        public IHttpActionResult GetArtists()
        {
            return Ok(_db.Artists);
        }

        public IHttpActionResult GetArtist(int id)
        {
            var artist = _db.Artists.SingleOrDefault(x => x.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }
    }
}