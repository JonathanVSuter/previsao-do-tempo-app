using PrevisaoDoTempoApp.Core.Common.Request;
using PrevisaoDoTempoApp.Core.Requests.BuscarDadosCidade;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade.Dtos;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Application.RequestHandlers.BuscarDadosCidade
{
    public class BuscarDadosCidadeRequestHandler : IRequestHandler<BuscarDadosCidadeRequest, CidadesDto>
    {
        public readonly IBuscarDadosDaCidadeService _buscarDadosDaCidadeService;
        public BuscarDadosCidadeRequestHandler(IBuscarDadosDaCidadeService buscarDadosDaCidadeService)
        {
            _buscarDadosDaCidadeService = buscarDadosDaCidadeService;
        }
        public async Task<CidadesDto> Execute(BuscarDadosCidadeRequest query)
        {
            return await _buscarDadosDaCidadeService.BuscarDadosDaCidadePeloNome(query.Cidade).ConfigureAwait(true);
        }
    }
}
