using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReceivablesManagement.Api.Controllers;
using ReceivablesManagement.Business.DTOs;
using ReceivablesManagement.Business.Services;
using ReceivablesManagement.Business.Validation;

namespace ReceivablesManagement.Tests
{
    public class ReceivableControllerTests
	{
        private readonly Mock<ILogger<ReceivablesController>> loggerMock;
        private readonly Mock<IReceivablesServices> receivablesServiceMock;
        private readonly Mock<IValidator<ReceivableDTO>> validatorMock;

        public ReceivableControllerTests()
        {
           
            this.receivablesServiceMock = new Mock<IReceivablesServices>();
            this.loggerMock = new Mock<ILogger<ReceivablesController>>();
            this.validatorMock = new Mock<IValidator<ReceivableDTO>>();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedReceivables()
        {
            // Arrange

            var receivablesController = new ReceivablesController(receivablesServiceMock.Object, loggerMock.Object , validatorMock.Object);

            var receivableDTOs = Data.GetDefaultReceivableDTOs();

            receivablesServiceMock.Setup(service => service.GetAllAsync()).ReturnsAsync(receivableDTOs);

            // Act
            var result = await receivablesController.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<ActionResult<List<ReceivableDTO>>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.Equal(200, okObjectResult.StatusCode);
            var receivablesResult = Assert.IsType<List<ReceivableDTO>>(okObjectResult.Value);
            Assert.Equal(receivableDTOs.Count, receivablesResult.Count);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsBadRequestOnException()
        {
            // Arrange
            var errorMessage = "An error message";
            var exception = new Exception(errorMessage);

            receivablesServiceMock.Setup(s => s.GetAllAsync()).ThrowsAsync(exception);

            var controller = new ReceivablesController(receivablesServiceMock.Object, loggerMock.Object, validatorMock.Object);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            var badRequestResult = Assert.IsType<ActionResult<List<ReceivableDTO>>>(result);
            var badReqObj = Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
            Assert.Equal(400, badReqObj.StatusCode);
            Assert.Contains(errorMessage, badReqObj.Value?.ToString());
        }

        [Fact]
        public async Task AddAsync_ShouldReturnReceivableGuid()
        {
            // Arrange
            var receivablesController = new ReceivablesController(receivablesServiceMock.Object, loggerMock.Object, new ReceivableDTOValidator());

            var receivableDTOs = Data.GetSingleReceivableDTO();

            var generatedGuid = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880773");
            
            receivablesServiceMock.Setup(service => service.AddAsync(receivableDTOs)).ReturnsAsync(generatedGuid);
            
            // Act
            var result = await receivablesController.AddAsync(receivableDTOs);

            // Assert
            var okResult = Assert.IsType<ActionResult<Guid>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.Equal(200, okObjectResult.StatusCode);
            var guid = Assert.IsType<Guid>(okObjectResult.Value);
            Assert.Equal(generatedGuid, guid);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnReferenceEmptyError()
        {
            // Arrange
            var receivablesController = new ReceivablesController(receivablesServiceMock.Object, loggerMock.Object, new ReceivableDTOValidator());

            var receivableDTOs = Data.GetSingleReceivableDTO();
            receivableDTOs.Reference = "";

            // Act
            var result = await receivablesController.AddAsync(receivableDTOs);

            // Assert
            var guidResult = Assert.IsType<ActionResult<Guid>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(guidResult.Result);
            Assert.Equal(400, badRequestResult.StatusCode);
            var errors = Assert.IsType<List<ValidationFailure>>(badRequestResult.Value);
            Assert.Contains("Reference is empty", errors.First().ErrorMessage);
        }
    }
}

