namespace BankOfBIT_JP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chequingAccountFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NextChequingAccounts",
                c => new
                    {
                        NextChequingAccountId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextChequingAccountId);
            
            DropTable("dbo.NextCheckingAccounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NextCheckingAccounts",
                c => new
                    {
                        NextCheckingAccountId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextCheckingAccountId);
            
            DropTable("dbo.NextChequingAccounts");
        }
    }
}
