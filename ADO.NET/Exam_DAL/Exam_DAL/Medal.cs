namespace Exam_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medal")]
    public partial class Medal
    {
        public int id { get; set; }

        public int? athlete_id { get; set; }

        public int? olympic_game_id { get; set; }

        [Column("medal")]
        [Required]
        [StringLength(10)]
        public string medal1 { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual OlympicGame OlympicGame { get; set; }
    }
}
