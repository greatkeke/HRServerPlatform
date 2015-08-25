namespace _04Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTurnoverDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.t_Orders", "TurnoverDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.t_Orders", "TurnoverDate", c => c.DateTime(nullable: false));
        }
    }
}
