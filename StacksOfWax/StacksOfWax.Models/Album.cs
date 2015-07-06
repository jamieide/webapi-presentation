using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace StacksOfWax.Models
{
    [DataContract]
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

        [DataMember]
        public int AlbumId { get; private set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        public int ArtistId { get; set; }
        
        [DataMember]
        public Artist Artist { get; set; }

        [DataMember]
        public ICollection<Track> Tracks { get; private set; }
    }
}