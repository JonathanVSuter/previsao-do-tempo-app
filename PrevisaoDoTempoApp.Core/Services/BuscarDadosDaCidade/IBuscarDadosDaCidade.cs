using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade.Dtos;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade
{
    public interface IBuscarDadosDaCidadeService
    {
        public Task<CidadesDto> BuscarDadosDaCidadePeloNome(string nomeCidade);
    }
}
