namespace res
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Worker
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public decimal? Salary { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string PhoneNumber { get; set; }

        public int? PositionId { get; set; }

        public int? ShopId { get; set; }

        public virtual Position Position { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
