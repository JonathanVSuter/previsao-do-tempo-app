using PrevisaoDoTempoApp.Core.Common.Request;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade.Dtos;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Core.Requests.BuscarDadosCidade
{
    public class BuscarDadosCidadeRequest : IRequest<Task<CidadesDto>>
    {
        public string Cidade { get; set; }
        public BuscarDadosCidadeRequest(string cidade)
        {
            Cidade = cidade;
        }
    }
}
