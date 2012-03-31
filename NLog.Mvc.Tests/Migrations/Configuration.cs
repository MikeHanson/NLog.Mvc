using System;
   using System.Data.Entity.Migrations;
using System.Linq;

namespace NLog.Mvc.Tests.Migrations
{
	public sealed class Configuration : DbMigrationsConfiguration<LoggingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LoggingContext context)
        {
        	if(context.Log.Any())
        	{
        		return;
        	}

        	context.Log.Add(new LogEntry
        	                	{
        	                		Level = "DEBUG",
        	                		Logger = "TestLogger",
        	                		Message = "Test Message",
        	                		TimeStamp = DateTime.UtcNow
        	                	});

        	context.Log.Add(new LogEntry
        	                	{
        	                		Level = "DEBUG",
        	                		Logger = "TestLogger",
        	                		Message = "Test Message",
        	                		TimeStamp = DateTime.UtcNow
        	                	});
        }
    }
}
