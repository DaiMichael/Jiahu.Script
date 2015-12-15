using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class BooleanVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new BooleanVariableSymbol("flag"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            BooleanVariableSymbol symbol = new BooleanVariableSymbol("flag");

            Assert.AreEqual("flag", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            BooleanVariableSymbol symbol = new BooleanVariableSymbol("flag");

            Assert.AreEqual("bool", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            BooleanVariableSymbol symbol = new BooleanVariableSymbol("flag");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            BooleanVariableSymbol symbol = new BooleanVariableSymbol("flag");

            Assert.AreEqual(false, symbol.Value);
            symbol.Value = true;
            Assert.AreEqual(true, symbol.Value);
        }
    }
}
