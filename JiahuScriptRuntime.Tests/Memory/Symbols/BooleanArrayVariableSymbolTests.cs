using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class BooleanArrayVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new BooleanArrayVariableSymbol("flag"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            BooleanArrayVariableSymbol symbol = new BooleanArrayVariableSymbol("flag");

            Assert.AreEqual("flag", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            BooleanArrayVariableSymbol symbol = new BooleanArrayVariableSymbol("flag");

            Assert.AreEqual("bool[]", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            BooleanArrayVariableSymbol symbol = new BooleanArrayVariableSymbol("flag");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            BooleanArrayVariableSymbol symbol = new BooleanArrayVariableSymbol("flag");

            Assert.AreEqual(0, symbol.Value.Length);
            symbol.Value = new [] { false,  true };
            Assert.AreEqual(false, symbol.Value[0]);
            Assert.AreEqual(true, symbol.Value[1]);
        }

        [Test]
        public void ShouldReturnValueAsString()
        {
            BooleanArrayVariableSymbol symbol = new BooleanArrayVariableSymbol("flag") {Value = new[] {true, false}};

            Assert.AreEqual("{True, False}", symbol.ValueAsString());
        }

        [Test]
        public void ShouldReturnValueAsStringWhenEmpty()
        {
            BooleanArrayVariableSymbol symbol = new BooleanArrayVariableSymbol("flag");

            Assert.AreEqual("{}", symbol.ValueAsString());
        }
    }
}
