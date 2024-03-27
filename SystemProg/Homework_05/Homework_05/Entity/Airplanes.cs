namespace Homework_05
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    [Table("Airplanes")]
    public partial class Airplanes
    {
     
        public Airplanes()
        {
            Flights = new HashSet<Flights>();
        }

        [Key]
        public int airplane_id { get; set; }

        [StringLength(100)]
        public string model { get; set; }

        [StringLength(100)]
        public string type { get; set; }

        public int? max_passengers { get; set; }

        [StringLength(100)]
        public string country { get; set; }


        public virtual ICollection<Flights> Flights { get; set; }
    }
}
