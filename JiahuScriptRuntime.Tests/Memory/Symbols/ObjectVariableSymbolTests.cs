using System.Xml;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class ObjectVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new ObjectVariableSymbol("flag"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            ObjectVariableSymbol symbol = new ObjectVariableSymbol("flag");

            Assert.AreEqual("flag", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            ObjectVariableSymbol symbol = new ObjectVariableSymbol("flag");

            Assert.AreEqual("object", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            ObjectVariableSymbol symbol = new ObjectVariableSymbol("flag");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            XmlDocument xmlDocument = new XmlDocument();
            ObjectVariableSymbol symbol = new ObjectVariableSymbol("flag");

            Assert.AreEqual(null, symbol.Value);
            symbol.Value = xmlDocument;
            Assert.AreEqual(xmlDocument, symbol.Value);
        }
    }
}
