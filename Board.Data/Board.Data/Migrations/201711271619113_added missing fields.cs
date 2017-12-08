namespace Board.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmissingfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "reputation", c => c.Int(nullable: false));
            AddColumn("dbo.Reputations", "amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reputations", "amount");
            DropColumn("dbo.Users", "reputation");
        }
    }
}
