using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo.Models
{
    public class CidadePrevisaoDoTempoDb
    {
        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string Atualizacao { get; set; }
        public IList<PrevisaoDb> Previsao { get; set; }
    }
}
