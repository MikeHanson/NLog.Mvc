using System;
using System.Data.Entity;

namespace NLog.Mvc
{
	/// <summary>
	/// Interface to be implemented by logging context
	/// </summary>
	public interface ILoggingContext
	{
		/// <summary>
		/// Gets or sets the log.
		/// </summary>
		/// <value>
		/// The log.
		/// </value>
		IDbSet<LogEntry> Log { get; set; }
		
		/// <summary>
		/// Saves the changes.
		/// </summary>
		/// <returns>Number of entries affected by the operation</returns>
		int SaveChanges();
	}
}
