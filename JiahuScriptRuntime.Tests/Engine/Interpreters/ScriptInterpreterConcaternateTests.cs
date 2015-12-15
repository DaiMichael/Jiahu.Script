using System;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptInterpreterConcaternateTests
    {
        [Test]
        [TestCase("string var = \"test\" & \" here\"", ExpectedResult = "test here")]
        [TestCase("string var = \"dave\" & \" \" & \"michael\"", ExpectedResult = "dave michael")]
        [TestCase("string var = \"dave\" & (1 + 2) & \"michael\"", ExpectedResult = "dave3michael")]
        [TestCase("string const = \"wotcha\" string var = const & \" chris!\"", ExpectedResult = "wotcha chris!")]
        [TestCase("int index = 1 & 2", ExpectedException = typeof(InvalidCastException))]
        [TestCase("int index = 21 string const = \"my\" string var = const & \" age is \" & index", ExpectedResult = "my age is 21")]
        public string ShouldConcaternate(string script)
        {
            IManagedMemory managedMemory = new ManagedMemory();
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);
            scope.Add(new StringVariableSymbol("var"));
            scope.Add(new StringVariableSymbol("const"));
            scope.Add(new IntVariableSymbol("index"));
            managedMemory.Add(scope);

            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());
            interpreter.Visit(new ScriptAstGenerator().Generate(script));

            return ((SymbolValue<string>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("var")).Value;
        }
    }
}
