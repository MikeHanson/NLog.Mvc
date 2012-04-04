using System;
using System.Web.Mvc;
using NLog.Mvc;
using NLog.Mvc4.Web.Models;
using System.Linq;

namespace NLog.Mvc4.Web.Controllers
{
    public class LogController : Controller
    {
    	private readonly ILogger logger;

    	public LogController(ILogger logger)
    	{
    		this.logger = logger;
    	}

    	public ViewResult Index()
        {
			logger.Trace("/Log/Index called");
			using(var context = new LoggingContext("LoggingContext"))
			{
				var model = new LogModel
				            	{
				            		LogEntries = context.Log.OrderByDescending(e => e.TimeStamp).ToList()
				            	};
				return View(model);
			}
        }

		public ViewResult Throw()
		{
			logger.Trace("/Log/Index called");
			throw new Exception("Exception thrown");
		}
    }
}
