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
    [Route("[controller]/[action]")]
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
        public IActionResult BuscarDadosCidade([FromQuery] string cidadeNome)
        {
            var query = new BuscarDadosCidadeQuery(cidadeNome);

            var result = _queryExecutor.Execute<BuscarDadosCidadeQuery, IEnumerable<CidadesQueryDto>>(query);

            if (result is null || !result.ToList().Any())
                return NotFound(new { result, sucesso = false, mensagem = $"Nenhum registro encontrado com o termo '{cidadeNome}'." });
            return Ok(new { result, sucesso = true });
        }
        [HttpGet]
        public async Task<IActionResult> BuscarEGuardarDadosCidade([FromQuery] string cidade)
        {
            var request = new BuscarDadosCidadeRequest(cidade);

            var resultado = await _requestExecutor.ExecuteRequest<BuscarDadosCidadeRequest, CidadesDto>(request).ConfigureAwait(true);

            if (resultado is null || !resultado.Cidade.Any())
                return NotFound(new { resultado, sucesso = false, mensagem = $"Nenhum registro encontrado com o termo '{cidade}'." });

            var command = new GuardarDadosCidadesCommand(resultado.Cidade.AsBusiness());

            var cidadesGuardadas = _commandDispatcher.Dispatch<GuardarDadosCidadesCommand, IList<CidadeCommandDto>>(command);

            return Ok(new { cidadesGuardadas, sucesso = true });
        }
        [HttpGet]
        public IActionResult BuscarPrevisaoDoTempoUmaSemana([FromQuery] string codigoCidade)
        {
            var query = new BuscarDadosPrevisaoDoTempoUmaSemanaQuery(codigoCidade);

            var resultado = _queryExecutor.Execute<BuscarDadosPrevisaoDoTempoUmaSemanaQuery, IList<PrevisaoTempoDto>>(query);

            if (resultado is null || !resultado.Any())
                return NotFound(new { resultado, sucesso = false, mensagem = $"Nenhum registro encontrado com o termo '{codigoCidade}'." });

            return Ok(new { resultado, sucesso = true });
        }        
    }
}
