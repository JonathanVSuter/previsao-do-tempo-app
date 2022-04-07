using Microsoft.Extensions.Options;
using PrevisaoDoTempoApp.Core.Configuration;
using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDotempo;
using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDoTempo.Dtos;
using PrevisaoDoTempoApp.Http.BuscarPrevisaoDoTempoUmaSemana.ValueObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrevisaoDoTempoApp.Http.BuscarPrevisaoDoTempoUmaSemana
{
    public class BuscarPrevisaoDoTempoUmaSemanaService : IBuscarPrevisaoDoTempoUmaSemanaService
    {
        private readonly IOptions<ApiConfiguration> _options;
        public BuscarPrevisaoDoTempoUmaSemanaService(IOptions<ApiConfiguration> options)
        {
            _options = options;
        }
        public async Task<CidadeDto> BuscarPrevisaoDoTempoUmaSemanaPeloCodigoDaCidade(int codigoCidade)
        {
            HttpResponseMessage httpResponseMessage;
            Cidade cidades;

            using (var client = ApiExtensions.CreateHttpClient(_options.Value.BuscarPrevisaoDoTempoUmaSemanaBase))
            {
                httpResponseMessage = await client.GetAsync($"{codigoCidade}/previsao.xml").ConfigureAwait(true);
            }

            var xml = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(true);
            var serializer = new XmlSerializer(typeof(Cidade));
            using (var reader = new StringReader(xml))
            {
                cidades = (Cidade)serializer.Deserialize(reader);
            }

            return cidades.AsDto();
        }
    }
    public static class BuscarPrevisaoDoTempoUmaSemanaExtensions
    {
        public static CidadeDto AsDto(this Cidade cidade)
        {
            if (cidade is null) throw new ArgumentNullException($"Parâmetro {nameof(cidade)} está nulo");
            if (!cidade.Previsao.Any() || cidade.Previsao is null) throw new ArgumentNullException($"Parâmetro {nameof(cidade.Previsao)} está nulo ou vazio");

            return new CidadeDto()
            {
                Atualizacao = cidade.Atualizacao,
                Nome = cidade.Nome,
                Uf = cidade.Uf,
                Previsao = cidade.Previsao.AsDto()
            };
        }
        public static List<PrevisaoDto> AsDto(this IList<Previsao> previsao)
        {
            var listaPrevisaoDto = new List<PrevisaoDto>();
            if (!previsao.Any() || previsao is null) throw new ArgumentNullException($"Parâmetro {nameof(previsao)} está nulo ou vazio");

            previsao.ToList().ForEach(e =>
            {
                listaPrevisaoDto.Add(new PrevisaoDto()
                {
                    Dia = e.Dia,
                    Iuv = e.Iuv,
                    Maxima = e.Maxima,
                    Minima = e.Minima,
                    Tempo = e.Tempo
                });
            });

            return listaPrevisaoDto;
        }
    }
}
