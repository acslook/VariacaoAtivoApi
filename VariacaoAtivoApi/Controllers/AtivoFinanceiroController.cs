using Microsoft.AspNetCore.Mvc;
using VariacaoAtivoApi.Domain.Dtos.Request;
using VariacaoAtivoApi.Domain.Interfaces.Services;

namespace VariacaoAtivoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtivoFinanceiroController : ControllerBase
    {        
        private readonly ILogger<AtivoFinanceiroController> _logger;
        private readonly IAtivoFinanceiroService _ativoFinanceiroService;

        public AtivoFinanceiroController(
            ILogger<AtivoFinanceiroController> logger,
            IAtivoFinanceiroService ativoFinanceiroService)
        {
            _logger = logger;
            _ativoFinanceiroService = ativoFinanceiroService;
        }

        [HttpGet]
        [Route("{codigoAtivo}/ObterVariacaoUltimos30Dias")]
        public async Task<ActionResult> Get([FromRoute] string codigoAtivo)
        {
            try
            {
                var variacoesAtivo = await _ativoFinanceiroService.ObterVariacaoUltimos30DiasAsync(codigoAtivo);

                return Ok(variacoesAtivo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante processamento.");
                return BadRequest();
            }
        }
    }
}