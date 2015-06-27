using System.ComponentModel.DataAnnotations;

namespace StacksOfWax.Models
{
    public class Track
    {
        protected Track()
        {}

        public Track(int ordinal, string name)
        {
            Ordinal = ordinal;
            Name = name;
        }

        public int TrackId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int Ordinal { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}