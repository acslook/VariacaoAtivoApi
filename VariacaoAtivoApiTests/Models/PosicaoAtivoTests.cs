using VariacaoAtivoApi.Domain.Models;

namespace VariacaoAtivoApiTests.Models
{
    public class PosicaoAtivoTests
    {
        private const string ATIVO = "PETR4.SA";
        [Fact]
        public async Task CalcularVariacao_DeveExecutarComSucesso()
        {
            // Arrange
            var posicaoPrimeiroDia = new PosicaoAtivo
            {
                DataPosicao = DateTime.UtcNow.AddDays(-10),
                CodigoAtivo = ATIVO,
                ValorPosicao = 50
            };
            var posicaoDia = new PosicaoAtivo
            {
                DataPosicao = DateTime.UtcNow,
                CodigoAtivo = ATIVO,
                ValorPosicao = 65
            };
            var posicaoDiaAnterior = new PosicaoAtivo
            {
                DataPosicao = DateTime.UtcNow.AddDays(-1),
                CodigoAtivo = ATIVO,
                ValorPosicao = 45
            };

            // Action
            var result = posicaoDia.CalcularVariacao(posicaoDiaAnterior, posicaoPrimeiroDia);

            // Assert
            Assert.NotNull(result);
            Assert.Equal((posicaoDia.ValorPosicao - posicaoDiaAnterior.ValorPosicao) / posicaoDiaAnterior.ValorPosicao, result.VariacaoD_Menos_1.Value);
            Assert.Equal((posicaoDia.ValorPosicao - posicaoPrimeiroDia.ValorPosicao) / posicaoPrimeiroDia.ValorPosicao, result.VariacaoPrimeriaData.Value);
        }
    }
}
