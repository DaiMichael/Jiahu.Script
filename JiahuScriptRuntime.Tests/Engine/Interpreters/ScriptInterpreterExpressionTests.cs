using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptInterpreterExpressionTests
    {
        [Test]
        [TestCase("bool var = 1 == 1", ExpectedResult = true)]
        [TestCase("bool var = 1 == 2", ExpectedResult = false)]
        [TestCase("bool var = 1 < 2", ExpectedResult = true)]
        [TestCase("bool var = 1 <= 2", ExpectedResult = true)]
        [TestCase("bool var = 10 <= 2", ExpectedResult = false)]
        [TestCase("bool var = 10 > 2", ExpectedResult = true)]
        [TestCase("bool var = 2 > 2", ExpectedResult = false)]
        [TestCase("bool var = 10 >= 2", ExpectedResult = true)]
        [TestCase("bool var = 1 >= 2", ExpectedResult = false)]
        [TestCase("bool var = 10 >= 2", ExpectedResult = true)]
        [TestCase("string constString = \"tom\" bool var = constString == \"tom\"", ExpectedResult = true)]
        [TestCase("string constString = \"neil\" bool var = constString == \"tom\"", ExpectedResult = false)]
        [TestCase("int constInt = 5 bool var = constInt == (2+3)", ExpectedResult = true)]
        [TestCase("int constInt = 5 bool var = constInt == (4+3)", ExpectedResult = false)]
        [TestCase("int constInt = 5 bool var = constInt < (4+3)", ExpectedResult = true)]
        [TestCase("bool var = 1 != 2", ExpectedResult = true)]
        [TestCase("bool var = 1 != 1", ExpectedResult = false)]
        [TestCase("bool var = true != false", ExpectedResult = true)]
        [TestCase("bool var = \"hello\" != \"goodbye\"", ExpectedResult = true)]
        [TestCase("bool var = \"hello\" != \"hello\"", ExpectedResult = false)]
        [TestCase("bool var = !(1==2)", ExpectedResult = true)]
        [TestCase("bool var = !(2==2)", ExpectedResult = false)]
        [TestCase("bool constBool = true bool var = constBool==true", ExpectedResult = true)]
        [TestCase("bool constBool = true bool var = !constBool", ExpectedResult = false)]
        [TestCase("bool var = \"01/03/2015\" == \"01/03/2015\"", ExpectedResult = true)]
        [TestCase("bool var = \"02/03/2015\" == \"01/03/2015\"", ExpectedResult = false)]
        [TestCase("bool var = \"02/03/2015\" >= \"01/03/2015\"", ExpectedResult = true)]
        [TestCase("bool var = \"02/03/2015\" <= \"01/03/2015\"", ExpectedResult = false)]
        [TestCase("int constInt = 5 bool var = constInt++ == (3+3)", ExpectedResult = true)]
        [TestCase("int constInt = 5 bool var = constInt-- == 4", ExpectedResult = true)]
        [TestCase("int constInt = 5 bool var = constInt-- != (3+3)", ExpectedResult = true)]
        [TestCase("int constInt = 5 bool var = constInt-- < 5", ExpectedResult = true)]
        [TestCase("int constInt = 5 bool var = constInt-- == 5", ExpectedResult = false)]
        [TestCase("bool var = 4++ == 5", ExpectedResult = true)]
        [TestCase("bool var = (5 - 1)++ == 5", ExpectedResult = true)]
        public bool ShouldEvaluate(string script)
        {
            IManagedMemory managedMemory = new ManagedMemory();
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);
            scope.Add(new IntVariableSymbol("constInt"));
            scope.Add(new StringVariableSymbol("constString"));
            scope.Add(new BooleanVariableSymbol("constBool"));
            scope.Add(new BooleanVariableSymbol("var"));
            managedMemory.Add(scope);

            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());
            interpreter.Visit(new ScriptAstGenerator().Generate(script));

            return ((SymbolValue<bool>) managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("var")).Value;
        }
    }
}
