namespace Exam_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public int id { get; set; }

        public int? olympic_game_id { get; set; }

        public int? sport_id { get; set; }

        public int? participants { get; set; }

        public virtual OlympicGames OlympicGames { get; set; }

        public virtual Sport Sport { get; set; }
    }
}
