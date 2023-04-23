using VariacaoAtivoApi.Domain.Models;

namespace VariacaoAtivoApi.Domain.Interfaces.Repositories
{
    public interface IVariacaoAtivoRepository
    {
        Task InserirPosicoesAtivosAsync(List<PosicaoAtivo> posicoesAtivo);
        Task<List<PosicaoAtivo>> ObterPosicoesAtivoAsync(string codigoAtivo);
    }
}
