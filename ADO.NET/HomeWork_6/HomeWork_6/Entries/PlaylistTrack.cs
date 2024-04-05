namespace HomeWork_06
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlaylistTrack
    {
        public int PlaylistTrackID { get; set; }

        public int? PlaylistID { get; set; }

        public int? TrackID { get; set; }

        public virtual Playlist Playlist { get; set; }

        public virtual Track Track { get; set; }
    }
}
