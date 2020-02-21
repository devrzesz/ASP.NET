namespace HomeBudgetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    public partial class ChangeBalancePropToNonNullableInAccountModel : DbMigration
    {
        public override void Up()
        {
            //Update Balance Columnt where Null to convert Balance and OpeningBalance with exissting data
            Sql(@"UPDATE [dbo].[Accounts] SET Balance = 1.00  WHERE Balance IS NULL");

            AlterColumn("dbo.Accounts", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Accounts", "OpeningBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }

        public override void Down()
        {
            AlterColumn("dbo.Accounts", "OpeningBalance", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Accounts", "Balance", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
