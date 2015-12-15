using JiahuScriptRuntime.Exceptions.Compiler;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Compiler
{
    [TestFixture]
    public class VariableUndefinedExceptionTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new VariableNotDefinedException("myvar"));
        }

        [Test]
        public void ShouldReturnCorrectMessage()
        {
            VariableNotDefinedException exception = new VariableNotDefinedException("myvar");

            Assert.IsNotNull(exception);
            Assert.AreEqual("Variable myvar is undefined.", exception.Message);
        }
    }
}
