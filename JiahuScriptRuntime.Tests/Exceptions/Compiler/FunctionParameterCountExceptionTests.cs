using JiahuScriptRuntime.Exceptions.Compiler;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Compiler
{
    [TestFixture]
    public class FunctionParameterCountExceptionTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new FunctionParameterCountException("func"));
        }

        [Test]
        public void ShouldReturnCorrectMessage()
        {
            FunctionParameterCountException exception = new FunctionParameterCountException("func");

            Assert.IsNotNull(exception);
            Assert.AreEqual("Invalid parameter count for function func.", exception.Message);
        }
    }
}
