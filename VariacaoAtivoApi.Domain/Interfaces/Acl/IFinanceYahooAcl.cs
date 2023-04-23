using VariacaoAtivoApi.Domain.Models;

namespace VariacaoAtivoApi.Domain.Interfaces.Acl
{
    public interface IFinanceYahooAcl
    {
        Task<HistoricoAtivo> ObterHistoricoAtivo(string ativo, long periodoInicial, long periodoFinal);
    }
}
