namespace HomeBudgetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateDatefieldtoAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "LastUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "LastUpdate");
        }
    }
}
