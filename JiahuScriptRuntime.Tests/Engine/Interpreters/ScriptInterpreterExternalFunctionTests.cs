using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Compilers;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.External.Attributes;
using JiahuScriptRuntime.External.RepositoryRegisters;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptExternalInterpreterFunctionTests
    {
        [Test]
        [TestCase("string result = Basic(1)", ExpectedResult = "1")]
        [TestCase("string result = Register(1, 2)", ExpectedResult = "3")]
        [TestCase("string result = Register(Basic(4), 2)", ExpectedResult = "6")]
        [TestCase("string result = Register(GetNum(), 2) int GetNum() { return 1 + 2 }", ExpectedResult = "5")]
        [TestCase("string result = Get(Register(1,2)) string Get(bool flag) { return \"should fail\" }", ExpectedException = typeof(InvalidReturnTypeException))]
        public string ShouldRunFunctions(string script)
        {
            SymbolFacilitator symbolFacilitator = new SymbolFacilitator();
            IManagedMemory managedMemory = new ManagedMemory();
            IParseTree parseTree = new ScriptAstGenerator().Generate(script);
            IRepositoryRegister repositoryRegister = new RepositoryRegister();
            IRepository functionRepository = new Repository(repositoryRegister);
            
            SymbolCompiler symbolCompiler = new SymbolCompiler(managedMemory, symbolFacilitator);
            FunctionReferenceCompiler functionReferenceCompiler = new FunctionReferenceCompiler(managedMemory, symbolFacilitator, functionRepository);
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, symbolFacilitator, functionRepository);

            repositoryRegister.Register("Basic", new BasicReturnFunction());
            repositoryRegister.Register("Register", new AddFunction());

            symbolCompiler.Visit(parseTree);
            functionReferenceCompiler.Visit(parseTree);
            interpreter.Visit(parseTree);

            return symbolFacilitator.GetValueAsString(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("result"));
        }
    }

    [Function("Basic", "General")]
    [Parameter(1, "num", typeof(int))]
    [ReturnType(typeof(int))]
    internal class BasicReturnFunction : FunctionBase
    {
        public override object Eval(string functionName, object[] parameters)
        {
            CheckParametersAndThrowOnMissMatch(parameters);

            return (int) parameters[0];
        }
    }

    [Function("Register", "General")]
    [Parameter(1, "num1", typeof(int))]
    [Parameter(2, "num2", typeof(int))]
    [ReturnType(typeof(int))]
    internal class AddFunction : FunctionBase
    {
        public override object Eval(string functionName, object[] parameters)
        {
            CheckParametersAndThrowOnMissMatch(parameters);

            return (int) ((int)parameters[0]) + ((int)parameters[1]);
        }
    }
}