using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace HomeWork_06.EF
{
    public partial class MusicLibrary : DbContext
    {
        public MusicLibrary()
            : base("name=MusicLibraryDB")
        {
            Database.SetInitializer(new Initializer());

        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

      
    }
}
