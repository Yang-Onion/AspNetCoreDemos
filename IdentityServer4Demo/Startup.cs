using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4Demo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            //InMemoryConfiguration.Configuration = this.Configuration;

            services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            //.AddSigningCredential(new X509Certificate2(Path.Combine(basePath,Configuration["Certificates:CerPath"]),Configuration["Certificates:Password"]))
            .AddTestUsers(InMemoryConfiguration.GetUsers().ToList())
            .AddInMemoryClients(InMemoryConfiguration.GetClients())
            .AddInMemoryApiResources(InMemoryConfiguration.GetApiResources());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();
            
        }
    }
}
