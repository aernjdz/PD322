namespace HomeWork_06
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artist
    {
       
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public int ArtistID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

       // public int age { get; set;}

        [StringLength(50)]
        public string Country { get; set; }

     
        public virtual ICollection<Album> Albums { get; set; }
    }
}
