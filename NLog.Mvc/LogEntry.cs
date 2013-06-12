using System;

namespace NLog.Mvc
{
	public class LogEntry
	{
		public int Id{ get; set; }
		public DateTime TimeStamp{ get; set; }
		public string Level{ get; set; }
		public string Logger{ get; set; }
		public string Message{ get; set; }
		public string ExceptionType{ get; set; }
		public string Operation{ get; set; }
		public string ExceptionMessage{ get; set; }
		public string StackTrace{ get; set; }
	}
}
