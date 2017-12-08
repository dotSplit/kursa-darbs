namespace Board.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEMAIL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "email");
        }
    }
}
