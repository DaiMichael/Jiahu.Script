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
    public class ScriptInterpreterForEachTests
    {
        [Test]
        [TestCase("string stringVar = \"none\" foreach(int intVar in {1,2,3}) { stringVar = intVar }", ExpectedResult = "3")]
        [TestCase("string stringVar = \"none\" foreach(int intVar in {1,2,3}) { stringVar = intVar break }", ExpectedResult = "1")]
        [TestCase("string stringVar = \"none\" foreach(int intVar in {1,2,3}) { stringVar = intVar return }", ExpectedResult = "1")]
        [TestCase("string stringVar = \"\" string stringCheck=\"David\" foreach(string item in {\"Tim\",\"David\",\"Rob\"}) { if (item == stringCheck) { stringVar=\"found!\" break} }", ExpectedResult = "found!")]
        public string ShouldRunForEachStatements(string script)
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
