using Microsoft.EntityFrameworkCore;

namespace HomeWork_06
{
    public class MusicLibrary : DbContext
    {
        private const string stor = "name=MusicLibrary";

        public MusicLibrary()
            : base(stor)
        {
            
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .Property(e => e.AlbumName)
                .IsUnicode(false);

            modelBuilder.Entity<Album>()
                .Property(e => e.Genre)
                .IsUnicode(false);

            modelBuilder.Entity<Album>()
                .Property(e => e.CoverPhoto)
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Playlist>()
                .Property(e => e.PlaylistName)
                .IsUnicode(false);

            modelBuilder.Entity<Playlist>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Playlist>()
                .Property(e => e.CoverPhoto)
                .IsUnicode(false);

            modelBuilder.Entity<Track>()
                .Property(e => e.TrackName)
                .IsUnicode(false);
        }
    }
}
