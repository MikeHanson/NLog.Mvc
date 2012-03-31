using System;

namespace NLog.Mvc
{
	public class LogEntry
	{
		public int Id{ get; set; }
		public DateTime TimeStamp{ get; set; }
		public string Level{ get; set; }
		public string Logger{ get; set; }
		public string Server{ get; set; }
		public string Message{ get; set; }
	}
}
