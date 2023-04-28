using Microsoft.AspNetCore.Mvc;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Dto;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo;
using PrevisaoDoTempoApp.Core.Common.Command;
using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Common.Request;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery.Dtos;
using PrevisaoDoTempoApp.Core.Requests.BuscarDadosCidade;
using PrevisaoDoTempoApp.Core.Services.BuscarDadosDaCidade.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PrevisaoDoTempoController : ControllerBase
    {
        private readonly IRequestExecutor _requestExecutor;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandDispatcher _commandDispatcher;
        public PrevisaoDoTempoController(IRequestExecutor requestExecutor, IQueryExecutor queryExecutor, ICommandDispatcher commandDispatcher)
        {
            _requestExecutor = requestExecutor;
            _queryExecutor = queryExecutor;
            _commandDispatcher = commandDispatcher;
        }        
        
        [HttpGet]
        public async Task<IActionResult> BuscarPrevisaoDoTempoUmaSemana([FromQuery] string codigoCidade)
        {
            var query = new BuscarDadosPrevisaoDoTempoUmaSemanaQuery(codigoCidade);

            var resultado = await _queryExecutor.Execute<BuscarDadosPrevisaoDoTempoUmaSemanaQuery, Task<CidadePrevisaoDto>>(query);

            if (resultado is null)
                return NoContent();

            return Ok(resultado);
        }
    }
}
