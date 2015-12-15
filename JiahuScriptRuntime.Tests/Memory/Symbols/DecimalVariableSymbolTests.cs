using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class DecimalVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new DecimalVariableSymbol("money"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            DecimalVariableSymbol symbol = new DecimalVariableSymbol("money");

            Assert.AreEqual("money", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            DecimalVariableSymbol symbol = new DecimalVariableSymbol("money");

            Assert.AreEqual("decimal", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            DecimalVariableSymbol symbol = new DecimalVariableSymbol("money");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            DecimalVariableSymbol symbol = new DecimalVariableSymbol("money");

            Assert.AreEqual(0m, symbol.Value);
            symbol.Value = 3.89m;
            Assert.AreEqual(3.89m, symbol.Value);
        }
    }
}
