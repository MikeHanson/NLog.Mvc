using System;

namespace NLog.Mvc4.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			Bootstrapper.Run();
		}
	}
}