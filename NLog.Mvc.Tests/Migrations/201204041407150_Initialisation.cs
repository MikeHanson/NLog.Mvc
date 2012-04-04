namespace NLog.Mvc.Tests.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initialisation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        Level = c.String(nullable: false, maxLength: 5),
                        Logger = c.String(nullable: false, maxLength: 200),
                        Message = c.String(nullable: false),
                        ExceptionType = c.String(),
                        Operation = c.String(),
                        ExceptionMessage = c.String(),
                        StackTrace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("Log");
        }
    }
}
