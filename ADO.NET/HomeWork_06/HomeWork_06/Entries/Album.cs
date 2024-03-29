namespace HomeWork_06
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Album
    {

        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        public int AlbumID { get; set; }

        [StringLength(100)]
        public string AlbumName { get; set; }

        public int? ArtistID { get; set; }

        public int? ReleaseYear { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [Required]
        [StringLength(255)]
        public string CoverPhoto { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
