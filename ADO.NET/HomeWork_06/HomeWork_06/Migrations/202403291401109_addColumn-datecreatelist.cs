namespace HomeWork_06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumndatecreatelist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Playlists", "PlayDataCreate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Playlists", "PlayDataCreate");
        }
    }
}
