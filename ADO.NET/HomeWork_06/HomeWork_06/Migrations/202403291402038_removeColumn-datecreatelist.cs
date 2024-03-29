namespace HomeWork_06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeColumndatecreatelist : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Playlists", "PlayDataCreate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playlists", "PlayDataCreate", c => c.DateTime());
        }
    }
}
