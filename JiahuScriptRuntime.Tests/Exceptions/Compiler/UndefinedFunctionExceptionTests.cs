using JiahuScriptRuntime.Exceptions.Compiler;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Compiler
{
    [TestFixture]
    public class UndefinedFunctionExceptionTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new UndefinedFunctionException("func"));
        }

        [Test]
        public void ShouldReturnCorrectMessage()
        {
            UndefinedFunctionException exception = new UndefinedFunctionException("func");

            Assert.IsNotNull(exception);
            Assert.AreEqual("Function func is called but not defined.", exception.Message);
        }
    }
}
