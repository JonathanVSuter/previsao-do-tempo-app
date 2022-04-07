using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo.Models;
using PrevisaoDoTempoApp.Core.Common.Command;

namespace PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo
{
    public class GuardarDadosClimaTempoCommand : ICommand
    {
        public CidadePrevisaoDoTempoDb CidadePrevisaoDoTempo { get; set; }
        public GuardarDadosClimaTempoCommand(CidadePrevisaoDoTempoDb cidadePrevisaoDoTempo)
        {
            CidadePrevisaoDoTempo = cidadePrevisaoDoTempo;
        }
    }
}
