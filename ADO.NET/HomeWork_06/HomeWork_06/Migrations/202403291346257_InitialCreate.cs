namespace HomeWork_06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(maxLength: 100),
                        ArtistID = c.Int(),
                        ReleaseYear = c.Int(),
                        Genre = c.String(maxLength: 50),
                        CoverPhoto = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.Artists", t => t.ArtistID)
                .Index(t => t.ArtistID);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        TrackID = c.Int(nullable: false, identity: true),
                        TrackName = c.String(maxLength: 100),
                        AlbumID = c.Int(),
                        Duration = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.TrackID)
                .ForeignKey("dbo.Albums", t => t.AlbumID)
                .Index(t => t.AlbumID);
            
            CreateTable(
                "dbo.PlaylistTracks",
                c => new
                    {
                        PlaylistTrackID = c.Int(nullable: false, identity: true),
                        PlaylistID = c.Int(),
                        TrackID = c.Int(),
                    })
                .PrimaryKey(t => t.PlaylistTrackID)
                .ForeignKey("dbo.Playlists", t => t.PlaylistID)
                .ForeignKey("dbo.Tracks", t => t.TrackID)
                .Index(t => t.PlaylistID)
                .Index(t => t.TrackID);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistID = c.Int(nullable: false, identity: true),
                        PlaylistName = c.String(maxLength: 100),
                        Category = c.String(maxLength: 50),
                        CoverPhoto = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.PlaylistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistTracks", "TrackID", "dbo.Tracks");
            DropForeignKey("dbo.PlaylistTracks", "PlaylistID", "dbo.Playlists");
            DropForeignKey("dbo.Tracks", "AlbumID", "dbo.Albums");
            DropForeignKey("dbo.Albums", "ArtistID", "dbo.Artists");
            DropIndex("dbo.PlaylistTracks", new[] { "TrackID" });
            DropIndex("dbo.PlaylistTracks", new[] { "PlaylistID" });
            DropIndex("dbo.Tracks", new[] { "AlbumID" });
            DropIndex("dbo.Albums", new[] { "ArtistID" });
            DropTable("dbo.Playlists");
            DropTable("dbo.PlaylistTracks");
            DropTable("dbo.Tracks");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
