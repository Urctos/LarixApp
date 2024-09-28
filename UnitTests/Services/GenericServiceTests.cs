using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Application.Dto.DoorsDtos;
using FluentAssertions;

namespace UnitTests.Services
{
    public class GenericServiceTests
    {

        [Fact]
        public async Task add_item_async_should_invoke_add_async_on_item_repository()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Door>>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>>>();

            var genericService = new GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>(
                repositoryMock.Object, mapperMock.Object, loggerMock.Object );

            var doorDto = new CreateDoorDto()
            {
                Name = "Test 1",
                Description = "Opis testowy"

            };

            mapperMock.Setup(x => x.Map<Door>(doorDto)).Returns(new Door()
            { 
                Name = doorDto.Name, 
                Description = doorDto.Description 
            });

            //Act

            await genericService.AddAsync(doorDto);

            //Assert

            repositoryMock.Verify(x => x.AddAsync(It.IsAny<Door>()), Times.Once);
        }

        [Fact]
        public async Task when_invoking_get_item_async_it_should_invoke_get_async_on_item_repository()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<Door>>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>>>();

            var genericService = new GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>(
                repositoryMock.Object, mapperMock.Object, loggerMock.Object);


            var door = new Door(1, "Test name", "test description", 10, 10, 1500,1,1,1,1);
            var doorDto = new DoorDto()
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

            mapperMock.Setup(x => x.Map<Door>(doorDto)).Returns(door);
            repositoryMock.Setup(x =>x.GetByIdAsync(door.Id)).ReturnsAsync(door);


            //Act 

            var existingDoorDto = await genericService.GetByIdAsync(door.Id);

            //Assert

            repositoryMock.Verify(x => x.GetByIdAsync(door.Id), Times.Once());
            doorDto.Should().NotBeNull();
            doorDto.Name.Should().NotBeNull();
            doorDto.Name.Should().BeEquivalentTo(door.Name);
            doorDto.Description.Should().NotBeNull();
            doorDto.Description.Should().BeEquivalentTo(door.Description);
        }

        [Fact]
        public async Task update_item_async_should_invoke_update_async_on_item_repository()
        {
            var  repositoryMock = new Mock<IRepository<Door>>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>>>();

            var genericService = new GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>(
                repositoryMock.Object, mapperMock.Object, loggerMock.Object);

            var updateDoorDto = new UpdateDoorDto()
            {
                Name = "Updated Test 1",
                Description = "Updated Opis testowy"
            };

            var door = new Door(1, "Test name", "test description", 10, 10, 1500, 1, 1, 1, 1);

            mapperMock.Setup(x => x.Map<Door>(updateDoorDto)).Returns(new Door()
            {
                Name = updateDoorDto.Name,
                Description = updateDoorDto.Description,
                Id = door.Id
            });

            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(door);

            //Act
            await genericService.UpdateAsync(updateDoorDto);

            //Assert
            repositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Door>()), Times.Once);
        }

        [Fact]
        public async Task delete_item_async_should_invoke_delete_async_on_item_repository()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Door>>();
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>>>();

            var genericService = new GenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto>(
                repositoryMock.Object, mapperMock.Object, loggerMock.Object);

            var door = new Door(1, "Test name", "test description", 10, 10, 1500, 1, 1, 1, 1);

            repositoryMock.Setup(x => x.GetByIdAsync(door.Id)).ReturnsAsync(door);
            repositoryMock.Setup(x=>x.DeleteAsync(door)).Returns(Task.CompletedTask);

            // Act
            await genericService.DeleteAsync(door.Id);

            // Assert
            repositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Door>()), Times.Once);
        }
    }
}
