using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos;
using System;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery
{
    public class BuscarDadosPrevisaoDoTempoUmaSemanaQuery : IQuery<IList<PrevisaoTempoDto>>
    {
        public string Cidade { get; set; }

        public BuscarDadosPrevisaoDoTempoUmaSemanaQuery(string cidade)
        {
            if (string.IsNullOrEmpty(cidade)) throw new ArgumentNullException($"parâmetro {nameof(cidade)} está nulo ou vazio");

            Cidade = cidade;
        }
    }
}
