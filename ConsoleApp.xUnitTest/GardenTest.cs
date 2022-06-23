using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.xUnitTest
{
    public class GardenTest
    {
        [Fact]
        public void Garden_AnySize_HasSetSize()
        {
            // Arrage
            var size = 1;

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

        [Fact]
        //public void Plant_PassValidName_RetursTrue()
        public void Plant_ValidName_True()
        {
            // Arrage
            var garden = new Garden(1);

            // Act
            var result = garden.Plant("A");

            // Assert
            Assert.True(result, "Method should return true");
        }

        [Fact]
        public void Plant_Overflow_False()
        {
            // Arrage
            var garden = new Garden(0);

            // Act
            var result = garden.Plant("A");

            // Assert
            Assert.False(result, "Method should return false");
        }

        [Fact]
        // public void Plant_PassEmptyName_ThrowsArgumentException()
        public void Plant_EmptyName_ArgumentException()
        {
            // Arrange
            var garden = new Garden(0);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => garden.Plant(""));
            Assert.Equal("Name",exception.ParamName, ignoreCase: true);
        }

        [Fact]
        public void Plant_Whitespace_ArgumentException()
        {
            // Arrange
            var garden = new Garden(0);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => garden.Plant(" "));
            Assert.Equal("Name", exception.ParamName, ignoreCase: true);
        }

        [Fact]
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

    }
}
