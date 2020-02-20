namespace HomeBudgetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAccountType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AccountTypes (Name) VALUES ('Pocket Account')");
            Sql("INSERT INTO AccountTypes (Name) VALUES ('Debit Account')");

        }

        public override void Down()
        {
        }
    }
}
