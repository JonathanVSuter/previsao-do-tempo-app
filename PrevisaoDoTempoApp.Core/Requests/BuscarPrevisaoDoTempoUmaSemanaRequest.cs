using PrevisaoDoTempoApp.Core.Common.Request;
using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDoTempo.Dtos;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Core.Requests
{
    public class BuscarPrevisaoDoTempoUmaSemanaRequest : IRequest<Task<CidadeDto>>
    {
        public int CodigoCidade { get; set; }

        public BuscarPrevisaoDoTempoUmaSemanaRequest(int codigoCidade)
        {
            CodigoCidade = codigoCidade;
        }
    }
}
