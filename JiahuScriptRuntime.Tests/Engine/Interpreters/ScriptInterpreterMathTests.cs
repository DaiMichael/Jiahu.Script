using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptInterpreterMathTests
    {
        [Test]
        [TestCase("int var = 1 + 2", ExpectedResult = 3)]
        [TestCase("int var = 99 + 20", ExpectedResult = 119)]
        [TestCase("int var = (99 + 20) + 1", ExpectedResult = 120)]
        [TestCase("int var = (99 + 20) + (10 + 1)", ExpectedResult = 130)]
        [TestCase("int var = (20 - 10) + (90 - 80)", ExpectedResult = 20)]
        [TestCase("int const = 10 int var = (20 - const) + (90 - 80)", ExpectedResult = 20)]
        [TestCase("int var = (90 - 80) * 10", ExpectedResult = 100)]
        [TestCase("int var = 9 / 3", ExpectedResult = 3)]
        [TestCase("int var var = 10 + 9", ExpectedResult = 19)]
        [TestCase("int const = 10 int var var = const + 9", ExpectedResult = 19)]
        [TestCase("int const = 10 int var var = const + 9.89", ExpectedException = typeof(ValueCastException))]
        [TestCase("int var = 9 - -3", ExpectedResult = 12)]
        [TestCase("int var = 9 - 3", ExpectedResult = 6)]
        [TestCase("int var = 9-3", ExpectedResult = 6)]
        public int ShouldDoIntOperandsTogether(string script)
        {
            IManagedMemory managedMemory = new ManagedMemory();
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);
            scope.Add(new IntVariableSymbol("var"));
            scope.Add(new IntVariableSymbol("const"));
            managedMemory.Add(scope);

            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());
            interpreter.Visit(new ScriptAstGenerator().Generate(script));

            return ((SymbolValue<int>) managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("var")).Value;
        }

        [Test]
        [TestCase("decimal var = 1.5 + 2.5", ExpectedResult = 4)]
        [TestCase("decimal var = 9.82 + 10", ExpectedResult = 19.82)]
        [TestCase("decimal var = (99 + 20) + 1.5", ExpectedResult = 120.5)]
        [TestCase("decimal var = (99 + 20) + (10 + 1)", ExpectedResult = 130)]
        [TestCase("decimal var = (20 - 10) + (90.5 - 80.5)", ExpectedResult = 20)]
        [TestCase("decimal const = 10.5 decimal var = (20.5 - const) + (90 - 80)", ExpectedResult = 20)]
        [TestCase("decimal var = (90 - 80) * 10", ExpectedResult = 100)]
        [TestCase("decimal var = 45 / 6", ExpectedResult = 7.5)]
        [TestCase("decimal var var = 10 + 9", ExpectedResult = 19)]
        [TestCase("int const = 10 decimal var var = const + 9.78", ExpectedResult = 19.78)]
        public decimal ShouldDoDecimalOperandsTogether(string script)
        {
            IManagedMemory managedMemory = new ManagedMemory();
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);
            scope.Add(new DecimalVariableSymbol("var"));
            scope.Add(new DecimalVariableSymbol("const"));
            managedMemory.Add(scope);

            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());
            interpreter.Visit(new ScriptAstGenerator().Generate(script));

            return ((SymbolValue<decimal>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("var")).Value;
        }
    }
}
