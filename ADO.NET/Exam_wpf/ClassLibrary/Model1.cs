using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace exam
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<book> books { get; set; }


        public List<book> SearchBooks(string title = null, string author = null, string genre = null)
        {
            var query = books.AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(b => b.title.Contains(title));

            if (!string.IsNullOrEmpty(author))
                query = query.Where(b => b.author_name.Contains(author));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(b => b.genre.Contains(genre));


            return query.ToList();
        }


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
                .HasMany(e => e.books1)
                .WithOptional(e => e.book1)
                .HasForeignKey(e => e.parent_book_id);
        }
    }
}


