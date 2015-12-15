using System;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class StringArrayVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new StringArrayVariableSymbol("stringArray"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            StringArrayVariableSymbol symbol = new StringArrayVariableSymbol("stringArray");

            Assert.AreEqual("stringArray", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            StringArrayVariableSymbol symbol = new StringArrayVariableSymbol("stringArray");

            Assert.AreEqual("string[]", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            StringArrayVariableSymbol symbol = new StringArrayVariableSymbol("stringArray");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            StringArrayVariableSymbol symbol = new StringArrayVariableSymbol("stringArray");

            Assert.AreEqual(0, symbol.Value.Length);
            symbol.Value = new [] { "one", "two" };
            Assert.AreEqual("one", symbol.Value[0]);
            Assert.AreEqual("two", symbol.Value[1]);
        }
    }
}
