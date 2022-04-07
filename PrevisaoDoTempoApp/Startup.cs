using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrevisaoDoTempoApp.Application;
using PrevisaoDoTempoApp.Application.CommandHandlers;
using PrevisaoDoTempoApp.Application.QueryHandlers;
using PrevisaoDoTempoApp.Application.RequestHandlers;
using PrevisaoDoTempoApp.Core.Configuration;
using PrevisaoDoTempoApp.HostedServices;
using PrevisaoDoTempoApp.Http;
using PrevisaoDoTempoApp.Infra.Dapper;

namespace PrevisaoDoTempoApp
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
            services.AddRequestHandlers();
            services.AddCommandHandlers();
            services.AddExecutors();
            services.AddHttpClients();
            services.AddControllers();
            services.AddQueryHandlers();
            services.AddRepositories();
            services.AddInfraOperations();
            services.AddHostedService<PrevisaoDoTempoHostedService>();
            services.Configure<ApiConfiguration>(Configuration.GetSection("ConfiguracaoApi"));
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
