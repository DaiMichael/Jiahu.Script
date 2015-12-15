using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Memory
{
    [TestFixture]
    public class DuplicateSymbolInScopeExceptionTests
    {
        [Test]
        public void ShouldConstructException()
        {
            Assert.DoesNotThrow(() => new DuplicateSymbolException(ScopeOwner.Main, new IntVariableSymbol("count")));
        }

        [Test]
        public void ShouldReturnValidMessage()
        {
            DuplicateSymbolException exception = new DuplicateSymbolException(ScopeOwner.Main, new IntVariableSymbol("count"));

            Assert.AreEqual("Duplicate symbol of type [int] and name [count] in scope [main].", exception.Message);
        }
    }
}
