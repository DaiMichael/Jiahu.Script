using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class IntVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new IntVariableSymbol("whole"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            IntVariableSymbol symbol = new IntVariableSymbol("whole");

            Assert.AreEqual("whole", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            IntVariableSymbol symbol = new IntVariableSymbol("whole");

            Assert.AreEqual("int", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            IntVariableSymbol symbol = new IntVariableSymbol("whole");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            IntVariableSymbol symbol = new IntVariableSymbol("whole");

            Assert.AreEqual(0, symbol.Value);
            symbol.Value = 569;
            Assert.AreEqual(569, symbol.Value);
        }
    }
}
