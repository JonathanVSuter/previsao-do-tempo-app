using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Models;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades
{
    public static class GuardarDadosCidadesExtensions
    {
        public static List<Cidade> AsBusiness(this IList<CidadeDto> cidadeDtos)
        {
            var lista = new List<Cidade>();

            if (cidadeDtos is null || !cidadeDtos.Any()) throw new ArgumentNullException($"Parâmetro {nameof(cidadeDtos)} está nulo ou vazio");

            cidadeDtos.ToList().ForEach(e =>
            {
                lista.Add(new Cidade(e.Nome, e.Uf, e.Id));
            });

            return lista;
        }
    }
}
