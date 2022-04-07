using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Models;
using PrevisaoDoTempoApp.Core.Common.Command;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades
{
    public class GuardarDadosCidadesCommand : ICommand
    {
        public IList<Cidade> Cidades { get; set; }
        public GuardarDadosCidadesCommand(IList<Cidade> cidades)
        {
            Cidades = cidades;
        }
    }
}
