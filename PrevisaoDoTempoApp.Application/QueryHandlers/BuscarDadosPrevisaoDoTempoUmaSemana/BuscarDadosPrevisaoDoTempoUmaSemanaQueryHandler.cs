using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos;
using PrevisaoDoTempoApp.Core.Repositories;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Application.QueryHandlers.BuscarDadosPrevisaoDoTempoUmaSemana
{
    public class BuscarDadosPrevisaoDoTempoUmaSemanaQueryHandler : IQueryHandler<BuscarDadosPrevisaoDoTempoUmaSemanaQuery, IList<PrevisaoTempoDto>>
    {
        private readonly IDadosClimaTempoRepository _dadosClimaTempoRepository;
        public BuscarDadosPrevisaoDoTempoUmaSemanaQueryHandler(IDadosClimaTempoRepository dadosClimaTempoRepository)
        {
            _dadosClimaTempoRepository = dadosClimaTempoRepository;
        }
        public IList<PrevisaoTempoDto> Execute(BuscarDadosPrevisaoDoTempoUmaSemanaQuery query)
        {
            return _dadosClimaTempoRepository.BuscarPrevisaoDoTempoUmaSemana(query.Cidade);
        }
    }
}
