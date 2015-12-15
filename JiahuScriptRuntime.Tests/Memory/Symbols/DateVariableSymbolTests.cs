using System;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class DateVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new DateVariableSymbol("now"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            DateVariableSymbol symbol = new DateVariableSymbol("now");

            Assert.AreEqual("now", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            DateVariableSymbol symbol = new DateVariableSymbol("now");

            Assert.AreEqual("date", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            DateVariableSymbol symbol = new DateVariableSymbol("now");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            DateVariableSymbol symbol = new DateVariableSymbol("now");

            Assert.AreEqual(DateTime.MinValue, symbol.Value);
            symbol.Value = new DateTime(2015, 03, 01);
            Assert.AreEqual("01Mar2015", symbol.Value.ToString("ddMMMyyyy"));
        }
    }
}
