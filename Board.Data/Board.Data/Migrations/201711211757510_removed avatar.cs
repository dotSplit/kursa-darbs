namespace Board.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedavatar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "image", c => c.String(nullable: false));
        }
    }
}
