using System;
using System.Data.Entity;

namespace NLog.Mvc
{
	/// <summary>
	/// Context for accessing log data
	/// </summary>
	public class LoggingContext : DbContext, ILoggingContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LoggingContext"/> class.
		/// </summary>
		public LoggingContext()
			: base("name=LoggingContext")
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LoggingContext"/> class.
		/// </summary>
		/// <param name="connectionStringName">Name of the connection string.</param>
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