using JiahuScriptRuntime.Exceptions.Compiler;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Compiler
{
    [TestFixture]
    public class InvalidTypeExceptionTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new InvalidTypeException("Message"));
        }

        [Test]
        public void ShouldReturnCorrectMessage()
        {
            InvalidTypeException exception = new InvalidTypeException("bob");

            Assert.IsNotNull(exception);
            Assert.AreEqual("Unable to match type bob.", exception.Message);
        }
    }
}
