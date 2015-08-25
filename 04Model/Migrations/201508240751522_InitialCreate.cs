namespace _04Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_Categories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_ChatContent",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        SessionID = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_JobNews",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PostID = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_NewsEvalution",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        NewsID = c.Guid(nullable: false),
                        EvalutionID = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_Orders",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RequirementID = c.Guid(nullable: false),
                        AchievementID = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TurnoverDate = c.DateTime(nullable: false),
                        StarNums = c.Int(),
                        Evalute = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_Power",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Power = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_Requirement",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Gread = c.Int(nullable: false),
                        PostID = c.Guid(nullable: false),
                        CategoryID = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_Role",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_RolePower",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Guid(nullable: false),
                        PowerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_Session",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RequirementID = c.Guid(nullable: false),
                        AchivementID = c.Guid(nullable: false),
                        RequireID = c.Guid(nullable: false),
                        SessionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_User",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        User = c.String(),
                        Pwd = c.String(),
                        RoleID = c.Guid(nullable: false),
                        ShowInfo = c.String(),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.t_UserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        RoleID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.t_UserRole");
            DropTable("dbo.t_User");
            DropTable("dbo.t_Session");
            DropTable("dbo.t_RolePower");
            DropTable("dbo.t_Role");
            DropTable("dbo.t_Requirement");
            DropTable("dbo.t_Power");
            DropTable("dbo.t_Orders");
            DropTable("dbo.t_NewsEvalution");
            DropTable("dbo.t_JobNews");
            DropTable("dbo.t_ChatContent");
            DropTable("dbo.t_Categories");
        }
    }
}
