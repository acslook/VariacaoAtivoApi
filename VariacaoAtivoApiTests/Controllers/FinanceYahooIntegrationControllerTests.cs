using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VariacaoAtivoApi.Application.Services;
using VariacaoAtivoApi.Controllers;
using VariacaoAtivoApi.Domain.Dtos.Request;
using VariacaoAtivoApi.Domain.Interfaces.Services;

namespace VariacaoAtivoApiTests.Controllers
{
    public class FinanceYahooIntegrationControllerTests
    {
        private readonly Mock<ILogger<FinanceYahooIntegrationController>> _logger;
        private readonly Mock<IFinanceYahooIntegrationService> _financeYahooIntegrationService;

        public FinanceYahooIntegrationControllerTests()
        {
            _logger = new Mock<ILogger<FinanceYahooIntegrationController>>();
            _financeYahooIntegrationService = new Mock<IFinanceYahooIntegrationService>();
        }

        [Fact]
        public async Task IntegrarHistoricoAtivo_DeveExecutarComSucesso()
        {
            // Arrange
            var controller = new FinanceYahooIntegrationController(_logger.Object, _financeYahooIntegrationService.Object);

            // Action
            var actionResult = await controller.IntegrarHistoricoAtivo(new Fixture().Create<IntegracaoAtivoRequestDto>());

            // Assert            
            Assert.NotNull(actionResult);
            _financeYahooIntegrationService.Verify(d => d.IntegrarHistoricoAtivo(It.IsAny<string>()), Times.Once);
            var viewResult = Assert.IsType<OkResult>(actionResult);
        }

        [Fact]
        public async Task IntegrarHistoricoAtivo_DeveRetornarBadRequest()
        {
            // Arrange
            var fixture = new Fixture();
            _financeYahooIntegrationService.Setup(r => r.IntegrarHistoricoAtivo(It.IsAny<string>()))
            .ThrowsAsync(new Exception());

            var controller = new FinanceYahooIntegrationController(_logger.Object, _financeYahooIntegrationService.Object);

            // Action
            var actionResult = await controller.IntegrarHistoricoAtivo(new Fixture().Create<IntegracaoAtivoRequestDto>());

            // Assert            
            Assert.NotNull(actionResult);
            _financeYahooIntegrationService.Verify(d => d.IntegrarHistoricoAtivo(It.IsAny<string>()), Times.Once);
            var viewResult = Assert.IsType<BadRequestResult>(actionResult);
        }
    }
}
