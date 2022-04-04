using ContactService.Context;
using ContactService.Data.Abstract;
using ContactService.Data.Concrete;
using ContactService.Services.Abstract;
using ContactService.Services.Concrete;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactService
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
            services.AddDbContext<ContactDbContext>(options =>
          options.UseNpgsql(Configuration.GetConnectionString("ContactConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactService", Version = "v1" });
            });
            services.AddHttpClient();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactInformationRepository, ContactInformationRepository>();
            services.AddScoped<IContactService, ContactServices>();
            services.AddScoped<IContactInformationService, ContactInformationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ContactDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "ContactService v1"));
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
