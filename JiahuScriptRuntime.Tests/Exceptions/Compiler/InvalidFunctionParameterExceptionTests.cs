using JiahuScriptRuntime.Exceptions.Compiler;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Compiler
{
    [TestFixture]
    public class InvalidFunctionParameterExceptionTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new InvalidFunctionParameterException("func", "i"));
        }

        [Test]
        public void ShouldReturnCorrectMessage()
        {
            InvalidFunctionParameterException exception = new InvalidFunctionParameterException("func", "i");

            Assert.IsNotNull(exception);
            Assert.AreEqual("Function func has an invalid parameter i.", exception.Message);
        }
    }
}
