using Application.Dto.DoorsDtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests.Services
{
    public class DoorServiceTests
    {
        [Fact]
        public async Task CalculateDoorPriceAsync_ShouldInvokeGetByIdAsyncAndCalculatePriceAsync()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Door>>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<DoorService>>();
            var priceCalculatorMock = new Mock<IPriceCalculator>();


            var door = new Door(1, "Test Door", "Test Description", 100, 200, 1500, 1, 1, 1, 1);
            var doorDto = new DoorDto
            {
                Id = door.Id,
                Name = door.Name,
                Description = door.Description,
                Width = door.Width,
                Height = door.Height,
                Price = door.Price,
                WoodId = door.WoodId,
                ImpregnationTypeId = door.ImpregnationTypeId,
                HingesId = door.HingesId,
                GlassTypeId = door.GlassTypeId
            };

            repositoryMock.Setup(r => r.GetByIdAsync(door.Id)).ReturnsAsync(door);
            mapperMock.Setup(m => m.Map<Door>(It.IsAny<DoorDto>())).Returns(door);
            mapperMock.Setup(m => m.Map<DoorDto>(It.IsAny<Door>())).Returns(doorDto);
            priceCalculatorMock.Setup(pc => pc.CalculatePriceAsync(It.IsAny<Door>())).ReturnsAsync(1500m);

            var doorService = new DoorService(
                 repositoryMock.Object,
                 mapperMock.Object,
                 priceCalculatorMock.Object,
                 loggerMock.Object
            );

            //Act
            var result = await doorService.CalculateDoorPriceAsync(door.Id);

            //Assert
            repositoryMock.Verify(r => r.GetByIdAsync(door.Id), Times.Once);
            priceCalculatorMock.Verify(pc => pc.CalculatePriceAsync(door), Times.Once);
            result.Should().Be(1500m);
        }
    }
}
