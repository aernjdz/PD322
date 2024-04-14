using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Homework_05_02_DAL
{
    public partial class LIbraryModel : DbContext
    {
        public LIbraryModel()
            : base("name=LIbraryModel")
        {
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);


            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Book>()
                .Property(b => b.Year)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Genre)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .WillCascadeOnDelete(false);
        }
    }
}
