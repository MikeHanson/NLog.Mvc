using System;
using System.Linq;
using NUnit.Framework;

namespace NLog.Mvc.Tests
{
	[TestFixture]
	public class TargetTests
	{
		private const string LoggerName = "NLog.Mvc.Tests.Logger";
		private const string ConnectionStringName = "LoggingContext";

		[TearDown]
		public void TearDown()
		{
			using(var context = new LoggingContext(ConnectionStringName))
			{
				foreach(var entry in context.Log.Where(e => e.Logger == LoggerName))
				{
					context.Log.Remove(entry);
				}

				context.SaveChanges();
			}
		}

		[Test]
		public void WriteAddLogEntryToDatabase()
		{
			var target = new DbContextTargetDouble();
			target.Write(new LogEventInfo(LogLevel.Debug, LoggerName, "some debug message"));
			using(var context = new LoggingContext(ConnectionStringName))
			{
				Assert.That(context.Log.Any(e => e.Logger == LoggerName));
			}
		}
	}

	public class DbContextTargetDouble: DbContextTarget
	{
		public DbContextTargetDouble()
		{
			ConnectionStringName = "LoggingContext";
		}

		public new void Write(LogEventInfo eventInfo)
		{
			base.Write(eventInfo);
		}
	}
}
