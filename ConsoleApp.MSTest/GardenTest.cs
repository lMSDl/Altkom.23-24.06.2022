using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.MSTest
{
    [TestClass]
    public class GardenTest
    {
        //[TestInitialize]
        //public void Setup()
        //{
        //    Garden = new Garden(0);
        //}

        //[TestCleanup]
        //public void TearDown()
        //{
        //    Garden = null;
        //}
        //private Garden Garden { get; set; }


        [TestMethod]
        public void Garden_AnySize_ListNotNull()
        {
            // Arrage & Act
            var garden = new Garden(0);

            // Assert
            var list = garden.GetPlants();
            Assert.IsNotNull(list);
        }



        [TestMethod]
        //[Ignore("replaced by Plant_InvalidName_ArgumentException")]
        public void Plant_Null_ArgumentNullException()
        {
            // Arrange
            var garden = new Garden(0);

            // Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => garden.Plant(null));
            Assert.AreEqual("name", exception.ParamName);
        }

        [TestMethod]
        public void Plant_ExistingName_ArgumentException()
        {
            // Arrange
            var garden = new Garden(1);
            garden.Plant("A");

            // Act & Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => garden.Plant("A"));
            Assert.AreEqual("name", exception.ParamName);
        }

        [TestMethod]
        public void Plant_ValidName_AddedToList()
        {
            // Arrage
            var garden = new Garden(1);
            var value = "A";

            // Act
            garden.Plant(value);

            // Assert
            var result = garden.GetPlants();
            Assert.IsTrue(result.Contains(value));
        }

        [TestMethod]
        public void GetPlants_CopyOfPlantsList()
        {
            // Arrage
            var garden = new Garden(1);

            // Act
            var baseList = garden.GetPlants();
            baseList.Add("A");
            var resultList = garden.GetPlants();

            // Assert
            Assert.AreNotSame(baseList, resultList);
        }

    }
}
