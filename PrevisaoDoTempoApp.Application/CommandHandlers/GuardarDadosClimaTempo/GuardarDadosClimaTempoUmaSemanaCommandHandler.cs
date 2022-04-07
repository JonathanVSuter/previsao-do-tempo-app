using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo;
using PrevisaoDoTempoApp.Core.Common.Command;
using PrevisaoDoTempoApp.Core.Repositories;

namespace PrevisaoDoTempoApp.Application.CommandHandlers.GuardarDadosClimaTempo
{
    public class GuardarDadosClimaTempoUmaSemanaCommandHandler : ICommandHandler<GuardarDadosClimaTempoCommand>
    {
        private readonly IDadosClimaTempoRepository _dadosClimaTempoRepository;
        public GuardarDadosClimaTempoUmaSemanaCommandHandler(IDadosClimaTempoRepository dadosClimaTempoRepository)
        {
            _dadosClimaTempoRepository = dadosClimaTempoRepository;
        }
        public void Handle(GuardarDadosClimaTempoCommand command)
        {
            _dadosClimaTempoRepository.GuardarDadosClima(command.CidadePrevisaoDoTempo.Previsao);
            _dadosClimaTempoRepository.VincularCidadeEClimas(command.CidadePrevisaoDoTempo);
        }
    }
}
