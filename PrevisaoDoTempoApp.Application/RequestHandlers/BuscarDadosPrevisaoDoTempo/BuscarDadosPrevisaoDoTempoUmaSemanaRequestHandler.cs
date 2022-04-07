using PrevisaoDoTempoApp.Core.Common.Request;
using PrevisaoDoTempoApp.Core.Requests;
using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDotempo;
using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDoTempo.Dtos;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Application.RequestHandlers.BuscarDadosPrevisaoDoTempo
{
    public class BuscarDadosPrevisaoDoTempoUmaSemanaRequestHandler : IRequestHandler<BuscarPrevisaoDoTempoUmaSemanaRequest, CidadeDto>
    {
        private readonly IBuscarPrevisaoDoTempoUmaSemanaService _buscarPrevisaoDoTempoUmaSemanaService;
        public BuscarDadosPrevisaoDoTempoUmaSemanaRequestHandler(IBuscarPrevisaoDoTempoUmaSemanaService buscarPrevisaoDoTempoUmaSemanaService)
        {
            _buscarPrevisaoDoTempoUmaSemanaService = buscarPrevisaoDoTempoUmaSemanaService;
        }

        public async Task<CidadeDto> Execute(BuscarPrevisaoDoTempoUmaSemanaRequest query)
        {
            var resultado = await _buscarPrevisaoDoTempoUmaSemanaService.BuscarPrevisaoDoTempoUmaSemanaPeloCodigoDaCidade(query.CodigoCidade).ConfigureAwait(true);
            resultado.IdCidade = query.CodigoCidade;
            return resultado;
        }
    }
}
