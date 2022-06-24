using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.xUnitTest
{
    public class GardenTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void Garden_AnySize_HasSetSize(int size)
        {
            // Act
            var garden = new Garden(size);

            // Assert
            Assert.Equal(size, garden.Size);
        }

        [Fact]
        public void Garden_AnySize_ListNotNull()
        {
            // Arrage & Act
            var garden = new Garden(0);

            // Assert
            var list = garden.GetPlants();
            Assert.NotNull(list);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        public void Plant_ValidName_ResultIndicatingAddition(int gardenSize, bool expectedResult)
        {
            // Arrage
            var garden = new Garden(gardenSize);

            // Act
            var result = garden.Plant("A");

            // Assert
            Assert.Equal(expectedResult, result);
        }

        //[Fact]
        ////public void Plant_PassValidName_RetursTrue()
        //public void Plant_ValidName_True()
        //{
        //    // Arrage
        //    var garden = new Garden(1);

        //    // Act
        //    var result = garden.Plant("A");

        //    // Assert
        //    Assert.True(result, "Method should return true");
        //}

        //[Fact]
        //public void Plant_Overflow_False()
        //{
        //    // Arrage
        //    var garden = new Garden(0);

        //    // Act
        //    var result = garden.Plant("A");

        //    // Assert
        //    Assert.False(result, "Method should return false");
        //}

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Plant_InvalidName_ArgumentException(string name)
        {
            // Arrange
            var garden = new Garden(0);

            // Act & Assert
            var exception = Assert.ThrowsAny<ArgumentException>(() => garden.Plant(name));
            Assert.Equal("Name", exception.ParamName, ignoreCase: true);
        }

        [Theory(Skip = "replaced by Plant_InvalidName_ArgumentException")]
        [InlineData("")]
        [InlineData(" ")]
        public void Plant_InvalidName_ArgumentException2(string name)
        {
            // Arrange
            var garden = new Garden(0);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => garden.Plant(name));
            Assert.Equal("Name", exception.ParamName, ignoreCase: true);
        }

        [Fact(Skip = "replaced by Plant_InvalidName_ArgumentException")]
        public void Plant_Null_ArgumentNullException()
        {
            // Arrange
            var garden = new Garden(0);

            //Act
            var exception = Record.Exception(() => garden.Plant(null));

            // Assert
            var argumentNullException = Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("Name", argumentNullException.ParamName, ignoreCase: true);
        }

        [Fact]
        public void Plant_ExistingName_ArgumentException()
        {
            // Arrange
            var garden = new Garden(1);
            garden.Plant("A");

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => garden.Plant("A"));
            Assert.Equal("Name", exception.ParamName, ignoreCase: true);
        }

        [Fact]
        public void Plant_ValidName_AddedToList()
        {
            // Arrage
            var garden = new Garden(1);
            var value = "A";

            // Act
            garden.Plant(value);

            // Assert
            var result = garden.GetPlants();
            Assert.Contains(value, result);
        }

        [Fact]
        public void GetPlants_CopyOfPlantsList()
        {
            // Arrage
            var garden = new Garden(1);

            // Act
            var baseList = garden.GetPlants();
            baseList.Add("A");
            var resultList = garden.GetPlants();

            // Assert
            Assert.NotEqual(baseList, resultList);
        }


        [Fact]
        public void Plant_ValidName_ActionLogged()
        {
            // Arrage
            var logger = new Mock<ILogger>();
            logger.Setup(x => x.Log(It.IsAny<string>())).Verifiable();

            var garden = new Garden(1, logger.Object);

            //Act
            garden.Plant("A");

            //Assert
            //logger.Verify(x => x.Log("Zasadzono w ogrodzie A"), Times.Once);
            logger.Verify();
        }


    }
}
