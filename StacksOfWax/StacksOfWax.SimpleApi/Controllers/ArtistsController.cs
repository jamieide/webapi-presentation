using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using StacksOfWax.DataAccess;
using StacksOfWax.Models;

namespace StacksOfWax.SimpleApi.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly StacksOfWaxDbContext _dbContext;

        public ArtistsController()
        {
            _dbContext = new StacksOfWaxDbContext();
        }

        public IHttpActionResult Get()
        {
            var artists = _dbContext.Artists.ToList();
            return Ok(artists);
        }

        public IHttpActionResult Get(int id)
        {
            var artist = _dbContext.Artists.SingleOrDefault(x => x.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        public IHttpActionResult Post(Artist artist)
        {
            _dbContext.Artists.Add(artist);
            _dbContext.SaveChanges();
            return CreatedAtRoute("DefaultApi", new {id = artist.ArtistId}, artist);
        }

        public IHttpActionResult Put(int id, [FromBody]Artist artist)
        {
            // private setter on ArtistId so it is not bound
            var existingArtist = _dbContext.Artists.SingleOrDefault(x => x.ArtistId == id);
            if (existingArtist == null)
            {
                return NotFound();
            }

            existingArtist.Name = artist.Name;
            _dbContext.SaveChanges();

            return Ok(existingArtist);
        }
    }
}