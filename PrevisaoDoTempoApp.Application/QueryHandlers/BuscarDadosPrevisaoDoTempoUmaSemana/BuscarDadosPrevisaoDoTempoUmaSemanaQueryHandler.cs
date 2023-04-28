using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo;
using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Exceptions.ApiExceptions;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos;
using PrevisaoDoTempoApp.Core.Repositories;
using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDotempo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Application.QueryHandlers.BuscarDadosPrevisaoDoTempoUmaSemana
{
    public class BuscarDadosPrevisaoDoTempoUmaSemanaQueryHandler : IQueryHandler<BuscarDadosPrevisaoDoTempoUmaSemanaQuery, Task<CidadePrevisaoDto>>
    {
        private readonly IDadosClimaTempoRepository _dadosClimaTempoRepository;
        private readonly IBuscarPrevisaoDoTempoUmaSemanaService _previsaoDoTempoService;
        private readonly IDadosCidadeRepository _dadosCidadeRepository;

        public BuscarDadosPrevisaoDoTempoUmaSemanaQueryHandler(IDadosClimaTempoRepository dadosClimaTempoRepository, IBuscarPrevisaoDoTempoUmaSemanaService previsaoDoTempoService, IDadosCidadeRepository dadosCidadeRepository)
        {
            _dadosClimaTempoRepository = dadosClimaTempoRepository;
            _previsaoDoTempoService = previsaoDoTempoService;
            _dadosCidadeRepository = dadosCidadeRepository;
        }

        public async Task<CidadePrevisaoDto> Execute(BuscarDadosPrevisaoDoTempoUmaSemanaQuery query)
        {
            //buscar na base e ver se há previsão atualizada em até 6 horas da previsão do tempo, caso haja, retornar da base, se não houver, buscar no clima tempo, atualizar na base e retornar.            
            var cidade = _dadosCidadeRepository.BuscarCidadePorId(query.CodigoCidade);

            if(cidade is null)
            {
                throw new DadosDaCidadeNaoEncontradosException($"Cidade não encontrada com o código: {query.CodigoCidade}");
            }

            var previsoes = _dadosClimaTempoRepository.BuscarPrevisaoDoTempoUmaSemana(cidade.Id);

            if (previsoes is null || !previsoes.Any())
            {
                //TODO: revisar essa implementação, command pode ser simplificado e as conversões também.
                var buscarPrevisoes = await _previsaoDoTempoService.BuscarPrevisaoDoTempoUmaSemanaPeloCodigoDaCidade(cidade.Id);
                var cidadeComPrevisaoInserida = buscarPrevisoes.AsBusiness();
                _dadosClimaTempoRepository.GuardarDadosClima(cidadeComPrevisaoInserida.Previsao);
                _dadosClimaTempoRepository.VincularCidadeEClimas(cidadeComPrevisaoInserida);
                previsoes = _dadosClimaTempoRepository.BuscarPrevisaoDoTempoUmaSemana(cidade.Id);
                cidade.Previsoes = previsoes;
            }
            cidade.Previsoes = previsoes;
            return cidade;
        }
    }
}
