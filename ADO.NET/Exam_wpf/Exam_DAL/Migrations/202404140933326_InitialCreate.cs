namespace Exam_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.books",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 255, unicode: false),
                        author_name = c.String(nullable: false, maxLength: 255, unicode: false),
                        publisher = c.String(nullable: false, maxLength: 255, unicode: false),
                        pages = c.Int(),
                        genre = c.String(maxLength: 100, unicode: false),
                        publication_year = c.Int(),
                        cost_price = c.Decimal(precision: 10, scale: 2),
                        selling_price = c.Decimal(precision: 10, scale: 2),
                        parent_book_id = c.Int(),
                        is_reserved = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        is_shared = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.books", t => t.parent_book_id)
                .Index(t => t.parent_book_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.books", "parent_book_id", "dbo.books");
            DropIndex("dbo.books", new[] { "parent_book_id" });
            DropTable("dbo.books");
        }
    }
}
