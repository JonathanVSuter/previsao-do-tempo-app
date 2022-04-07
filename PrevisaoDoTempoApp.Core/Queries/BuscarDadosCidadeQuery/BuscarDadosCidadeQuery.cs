using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery.Dtos;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery
{
    public class BuscarDadosCidadeQuery : IQuery<IEnumerable<CidadesQueryDto>>
    {
        public string Nome { get; set; }
        public BuscarDadosCidadeQuery(string nome)
        {
            Nome = nome;
        }
    }
}
