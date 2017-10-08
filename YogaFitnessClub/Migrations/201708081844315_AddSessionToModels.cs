namespace YogaFitnessClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSessionToModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        InstructorName = c.String(nullable: false),
                        ActivityId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sessions", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Sessions", new[] { "CustomerId" });
            DropIndex("dbo.Sessions", new[] { "ActivityId" });
            DropTable("dbo.Activities");
            DropTable("dbo.Sessions");
        }
    }
}