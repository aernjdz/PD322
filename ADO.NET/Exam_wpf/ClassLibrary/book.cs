namespace EXAM_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public book()
        {
            books1 = new HashSet<book>();
        }

        [Key]
        public int book_id { get; set; }

        [Required]
        [StringLength(255)]
        public string title { get; set; }

        [Required]
        [StringLength(255)]
        public string author_name { get; set; }

        [Required]
        [StringLength(255)]
        public string publisher { get; set; }

        public int? pages { get; set; }

        [StringLength(100)]
        public string genre { get; set; }

        public int? publication_year { get; set; }

        public decimal? cost_price { get; set; }

        public decimal? selling_price { get; set; }

        public int? parent_book_id { get; set; }

        [StringLength(1)]
        public string is_reserved { get; set; }

        [StringLength(1)]
        public string is_shared { get; set; }

        public virtual ICollection<book> books1 { get; set; }

        public virtual book book1 { get; set; }
    }
}

