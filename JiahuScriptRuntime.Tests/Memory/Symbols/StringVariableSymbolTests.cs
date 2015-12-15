using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class StringVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new StringVariableSymbol("varchar"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            StringVariableSymbol symbol = new StringVariableSymbol("varchar");

            Assert.AreEqual("varchar", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            StringVariableSymbol symbol = new StringVariableSymbol("varchar");

            Assert.AreEqual("string", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            StringVariableSymbol symbol = new StringVariableSymbol("varchar");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            StringVariableSymbol symbol = new StringVariableSymbol("varchar");

            Assert.AreEqual(string.Empty, symbol.Value);
            symbol.Value = "some-value";
            Assert.AreEqual("some-value", symbol.Value);
        }
    }
}
