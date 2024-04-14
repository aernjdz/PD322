namespace Exam_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OlympicGame
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OlympicGame()
        {
            Events = new HashSet<Event>();
            Medals = new HashSet<Medal>();
        }

        public int id { get; set; }

        public int year { get; set; }

        [Required]
        [StringLength(10)]
        public string season { get; set; }

        [Required]
        [StringLength(255)]
        public string host_country { get; set; }

        [Required]
        [StringLength(255)]
        public string host_city { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medal> Medals { get; set; }
    }
}
