using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06.EF
{
    internal class Initializer : CreateDatabaseIfNotExists<MusicLibrary>
    {
        protected override void Seed(MusicLibrary context)
        {
            base.Seed(context);
            //Artists
            Artist John = context.Artists.Add(new Artist()
            {
                FirstName = "John",
                LastName = "Doe",
                Country = "USA"
               
            });

            Artist Jane = context.Artists.Add(new Artist()
            {
                FirstName = "Jane",
                LastName = "Smith",
                Country = "UK"

            });
            Artist Michael = context.Artists.Add(new Artist()
            {
                FirstName = "Michael",
                LastName = "Johnson",
                Country = "Canada"

            });
            context.SaveChanges();

            //Albums

            Album album1 = context.Albums.Add(new Album()
            {
                AlbumName = "Greatest Hits",
                ArtistID = John.ArtistID, 
                ReleaseYear = 2000,
                Genre = "Rock",
                CoverPhoto = "https://example.com/album1_cover.jpg"
           
            });

            Album album2 = context.Albums.Add(new Album()
            {
                AlbumName = "Love Songs",
                ArtistID = Jane.ArtistID, 
                ReleaseYear = 1995,
                Genre = "Pop",
                CoverPhoto = "https://example.com/album2_cover.jpg"
            });

            Album album3 = context.Albums.Add(new Album()
            {
                AlbumName = "Country Roads",
                ArtistID = Michael.ArtistID, 
                ReleaseYear = 2010,
                Genre = "Country",
                CoverPhoto = "https://example.com/album3_cover.jpg"
            });
            context.SaveChanges();

            //Tracks

            context.Tracks.Add(new Track()
            {
                TrackName = "Song 1",
                AlbumID = album1.AlbumID,
                Duration = TimeSpan.FromSeconds(240) 
            });

            context.Tracks.Add(new Track()
            {
                TrackName = "Song 2",
                AlbumID = album1.AlbumID,
                Duration = TimeSpan.FromSeconds(320) 
            });

             context.Tracks.Add(new Track()
            {
                TrackName = "Love Ballad",
                AlbumID = album2.AlbumID,
                Duration = TimeSpan.FromSeconds(250) 
            });
             context.Tracks.Add(new Track()
            {
                TrackName = "Country Road",
                AlbumID = album3.AlbumID,
                Duration = TimeSpan.FromSeconds(235) ,
               
            });

            context.SaveChanges();


            //Playlists

            Playlist playlist = context.Playlists.Add(new Playlist() 
            {
                PlaylistName = "MyPlaylist",
                Category = "General",
                CoverPhoto = "https://example.com/playlist1_cover.jpg"
            });

         
           


            var tracksForPlaylist = context.Tracks.ToList();

            foreach (var track in tracksForPlaylist)
            {
                context.PlaylistTracks.Add(new PlaylistTrack()
                {
                    PlaylistID = playlist.PlaylistID,
                    TrackID = track.TrackID
                });
            }

            context.SaveChanges();
            /*
                        context.PlaylistTracks.Add(new PlaylistTrack
                        {
                           PlaylistID = list1.PlaylistID,
                           TrackID = track1.TrackID
                        });*/
           

        }
        
    }
}
