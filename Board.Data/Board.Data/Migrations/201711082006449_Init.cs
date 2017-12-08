namespace Board.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        surname = c.String(nullable: false, maxLength: 50),
                        username = c.String(nullable: false, maxLength: 30),
                        screenname = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 50),
                        birth_date = c.DateTime(nullable: false),
                        gender = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        content = c.String(nullable: false),
                        Post_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        title = c.String(nullable: false, maxLength: 30),
                        content = c.String(nullable: false),
                        Channel_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Channels", t => t.Channel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: false)
                .Index(t => t.Channel_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 30),
                        rules = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        title = c.String(nullable: false, maxLength: 30),
                        content = c.String(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.Reputations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Receiver_Id = c.Int(nullable: false),
                        Sender_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.Receiver_Id, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.Sender_Id, cascadeDelete: false)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reputations", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Reputations", "Receiver_Id", "dbo.Users");
            DropForeignKey("dbo.Attachments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Announcements", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Administrators", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "Channel_Id", "dbo.Channels");
            DropIndex("dbo.Reputations", new[] { "Sender_Id" });
            DropIndex("dbo.Reputations", new[] { "Receiver_Id" });
            DropIndex("dbo.Attachments", new[] { "Post_Id" });
            DropIndex("dbo.Announcements", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Channel_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Administrators", new[] { "User_Id" });
            DropTable("dbo.Reputations");
            DropTable("dbo.Attachments");
            DropTable("dbo.Announcements");
            DropTable("dbo.Channels");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Administrators");
        }
    }
}
