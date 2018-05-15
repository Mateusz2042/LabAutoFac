namespace AdvancedProgramming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adults", "Singiel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adults", "Singiel", c => c.Boolean(nullable: false));
        }
    }
}
