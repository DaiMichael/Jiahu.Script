using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptInterpreterInlineIfTests
    {
        [Test]
        [TestCase("string var = true ? \"yay\" : \"nay\"", ExpectedResult = "yay")]
        [TestCase("string var = false ? \"yay\" : \"nay\"", ExpectedResult = "nay")]
        [TestCase("string var = 3 == (1+2)  ? \"yay\" : \"nay\"", ExpectedResult = "yay")]
        [TestCase("string var = 45 != (1+2)  ? \"yay\" : \"nay\"", ExpectedResult = "yay")]
        [TestCase("string var = 45++ == 47  ? \"yay\" : \"nay\"", ExpectedResult = "nay")]
        [TestCase("string var = 45++ >= 46  ? \"yay\" : \"nay\"", ExpectedResult = "yay")]
        [TestCase("string var = (1 != 2 ? true : false)  ? \"yay\" : \"nay\"", ExpectedResult = "yay")]
        [TestCase("string var = (1 == 2 ? true : false)  ? \"yay\" : \"nay\"", ExpectedResult = "nay")]
        public string ShouldEvaluateInlineIf(string script)
        {
            SymbolFacilitator symbolFacilitator = new SymbolFacilitator();
            IManagedMemory managedMemory = new ManagedMemory();
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);
            scope.Add(new StringVariableSymbol("var"));
            managedMemory.Add(scope);

            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());
            interpreter.Visit(new ScriptAstGenerator().Generate(script));

            return symbolFacilitator.GetValueAsString(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("var"));
        }
    }
}
