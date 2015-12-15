using System;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Compilers;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Compilers
{
    [TestFixture]
    public class SymbolCompilerTests
    {
        [Test]
        public void ShouldFindOneFunctionDefinition()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            visitor.Visit(new ScriptAstGenerator().Generate("int GetCount(int number) { return number }"));

            Assert.AreEqual(1, symbolTable.FunctionSymbols.Count);
            Assert.IsTrue(symbolTable.FunctionSymbols.Contains(new FunctionSymbol("GetCount")));
        }

        [Test]
        public void ShouldFindTwoFunctionDefinition()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            visitor.Visit(new ScriptAstGenerator().Generate("int GetCount(int number) { return number } string GetName(string myvalue) { return \"name\" }"));

            Assert.AreEqual(2, symbolTable.FunctionSymbols.Count);
            Assert.IsTrue(symbolTable.FunctionSymbols.Contains(new FunctionSymbol("GetCount")));
            Assert.IsTrue(symbolTable.FunctionSymbols.Contains(new FunctionSymbol("GetName")));
        }

        [Test]
        public void ShouldFindVariableDeclaration()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            visitor.Visit(new ScriptAstGenerator().Generate("int myVar"));

            Assert.IsTrue(symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol("myVar"));
        }

        [Test]
        public void ShouldFindVariableDeclarationInFunction()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            visitor.Visit(new ScriptAstGenerator().Generate("int myVar int GetCount(int i) { int count = i return count }"));

            Assert.IsTrue(symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol("myVar"));
            Assert.IsTrue(symbolTable.GetScope(new ScopeOwner("GetCount", ScopeOwnerType.Function, 10)).HasSymbol("i"));
            Assert.IsTrue(symbolTable.GetScope(new ScopeOwner("GetCount", ScopeOwnerType.Function, 10)).HasSymbol("count"));
        }

        [Test]
        public void ShouldFindThrowErrorWithUndeclaredIdentifier()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            Assert.Throws<VariableNotDefinedException>(() => visitor.Visit(new ScriptAstGenerator().Generate("int myVar int GetCount(int i) { int count = X return count }")));
        }

        [Test]
        public void ShouldFindThrowErrorOnScriptError()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            Assert.Throws<ScriptErrorException>(() => visitor.Visit(new ScriptAstGenerator().Generate("int i = 0 int x = i**")));
        }

        [Test]
        public void ShouldAllowArrayVariableToBeInitialisedWithArrayInitialiser()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            visitor.Visit(new ScriptAstGenerator().Generate("int[] myVar = {1,2}"));

            Assert.IsTrue(symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol("myVar"));
        }

        [Test]
        public void ShouldAllowArrayVariableToBeDeclaredThenWithArrayInitialiser()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            visitor.Visit(new ScriptAstGenerator().Generate("int[] myVar myVar = {1,2}"));

            Assert.IsTrue(symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol("myVar"));
        }

        [Test]
        public void ShouldThrowExceptionIncorrectValuesInArrayInitialiserInLine()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            InvalidCastException exception = Assert.Throws<InvalidCastException>(() => visitor.Visit(new ScriptAstGenerator().Generate("bool[] flags = {true, false, 3.4}")));
            Assert.NotNull(exception);
            Assert.AreEqual("Unable to assign {true,false,3.4} to flags.", exception.Message);
        }

        [Test]
        public void ShouldThrowExceptionIncorrectValuesInArrayInitialiser()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            InvalidCastException exception = Assert.Throws<InvalidCastException>(() => visitor.Visit(new ScriptAstGenerator().Generate("int[] myVar myVar = {1,\"mixed\"}")));
            Assert.NotNull(exception);
            Assert.AreEqual("Unable to assign {1,\"mixed\"} to myVar.", exception.Message);
        }

        [Test]
        public void ShouldThrowExceptionOnVariableNotDeclaredInFunction()
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            Assert.Throws<SymbolNotFoundException>(() => visitor.Visit(new ScriptAstGenerator().Generate("int func(int i, int b) { return c + i}")));
        }

        [Test]
        public void ShouldAddVariableToInnerBlockOfWhile()
        {
            const string script = "int i = 0 string func(int i) { return i } while(i < 10) { i++ int x=90 }";
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            Assert.DoesNotThrow(() => visitor.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.AreEqual("x", symbolTable.GetScope(new ScopeOwner("main", ScopeOwnerType.Main)).GetScope(new ScopeOwner("while", ScopeOwnerType.Block, 42)).GetSymbol("x").Name);
        }

        [Test]
        public void ShouldAddVariableToInnerBlockOfForEach()
        {
            const string script = "int i = 0 string func(int i) { return i } foreach(int n in {1,2}) { i++ int x=90 }";
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            Assert.DoesNotThrow(() => visitor.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.AreEqual("x", symbolTable.GetScope(new ScopeOwner("main", ScopeOwnerType.Main)).GetScope(new ScopeOwner("foreach", ScopeOwnerType.Block, 42)).GetSymbol("x").Name);
        }

        [Test]
        public void ShouldAddVariableToInnerBlockOfIf()
        {
            const string script = "int i = 0 if (i == 0) { int x = i } ";
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            Assert.DoesNotThrow(() => visitor.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.AreEqual("x", symbolTable.GetScope(new ScopeOwner("main", ScopeOwnerType.Main)).GetScope(new ScopeOwner("if", ScopeOwnerType.Block, 10)).GetSymbol("x").Name);
        }

        [Test]
        public void ShouldAddVariableToInnerBlockOfElse()
        {
            const string script = "int i = 0 if (i == 0) { int x = i } else { int v = i }";
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            Assert.DoesNotThrow(() => visitor.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.AreEqual("v", symbolTable.GetScope(new ScopeOwner("main", ScopeOwnerType.Main)).GetScope(new ScopeOwner("else", ScopeOwnerType.Block, 10)).GetSymbol("v").Name);
        }

        [Test]
        public void ShouldAddVariableToTwoWhiles()
        {
            const string script = "bool flag = true while(flag) { decimal i = 0 } while(flag) { int b = 0 }";
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            Assert.DoesNotThrow(() => visitor.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.AreEqual("i", symbolTable.GetScope(new ScopeOwner("main", ScopeOwnerType.Main)).GetScope(new ScopeOwner("while", ScopeOwnerType.Block, 17)).GetSymbol("i").Name);
            Assert.AreEqual("b", symbolTable.GetScope(new ScopeOwner("main", ScopeOwnerType.Main)).GetScope(new ScopeOwner("while", ScopeOwnerType.Block, 47)).GetSymbol("b").Name);
        }

        [Test]
        [TestCase("int", 0)]
        [TestCase("int", "\"string\"", ExpectedException = typeof(InvalidCastException))]
        [TestCase("int", 0.2, ExpectedException = typeof(InvalidCastException))]
        [TestCase("string", "\"hello\"")]
        [TestCase("string", 10)]
        [TestCase("decimal", 1.2)]
        [TestCase("decimal", 10)]
        [TestCase("decimal", "\"Hello\"", ExpectedException = typeof(InvalidCastException))]
        [TestCase("bool", "true")]
        [TestCase("bool", "false")]
        [TestCase("bool", 1, ExpectedException = typeof(InvalidCastException))]
        [TestCase("datetime", "\"01Mar1975\"")]
        [TestCase("date", "\"01Mar1975\"")]
        [TestCase("date", "\"99Mar1975\"", ExpectedException = typeof(InvalidCastException))]
        public void ShouldAssignRawValueToType(string type, object value)
        {
            string script = type + " myVar = " + value;
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            visitor.Visit(new ScriptAstGenerator().Generate(script));

            Assert.IsTrue(symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol("myVar"));
        }

        [Test]
        [TestCase("int i = 1 + 2")]
        [TestCase("int i = 1 & \" is my id\"")]
        [TestCase("string i = 1 & 2")]
        [TestCase("string i = 1 & \" bob\"")]
        [TestCase("string name=\"dave\" string i = \" bob\" & \" \" & name")]
        public void ShouldAllowInLineConcaternationAndMaths(string script)
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            visitor.Visit(new ScriptAstGenerator().Generate(script));
        }

        [Test]
        [TestCase("string get(string i) {return i}")]
        [TestCase("string[] get(string i) {return {\"hello\", \"goodbye\"}}")]
        [TestCase("int get(string i) {return i}", ExpectedException = typeof(InvalidCastException))]
        [TestCase("int[] get(string i) {return {1, \"goodbye\"}}", ExpectedException = typeof(InvalidCastException))]
        [TestCase("string get(string i) {return i & \"hello\" }")]
        [TestCase("string func(int i) { return i } string get(string i) {return func(1) }")]
        [TestCase("int get() {return 1 * 2}")]
        public void ShouldCheckReturnValuesToFunctionReturn(string script)
        {
            IManagedMemory symbolTable = new ManagedMemory();
            SymbolCompiler visitor = new SymbolCompiler(symbolTable, new SymbolFacilitator());

            visitor.Visit(new ScriptAstGenerator().Generate(script));
        }
    }
}
