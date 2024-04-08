using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Exam_DAL
{
    public partial class Olympiad : DbContext
    {
        public Olympiad()
            : base("name=Olympiad")
        {
        }

        public virtual DbSet<Athlete> Athlete { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Medal> Medal { get; set; }
        public virtual DbSet<OlympicGames> OlympicGames { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.Medal)
                .WithOptional(e => e.Athlete)
                .HasForeignKey(e => e.athlete_id);

            modelBuilder.Entity<OlympicGames>()
                .HasMany(e => e.Event)
                .WithOptional(e => e.OlympicGames)
                .HasForeignKey(e => e.olympic_game_id);

            modelBuilder.Entity<OlympicGames>()
                .HasMany(e => e.Medal)
                .WithOptional(e => e.OlympicGames)
                .HasForeignKey(e => e.olympic_game_id);

            modelBuilder.Entity<Sport>()
                .HasMany(e => e.Athlete)
                .WithOptional(e => e.Sport)
                .HasForeignKey(e => e.sport_id);

            modelBuilder.Entity<Sport>()
                .HasMany(e => e.Event)
                .WithOptional(e => e.Sport)
                .HasForeignKey(e => e.sport_id);
        }
    }
}
