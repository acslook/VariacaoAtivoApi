using Moq;
using System.Text.Json;
using VariacaoAtivoApi.Application.Services;
using VariacaoAtivoApi.Domain.Interfaces.Acl;
using VariacaoAtivoApi.Domain.Interfaces.Services;
using VariacaoAtivoApi.Domain.Models;
using VariacaoAtivoApiTests.Fixtures;

namespace VariacaoAtivoApiTests.Services
{
    public class FinanceYahooIntegrationServiceTests
    {
        private readonly Mock<IFinanceYahooAcl> _financeYahooAcl;
        private readonly Mock<IAtivoFinanceiroService> _variacaoAtivoService;

        public FinanceYahooIntegrationServiceTests()
        {
            _financeYahooAcl = new Mock<IFinanceYahooAcl>();
            _variacaoAtivoService = new Mock<IAtivoFinanceiroService>();
        }

        [Fact]
        public async Task IntegrarHistoricoAtivo_DeveExecutarComSucesso()
        {
            // Arrange
            _financeYahooAcl.Setup(r => r.ObterHistoricoAtivo(It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>()))
               .ReturnsAsync(JsonSerializer.Deserialize<HistoricoAtivo>(FinanceYahooFixture.ResponseJsonAtivoPETR4_30Dias));

            var service = new FinanceYahooIntegrationService(_financeYahooAcl.Object, _variacaoAtivoService.Object);
            var historico = JsonSerializer.Deserialize<HistoricoAtivo>(FinanceYahooFixture.ResponseJsonAtivoPETR4_30Dias);

            // Action
            await service.IntegrarHistoricoAtivo("PETR4.SA");

            // Assert
            _financeYahooAcl.Verify(d => d.ObterHistoricoAtivo(It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>()), Times.Once);
            _variacaoAtivoService.Verify(d => d.GravarPosicoesDoHistoricoAsync(It.IsAny<HistoricoAtivo>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task IntegrarHistoricoAtivo_DeveLancarExcecao()
        {
            // Arrange
            _financeYahooAcl.Setup(r => r.ObterHistoricoAtivo(It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>()))
               .ReturnsAsync((HistoricoAtivo)null);

            var service = new FinanceYahooIntegrationService(_financeYahooAcl.Object, _variacaoAtivoService.Object);
            var historico = JsonSerializer.Deserialize<HistoricoAtivo>(FinanceYahooFixture.ResponseJsonAtivoPETR4_30Dias);

            // Action
            var ex = await Assert.ThrowsAsync<Exception>(() => service.IntegrarHistoricoAtivo("PETR4.SA"));

            // Assert
            _financeYahooAcl.Verify(d => d.ObterHistoricoAtivo(It.IsAny<string>(), It.IsAny<long>(), It.IsAny<long>()), Times.Once);
            Assert.Equal("Não encontrado histórico para o ativo PETR4.SA", ex.Message);
        }
    }
}
