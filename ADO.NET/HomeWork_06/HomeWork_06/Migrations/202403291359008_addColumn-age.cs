namespace HomeWork_06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "age");
        }
    }
}
