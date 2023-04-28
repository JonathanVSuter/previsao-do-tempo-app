using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Dto;
using PrevisaoDoTempoApp.Core.Common.Command;
using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Common.Request;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery.Dtos;
using PrevisaoDoTempoApp.Core.Requests.BuscarDadosCidade;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly IRequestExecutor _requestExecutor;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryExecutor _queryExecutor;

        public CidadesController(IRequestExecutor requestExecutor, ICommandDispatcher commandDispatcher, IQueryExecutor queryExecutor)
        {
            _requestExecutor = requestExecutor;
            _commandDispatcher = commandDispatcher;
            _queryExecutor = queryExecutor;
        }
        
        [HttpGet]
        public async Task<IActionResult> BuscarCidades([FromQuery] string cidade)
        {
            var query = new BuscarDadosCidadeQuery(cidade);
            var cidadesNaBase = _queryExecutor.Execute<BuscarDadosCidadeQuery, IEnumerable<CidadesQueryDto>>(query);

            if(cidadesNaBase is null || !cidadesNaBase.Any())
            {
                var request = new BuscarDadosCidadeRequest(cidade);
                var resultado = await _requestExecutor.ExecuteRequest<BuscarDadosCidadeRequest, CidadesDto>(request).ConfigureAwait(true);

                var command = new GuardarDadosCidadesCommand(resultado.Cidade.AsBusiness());
                var cidadesGuardadas = _commandDispatcher.Dispatch<GuardarDadosCidadesCommand, IList<CidadeCommandDto>>(command);

                if (resultado is null || !resultado.Cidade.Any())
                    return NoContent();

                return Ok(new { cidades = cidadesGuardadas});
            }

            return Ok(new { cidades = cidadesNaBase });
        }        
    }
}
