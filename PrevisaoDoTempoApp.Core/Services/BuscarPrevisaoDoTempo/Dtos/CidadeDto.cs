using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDoTempo.Dtos
{
    public class CidadeDto
    {
        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string Atualizacao { get; set; }
        public IList<PrevisaoDto> Previsao { get; set; }
    }
}
