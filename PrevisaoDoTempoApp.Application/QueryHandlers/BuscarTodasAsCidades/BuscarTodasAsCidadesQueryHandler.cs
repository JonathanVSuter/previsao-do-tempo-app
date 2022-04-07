using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Queries.ListarTodasAsCidades;
using PrevisaoDoTempoApp.Core.Queries.ListarTodasAsCidades.Dtos;
using PrevisaoDoTempoApp.Core.Repositories;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Application.QueryHandlers.BuscarTodasAsCidades
{
    public class BuscarTodasAsCidadesQueryHandler : IQueryHandler<ListarTodasAsCidadesQuery, IList<ListarTodasAsCidadesDto>>
    {
        public readonly IDadosCidadeRepository _dadosCidadeRepository;
        public BuscarTodasAsCidadesQueryHandler(IDadosCidadeRepository dadosCidadeRepository)
        {
            _dadosCidadeRepository = dadosCidadeRepository;
        }

        public IList<ListarTodasAsCidadesDto> Execute(ListarTodasAsCidadesQuery query)
        {
            return _dadosCidadeRepository.ListarTodasAsCidades();
        }
    }
}
