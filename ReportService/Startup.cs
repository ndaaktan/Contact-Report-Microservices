using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReportService.AsyncReportService;
using ReportService.Context;
using ReportService.Data.Abstract;
using ReportService.Data.Concrete;
using ReportService.Http.Abstract;
using ReportService.Http.Concrete;
using ReportService.Services.Abstract;
using ReportService.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ReportDbContext>(options =>
       options.UseNpgsql(Configuration.GetConnectionString("ReportConnection")));
            services.AddHttpClient();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportServices>();
            services.AddScoped<IMessageProducer, RabbitMqProducer>();
            services.AddHttpClient<IContactClient, ContactClient>();
            services.AddHostedService<ReportBackgroundService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReportService", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ReportDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReportService v1"));
            }
            //context.Database.Migrate();

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
