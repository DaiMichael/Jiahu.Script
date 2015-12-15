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
    public class ScriptInterpreterSwitchTests
    {
        [Test]
        [TestCase("string stringVar=\"zero\" int intVar = 1 switch(intVar) { case 1: { stringVar = \"one\"} case 2 : { stringVar=\"two\" } }", ExpectedResult = "one")]
        [TestCase("string stringVar=\"zero\" int intVar = 2 switch(intVar) { case 1: { stringVar = \"one\"} case 2 : { stringVar=\"two\" } }", ExpectedResult = "two")]
        [TestCase("string stringVar=\"zero\" int intVar = 3 switch(intVar) { case 1: { stringVar = \"one\"} case 2 : { stringVar=\"two\" } }", ExpectedResult = "zero")]
        [TestCase("string stringVar=\"zero\" int intVar = 3 switch(intVar) { case 1: { stringVar = \"one\"} case 2 : { stringVar=\"two\" } default : { stringVar=\"default\" } }", ExpectedResult = "default")]
        public string ShouldRunSwitchStatements(string script)
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
