using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace WebAPI.Test.Unit.Controllers
{
    public class UsersControllerTest
    {

        [Fact]
        public async Task Get_ReturnsOk_WithAllUsers()
        {
            //Arrage
            var fakeService = new Mock<ICrudService<User>>();

            var expectedList = new List<User>();
            fakeService.Setup(x => x.ReadAsync()).ReturnsAsync(() => expectedList).Verifiable();
            var controller = new UsersController(fakeService.Object);

            //Act
            var result = await controller.Get();

            //Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            fakeService.Verify();
            Assert.IsAssignableFrom<IEnumerable<User>>(actionResult.Value);
            //Assert.StrictEqual(expectedList, actionResult.Value);
        }

        [Fact]
        public async Task Get_ReturnsOk_WithSelectedUser()
        {
            //Arrage
            Mock<ICrudService<User>> fakeService = ArrangeFakeServiceWithRead();
            var controller = new UsersController(fakeService.Object);

            //Act
            var result = await controller.Get(1);

            //Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            fakeService.VerifyAll();
            Assert.IsAssignableFrom<User>(actionResult.Value);
        }


        [Fact]
        public async Task Get_ReturnsNotFound_WhenIdNotExists()
        {
            //Arrage
            var fakeService = new Mock<ICrudService<User>>();
            fakeService.Setup(x => x.ReadAsync(It.Is<int>(x => x > 0)));
            var controller = new UsersController(fakeService.Object);

            //Act
            var result = await controller.Get(1);

            //Assert
            Assert.IsType<NotFoundResult>(result);
            fakeService.VerifyAll();
        }


        [Fact]
        public async Task Delete_ReturnsNoContent_WhenIdExists()
        {
            //Arrange
            Mock<ICrudService<User>> fakeService = ArrangeFakeServiceWithRead();
            fakeService.Setup(x => x.DeleteAsync(It.Is<int>(x => x > 0)))
                .Returns(Task.CompletedTask);
            var controller = new UsersController(fakeService.Object);

            //Act
            var result = await controller.Delete(1);

            //Assert
            Assert.IsType<NoContentResult>(result);
            fakeService.VerifyAll();
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenIdNotExists()
        {
            //Arrange
            var fakeService = new Mock<ICrudService<User>>();
            fakeService.Setup(x => x.ReadAsync(It.Is<int>(x => x > 0)));
            var controller = new UsersController(fakeService.Object);

            //Act
            var result = await controller.Delete(1);

            //Assert
            Assert.IsType<NotFoundResult>(result);
            fakeService.VerifyAll();
        }

        private static Mock<ICrudService<User>> ArrangeFakeServiceWithRead()
        {
            var fakeService = new Mock<ICrudService<User>>();
            fakeService.Setup(x => x.ReadAsync(It.Is<int>(x => x > 0)))
                .ReturnsAsync(() => new User());
            return fakeService;
        }
    }
}
