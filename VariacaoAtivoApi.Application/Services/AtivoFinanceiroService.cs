using VariacaoAtivoApi.Domain.Dtos.Response;
using VariacaoAtivoApi.Domain.Interfaces.Repositories;
using VariacaoAtivoApi.Domain.Interfaces.Services;
using VariacaoAtivoApi.Domain.Models;
using VariacaoAtivoApi.Domain.Utils;

namespace VariacaoAtivoApi.Application.Services
{
    public class AtivoFinanceiroService : IAtivoFinanceiroService
    {
        private readonly IVariacaoAtivoRepository _variacaoAtivoRepository;

        public AtivoFinanceiroService(IVariacaoAtivoRepository variacaoAtivoRepository)
        {
            _variacaoAtivoRepository = variacaoAtivoRepository;
        }

        public async Task GravarPosicoesDoHistoricoAsync(HistoricoAtivo historico, int numDias)
        {            
            var totalPosicoes = (historico.chart.result[0].timestamp.Length);
            var posicaoInicial = totalPosicoes > numDias ? (totalPosicoes - numDias) : 0;

            var posicoes = new List<PosicaoAtivo>();
            for (int i = posicaoInicial; i < totalPosicoes; i++)
            {
                var CodigoAtivo = historico.chart.result[0].meta.symbol;
                var dataPosicao = DateTimeUtil.UnixTimeParaDateTime(historico.chart.result[0].timestamp[i]);
                var valorPosicao = historico.chart.result[0].indicators.quote[0].open[i].GetValueOrDefault();

                posicoes.Add(new PosicaoAtivo
                {
                    CodigoAtivo = CodigoAtivo,
                    DataPosicao = dataPosicao,
                    ValorPosicao = valorPosicao
                });
            }

            await _variacaoAtivoRepository.InserirPosicoesAtivosAsync(posicoes);
        }

        public async Task<List<VariacaoAtivoResponseDto>> ObterVariacaoUltimos30DiasAsync(string codigoAtivo)
        {
            var posicoesAtivo = await _variacaoAtivoRepository.ObterPosicoesAtivoAsync(codigoAtivo);
            
            var variacoes = new List<VariacaoAtivo>();
            
            for (int i = 0; i < posicoesAtivo.Count(); i++)
            {
                if (i == 0)
                {
                    variacoes.Add(posicoesAtivo[i].CalcularVariacao(null, null));
                    continue;
                }

                variacoes.Add(posicoesAtivo[i].CalcularVariacao(posicoesAtivo[i - 1], posicoesAtivo[0]));
            }

            return variacoes.Select(s => (VariacaoAtivoResponseDto)s).ToList();
        }             
    }
}
