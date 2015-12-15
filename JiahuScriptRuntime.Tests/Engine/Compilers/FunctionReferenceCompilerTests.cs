using System;
using System.Collections.Generic;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Compilers;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.External.Attributes;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using Moq;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Compilers
{
    [TestFixture]
    public class FunctionReferenceCompilerTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Mock<IRepository> functionRepository = new Mock<IRepository>();

            Assert.DoesNotThrow(() => new FunctionReferenceCompiler(new ManagedMemory(true), new SymbolFacilitator(), functionRepository.Object));
        }

        [Test]
        public void ShouldThrowExceptionOnNullArgumentForMemory()
        {
            Assert.Throws<ArgumentNullException>(() => new FunctionReferenceCompiler(null, null));
        }

        [Test]
        public void ShouldThrowExceptionOnNullArgumentForFacilitator()
        {
            Assert.Throws<ArgumentNullException>(() => new FunctionReferenceCompiler(new ManagedMemory(true), null));
        }

        [Test]
        public void ShouldFindFunctions()
        {
            const string functionName = "func";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("i"));
            
            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate("int i = func() int func() { return 0 }")));
        }

        [Test]
        public void ShouldFindFunctionsWithOneParameter()
        {
            const string functionName = "func";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            functionSymbol.Parameters.Add(new IntVariableSymbol("i"));

            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("i"));

            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate("int i = func(1) int func(int i) { return i }")));
        }

        [Test]
        public void ShouldFindFunctionsWithTwoParameter()
        {
            const string functionName = "func";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            functionSymbol.Parameters.Add(new IntVariableSymbol("i"));
            functionSymbol.Parameters.Add(new StringVariableSymbol("x"));

            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("i"));

            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate("int i = func(1, \"hello\") int func(int i, string x) { return i }")));
        }

        [Test]
        public void ShouldThrowExceptionInvalidParameterCountInCall()
        {
            const string functionName = "func";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            functionSymbol.Parameters.Add(new IntVariableSymbol("i"));
            functionSymbol.Parameters.Add(new StringVariableSymbol("x"));

            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("i"));

            Assert.Throws<FunctionParameterCountException>(() => compiler.Visit(new ScriptAstGenerator().Generate("int i = func() int func(int i, string x) { return i}")));
        }

        [Test]
        public void ShouldThrowExceptionInvalidParameterCountInDefinition()
        {
            const string functionName = "func";
            ManagedMemory symbolTable = new ManagedMemory();
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            Scope mainScope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            functionSymbol.Parameters.Add(new IntVariableSymbol("i"));
            functionSymbol.Parameters.Add(new StringVariableSymbol("x"));
            mainScope.Add(new IntVariableSymbol("i"));
            symbolTable.Add(mainScope);
            symbolTable.Add(functionSymbol);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);


            Assert.Throws<FunctionParameterCountException>(() => compiler.Visit(new ScriptAstGenerator().Generate("int i = func(1) int func() { return 0}")));
        }

        [Test]
        public void ShouldThrowExceptionInvalidAssigmnetFromReturnType()
        {
            const string functionName = "func";
            ManagedMemory symbolTable = new ManagedMemory(true);
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new StringVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            
            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("i"));

            Assert.Throws<InvalidReturnTypeException>(() => compiler.Visit(new ScriptAstGenerator().Generate("int i = func() string func() { return 0 }")));
        }

        [Test]
        public void ShouldBeValidFunctionCall()
        {
            const string script = "int i = 123 int b = getId(i) int getId(int i) { return i }";
            const string functionName = "getId";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            
            functionSymbol.Parameters.Add(new IntVariableSymbol("i"));
            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("i"));
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));
            
            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldBeValidFunctionParameterTypesWithInt()
        {
            const string script = "int b = getId(1) int getId(int i) { return i }";
            const string functionName = "getId";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);

            functionSymbol.Parameters.Add(new IntVariableSymbol("i"));
            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldThrowFunctionParameterTypesWithInt()
        {
            const string script = "int b = getId(\"s\") int getId(int i) { return i }";
            const string functionName = "getId";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);

            functionSymbol.Parameters.Add(new IntVariableSymbol("i"));
            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.Throws<InvalidFunctionParameterException>(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldBeValidWithFunctionParameterTypesWithIntArray()
        {
            const string script = "int b = getId({1,2}) int getId(int[] i) { return i[0] }";
            const string functionName = "getId";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);

            functionSymbol.Parameters.Add(new IntArrayVariableSymbol("i"));
            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldThrowWithFunctionParameterTypesWithIntArrayInvalid()
        {
            const string script = "int b = getId({1,\"2\"}) int getId(int[] i) { return i[0] }";
            const string functionName = "getId";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbol = new FunctionSymbol(functionName, null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);

            functionSymbol.Parameters.Add(new IntArrayVariableSymbol("i"));
            symbolTable.Add(functionSymbol);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.Throws<InvalidFunctionParameterException>(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldBeValidFunctionInternalFunctionCallWithInFunctionDefinition()
        {
            const string script = "int b = getId(1) int getId(int i) { return Register(1,2) } int Register(int e, int f) { return e + f }";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbolGetId = new FunctionSymbol("getId", null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            FunctionSymbol functionSymbolAdd = new FunctionSymbol("Register", null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);

            functionSymbolGetId.Parameters.Add(new IntVariableSymbol("i"));
            functionSymbolAdd.Parameters.Add(new IntVariableSymbol("e"));
            functionSymbolAdd.Parameters.Add(new IntVariableSymbol("f"));
            symbolTable.Add(functionSymbolAdd);
            symbolTable.Add(functionSymbolGetId);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldBeValidFunctionCallWithNestedFunctions()
        {
            const string script = "int b = getId(Register(1,2)) int getId(int i) { return i } int Register(int e, int f) { return e + f }";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbolGetId = new FunctionSymbol("getId", null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            FunctionSymbol functionSymbolAdd = new FunctionSymbol("Register", null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);

            functionSymbolGetId.Parameters.Add(new IntVariableSymbol("i"));
            functionSymbolAdd.Parameters.Add(new IntVariableSymbol("e"));
            functionSymbolAdd.Parameters.Add(new IntVariableSymbol("f"));
            symbolTable.Add(functionSymbolAdd);
            symbolTable.Add(functionSymbolGetId);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldThrowInValidFunctionInternalFunctionCallAssignmentWithInFunctionDefinition()
        {
            const string script = "int b = getId(1) int getId(int i) { int c = Register(1,2) } string Register(int e, int f) { return e + f }";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbolGetId = new FunctionSymbol("getId", null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            FunctionSymbol functionSymbolAdd = new FunctionSymbol("Register", null, new StringVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);

            functionSymbolGetId.Parameters.Add(new IntVariableSymbol("i"));
            functionSymbolAdd.Parameters.Add(new IntVariableSymbol("e"));
            functionSymbolAdd.Parameters.Add(new IntVariableSymbol("f"));
            symbolTable.Add(functionSymbolAdd);
            symbolTable.Add(functionSymbolGetId);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.Throws<InvalidReturnTypeException>(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldThrowInValidFunctionInternalFunctionCallWithInFunctionDefinition()
        {
            const string script = "int b = getId(1) int getId(int i) { return Register(1,2) } string Register(int e, int f) { return e + f }";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);
            FunctionSymbol functionSymbolGetId = new FunctionSymbol("getId", null, new IntVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);
            FunctionSymbol functionSymbolAdd = new FunctionSymbol("Register", null, new StringVariableSymbol(FunctionSymbol.ReturnTypeIdentifier), 0);

            functionSymbolGetId.Parameters.Add(new IntVariableSymbol("i"));
            functionSymbolAdd.Parameters.Add(new IntVariableSymbol("e"));
            functionSymbolAdd.Parameters.Add(new IntVariableSymbol("f"));
            symbolTable.Add(functionSymbolAdd);
            symbolTable.Add(functionSymbolGetId);
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.Throws<InvalidReturnTypeException>(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldUseExternalFunctionWithZeroParameters()
        {
            const string script = "int b = exFunc()";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            Mock<IFunction> function = new Mock<IFunction>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);

            functionRepository.Setup(x => x.Has("exFunc")).Returns(true);
            functionRepository.Setup(x => x.Resolve<IFunction>("exFunc")).Returns(function.Object);
            function.Setup(x => x.ReturnType).Returns(new ReturnTypeAttribute(typeof(int)));
            function.Setup(x => x.Parameters).Returns(new List<IParameter>());
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldUseExternalFunctionWithTwoParameters()
        {
            const string script = "int b = exFunc(1, 2)";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            Mock<IFunction> function = new Mock<IFunction>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);

            functionRepository.Setup(x => x.Has("exFunc")).Returns(true);
            functionRepository.Setup(x => x.Resolve<IFunction>("exFunc")).Returns(function.Object);
            function.Setup(x => x.ReturnType).Returns(new ReturnTypeAttribute(typeof(int)));
            function.Setup(x => x.Parameters).Returns(new List<IParameter> { new ParameterAttribute(1, "var1", typeof(int)), new ParameterAttribute(1, "var2", typeof(int)) });
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.DoesNotThrow(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldThrowExceptionUsingExternalFunctionWithIncorrectParameters()
        {
            const string script = "int b = exFunc(\"string\", 2)";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            Mock<IFunction> function = new Mock<IFunction>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);

            functionRepository.Setup(x => x.Has("exFunc")).Returns(true);
            functionRepository.Setup(x => x.Resolve<IFunction>("exFunc")).Returns(function.Object);
            function.Setup(x => x.ReturnType).Returns(new ReturnTypeAttribute(typeof(int)));
            function.Setup(x => x.Parameters).Returns(new List<IParameter> { new ParameterAttribute(1, "var1", typeof(int)), new ParameterAttribute(1, "var2", typeof(int)) });
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new IntVariableSymbol("b"));

            Assert.Throws<InvalidFunctionParameterException>(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }

        [Test]
        public void ShouldThrowExceptionUsingExternalFunctionWithIncorrectReturnType()
        {
            const string script = "bool b = exFunc(12, 2)";
            Mock<IRepository> functionRepository = new Mock<IRepository>();
            Mock<IFunction> function = new Mock<IFunction>();
            ManagedMemory symbolTable = new ManagedMemory(true);
            FunctionReferenceCompiler compiler = new FunctionReferenceCompiler(symbolTable, new SymbolFacilitator(), functionRepository.Object);

            functionRepository.Setup(x => x.Has("exFunc")).Returns(true);
            functionRepository.Setup(x => x.Resolve<IFunction>("exFunc")).Returns(function.Object);
            function.Setup(x => x.ReturnType).Returns(new ReturnTypeAttribute(typeof(int)));
            function.Setup(x => x.Parameters).Returns(new List<IParameter> { new ParameterAttribute(1, "var1", typeof(int)), new ParameterAttribute(1, "var2", typeof(int)) });
            symbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Add(new BooleanVariableSymbol("b"));

            Assert.Throws<InvalidReturnTypeException>(() => compiler.Visit(new ScriptAstGenerator().Generate(script)));
        }
    }
}