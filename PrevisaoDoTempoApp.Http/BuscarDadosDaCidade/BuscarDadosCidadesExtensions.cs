using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade.Dtos;
using PrevisaoDoTempoApp.Http.BuscarDadosDaCidade.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrevisaoDoTempoApp.Http.BuscarDadosDaCidade
{
    public static class BuscarDadosCidadesExtensions
    {
        public static CidadesDto AsDto(this Cidades cidades)
        {
            if (cidades is null) throw new ArgumentNullException($"Parâmetro {nameof(cidades)} está nulo");
            if (cidades.Cidade is null || !cidades.Cidade.Any()) throw new ArgumentNullException($"Parâmetro {nameof(cidades.Cidade)} dentro de {nameof(cidades)} está nulo ou vazio.");

            return new CidadesDto
            {
                Cidade = cidades.Cidade.AsDto()
            };
        }
        public static List<CidadeDto> AsDto(this List<Cidade> list)
        {
            var lista = new List<CidadeDto>();
            list.ForEach(e =>
            {
                lista.Add(new CidadeDto()
                {
                    Id = e.Id,
                    Nome = e.Nome,
                    Uf = e.Uf
                });
            });
            return lista;
        }
    }
}
