using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace StacksOfWax.Models
{
    public class Album
    {
        protected Album()
        {}

        public Album(string name)
        {
            Name = name;
            Tracks = new Collection<Track>();
        }

        public int AlbumId { get; set; }

        [Required]
        public string Name { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Track> Tracks { get; private set; }
    }
}