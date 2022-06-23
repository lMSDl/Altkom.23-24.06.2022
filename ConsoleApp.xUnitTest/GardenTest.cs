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

        }
        [Fact]
        public void Garden_AnySize_ListNotNull()
        {

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

        }
        [Fact]
        public void Plant_Whitespace_ArgumentException()
        {

        }
        [Fact]
        public void Plant_Null_ArgumentNullException()
        {

        }
        [Fact]
        public void Plant_ExistingName_ArgumentException()
        {

        }
        [Fact]
        public void Plant_ValidName_AddedToList()
        {
        }

        [Fact]
        public void GetPlants_CopyOfPlantsList()
        {

        }

    }
    }
