using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class DecimalArrayVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new DecimalArrayVariableSymbol("money"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            DecimalArrayVariableSymbol symbol = new DecimalArrayVariableSymbol("money");

            Assert.AreEqual("money", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            DecimalArrayVariableSymbol symbol = new DecimalArrayVariableSymbol("money");

            Assert.AreEqual("decimal[]", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            DecimalArrayVariableSymbol symbol = new DecimalArrayVariableSymbol("money");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            DecimalArrayVariableSymbol symbol = new DecimalArrayVariableSymbol("money");

            Assert.AreEqual(0, symbol.Value.Length);
            symbol.Value = new [] { 1.23m, 56.9m };
            Assert.AreEqual(1.23m, symbol.Value[0]);
            Assert.AreEqual(56.9m, symbol.Value[1]);
        }
    }
}
