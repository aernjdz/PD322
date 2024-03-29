namespace HomeWork_06
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Track
    {
       
        public Track()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int TrackID { get; set; }

        [StringLength(100)]
        public string TrackName { get; set; }

        public int? AlbumID { get; set; }

        public TimeSpan? Duration { get; set; }

        public virtual Album Album { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
