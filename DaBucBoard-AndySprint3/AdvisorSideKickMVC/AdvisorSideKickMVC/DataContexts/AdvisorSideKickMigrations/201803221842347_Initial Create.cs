namespace AdvisorSideKickMVC.DataContexts.AdvisorSideKickMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advisors",
                c => new
                    {
                        AdvisorId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AdvisorEmail = c.String(),
                        OfficeNumber = c.String(),
                    })
                .PrimaryKey(t => t.AdvisorId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Student_AccountId = c.Int(),
                        SchoolName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Students", t => t.Student_AccountId)
                .Index(t => t.Student_AccountId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        HighSchool = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "Student_AccountId", "dbo.Students");
            DropForeignKey("dbo.Advisors", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Departments", new[] { "Student_AccountId" });
            DropIndex("dbo.Advisors", new[] { "DepartmentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
            DropTable("dbo.Advisors");
        }
    }
}
