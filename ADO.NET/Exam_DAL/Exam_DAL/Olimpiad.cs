using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Exam_DAL
{
    public partial class Olimpiad : DbContext
    {
        public Olimpiad()
            : base("name=Olimpiad")
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Medal> Medals { get; set; }
        public virtual DbSet<OlympicGame> OlympicGames { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.Medals)
                .WithOptional(e => e.Athlete)
                .HasForeignKey(e => e.athlete_id);

            modelBuilder.Entity<OlympicGame>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.OlympicGame)
                .HasForeignKey(e => e.olympic_game_id);

            modelBuilder.Entity<OlympicGame>()
                .HasMany(e => e.Medals)
                .WithOptional(e => e.OlympicGame)
                .HasForeignKey(e => e.olympic_game_id);

            modelBuilder.Entity<Sport>()
                .HasMany(e => e.Athletes)
                .WithOptional(e => e.Sport)
                .HasForeignKey(e => e.sport_id);

            modelBuilder.Entity<Sport>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.Sport)
                .HasForeignKey(e => e.sport_id);
        }
    }
}
