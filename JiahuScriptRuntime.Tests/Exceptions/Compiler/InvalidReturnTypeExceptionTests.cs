using JiahuScriptRuntime.Exceptions.Compiler;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Compiler
{
    [TestFixture]
    public class InvalidReturnTypeExceptionTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new InvalidReturnTypeException("func", "string", "int"));
        }

        [Test]
        public void ShouldReturnCorrectMessage()
        {
            InvalidReturnTypeException exception = new InvalidReturnTypeException("func", "string", "int");

            Assert.IsNotNull(exception);
            Assert.AreEqual("Function func returns a string but is trying to assign to a int.", exception.Message);
        }
    }
}
