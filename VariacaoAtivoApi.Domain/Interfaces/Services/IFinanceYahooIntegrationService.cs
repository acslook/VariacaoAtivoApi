namespace VariacaoAtivoApi.Domain.Interfaces.Services
{
    public interface IFinanceYahooIntegrationService
    {
        Task IntegrarHistoricoAtivo(string ativo);
    }
}
