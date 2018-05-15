namespace AdvancedProgramming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Job = c.String(),
                        Singiel = c.Boolean(),
                        Salary = c.Double(),
                        SchoolType = c.Int(),
                        NameClass = c.String(),
                        PocketMonetValue = c.Double(),
                        PensionValue = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
