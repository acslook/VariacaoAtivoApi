using System.Text.Json;
using VariacaoAtivoApi.Domain.Interfaces.Acl;
using VariacaoAtivoApi.Domain.Models;

namespace VariacaoAtivoApi.Acl
{
    public class FinanceYahooAcl : IFinanceYahooAcl
    {
        private readonly HttpClient _httpClient;

        public FinanceYahooAcl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HistoricoAtivo> ObterHistoricoAtivo(string ativo, long periodoInicial, long periodoFinal)
        {
            var response = await _httpClient.GetAsync($"https://query2.finance.yahoo.com/v8/finance/chart/{ativo}?period1={periodoInicial}&period2={periodoFinal}&interval=1d");

            response.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<HistoricoAtivo>(await response.Content.ReadAsStringAsync());
        }
    }
}
