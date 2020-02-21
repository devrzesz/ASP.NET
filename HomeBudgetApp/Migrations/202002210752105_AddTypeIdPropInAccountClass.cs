namespace HomeBudgetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeIdPropInAccountClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "TypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "TypeId");
        }
    }
}
