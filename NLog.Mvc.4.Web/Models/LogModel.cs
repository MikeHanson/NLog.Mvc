using System;
using System.Collections.Generic;
using NLog.Mvc;

namespace NLog.Mvc4.Web.Models
{
	public class LogModel
	{
		public IEnumerable<LogEntry> LogEntries { get; set; }
	}
}