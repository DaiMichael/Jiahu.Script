using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Memory.Symbols;
using Moq;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class FunctionSymbolTests
    {
        [Test]
        public void ShouldReturnTrueOnEqualsName()
        {
            FunctionSymbol symbol = new FunctionSymbol("func");

            Assert.IsTrue(symbol.Equals(new FunctionSymbol("func")));
        }

        [Test]
        public void ShouldReturnFalseOnNoneEqualsName()
        {
            FunctionSymbol symbol = new FunctionSymbol("func");

            Assert.IsFalse(symbol.Equals(new FunctionSymbol("non-func")));
        }

        [Test]
        public void ShouldConstructWithBodyParseTree()
        {
            Mock<IParseTree> body = new Mock<IParseTree>();
            FunctionSymbol symbol = new FunctionSymbol("func", body.Object, new IntVariableSymbol("i"), 0);

            Assert.IsNotNull(symbol.Body);
        }

        [Test]
        public void ShouldBeAbleToAddParameterToFunction()
        {
            Mock<IParseTree> body = new Mock<IParseTree>();
            FunctionSymbol symbol = new FunctionSymbol("func", body.Object, new IntVariableSymbol("i"), 0);
            symbol.Parameters.Add(new BooleanVariableSymbol("flag"));

            Assert.IsNotNull(symbol.Body);
            Assert.IsNotNull(symbol.Parameters);
            Assert.AreEqual(1, symbol.Parameters.Count);
            Assert.AreEqual("flag", symbol.Parameters[0].Name);
        }

        [Test]
        public void ShouldBeAbleToAddMultipleParametersToFunction()
        {
            Mock<IParseTree> body = new Mock<IParseTree>();
            FunctionSymbol symbol = new FunctionSymbol("func", body.Object, new IntVariableSymbol("i"), 0);
            symbol.Parameters.Add(new BooleanVariableSymbol("flag"));
            symbol.Parameters.Add(new IntVariableSymbol("count"));

            Assert.IsNotNull(symbol.Body);
            Assert.IsNotNull(symbol.Parameters);
            Assert.AreEqual(2, symbol.Parameters.Count);
            Assert.AreEqual("flag", symbol.Parameters[0].Name);
            Assert.AreEqual("count", symbol.Parameters[1].Name);
        }

        [Test]
        public void ShouldHaveCorrectReturnType()
        {
            Mock<IParseTree> body = new Mock<IParseTree>();
            FunctionSymbol symbol = new FunctionSymbol("func", body.Object, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            symbol.Parameters.Add(new BooleanVariableSymbol("flag"));
            symbol.Parameters.Add(new IntVariableSymbol("count"));

            Assert.IsNotNull(symbol.Body);
            Assert.IsNotNull(symbol.Parameters);
            Assert.AreEqual(2, symbol.Parameters.Count);
            Assert.AreEqual("flag", symbol.Parameters[0].Name);
            Assert.AreEqual("count", symbol.Parameters[1].Name);
            Assert.AreEqual(FunctionSymbol.ReturnTypeIdentifier, symbol.ReturnType.Name);
            Assert.AreEqual("int", ((ISymbolValueType)symbol.ReturnType).ValueType);
        }
    }
}
