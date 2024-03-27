namespace Homework_05
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
   
    [Table("Flights")]
    public partial class Flights
    {
        [Key]
        public int flight_id { get; set; }

        [StringLength(20)]
        public string flight_number { get; set; }

        public int? airplane_id { get; set; }

        [StringLength(255)]
        public string clients { get; set; }

        public DateTime? departure_date { get; set; }

        public DateTime? arrival_date { get; set; }

        [StringLength(100)]
        public string departure_location { get; set; }

        [StringLength(100)]
        public string arrival_location { get; set; }

        public virtual Airplanes Airplanes { get; set; }
    }
}
