using System;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using NLog.Mvc;

namespace NLog.Mvc4.Web
{
	public static class Bootstrapper
	{
		public static void Run()
		{
			ConfigureContainer();

			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		private static void ConfigureContainer()
		{
			var builder = new ContainerBuilder();

			RegisterSingletons(builder);
			RegisterTransientTypes(builder);

			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
		}

		private static void RegisterSingletons(ContainerBuilder builder)
		{
			builder.RegisterType<Mvc.Logger>().As<ILogger>().SingleInstance();
		}

		private static void RegisterTransientTypes(ContainerBuilder builder)
		{

		}

		private static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			var logger = DependencyResolver.Current.GetService<ILogger>();
			filters.Add(new NLogMvcHandleErrorAttribute(logger));
		}

		private static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
				);

		}
	}
}