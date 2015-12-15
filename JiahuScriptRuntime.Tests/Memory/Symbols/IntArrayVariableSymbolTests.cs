using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class IntArrayVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new IntArrayVariableSymbol("whole"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            IntArrayVariableSymbol symbol = new IntArrayVariableSymbol("whole");

            Assert.AreEqual("whole", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            IntArrayVariableSymbol symbol = new IntArrayVariableSymbol("whole");

            Assert.AreEqual("int[]", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            IntArrayVariableSymbol symbol = new IntArrayVariableSymbol("whole");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            IntArrayVariableSymbol symbol = new IntArrayVariableSymbol("whole");

            Assert.AreEqual(0, symbol.Value.Length);
            symbol.Value = new[] { 45, 2 };
            Assert.AreEqual(45, symbol.Value[0]);
            Assert.AreEqual(2, symbol.Value[1]);
        }
    }
}
