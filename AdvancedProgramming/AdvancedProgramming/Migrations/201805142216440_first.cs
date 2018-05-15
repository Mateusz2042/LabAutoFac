namespace AdvancedProgramming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "PensionValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "PensionValue", c => c.Double());
        }
    }
}
