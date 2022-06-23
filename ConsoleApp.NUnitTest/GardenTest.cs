using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.NUnitTest
{

    [TestFixture]
    public class GardenTest
    {
        //[SetUp]
        //public void Setup()
        //{
        //    Garden = new Garden(0);
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    Garden = null;
        //}
        //private Garden Garden { get; set; }

        [Theory]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void Garden_AnySize_HasSetSize(int size)
        {
            // Act
            var garden = new Garden(size);

            // Assert
            Assert.That(garden.Size, Is.EqualTo(size));
        }

        [Test]
        public void Garden_AnySize_ListNotNull()
        {
            // Arrage & Act
            var garden = new Garden(0);

            // Assert
            var list = garden.GetPlants();
            Assert.NotNull(list);
        }

        [Theory]
        [TestCase(0, false)]
        [TestCase(1, true)]
        public void Plant_ValidName_ResultIndicatingAddition(int gardenSize, bool expectedResult)
        {
            // Arrage
            var garden = new Garden(gardenSize);

            // Act
            var result = garden.Plant("A");

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private static List<string> TestValues = new List<string>() { "", " " };

        [Theory]
        [TestCaseSource(nameof(TestValues))]
        public void Plant_InvalidName_ArgumentException(string name)
        {
            // Arrange
            var garden = new Garden(0);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => garden.Plant(name));
            Assert.That(exception.ParamName, Is.EqualTo("name"));
        }

        [Test]
        //[Ignore("replaced by Plant_InvalidName_ArgumentException")]
        public void Plant_Null_ArgumentNullException()
        {
            // Arrange
            var garden = new Garden(0);

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => garden.Plant(null));
            Assert.That(exception.ParamName, Is.EqualTo("name"));
        }

        [Test]
        public void Plant_ExistingName_ArgumentException()
        {
            // Arrange
            var garden = new Garden(1);
            garden.Plant("A");

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => garden.Plant("A"));
            Assert.That(exception.ParamName, Is.EqualTo("name"));
        }

        [Test]
        public void Plant_ValidName_AddedToList()
        {
            // Arrage
            var garden = new Garden(1);
            var value = "A";

            // Act
            garden.Plant(value);

            // Assert
            var result = garden.GetPlants();
            Assert.That(result, Does.Contain(value));
        }

        [Test]
        public void GetPlants_CopyOfPlantsList()
        {
            // Arrage
            var garden = new Garden(1);

            // Act
            var baseList = garden.GetPlants();
            baseList.Add("A");
            var resultList = garden.GetPlants();

            // Assert
            Assert.That(baseList, Is.Not.EqualTo(resultList));
        }

    }
}
