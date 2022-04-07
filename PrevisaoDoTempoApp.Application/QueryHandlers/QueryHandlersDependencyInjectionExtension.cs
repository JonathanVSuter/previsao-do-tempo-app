using Microsoft.Extensions.DependencyInjection;
using PrevisaoDoTempoApp.Application.QueryHandlers.BuscarDadosCidade;
using PrevisaoDoTempoApp.Application.QueryHandlers.BuscarDadosPrevisaoDoTempoUmaSemana;
using PrevisaoDoTempoApp.Application.QueryHandlers.BuscarTodasAsCidades;
using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery.Dtos;
using PrevisaoDoTempoApp.Core.Queries.ListarTodasAsCidades;
using PrevisaoDoTempoApp.Core.Queries.ListarTodasAsCidades.Dtos;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Application.QueryHandlers
{
    public static class QueryHandlersDependencyInjectionExtension
    {
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<BuscarDadosCidadeQuery, IEnumerable<CidadesQueryDto>>, BuscarDadosCidadeQueryHandler>();
            services.AddTransient<IQueryHandler<ListarTodasAsCidadesQuery, IList<ListarTodasAsCidadesDto>>, BuscarTodasAsCidadesQueryHandler>();
            services.AddScoped<IQueryHandler<BuscarDadosPrevisaoDoTempoUmaSemanaQuery, IList<PrevisaoTempoDto>>, BuscarDadosPrevisaoDoTempoUmaSemanaQueryHandler>();
        }
    }
}
