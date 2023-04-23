using VariacaoAtivoApi.Domain.Dtos.Response;
using VariacaoAtivoApi.Domain.Models;

namespace VariacaoAtivoApi.Domain.Interfaces.Services
{
    public interface IAtivoFinanceiroService
    {
        Task GravarPosicoesDoHistoricoAsync(HistoricoAtivo historico, int numDias);
        Task<List<VariacaoAtivoResponseDto>> ObterVariacaoUltimos30DiasAsync(string codigoAtivo);
    }
}
