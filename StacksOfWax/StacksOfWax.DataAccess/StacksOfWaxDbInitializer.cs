using System.Data.Entity;
using StacksOfWax.Models;

namespace StacksOfWax.DataAccess
{
    public class StacksOfWaxDbInitializer : DropCreateDatabaseAlways<StacksOfWaxDbContext>
    {
        protected override void Seed(StacksOfWaxDbContext context)
        {
            var abb = context.Artists.Add(new Artist("The Allman Brothers Band"));
            AddAlbum(context, abb, "The Allman Brothers Band", new []
            {
                "Don't Want You No More",
                "It's Not My Cross To Bear",
                "Black Hearted Woman",
                "Trouble No More",
                "Every Hungry Woman",
                "Dreams",
                "Whipping Post"
            });
            AddAlbum(context, abb, "Idlewild South", new []
            {
                "Revival",
                "Don't Keep Me Wonderin'",
                "Midnight Rider",
                "In Memory Of Elizabeth Reed",
                "Hoochie Coochie Man",
                "Please Call Home",
                "Leave My Blues At Home"
            });

            context.SaveChanges();
        }

        private void AddAlbum(StacksOfWaxDbContext context, Artist artist, string name, string[] tracks)
        {
            var album = context.Albums.Add(new Album(name) {Artist = artist});
            for (var index = 0; index < tracks.Length; index++)
            {
                album.Tracks.Add(new Track(index + 1, tracks[index]) {Album = album});
            }
        }
    }
}