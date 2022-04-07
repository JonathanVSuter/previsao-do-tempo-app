using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDoTempo.Dtos;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDotempo
{
    public interface IBuscarPrevisaoDoTempoUmaSemanaService
    {
        Task<CidadeDto> BuscarPrevisaoDoTempoUmaSemanaPeloCodigoDaCidade(int codigoCidade);
    }
}
