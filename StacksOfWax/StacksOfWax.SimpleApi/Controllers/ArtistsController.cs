using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using StacksOfWax.DataAccess;
using StacksOfWax.Models;

namespace StacksOfWax.SimpleApi.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly StacksOfWaxDbContext _db;

        public ArtistsController()
        {
            _db = new StacksOfWaxDbContext();
        }

        // GET api/artists
        // Return all Artists.
        public IHttpActionResult GetArtists()
        {
            var artists = _db.Artists.ToList();
            return Ok(artists);
        }

        // GET api/artists/1
        [ResponseType(typeof(Album))]
        public IHttpActionResult GetArtist(int id)
        {
            var artist = _db.Artists.SingleOrDefault(x => x.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        // api/artists/1
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // private setter on ArtistId so it is not bound
            var existingArtist = _db.Artists.SingleOrDefault(x => x.ArtistId == id);
            if (existingArtist == null)
            {
                return NotFound();
            }

            // TODO Handle DbUpdateConcurrencyException
            existingArtist.Name = artist.Name;
            _db.SaveChanges();

            return Ok(artist);
        }

        // POST api/artists
        [ResponseType(typeof(Artist))]
        public IHttpActionResult PostArtist(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Artists.Add(artist);
            _db.SaveChanges();
            
            return CreatedAtRoute("DefaultApi", new {id = artist.ArtistId}, artist);
        }


        // api/artists/1
        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtist(int id)
        {
            var artist = _db.Artists.SingleOrDefault(x => x.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            _db.Artists.Remove(artist);
            _db.SaveChanges();

            return Ok(artist);
        }
    }
}