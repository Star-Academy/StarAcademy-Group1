using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Elastic.Communication;
using Elastic.Communication.Nest;
using Models.Banking;
using API.Services.Edge;
using API.Services.Node;
using API.Services.Graph;
using API.Services.Importer;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            NestClientFactory.GetInstance().CreateInitialClient(Configuration["ElasticAddress"]);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<,>(); // TODO
            services.AddControllers();
            services.AddCors();
            services.AddSingleton<IEntityHandler<string>, NestEntityHandler<string>>();
            services.AddSingleton<IImporterService<BankAccount>, ElasticImporterService<BankAccount>>();
            services.AddSingleton<IImporterService<Transaction>, ElasticImporterService<Transaction>>();
            services.AddSingleton<INodeService<string>, NodeService<string>>();
            services.AddSingleton<IEdgeService<string, string>, EdgeService<string, string>>();
            // services.AddSingleton<IGraphService, GraphService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>  // can be checked
                        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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
