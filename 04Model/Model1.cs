namespace _04Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“Model1”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“_04Model.Model1”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“Model1”
        //连接字符串。
        public Model1()
            : base("name=Model1")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<t_Categories> t_Categories { get; set; }
        public virtual DbSet<t_ChatContent> t_ChatContent { get; set; }
        public virtual DbSet<t_JobNews> t_JobNews { get; set; }
        public virtual DbSet<t_NewsEvalution> t_NewsEvalution { get; set; }
        public virtual DbSet<t_Orders> t_Orders { get; set; }
        public virtual DbSet<t_Power> t_Power { get; set; }
        public virtual DbSet<t_Requirement> t_Requirement { get; set; }
        public virtual DbSet<t_Role> t_Role { get; set; }
        public virtual DbSet<t_RolePower> t_RolePower { get; set; }
        public virtual DbSet<t_Session> t_Session { get; set; }
        public virtual DbSet<t_User> t_User { get; set; }
        public virtual DbSet<t_UserRole> t_UserRole { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    public partial class t_Categories
    {
        public System.Guid ID { get; set; }
        public string CategoryName { get; set; }
    }
    public partial class t_ChatContent
    {
        public System.Guid ID { get; set; }
        public System.Guid SessionID { get; set; }
        public System.DateTime Date { get; set; }
        public string Content { get; set; }
        public System.Guid SpeakID { get; set; }
    }
    public partial class t_JobNews
    {
        public System.Guid ID { get; set; }
        public System.Guid PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public System.DateTime Date { get; set; }
    }
    public partial class t_NewsEvalution
    {
        public System.Guid ID { get; set; }
        public System.Guid NewsID { get; set; }
        public System.Guid EvalutionID { get; set; }
        public System.DateTime Date { get; set; }
        public string Content { get; set; }
    }
    public partial class t_Orders
    {
        public System.Guid ID { get; set; }
        public System.Guid RequirementID { get; set; }
        public System.Guid AchievementID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> TurnoverDate { get; set; }
        public Nullable<int> StarNums { get; set; }
        public string Evalute { get; set; }
        public int Status { get; set; }
    }
    public partial class t_Power
    {
        public System.Guid ID { get; set; }
        public string Power { get; set; }
    }
    public partial class t_Requirement
    {
        public System.Guid ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Gread { get; set; }
        public System.Guid PostID { get; set; }
        public System.Guid CategoryID { get; set; }
        public int Status { get; set; }
        public System.DateTime PostDate { get; set; }
    }
    public partial class t_Role
    {
        public System.Guid ID { get; set; }
        public string RoleName { get; set; }
    }
    public partial class t_RolePower
    {
        public System.Guid RoleID { get; set; }
        public System.Guid PowerID { get; set; }
        public int ID { get; set; }
    }
    public partial class t_Session
    {
        public System.Guid ID { get; set; }
        public System.Guid RequirementID { get; set; }
        public System.Guid AchivementID { get; set; }
        public System.Guid RequireID { get; set; }
        public System.DateTime SessionDate { get; set; }
    }
    public partial class t_User
    {
        public System.Guid ID { get; set; }
        public string User { get; set; }
        public string Pwd { get; set; }
        public System.Guid RoleID { get; set; }
        public string ShowInfo { get; set; }
        public string Other { get; set; }
    }
    public partial class t_UserRole
    {
        public System.Guid UserID { get; set; }
        public System.Guid RoleID { get; set; }
        public int ID { get; set; }
    }
}