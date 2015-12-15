using System.Xml;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class ObjectArrayVariableSymbolTests
    {
        [Test]
        public void ShouldConstructSymbol()
        {
            Assert.DoesNotThrow(() => new ObjectArrayVariableSymbol("flag"));
        }

        [Test]
        public void ShouldReturnSymbolName()
        {
            ObjectArrayVariableSymbol symbol = new ObjectArrayVariableSymbol("flag");

            Assert.AreEqual("flag", symbol.Name);
        }

        [Test]
        public void ShouldReturnSymbolType()
        {
            ObjectArrayVariableSymbol symbol = new ObjectArrayVariableSymbol("flag");

            Assert.AreEqual("object[]", symbol.ValueType);
        }

        [Test]
        public void ShouldReturnSymbolValueTypeName()
        {
            ObjectArrayVariableSymbol symbol = new ObjectArrayVariableSymbol("flag");

            Assert.AreEqual(SymbolType.Variable, symbol.Type);
        }

        [Test]
        public void ShouldSetAndReturnValue()
        {
            XmlDocument xmlDocument = new XmlDocument();
            List list = new List();
            ObjectArrayVariableSymbol symbol = new ObjectArrayVariableSymbol("flag");

            Assert.AreEqual(0, symbol.Value.Length);
            symbol.Value = new object[] { list,  xmlDocument };
            Assert.AreEqual(list, symbol.Value[0]);
            Assert.AreEqual(xmlDocument, symbol.Value[1]);
        }

        [Test]
        public void ShouldReturnValueAsString()
        {
            XmlDocument xmlDocument = new XmlDocument();
            List list = new List();
            ObjectArrayVariableSymbol symbol = new ObjectArrayVariableSymbol("flag") { Value = new object[] { xmlDocument, list } };

            Assert.AreEqual("{System.Xml.XmlDocument, NUnit.Framework.List}", symbol.ValueAsString());
        }

        [Test]
        public void ShouldReturnValueAsStringWhenEmpty()
        {
            ObjectArrayVariableSymbol symbol = new ObjectArrayVariableSymbol("flag");

            Assert.AreEqual("{}", symbol.ValueAsString());
        }
    }
}
