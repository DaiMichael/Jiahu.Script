using JiahuScriptRuntime.Exceptions.External;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.External
{
    [TestFixture]
    public class ExternalFunctionExceptionTests
    {
        [Test]
        public void ShouldCreateException()
        {
            Assert.DoesNotThrow(() => new ExternalFunctionException("Message"));
        }

        [Test]
        public void ShouldHaveMessage()
        {
            ExternalFunctionException exception = new ExternalFunctionException("Function {0} error.", new object[]{"func"});

            Assert.AreEqual("Function func error.", exception.Message);
        }
    }
}
