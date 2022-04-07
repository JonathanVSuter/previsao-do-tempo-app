using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery.Dtos;
using PrevisaoDoTempoApp.Core.Repositories;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Application.QueryHandlers.BuscarDadosCidade
{
    public class BuscarDadosCidadeQueryHandler : IQueryHandler<BuscarDadosCidadeQuery, IEnumerable<CidadesQueryDto>>
    {
        public readonly IDadosCidadeRepository _dadosCidadeRepository;

        public BuscarDadosCidadeQueryHandler(IDadosCidadeRepository dadosCidadeRepository)
        {
            _dadosCidadeRepository = dadosCidadeRepository;
        }

        public IEnumerable<CidadesQueryDto> Execute(BuscarDadosCidadeQuery query)
        {
            return _dadosCidadeRepository.BuscarCidadesPorNome(query.Nome);
        }
    }
}
