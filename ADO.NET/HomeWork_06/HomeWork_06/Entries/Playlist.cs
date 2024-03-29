namespace HomeWork_06
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Playlist
    { 
        public Playlist()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int PlaylistID { get; set; }

     //   public DateTime? PlayDataCreate { get; set; }

        [StringLength(100)]
        public string PlaylistName { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        [StringLength(255)]
        public string CoverPhoto { get; set; }

      
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
