using CK.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CK.StObj;
using CK.Auth;

namespace TorrentService
{
	public class Startup
	{
		readonly IActivityMonitor _startupMonitor;
		readonly IWebHostEnvironment _hostingEnvironment;

		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			_startupMonitor = new ActivityMonitor($"App {env.ApplicationName}/{env.EnvironmentName} on {Environment.MachineName}/{Environment.UserName}.");
			Configuration = configuration;
			_hostingEnvironment = env;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOptions();

			string connectionString = Configuration["ConnectionString"];
			services.AddCKDatabase(_startupMonitor, typeof(GeneratedRootContext).Assembly, connectionString)
				.AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
				.AddSingleton<IAuthenticationTypeSystem, StdAuthenticationTypeSystem>()
				.AddAuthentication()
				.AddWebFrontAuth();
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseCors(c =>
				c.WithOrigins("http://localhost:8080")
				.AllowCredentials()
				.AllowAnyMethod()
				.AllowAnyHeader()
			  );
			app.UseAuthentication();

			app.UseRouting();
			app.UseExceptionHandler("/Home/Error");

			app.UseStaticFiles();
			app.UseFileServer();
			app.UseMvc();
		}
	}
}
