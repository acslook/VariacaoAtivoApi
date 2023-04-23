using AutoFixture;
using System.Text.Json;
using VariacaoAtivoApi.Application.Services;
using VariacaoAtivoApi.Domain.Interfaces.Repositories;
using VariacaoAtivoApi.Domain.Models;
using VariacaoAtivoApiTests.Fixtures;

namespace VariacaoAtivoApiTests.Services
{
    public class AtivoFinanceiroServiceTests
    {
        private readonly Mock<IVariacaoAtivoRepository> _variacaoAtivoRepository;
        private readonly Fixture _fixture;

        public AtivoFinanceiroServiceTests()
        {
            _fixture = new Fixture();
            _variacaoAtivoRepository = new Mock<IVariacaoAtivoRepository>();
        }

        [Fact]
        public async Task GravarPosicoesDoHistoricoAsync_DeveExecutarComSucesso()
        {
            // Arrange
            var service = new AtivoFinanceiroService(_variacaoAtivoRepository.Object);
            var historico = JsonSerializer.Deserialize<HistoricoAtivo>(FinanceYahooFixture.ResponseJsonAtivoPETR4_30Dias);

            // Action
            await service.GravarPosicoesDoHistoricoAsync(historico, 30);

            // Assert
            _variacaoAtivoRepository.Verify(d => d.InserirPosicoesAtivosAsync(It.IsAny<List<PosicaoAtivo>>()), Times.Once);
        }

        [Fact]
        public async Task ObterVariacaoUltimos30DiasAsync_DeveExecutarComSucesso()
        {
            // Arrange
            _variacaoAtivoRepository.Setup(r => r.ObterPosicoesAtivoAsync(It.IsAny<string>()))
               .ReturnsAsync(JsonSerializer.Deserialize<List<PosicaoAtivo>>(PosicaoAtivoFixture.FakeListPosicaoAtivo));

            var service = new AtivoFinanceiroService(_variacaoAtivoRepository.Object);

            // Action
            var result = await service.ObterVariacaoUltimos30DiasAsync("PETR4.SA");

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
            _variacaoAtivoRepository.Verify(d => d.ObterPosicoesAtivoAsync(It.IsAny<string>()), Times.Once);
        }
    }
}