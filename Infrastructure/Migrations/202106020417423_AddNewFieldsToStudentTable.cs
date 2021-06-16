namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldsToStudentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "studentLastName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "studentCode", c => c.String(nullable: false));
            AddColumn("dbo.Students", "studentCreatedAt", c => c.String());
            AddColumn("dbo.Students", "studentUpdatedAt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "studentUpdatedAt");
            DropColumn("dbo.Students", "studentCreatedAt");
            DropColumn("dbo.Students", "studentCode");
            DropColumn("dbo.Students", "studentLastName");
        }
    }
}
