using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo.Models;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos;
using System.Collections.Generic;

namespace PrevisaoDoTempoApp.Core.Repositories
{
    public interface IDadosClimaTempoRepository
    {
        IList<PrevisaoTempoDto> BuscarPrevisaoDoTempoUmaSemana(int codigoCidade);
        void GuardarDadosClima(IList<PrevisaoDb> cidadePrevisaoDoTempo);
        void VincularCidadeEClimas(CidadePrevisaoDoTempoDb cidadePrevisaoDoTempo);
    }
}
