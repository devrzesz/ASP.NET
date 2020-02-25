namespace HomeBudgetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriesEntityAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);

            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
