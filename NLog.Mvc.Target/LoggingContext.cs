using System;
using System.Data.Entity;

namespace NLog.Mvc
{
	/// <summary>
	/// Context for accessing log data
	/// </summary>
	public class LoggingContext : DbContext, ILoggingContext
	{
		public LoggingContext(string connectionStringName)
			: base(connectionStringName)
		{
		}

		/// <summary>
		/// Gets or sets the log.
		/// </summary>
		/// <value>
		/// The log.
		/// </value>
		public IDbSet<LogEntry> Log { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new LogEntryConfiguration());
		}
	}
}