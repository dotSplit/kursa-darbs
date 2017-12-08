namespace Board.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ayy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Announcements", "User_Id", "dbo.Users");
            DropIndex("dbo.Announcements", new[] { "User_Id" });
            AddColumn("dbo.Announcements", "Administrator_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Announcements", "Administrator_Id");
            AddForeignKey("dbo.Announcements", "Administrator_Id", "dbo.Administrators", "id", cascadeDelete: true);
            DropColumn("dbo.Announcements", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Announcements", "User_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Announcements", "Administrator_Id", "dbo.Administrators");
            DropIndex("dbo.Announcements", new[] { "Administrator_Id" });
            DropColumn("dbo.Announcements", "Administrator_Id");
            CreateIndex("dbo.Announcements", "User_Id");
            AddForeignKey("dbo.Announcements", "User_Id", "dbo.Users", "id", cascadeDelete: true);
        }
    }
}
