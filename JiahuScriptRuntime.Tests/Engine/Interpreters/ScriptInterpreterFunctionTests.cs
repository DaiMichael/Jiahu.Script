using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Compilers;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptInterpreterFunctionTests
    {
        [Test]
        [TestCase("string result = GetCount() int GetCount() { return 1 }", ExpectedResult = "1")]
        [TestCase("string result = GetName() string GetName() { return \"Darth Vader\" }", ExpectedResult = "Darth Vader")]
        [TestCase("string result = GetName(\"David\", \"Michael\") string GetName(string name, string surname) { return name & \" \" & surname }", ExpectedResult = "David Michael")]
        [TestCase("string result = DoMaths(1, 3, 10) string DoMaths(int a, int b, int c) { return ((a + b)*c) + 1 }", ExpectedResult = "41")]
        [TestCase("string result = ArrayCount({1,2,3,4,5}) string ArrayCount(int[] array) { int count=0 foreach(int item in array) {count++} return count}", ExpectedResult = "5")]
        [TestCase("string result = ArrayCount({1,2,3,4,5}) string Maths(int[] array) { int count=0 foreach(int item in array) {count++} return count}", ExpectedException = typeof(UndefinedFunctionException))]
        public string ShouldRunFunctions(string script)
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

            return symbolFacilitator.GetValueAsString(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("result"));
        }
    }
}