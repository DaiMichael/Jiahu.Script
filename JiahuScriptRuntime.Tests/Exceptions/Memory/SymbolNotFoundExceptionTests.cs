using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.Memory;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Memory
{
    [TestFixture]
    public class SymbolNotFoundExceptionTests
    {
        [Test]
        public void ShouldConstructException()
        {
            Assert.DoesNotThrow(() => new SymbolNotFoundException(ScopeOwner.Main, "i"));
        }

        [Test]
        public void ShouldReturnValidMessage()
        {
            SymbolNotFoundException exception = new SymbolNotFoundException(ScopeOwner.Main, "i");

            Assert.AreEqual("Symbol [i] not found in [main].", exception.Message);
        }
    }
}
