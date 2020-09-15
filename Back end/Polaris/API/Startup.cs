using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Elastic.Communication;
using Elastic.Communication.Nest;
using Models.Banking;
//using API.Services.Edge;
using API.Services.NodeBusiness;
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
            services.AddSingleton<IEntityHandler<BankAccount, string>, NestEntityHandler<BankAccount, string>>();
            services.AddSingleton<IEntityHandler<Transaction, string>, NestEntityHandler<Transaction, string>>();
            services.AddSingleton<IImporterService<BankAccount>, ElasticImporterService<BankAccount>>();
            services.AddSingleton<IImporterService<Transaction>, ElasticImporterService<Transaction>>();
            services.AddSingleton<INodeService<BankAccount, string>, NodeService<BankAccount, string>>();
            // services.AddSingleton<IEdgeService<string, string, Transaction>, EdgeService<string, string, Transaction>>();
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
