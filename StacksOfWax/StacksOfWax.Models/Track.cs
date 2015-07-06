using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace StacksOfWax.Models
{
    [DataContract]
    public class Track
    {
        protected Track()
        {}

        public Track(int ordinal, string name)
        {
            Ordinal = ordinal;
            Name = name;
        }

        [DataMember]
        public int TrackId { get; private set; }
        
        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public int Ordinal { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}