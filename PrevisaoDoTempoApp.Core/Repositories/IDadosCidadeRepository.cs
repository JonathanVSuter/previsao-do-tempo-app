using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Dto;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Models;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery.Dtos;
using PrevisaoDoTempoApp.Core.Queries.ListarTodasAsCidades.Dtos;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Core.Repositories
{
    public interface IDadosCidadeRepository
    {
        IEnumerable<CidadesQueryDto> BuscarCidadesPorNome(string cidade);
        IList<CidadeCommandDto> InserirERetornarCidades(IList<Cidade> cidades);
        IList<ListarTodasAsCidadesDto> ListarTodasAsCidades();
    }
}
