using System;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class DateTimeVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new DateTimeVariableSymbol("now"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            DateTimeVariableSymbol symbol = new DateTimeVariableSymbol("now");

            Assert.AreEqual("now", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            DateTimeVariableSymbol symbol = new DateTimeVariableSymbol("now");

            Assert.AreEqual("datetime", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            DateTimeVariableSymbol symbol = new DateTimeVariableSymbol("now");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            DateTimeVariableSymbol symbol = new DateTimeVariableSymbol("now");

            Assert.AreEqual(DateTime.MinValue, symbol.Value);
            symbol.Value = new DateTime(2015, 03, 01);
            Assert.AreEqual("01Mar2015", symbol.Value.ToString("ddMMMyyyy"));
        }
    }
}
