using Xunit;
using Microsoft.AspNetCore.Mvc;
using CheckList.Application.Services;
using CheckList.Infrastructure.MySql;
using CheckList.Controllers;

namespace Teste
{
    public class UnitTest1
    {
        private readonly TarefaService _tarefaService;

        public UnitTest1(TarefaService tarefaService) {
            _tarefaService = tarefaService;
        }

        [Fact]
        public void Index_DeveRetornarView()
        {

            // Arrange
            var controller = new TarefaController(_tarefaService);

            // Act
            var result = controller.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}