using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Flx.Training.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateHostBuilder(string[] args) =>
			   WebHost.CreateDefaultBuilder(args)
			.UseKestrel(options => { options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10); })
				.UseStartup<Startup>()
			.UseIISIntegration();
		 
	}
}
