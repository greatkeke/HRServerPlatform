namespace _04Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpeakID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_ChatContent", "SpeakID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.t_ChatContent", "SpeakID");
        }
    }
}
