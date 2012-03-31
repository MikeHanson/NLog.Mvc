using System;
using System.Web.Mvc;
using NLog.Mvc;

namespace NLog.Mvc4.Web.Controllers
{
    public class HomeController : Controller
    {
    	private readonly ILogger logger;

    	public HomeController(ILogger logger)
    	{
    		this.logger = logger;
    	}

    	public ActionResult Index()
        {
			this.logger.Trace("Home/Index loaded");
            return this.View();
        }
    }
}
