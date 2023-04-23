using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VariacaoAtivoApi.Controllers;
using VariacaoAtivoApi.Domain.Dtos.Response;
using VariacaoAtivoApi.Domain.Interfaces.Services;

namespace VariacaoAtivoApiTests.Controllers
{
    public class AtivoFinanceiroControllerTests
    {
        private readonly Mock<ILogger<AtivoFinanceiroController>> _logger;
        private readonly Mock<IAtivoFinanceiroService> _ativoFinanceiroService;

        public AtivoFinanceiroControllerTests()
        {
            _logger = new Mock<ILogger<AtivoFinanceiroController>>();
            _ativoFinanceiroService = new Mock<IAtivoFinanceiroService>();
        }

        [Fact]
        public async Task ObterVariacaoUltimos30Dias_DeveExecutarComSucesso()
        {
            // Arrange
            var fixture = new Fixture();
            _ativoFinanceiroService.Setup(r => r.ObterVariacaoUltimos30DiasAsync(It.IsAny<string>()))
           .ReturnsAsync(fixture.CreateMany<VariacaoAtivoResponseDto>(30).ToList());

            var controller = new AtivoFinanceiroController(_logger.Object, _ativoFinanceiroService.Object);

            // Action
            var actionResult = await controller.Get(It.IsAny<string>());           

            // Assert            
            Assert.NotNull(actionResult);
            _ativoFinanceiroService.Verify(d => d.ObterVariacaoUltimos30DiasAsync(It.IsAny<string>()), Times.Once);

            var viewResult = Assert.IsType<OkObjectResult>(actionResult);

            var model = Assert.IsAssignableFrom<List<VariacaoAtivoResponseDto>>(viewResult.Value);

            Assert.Equal(30, model.Count());
        }

        [Fact]
        public async Task ObterVariacaoUltimos30Dias_DeveRetornarBadRequest()
        {
            // Arrange
            var fixture = new Fixture();
            _ativoFinanceiroService.Setup(r => r.ObterVariacaoUltimos30DiasAsync(It.IsAny<string>()))
           .ThrowsAsync(new Exception());

            var controller = new AtivoFinanceiroController(_logger.Object, _ativoFinanceiroService.Object);

            // Action
            var actionResult = await controller.Get(It.IsAny<string>());

            // Assert            
            Assert.NotNull(actionResult);
            _ativoFinanceiroService.Verify(d => d.ObterVariacaoUltimos30DiasAsync(It.IsAny<string>()), Times.Once);
            Assert.IsType<BadRequestResult>(actionResult);
        }
    }
}
