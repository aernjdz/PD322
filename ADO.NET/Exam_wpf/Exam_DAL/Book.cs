using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_DAL
{
    public partial class book
    {
    
        public book()
        {
            Books = new HashSet<book>();
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

     
        public virtual ICollection<book> Books { get; set; }

        public virtual book Book { get; set; }
    }
}
