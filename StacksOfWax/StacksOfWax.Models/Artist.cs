using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace StacksOfWax.Models
{
    public class Artist
    {
        protected Artist()
        {}

        public Artist(string name)
        {
            Name = name;
            Albums = new Collection<Album>();
        }

        public int ArtistId { get; private set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Album> Albums { get; private set; }
    }
}
