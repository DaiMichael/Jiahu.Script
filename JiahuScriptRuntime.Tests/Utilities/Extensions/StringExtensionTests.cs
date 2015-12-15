using JiahuScriptRuntime.Utilities.Extensions;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Utilities.Extensions
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void ShouldRemoveDoubleQuoteFromString()
        {
            Assert.AreEqual("hello", "\"hello\"".RemoveQuotes());
        }

        [Test]
        public void ShouldRemoveSingleQuoteFromString()
        {
            Assert.AreEqual("hello", "'hello'".RemoveQuotes());
        }

        [Test]
        public void ShouldRemoveDoubleAndSingleQuoteFromString()
        {
            Assert.AreEqual("'both'", "\"'both'\"".RemoveQuotes());
        }

        [Test]
        public void ShouldRemoveDoubleAndSingleQuoteFromOneEndString()
        {
            Assert.AreEqual("'both", "\"'both".RemoveQuotes());
        }

        [Test]
        public void ShouldDoNothing()
        {
            Assert.AreEqual("nothing", "nothing".RemoveQuotes());
        }

        [Test]
        public void ShouldKeepSingleQuote()
        {
            Assert.AreEqual("won't", "won't".RemoveQuotes());
        }

        [Test]
        [TestCase("'Dave'", ExpectedResult = true)]
        [TestCase("\"Bob\"", ExpectedResult = true)]
        [TestCase("\"Jim'", ExpectedResult = true)]
        [TestCase("'Jim\"", ExpectedResult = true)]
        [TestCase("Jim\"", ExpectedResult = true)]
        [TestCase("'Jim", ExpectedResult = true)]
        [TestCase("\"", ExpectedResult = true)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("NoQuotes", ExpectedResult = false)]
        public bool ShouldTestHasQuotes(string value)
        {
            return value.HasQuotes();
        }

    }
}
