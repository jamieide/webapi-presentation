using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace StacksOfWax.Models
{
    public class Album
    {
        protected Album()
        {            
            Tracks = new Collection<Track>();
        }

        public Album(string name) : this()
        {
            Name = name;
        }

        public int AlbumId { get; private set; }

        [Required]
        public string Name { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Track> Tracks { get; private set; }
    }
}