using Microsoft.Extensions.Hosting;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo.Models;
using PrevisaoDoTempoApp.Core.Common.Command;
using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Common.Request;
using PrevisaoDoTempoApp.Core.Queries.ListarTodasAsCidades;
using PrevisaoDoTempoApp.Core.Queries.ListarTodasAsCidades.Dtos;
using PrevisaoDoTempoApp.Core.Requests;
using PrevisaoDoTempoApp.Core.Services.BuscarPrevisaoDoTempo.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.HostedServices
{
    public class PrevisaoDoTempoHostedService : BackgroundService
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IRequestExecutor _requestExecutor;
        private readonly ICommandDispatcher _commandDispatcher;
        public PrevisaoDoTempoHostedService(IQueryExecutor queryExecutor, IRequestExecutor requestExecutor, ICommandDispatcher commandDispatcher)
        {
            _queryExecutor = queryExecutor;
            _requestExecutor = requestExecutor;
            _commandDispatcher = commandDispatcher;
        }
        public async Task AtualizarPrevisaoDoTempo()
        {            
            var query = new ListarTodasAsCidadesQuery();

            var listaCidades = _queryExecutor.Execute<ListarTodasAsCidadesQuery, IList<ListarTodasAsCidadesDto>>(query);

            var listaRequests = new List<Task<CidadeDto>>();

            foreach (var cidade in listaCidades)
            {
                var buscarDadosClimaTempoUmaSemana = new BuscarPrevisaoDoTempoUmaSemanaRequest(cidade.Id);

                listaRequests.Add(_requestExecutor.ExecuteRequest<BuscarPrevisaoDoTempoUmaSemanaRequest, CidadeDto>(buscarDadosClimaTempoUmaSemana));
            }

            var respostasRequests = await Task.WhenAll(listaRequests).ConfigureAwait(true);

            IList<CidadePrevisaoDoTempoDb> cidadesComPrevisaoRetornada = new List<CidadePrevisaoDoTempoDb>();

            foreach (var item in respostasRequests)
            {
                var cidadeComPrevisaoInserida = item.AsBusiness();
                cidadesComPrevisaoRetornada.Add(cidadeComPrevisaoInserida);
                var command = new GuardarDadosClimaTempoCommand(cidadeComPrevisaoInserida);
                _commandDispatcher.Dispatch(command);
            }
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await AtualizarPrevisaoDoTempo().ConfigureAwait(true);
                await Task.Delay(TimeSpan.FromHours(6), stoppingToken);
            }
        }
    }
}
