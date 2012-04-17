using System;
using System.ComponentModel.DataAnnotations;
using NLog.Targets;

namespace NLog.Mvc
{
	/// <summary>
	/// NLog target that uses a DbContext to write log entries to a database
	/// </summary>
	[Target("DbContextTarget")]
	public class DbContextTarget: TargetWithLayout
	{
		/// <summary>
		/// Gets or sets the name of the connection string to use for accessing the database
		/// </summary>
		/// <value>
		/// The name of the connection string.
		/// </value>
		[Required]
		public string ConnectionStringName{ get; set; }

		/// <summary>
		/// Writes logging event to the log target.
		/// classes.
		/// </summary>
		/// <param name="logEvent">Logging event to be written out.</param>
		protected override void Write(LogEventInfo logEvent)
		{
			this.WriteLogMessage(logEvent);
		}

		private void WriteLogMessage(LogEventInfo logEvent)
		{
			var message = this.Layout.Render(logEvent);
			var messageElements = message.Split('|');
			
			if(messageElements.Length != 4 && messageElements.Length != 8)
			{
				ThrowInvalidLayoutException(message);
			}

			using(var context = new LoggingContext(string.Format("name={0}", this.ConnectionStringName)))
			{
				var entry = new LogEntry
				            	{
				            		TimeStamp = DateTime.Parse(messageElements[0]),
				            		Level = messageElements[1],
				            		Logger = messageElements[2], 
				            		Message = messageElements[3]
				            	};

				if(logEvent.Exception != null && messageElements.Length > 4)
				{
					entry.ExceptionType = messageElements[4];
					entry.Operation = messageElements[5];
					entry.ExceptionMessage = messageElements[6];
					entry.StackTrace = messageElements[7];
				}
				context.Log.Add(entry);
				context.SaveChanges();
			}
		}

		private void ThrowInvalidLayoutException(string message)
		{
			throw new InvalidLayoutException();
		}
	}
}
