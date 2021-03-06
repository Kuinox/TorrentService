using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace TorrentService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateWebHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseMonitoring("Monitoring")
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder
                        .UseKestrel()
                        .UseScopedHttpContext()
						.UseStartup<Startup>();
				})
				.ConfigureAppConfiguration((context, configuration) =>
				{
					configuration
					   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					   .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: false);
				});
	}
}
