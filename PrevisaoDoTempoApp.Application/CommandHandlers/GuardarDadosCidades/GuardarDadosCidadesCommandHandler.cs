using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Dto;
using PrevisaoDoTempoApp.Core.Common.Command;
using PrevisaoDoTempoApp.Core.Repositories;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Application.CommandHandlers.GuardarDadosCidades
{
    public class GuardarDadosCidadesCommandHandler : ICommandHandlerWithResult<GuardarDadosCidadesCommand, IList<CidadeCommandDto>>
    {
        private readonly IDadosCidadeRepository _dadosCidadeRepository;
        public GuardarDadosCidadesCommandHandler(IDadosCidadeRepository dadosCidadeRepository)
        {
            _dadosCidadeRepository = dadosCidadeRepository;
        }
        public IList<CidadeCommandDto> Handle(GuardarDadosCidadesCommand command)
        {
            return _dadosCidadeRepository.InserirERetornarCidades(command.Cidades);
        }
    }
}
