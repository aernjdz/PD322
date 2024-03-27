namespace Homework_05
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
   
    [Table("Clients")]
    public partial class Clients
    {
        [Key]
        public int client_id { get; set; }

        [StringLength(50)]
        public string first_name { get; set; }

        [StringLength(50)]
        public string last_name { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(1)]
        public string gender { get; set; }

        public int? account_id { get; set; }

        public virtual Accounts Accounts { get; set; }
    }
}
