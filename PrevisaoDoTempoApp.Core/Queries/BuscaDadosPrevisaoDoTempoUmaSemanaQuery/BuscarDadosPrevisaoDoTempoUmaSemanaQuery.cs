using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery
{
    public class BuscarDadosPrevisaoDoTempoUmaSemanaQuery : IQuery<Task<CidadePrevisaoDto>>
    {
        public string CodigoCidade { get; set; }

        public BuscarDadosPrevisaoDoTempoUmaSemanaQuery(string codigoCidade)
        {
            if (string.IsNullOrEmpty(codigoCidade)) throw new ArgumentNullException($"parâmetro {nameof(codigoCidade)} está nulo ou vazio");

            CodigoCidade = codigoCidade;
        }
    }
}
