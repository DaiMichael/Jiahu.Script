using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptInterpreterIfTests
    {
        [Test]
        [TestCase("string var = \"none\" if (true) { var=\"if is true\" } ", ExpectedResult = "if is true")]
        [TestCase("string var = \"none\" if (false) { var=\"if is true\" } ", ExpectedResult = "none")]
        [TestCase("bool boolVar1 = true string var = \"none\" if (boolVar1 == false) { var=\"if is true\" } else { var=\"else is true\" }", ExpectedResult = "else is true")]
        [TestCase("bool boolVar1 = true bool boolVar2 = true string var = \"none\" if (boolVar1 && boolVar2) { var=\"if is true\" } else { var=\"else is true\" }", ExpectedResult = "if is true")]
        [TestCase("bool boolVar1 = true bool boolVar2 = false string var = \"none\" if (boolVar1 && boolVar2) { var=\"if is true\" } else { var=\"else is true\" }", ExpectedResult = "else is true")]
        [TestCase("bool boolVar1 = true bool boolVar2 = true string var = \"none\" if (boolVar1 || boolVar2) { var=\"if is true\" } else { var=\"else is true\" }", ExpectedResult = "if is true")]
        [TestCase("bool boolVar1 = false bool boolVar2 = false string var = \"none\" if (boolVar1 || boolVar2) { var=\"if is true\" } else { var=\"else is true\" }", ExpectedResult = "else is true")]
        public string ShouldRunIfStatements(string script)
        {
            SymbolFacilitator symbolFacilitator = new SymbolFacilitator();
            IManagedMemory managedMemory = new ManagedMemory();
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);
            scope.Add(new StringVariableSymbol("var"));
            scope.Add(new BooleanVariableSymbol("boolVar1"));
            scope.Add(new BooleanVariableSymbol("boolVar2"));
            managedMemory.Add(scope);

            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());
            interpreter.Visit(new ScriptAstGenerator().Generate(script));

            return symbolFacilitator.GetValueAsString(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("var"));
        }
    }
}
