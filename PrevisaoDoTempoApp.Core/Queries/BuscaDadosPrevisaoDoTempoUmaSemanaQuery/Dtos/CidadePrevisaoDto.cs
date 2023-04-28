using System;
using System.Collections.Generic;
using System.Text;

namespace PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos
{
    public class CidadePrevisaoDto
    {
        public string Nome { get; set; }
        public string Uf { get; set; }
        public int Id { get; set; }
        public IList<PrevisaoTempoDto> Previsoes { get; set; }
    }
}
