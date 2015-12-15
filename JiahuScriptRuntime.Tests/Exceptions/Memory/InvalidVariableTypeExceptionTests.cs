using JiahuScriptRuntime.Exceptions.Memory;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Memory
{
    [TestFixture]
    public class InvalidVariableTypeExceptionTests
    {
        [Test]
        public void ShouldConstructException()
        {
            Assert.DoesNotThrow(() => new InvalidVariableTypeException("i"));
        }

        [Test]
        public void ShouldReturnValidMessage()
        {
            InvalidVariableTypeException exception = new InvalidVariableTypeException("i");

            Assert.AreEqual("Invalid variable i type.", exception.Message);
        }
    }
}
