using Microsoft.Extensions.Options;
using PrevisaoDoTempoApp.Core.Configuration;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade.Dtos;
using PrevisaoDoTempoApp.Http.BuscarDadosDaCidade.ValueObject;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrevisaoDoTempoApp.Http.BuscarDadosDaCidade
{
    public class BuscarDadosDaCidadeService : IBuscarDadosDaCidadeService
    {
        private readonly IOptions<ApiConfiguration> _options;
        public BuscarDadosDaCidadeService(IOptions<ApiConfiguration> options)
        {
            _options = options;
        }
        public async Task<CidadesDto> BuscarDadosDaCidadePeloNome(string nomeCidade)
        {
            HttpResponseMessage httpResponseMessage;
            Cidades cidades;

            using (var client = ApiExtensions.CreateHttpClient(_options.Value.BuscarDadosCidadeBase))
            {
                httpResponseMessage = await client.GetAsync($"listaCidades?city={nomeCidade}").ConfigureAwait(true);
            }

            var xml = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(true);
            var serializer = new XmlSerializer(typeof(Cidades));
            using (var reader = new StringReader(xml))
            {
                cidades = (Cidades)serializer.Deserialize(reader);
            }

            return cidades.AsDto();
        }
    }
}
