namespace BankOfBIT_JP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixerrors : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Province", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "PostalCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "PostalCode", c => c.String(nullable: false, maxLength: 7));
            AlterColumn("dbo.Clients", "Province", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
