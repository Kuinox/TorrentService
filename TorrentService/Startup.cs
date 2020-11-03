using CK.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CK.StObj;
using CK.Auth;
using CK.AspNet.Auth;
using System.Collections.Generic;

namespace TorrentService
{
    public class Startup
    {
        readonly IActivityMonitor _startupMonitor;
        readonly IWebHostEnvironment _hostingEnvironment;

        public IConfiguration Configuration { get; }
        public Startup( IConfiguration configuration, IWebHostEnvironment env )
        {
            _startupMonitor = new ActivityMonitor( $"App {env.ApplicationName}/{env.EnvironmentName} on {Environment.MachineName}/{Environment.UserName}." );
            Configuration = configuration;
            _hostingEnvironment = env;
        }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddOptions();

            string connectionString = Configuration["ConnectionString"];
            services.AddCKDatabase( _startupMonitor, typeof( GeneratedRootContext ).Assembly, connectionString )
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddSingleton<IAuthenticationTypeSystem, StdAuthenticationTypeSystem>();
            services.AddControllers();
            services.AddAuthentication( WebFrontAuthOptions.OnlyAuthenticationScheme )
                 .AddWebFrontAuth( options =>
                 {
                     options.ExpireTimeSpan = TimeSpan.FromHours( 1 );
                     options.SlidingExpirationTime = TimeSpan.FromHours( 1 );
                     options.SchemesCriticalTimeSpan = new Dictionary<string, TimeSpan>();
                     options.SchemesCriticalTimeSpan.Add( "Basic", new TimeSpan( 0, 5, 0 ) );
                 } );
            services.AddCors();
            services.AddMvc( s => s.EnableEndpointRouting = false );
            services.AddAuthorization();
        }

        public void Configure( IApplicationBuilder app )
        {
            app.UseCors( c =>
                 c.WithOrigins( "http://localhost:8080" )
                 .AllowCredentials()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
              );

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseFileServer();
            app.UseMvc();
        }
    }
}
