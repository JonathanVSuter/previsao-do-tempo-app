using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo.Models;
using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDoTempo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo
{
    public static class GuardarDadosClimaTempoUmaSemanaExtensions
    {
        public static CidadePrevisaoDoTempoDb AsBusiness(this CidadeDto cidadeDto)
        {
            var cidadePrevTempo = new CidadePrevisaoDoTempoDb();

            if (cidadeDto is null) throw new ArgumentNullException($"Parâmetro {nameof(cidadeDto)}");

            return new CidadePrevisaoDoTempoDb()
            {
                IdCidade = cidadeDto.IdCidade,
                Atualizacao = cidadeDto.Atualizacao,
                Nome = cidadeDto.Nome,
                Uf = cidadeDto.Uf,
                Previsao = cidadeDto.Previsao.AsBusiness()
            };
        }
        public static IList<PrevisaoDb> AsBusiness(this IList<PrevisaoDto> list)
        {
            var lista = new List<PrevisaoDb>();

            if (list is null || !list.Any()) return lista;

            list.ToList().ForEach(e =>
            {
                lista.Add(new PrevisaoDb()
                {
                    DataConsulta = DateTime.Now.ToString("dd/MM/yyyy"),
                    DataDoClima = e.Dia,
                    TemperaturaMaxima = e.Maxima,
                    TemperaturaMinima = e.Minima,
                    Tempo = e.Tempo,
                    Iuv = e.Iuv
                });
            });

            return lista;
        }
    }
}
