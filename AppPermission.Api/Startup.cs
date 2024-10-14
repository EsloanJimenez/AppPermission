using AppPermission.Domain.Interface;
using AppPermission.Infrastructure.Context;
using AppPermission.Infrastructure.Repository;
using AppPermission.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPermission.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppPermissionContext>(op =>
            {
                op.UseSqlServer(Configuration.GetConnectionString("AppDePermisos"));
            });

            #region "TRANSIENT"
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();
            #endregion

            #region "SCOPED"
            services.AddScoped<PermissionService>();
            services.AddScoped<PermissionTypeService>();
            services.AddScoped<TransitionService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
