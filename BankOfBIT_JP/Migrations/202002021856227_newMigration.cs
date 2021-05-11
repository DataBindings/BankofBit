namespace BankOfBIT_JP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BankAccounts", "SavingsServiceCharges");
            RenameColumn(table: "dbo.BankAccounts", name: "SavingsServiceCharges1", newName: "SavingsServiceCharges");
            CreateTable(
                "dbo.Transactions",
                c => new
                {
                    TransactionId = c.Int(nullable: false, identity: true),
                    TransactionNumber = c.Long(nullable: false),
                    BankAccountId = c.Int(nullable: false),
                    TransactionTypeId = c.Int(nullable: false),
                    Deposit = c.Double(nullable: false),
                    Withdrawal = c.Double(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    Notes = c.String(),
                })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId, cascadeDelete: true)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionTypeId, cascadeDelete: true)
                .Index(t => t.BankAccountId)
                .Index(t => t.TransactionTypeId);

            CreateTable(
                "dbo.TransactionTypes",
                c => new
                {
                    TransactionTypeId = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    ServiceCharges = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.TransactionTypeId);

            CreateTable(
                "dbo.Institutions",
                c => new
                {
                    InstitutionId = c.Int(nullable: false, identity: true),
                    InstitutionNumber = c.Int(nullable: false),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.InstitutionId);

            CreateTable(
                "dbo.NextCheckingAccounts",
                c => new
                {
                    NextCheckingAccountId = c.Int(nullable: false, identity: true),
                    NextAvailableNumber = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.NextCheckingAccountId);

            CreateTable(
                "dbo.NextClientNumbers",
                c => new
                {
                    NextClientNumberId = c.Int(nullable: false, identity: true),
                    NextAvailableNumber = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.NextClientNumberId);

            CreateTable(
                "dbo.NextInvestmentAccounts",
                c => new
                {
                    NextInvestmentAccountId = c.Int(nullable: false, identity: true),
                    NextAvailableNumber = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.NextInvestmentAccountId);

            CreateTable(
                "dbo.NextMortgageAccounts",
                c => new
                {
                    NextMortgageAccountId = c.Int(nullable: false, identity: true),
                    NextAvailableNumber = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.NextMortgageAccountId);

            CreateTable(
                "dbo.NextSavingsAccounts",
                c => new
                {
                    NextSavingsaccountId = c.Int(nullable: false, identity: true),
                    NextAvailableNumber = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.NextSavingsaccountId);

            CreateTable(
                "dbo.NextTransactionNumbers",
                c => new
                {
                    NextTransactionNumberId = c.Int(nullable: false, identity: true),
                    NextAvailableNumber = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.NextTransactionNumberId);

            CreateTable(
                "dbo.Payees",
                c => new
                {
                    PayeeId = c.Int(nullable: false, identity: true),
                    Description = c.String(nullable: false),
                })
                .PrimaryKey(t => t.PayeeId);

            CreateTable(
                "dbo.RFIDTags",
                c => new
                {
                    RFIDTagId = c.Int(nullable: false, identity: true),
                    CardNumber = c.Long(nullable: false),
                    ClientId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.RFIDTagId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);

            AddColumn("dbo.BankAccounts", "ChequingServiceCharges", c => c.Double());
        }

        public override void Down()
        {
            DropForeignKey("dbo.RFIDTags", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes");
            DropForeignKey("dbo.Transactions", "BankAccountId", "dbo.BankAccounts");
            DropIndex("dbo.RFIDTags", new[] { "ClientId" });
            DropIndex("dbo.Transactions", new[] { "TransactionTypeId" });
            DropIndex("dbo.Transactions", new[] { "BankAccountId" });
            DropColumn("dbo.BankAccounts", "ChequingServiceCharges");
            DropTable("dbo.RFIDTags");
            DropTable("dbo.Payees");
            DropTable("dbo.NextTransactionNumbers");
            DropTable("dbo.NextSavingsAccounts");
            DropTable("dbo.NextMortgageAccounts");
            DropTable("dbo.NextInvestmentAccounts");
            DropTable("dbo.NextClientNumbers");
            DropTable("dbo.NextCheckingAccounts");
            DropTable("dbo.Institutions");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
            RenameColumn(table: "dbo.BankAccounts", name: "SavingsServiceCharges", newName: "SavingsServiceCharges1");
            AddColumn("dbo.BankAccounts", "SavingsServiceCharges", c => c.Double());
        }
    }
}
