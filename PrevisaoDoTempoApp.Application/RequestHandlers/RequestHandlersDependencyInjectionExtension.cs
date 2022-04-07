using Microsoft.Extensions.DependencyInjection;
using PrevisaoDoTempoApp.Application.RequestHandlers.BuscarDadosCidade;
using PrevisaoDoTempoApp.Application.RequestHandlers.BuscarDadosPrevisaoDoTempo;
using PrevisaoDoTempoApp.Core.Common.Request;
using PrevisaoDoTempoApp.Core.Requests;
using PrevisaoDoTempoApp.Core.Requests.BuscarDadosCidade;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade.Dtos;
using CidadeDto = PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDoTempo.Dtos.CidadeDto;

namespace PrevisaoDoTempoApp.Application.RequestHandlers
{
    public static class RequestHandlersDependencyInjectionExtension
    {
        public static void AddRequestHandlers(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<BuscarDadosCidadeRequest, CidadesDto>, BuscarDadosCidadeRequestHandler>();
            services.AddTransient<IRequestHandler<BuscarPrevisaoDoTempoUmaSemanaRequest, CidadeDto>, BuscarDadosPrevisaoDoTempoUmaSemanaRequestHandler>();
        }
    }
}
