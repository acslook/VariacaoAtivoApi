using VariacaoAtivoApi.Domain.Interfaces.Acl;
using VariacaoAtivoApi.Domain.Interfaces.Services;
using VariacaoAtivoApi.Domain.Utils;

namespace VariacaoAtivoApi.Application.Services
{
    public class FinanceYahooIntegrationService : IFinanceYahooIntegrationService
    {        
        private readonly IFinanceYahooAcl _financeYahooAcl;
        private readonly IAtivoFinanceiroService _variacaoAtivoService;

        public FinanceYahooIntegrationService(            
            IFinanceYahooAcl financeYahooAcl,
            IAtivoFinanceiroService variacaoAtivoService)
        {
            _financeYahooAcl = financeYahooAcl;
            _variacaoAtivoService = variacaoAtivoService;
        }

        public async Task IntegrarHistoricoAtivo(string ativo)
        {
            var periodoFinal = DateTimeUtil.DateTimeParaUnixTime(DateTime.UtcNow);
            var periodoInicial = DateTimeUtil.DateTimeParaUnixTime(DateTime.UtcNow.AddDays(-60));

            var historicoAtivo = await _financeYahooAcl.ObterHistoricoAtivo(ativo, periodoInicial, periodoFinal);

            if (historicoAtivo == null)
                throw new Exception($"Não encontrado histórico para o ativo {ativo}");

            await _variacaoAtivoService.GravarPosicoesDoHistoricoAsync(historicoAtivo, 30);                  
        }
    }
}
