using System;
using System.Data.Entity.Migrations;

namespace NLog.Mvc4.Web.Migrations
{
	public partial class Initialisation : DbMigration
	{
		public override void Up()
		{
			this.CreateTable(
			   "Log",
			   c => new
			   {
				   Id = c.Int(nullable: false, identity: true),
				   TimeStamp = c.DateTime(nullable: false),
				   Level = c.String(nullable: false, maxLength: 5),
				   Logger = c.String(nullable: false, maxLength: 200),
				   Server = c.String(maxLength: 200),
				   Message = c.String(nullable: false),
			   })
			   .PrimaryKey(t => t.Id);

		}

		public override void Down()
		{
			this.DropTable("Log");
		}
	}
}
