using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Compilers;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptInterpreterWhileTests
    {
        [Test]
        [TestCase("string stringVar=\"nan\" int intVar = 0 while(intVar<=10) { stringVar = intVar intVar++ }", ExpectedResult = "10")]
        [TestCase("string stringVar=\"nan\" int intVar = 11 while(intVar<=10) { stringVar = intVar intVar++ }", ExpectedResult = "nan")]
        [TestCase("string stringVar=\"nan\" int intVar = 0 while(intVar < 6) { if (intVar == 3) { break } stringVar = intVar intVar++ }", ExpectedResult = "2")]
        [TestCase("string stringVar=\"nan\" int intVar = 0 while(intVar<=10) { stringVar = intVar return }", ExpectedResult = "0")]
        public string ShouldRunWhileStatements(string script)
        {
            SymbolFacilitator symbolFacilitator = new SymbolFacilitator();
            IManagedMemory managedMemory = new ManagedMemory();
            IParseTree parseTree = new ScriptAstGenerator().Generate(script);

            SymbolCompiler symbolCompiler = new SymbolCompiler(managedMemory, symbolFacilitator);
            FunctionReferenceCompiler functionReferenceCompiler = new FunctionReferenceCompiler(managedMemory, symbolFacilitator);
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, symbolFacilitator);

            symbolCompiler.Visit(parseTree);
            functionReferenceCompiler.Visit(parseTree);
            interpreter.Visit(parseTree);

            return symbolFacilitator.GetValueAsString(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("stringVar"));
        }
    }
}
