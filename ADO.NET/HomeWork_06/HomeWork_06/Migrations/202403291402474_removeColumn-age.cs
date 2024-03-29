namespace HomeWork_06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeColumnage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Artists", "age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "age", c => c.Int(nullable: false));
        }
    }
}
