using System.Linq;
using System.Web.Http;
using StacksOfWax.DataAccess;
using StacksOfWax.Models;

namespace StacksOfWax.SimpleApi.Controllers
{
    public class AlbumsController : ApiController
    {
        private readonly StacksOfWaxDbContext _dbContext;

        public AlbumsController()
        {
            _dbContext = new StacksOfWaxDbContext();
        }

        // GET api/albums
        public IHttpActionResult Get()
        {
            var albums = _dbContext.Albums.ToList();
            return Ok(albums);
        }

        // GET api/albums/1
        public IHttpActionResult Get(int id)
        {
            var album = _dbContext.Albums.SingleOrDefault(x => x.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        // POST api/albums
        public IHttpActionResult Post(Album newAlbum)
        {
            _dbContext.Albums.Add(newAlbum);
            _dbContext.SaveChanges();
            return CreatedAtRoute("DefaultApi", new {id = newAlbum.AlbumId}, newAlbum);
        }

        // PUT api/albums/1
        public IHttpActionResult Put(int id, [FromBody] Album existingAlbum )
        {
            var album = _dbContext.Albums.SingleOrDefault(x => x.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }
            album.Name = existingAlbum.Name;
            _dbContext.SaveChanges();

            return Ok(album);
        }

        // DELETE api/albums/1
        public IHttpActionResult Delete(int id)
        {
            var album = _dbContext.Albums.SingleOrDefault(x => x.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }
            _dbContext.Albums.Remove(album);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}