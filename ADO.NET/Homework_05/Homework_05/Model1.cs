using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Homework_05
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=AirplaneDBContext")
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Airplanes> Airplanes { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Airplanes>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<Airplanes>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Airplanes>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Flights>()
                .Property(e => e.flight_number)
                .IsUnicode(false);

            modelBuilder.Entity<Flights>()
                .Property(e => e.clients)
                .IsUnicode(false);

            modelBuilder.Entity<Flights>()
                .Property(e => e.departure_location)
                .IsUnicode(false);

            modelBuilder.Entity<Flights>()
                .Property(e => e.arrival_location)
                .IsUnicode(false);
        }
    }
}
