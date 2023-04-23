using Microsoft.AspNetCore.Mvc;
using VariacaoAtivoApi.Domain.Dtos.Request;
using VariacaoAtivoApi.Domain.Interfaces.Services;

namespace VariacaoAtivoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceYahooIntegrationController : ControllerBase
    {        
        private readonly ILogger<FinanceYahooIntegrationController> _logger;
        private readonly IFinanceYahooIntegrationService _financeYahooIntegrationService;

        public FinanceYahooIntegrationController(
            ILogger<FinanceYahooIntegrationController> logger, 
            IFinanceYahooIntegrationService financeYahooIntegrationService)
        {
            _logger = logger;
            _financeYahooIntegrationService = financeYahooIntegrationService;
        }

        [HttpPost]
        public async Task<ActionResult> IntegrarHistoricoAtivo([FromBody] IntegracaoAtivoRequestDto model)
        {
            try
            {
                await _financeYahooIntegrationService.IntegrarHistoricoAtivo(model.Ativo);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante processamento.");
                return BadRequest();
            }
        }
    }
}