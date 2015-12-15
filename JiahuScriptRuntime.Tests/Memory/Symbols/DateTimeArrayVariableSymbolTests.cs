using System;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class DateTimeArrayVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new DateTimeArrayVariableSymbol("now"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            DateTimeArrayVariableSymbol symbol = new DateTimeArrayVariableSymbol("now");

            Assert.AreEqual("now", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            DateTimeArrayVariableSymbol symbol = new DateTimeArrayVariableSymbol("now");

            Assert.AreEqual("datetime[]", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            DateTimeArrayVariableSymbol symbol = new DateTimeArrayVariableSymbol("now");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            DateTimeArrayVariableSymbol symbol = new DateTimeArrayVariableSymbol("now");

            Assert.AreEqual(0, symbol.Value.Length);
            symbol.Value = new [] { new DateTime(2001, 04, 05), new DateTime(2011, 10, 21) };
            Assert.AreEqual("05Apr2001", symbol.Value[0].ToString("ddMMMyyyy"));
            Assert.AreEqual("21Oct2011", symbol.Value[1].ToString("ddMMMyyyy"));
        }
    }
}
