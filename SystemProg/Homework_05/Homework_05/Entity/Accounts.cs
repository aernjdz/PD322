namespace Homework_05
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    [Table("Accounts")]
    public partial class Accounts
    {
       
        public Accounts()
        {
            Clients = new HashSet<Clients>();
        }

        [Key]
        public int account_id { get; set; }

        [StringLength(50)]
        public string login { get; set; }

        [StringLength(50)]
        public string password { get; set; }

    
        public virtual ICollection<Clients> Clients { get; set; }
    }
}
