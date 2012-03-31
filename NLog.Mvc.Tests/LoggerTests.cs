using System;
using System.Linq;
using NUnit.Framework;

namespace NLog.Mvc.Tests
{
	[TestFixture]
	public class LoggerTests
	{
		private const string LoggerName = "NLog.Mvc.Logger";
		private const string ConnectionStringName = "LoggingContext";
		private const string MessageTemplate = "{0} log entry";
		private Logger logger;

		[SetUp]
		public void SetUp()
		{
			logger = new Logger();
		}

		[TestFixtureTearDown]
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

		[TestCase("TRACE")]
		[TestCase("DEBUG")]
		[TestCase("INFO")]
		[TestCase("ERROR")]
		[TestCase("WARN")]
		public void WriteTraceMessageToDatabase(string level)
		{
			var message = this.MessageForLevel(level);
			this.WriteLogForLevel(level, message);
			this.AssertEntryWrittenToDatabase(level, message);
		}

		private string MessageForLevel(string level)
		{
			return String.Format(MessageTemplate, level);
		}

		private void WriteLogForLevel(string level, string message)
		{
			switch(level)
			{
				case "TRACE":
					this.logger.Trace(message);
					return;
				case "DEBUG":
					this.logger.Debug(message);
					return;
				case "INFO":
					this.logger.Information(message);
					return;
				case "ERROR":
					this.logger.Error(message);
					return;
				case "WARN":
					this.logger.Warning(message);
					return;
				default:
					return;
			}
		}

		private void AssertEntryWrittenToDatabase(string level, string message)
		{
			using(var context = new LoggingContext(ConnectionStringName))
			{
				Assert.That(context.Log.Any(e => e.Level == level && e.Message == message));
			}
		}
	}
}
