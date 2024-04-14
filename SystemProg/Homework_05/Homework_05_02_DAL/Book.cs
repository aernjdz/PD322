namespace Homework_05_02_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        public virtual Author Author { get; set; }
    }
}
