using Core3RestAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core3RestAPI.Profiles;
using System.Reflection;

namespace Core3RestAPI
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

            // Injeção de dependência           
            services.AddScoped<ICommanderRepo, CommandRepository>();

            // AutoMapper       
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddAutoMapper(Assembly.GetAssembly(typeof(CommandsProfile))); // Se estiver em outro projeto

            // Aqui pode ser adicionado tambem o DbContext
            /* Exemplo:
             * services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("DefaultConnection")));
             */
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
