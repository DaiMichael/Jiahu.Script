using JiahuScriptRuntime.Exceptions.Memory;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Memory
{
    [TestFixture]
    public class ScopeNotFoundExceptionTests
    {
        [Test]
        public void ShouldConstructException()
        {
            Assert.DoesNotThrow(() => new ScopeNotFoundException("while"));
        }

        [Test]
        public void ShouldReturnValidMessage()
        {
            ScopeNotFoundException exception = new ScopeNotFoundException("while");

            Assert.AreEqual("Scope [while] not found.", exception.Message);
        }
    }
}
