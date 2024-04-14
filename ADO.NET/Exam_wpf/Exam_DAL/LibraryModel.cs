using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_DAL
{
    public partial class LibraryModel : DbContext
    {

        public LibraryModel() : base("name=LibraryModel") { }

        public virtual DbSet<book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<book>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<book>()
                .Property(e => e.author_name)
                .IsUnicode(false);

            modelBuilder.Entity<book>()
                .Property(e => e.publisher)
                .IsUnicode(false);

            modelBuilder.Entity<book>()
                .Property(e => e.genre)
                .IsUnicode(false);

            modelBuilder.Entity<book>()
                .Property(e => e.cost_price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<book>()
                .Property(e => e.selling_price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<book>()
                .Property(e => e.is_reserved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<book>()
                .Property(e => e.is_shared)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<book>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Book)
                .HasForeignKey(e => e.parent_book_id);
        }
    }
}
