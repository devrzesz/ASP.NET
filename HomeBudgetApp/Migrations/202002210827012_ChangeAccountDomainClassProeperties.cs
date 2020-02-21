namespace HomeBudgetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAccountDomainClassProeperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Balance", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Accounts", "OpeningBalance", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Accounts", "LastUpdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "LastUpdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "OpeningBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Accounts", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Accounts", "Name", c => c.String());
        }
    }
}
