namespace Board.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ayy2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "image", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "gender", c => c.String());
            DropColumn("dbo.Users", "image");
        }
    }
}
