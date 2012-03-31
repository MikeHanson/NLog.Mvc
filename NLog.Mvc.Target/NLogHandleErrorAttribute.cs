using System;
using System.Web.Mvc;

namespace NLog.Mvc
{
	/// <summary>
	/// Logs errors using NLog.Mvc logger
	/// </summary>
	public class NLogHandleErrorAttribute: HandleErrorAttribute
	{
		private readonly ILogger logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="NLogHandleErrorAttribute"/> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		public NLogHandleErrorAttribute(ILogger logger)
		{
			this.logger = logger;
		}

		/// <summary>
		/// Called when an exception occurs.
		/// </summary>
		/// <param name="filterContext">The action-filter context.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="filterContext"/> parameter is null.</exception>
		public override void OnException(ExceptionContext filterContext)
		{
			base.OnException(filterContext);
			logger.Error("Unexpected error captured by filter", filterContext.Exception);
		}
	}
}
