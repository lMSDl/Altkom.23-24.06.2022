using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.NUnitTest
{
    [TestFixture]
    public class FizzBuzzTest
    {
        //[Test]
        //public void ReturnOne()
        //{
        //    //Assert.That(new FizzBuzz().Compute(1),
        //    //            Is.EqualTo(new List<string> { "1" }));
        //    //Arrage
        //    var fizzBuzz = new FizzBuzz();

        //    //Act
        //    var result = fizzBuzz.Compute(1);

        //    //Assert
        //    var expected = new List<string> { "1" };
        //    Assert.That(result, Is.EqualTo(expected));
        //}

        //[Test]
        //public void ReturnFifteen()
        //{
        //    int n = 15;
        //    List<string> result = new FizzBuzz().Compute(n);
        //    List<string> expected = new List<string> {
        //        "1", "2", "Fizz", "4", "Buzz",
        //        "Fizz", "7", "8", "Fizz", "Buzz",
        //        "11", "Fizz", "13", "14", "FizzBuzz"
        //    };

        //    Assert.That(result.Count,
        //                Is.EqualTo(expected.Count),
        //                string.Format("Your function should return {0} objects for n = {1}", n, n));

        //    for (int i = 0; i < n; i++)
        //    {
        //        Assert.That(result[i],
        //                    Is.EqualTo(expected[i]),
        //                    string.Format("Your function should convert the value {0} to {1} instead of {2}",
        //                                  i + 1, expected[i], result[i]));
        //    }
        //}

        [Theory]
        [TestCase(1, 0, 0)]
        [TestCase(15, 5, 3)]
        [TestCase(100, 33, 20)]
        public void Compute_AnyInt(int count, int fizzCount, int buzzCount)
        {
            //Arrage
            var fizzBuzz = new FizzBuzz();

            //Act
            var result = fizzBuzz.Compute(count);

            //Assert
            Assert.That(result.Count, Is.EqualTo(count));

            var fizzResultCount = result.Count(x => x.Contains("Fizz"));
            Assert.That(fizzResultCount, Is.EqualTo(fizzCount));

            var buzzResultCount = result.Count(x => x.Contains("Buzz"));
            Assert.That(buzzResultCount, Is.EqualTo(buzzCount));

            var items = Enumerable.Range(1, count).Select(x => x.ToString()).ToList();
            var zip = result.Zip(items);
            Assert.IsTrue(zip.Where(x => !x.First.Contains("Fizz"))
                             .Where(x => !x.First.Contains("Buzz"))
                             .All(x => x.First == x.Second));
        }
    }
}
