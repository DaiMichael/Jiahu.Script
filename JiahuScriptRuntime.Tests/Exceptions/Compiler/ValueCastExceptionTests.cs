using JiahuScriptRuntime.Exceptions.Compiler;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Compiler
{
    [TestFixture]
    public class ValueCastExceptionTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new ValueCastException("int", "0"));
        }

        [Test]
        public void ShouldReturnCorrectMessage()
        {
            ValueCastException exception = new ValueCastException("int", "NAN");

            Assert.IsNotNull(exception);
            Assert.AreEqual("Unable to cast value NAN to type int.", exception.Message);
        }
    }
}
