using System;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class DateArrayVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new DateArrayVariableSymbol("now"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            DateArrayVariableSymbol symbol = new DateArrayVariableSymbol("now");

            Assert.AreEqual("now", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            DateArrayVariableSymbol symbol = new DateArrayVariableSymbol("now");

            Assert.AreEqual("date[]", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            DateArrayVariableSymbol symbol = new DateArrayVariableSymbol("now");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            DateArrayVariableSymbol symbol = new DateArrayVariableSymbol("now");

            Assert.AreEqual(0, symbol.Value.Length);
            symbol.Value = new[] { new DateTime(2001, 04, 05), new DateTime(2011, 10, 21) };
            Assert.AreEqual("05Apr2001", symbol.Value[0].ToString("ddMMMyyyy"));
            Assert.AreEqual("21Oct2011", symbol.Value[1].ToString("ddMMMyyyy"));
        }
    }
}
