using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.NUnitTest
{
    [TestFixture]
    public class SentenceUtilsTest
    {
        [Theory]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("a", "A")]
        [TestCase("A", "A")]
        [TestCase("Abc", "Abc")]
        [TestCase("ABc", "Abc")]
        [TestCase("ABC", "Abc")]
        [TestCase("AbC", "Abc")]
        [TestCase("abc def ghi", "Abc Def Ghi")]
        [TestCase("  abc  def ghi ", "  Abc  Def Ghi ")]
        [TestCase("1", "1")]
        public void ToTitleCase_AnyString(string value, string expected)
        {
            Assert.That(SentenceUtils.ToTitleCase(value), Is.EqualTo(expected));
        }

        //[Test]
        //public void Character()
        //{
        //    Assert.That(SentenceUtils.ToTitleCase("a"),
        //                Is.EqualTo("A"),
        //                "Your function should convert a single character.");
        //    Assert.That(SentenceUtils.ToTitleCase("A"),
        //                Is.EqualTo("A"),
        //                "Your function should convert a single character.");
        //}

        //[Test]
        //public void Word()
        //{
        //    Assert.That(SentenceUtils.ToTitleCase("abc"),
        //                Is.EqualTo("Abc"),
        //                "Your function should convert a single word.");
        //    Assert.That(SentenceUtils.ToTitleCase("ABC"),
        //                Is.EqualTo("Abc"),
        //                "Your function should convert a single word.");
        //    Assert.That(SentenceUtils.ToTitleCase("aBC"),
        //                Is.EqualTo("Abc"),
        //                "Your function should convert a single word.");
        //    Assert.That(SentenceUtils.ToTitleCase("Abc"),
        //                Is.EqualTo("Abc"),
        //                "Your function should convert a single word.");
        //}

        //[Test]
        //public void Sentence()
        //{
        //    Assert.That(SentenceUtils.ToTitleCase("abc def ghi"),
        //                Is.EqualTo("Abc Def Ghi"),
        //                "Your function should convert a sentence.");
        //}

        //[Test]
        //public void MultipleWhitespace()
        //{
        //    Assert.That(SentenceUtils.ToTitleCase("  abc  def ghi "),
        //                Is.EqualTo("  Abc  Def Ghi "),
        //                "Your function should keep multiple whitespaces.");
        //}
    }
}
