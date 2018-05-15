namespace AdvancedProgramming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "Adults");
            CreateTable(
                "dbo.Kids",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SchoolType = c.Int(nullable: false),
                        NameClass = c.String(),
                        PocketMonetValue = c.Double(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Adults", "Singiel", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Adults", "Salary", c => c.Double(nullable: false));
            DropColumn("dbo.Adults", "SchoolType");
            DropColumn("dbo.Adults", "NameClass");
            DropColumn("dbo.Adults", "PocketMonetValue");
            DropColumn("dbo.Adults", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adults", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Adults", "PocketMonetValue", c => c.Double());
            AddColumn("dbo.Adults", "NameClass", c => c.String());
            AddColumn("dbo.Adults", "SchoolType", c => c.Int());
            AlterColumn("dbo.Adults", "Salary", c => c.Double());
            AlterColumn("dbo.Adults", "Singiel", c => c.Boolean());
            DropTable("dbo.Kids");
            RenameTable(name: "dbo.Adults", newName: "People");
        }
    }
}
