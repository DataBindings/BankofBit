namespace BankOfBIT_JP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class StoredProcedures : DbMigration
    {
        /// <summary>
        /// Calls the script to create next number.
        /// </summary>
        public override void Up()
        {
            //call script to re-create the stored procedure
            this.Sql(Properties.Resources.create_next_number);
        }

        /// <summary>
        /// Calls the script to drop next number.
        /// </summary>
        public override void Down()
        {
            //Call script to drop the stored procedure
            this.Sql(Properties.Resources.drop_next_number);
        }
    }
}
