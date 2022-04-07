using Microsoft.Extensions.DependencyInjection;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade;
using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDotempo;
using PrevisaoDoTempoApp.Http.BuscarDadosDaCidade;
using PrevisaoDoTempoApp.Http.BuscarPrevisaoDoTempoUmaSemana;

namespace PrevisaoDoTempoApp.Http
{
    public static class PrevisaoDoTempoServicesDependencyInjection
    {
        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddScoped<IBuscarDadosDaCidadeService, BuscarDadosDaCidadeService>();
            services.AddTransient<IBuscarPrevisaoDoTempoUmaSemanaService, BuscarPrevisaoDoTempoUmaSemanaService>();
        }
    }
}
