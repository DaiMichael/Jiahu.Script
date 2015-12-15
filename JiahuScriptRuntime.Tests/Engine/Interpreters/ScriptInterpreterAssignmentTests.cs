using System;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using Moq;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptInterpreterAssignmentTests
    {
        [Test]
        public void ShouldThrowOnNullMemory()
        {
            Assert.Throws<ArgumentNullException>(() => new ScriptInterpreter(null, null));
        }

        [Test]
        public void ShouldThrowOnNullFacilitator()
        {
            Mock<IManagedMemory> managedMemory = new Mock<IManagedMemory>();

            Assert.Throws<ArgumentNullException>(() => new ScriptInterpreter(managedMemory.Object, null));
        }

        [Test]
        public void ShouldConstruct()
        {
            Mock<IManagedMemory> managedMemory = new Mock<IManagedMemory>();
            Mock<ISymbolFacilitator> symbolFacititator = new Mock<ISymbolFacilitator>();
            
            Assert.DoesNotThrow(() => new ScriptInterpreter(managedMemory.Object, symbolFacititator.Object));
        }

        [Test]
        public void ShouldAssignIntVariable()
        {
            const int value = 99;
            const string script = "int var = 99";
            const string variableName = "var";
            
            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<int>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignDecimalVariable()
        {
            const decimal value = 78.3m;
            const string script = "decimal var = 78.3";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<decimal>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignStringVariable()
        {
            const string value = "working";
            const string script = "string var = \"working\"";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<string>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignBooleanVariable()
        {
            const bool value = true;
            const string script = "bool var = true";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<bool>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignDateVariable()
        {
            DateTime value = new DateTime(2015, 3, 1);
            const string script = "datetime var = \"01/03/2015\"";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<DateTime>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignDateTimeVariable()
        {
            DateTime value = new DateTime(2015, 3, 1, 15, 23, 01);
            const string script = "datetime var = \"01/03/2015 15:23:01\"";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<DateTime>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignIntArrayVariable()
        {
            int[] value = { 99, 1 };
            const string script = "int[] var = {99,1}";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<int[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignDecimalArrayVariable()
        {
            decimal[] value = { 78.3m };
            const string script = "decimal[] var = {78.3}";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<decimal[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignStringArrayVariable()
        {
            string[] value = { "working", "next" };
            const string script = "string[] var = {\"working\", \"next\"}";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<string[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignBooleanArrayVariable()
        {
            bool[] value = { true, false, true };
            const string script = "bool[] var = {true, false, true}";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<bool[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignDateArrayVariable()
        {
            DateTime[] value = { new DateTime(2015, 3, 1) };
            const string script = "datetime[] var = {\"01/03/2015\"}";
            const string variableName = "var";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(value, ((SymbolValue<DateTime[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }

        [Test]
        public void ShouldAssignDateTimeArrayVariable()
        {
            DateTime[] value = { new DateTime(2015, 3, 1, 15, 23, 01) };
            const string script = "datetime[] var = {\"01/03/2015 15:23:01\"} datetime[] var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<DateTime[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<DateTime[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToIntVariable()
        {
            const int value = 99;
            const string script = "int var = 99 int var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<int>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<int>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToDecimalVariable()
        {
            const decimal value = 78.3m;
            const string script = "decimal var = 78.3 decimal var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<decimal>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<decimal>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToStringVariable()
        {
            const string value = "working";
            const string script = "string var = \"working\" string var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<string>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<string>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToBooleanVariable()
        {
            const bool value = true;
            const string script = "bool var = true bool var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<bool>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<bool>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToDateVariable()
        {
            DateTime value = new DateTime(2015, 3, 1);
            const string script = "date var = \"01/03/2015\" date var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<DateTime>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<DateTime>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToDateTimeVariable()
        {
            DateTime value = new DateTime(2015, 3, 1, 15, 23, 01);
            const string script = "datetime var = \"01/03/2015 15:23:01\" datetime var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<DateTime>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<DateTime>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToIntArrayVariable()
        {
            int[] value = { 99, 1 };
            const string script = "int[] var = {99,1} int[] var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<int[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<int[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToDecimalArrayVariable()
        {
            decimal[] value = { 78.3m, 89.52m };
            const string script = "decimal[] var = {78.3, 89.52} decimal[] var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<decimal[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<decimal[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToStringArrayVariable()
        {
            string[] value = { "working", "next" };
            const string script = "string[] var = {\"working\", \"next\"} string[] var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<string[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<string[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToBooleanArrayVariable()
        {
            bool[] value = { true, false, true };
            const string script = "bool[] var = {true, false, true} bool[] var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<bool[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<bool[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToDateArrayVariable()
        {
            DateTime[] value = { new DateTime(2015, 3, 1) };
            const string script = "date[] var = {\"01/03/2015\"} date[] var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<DateTime[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<DateTime[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToDateTimeArrayVariable()
        {
            DateTime[] value = { new DateTime(2015, 3, 1, 15, 23, 01) };
            const string script = "datetime[] var = {\"01/03/2015 15:23:01\"} datetime[] var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(value, ((SymbolValue<DateTime[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(value, ((SymbolValue<DateTime[]>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignVariableToAnotherVariable()
        {
            const string script = "int var = 90 int var1 var1 = var";
            const string variableName = "var";
            const string assignedName = "var1";

            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(assignedName));
            Assert.AreEqual(90, ((SymbolValue<int>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
            Assert.AreEqual(90, ((SymbolValue<int>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(assignedName)).Value);
        }

        [Test]
        public void ShouldAssignArrayItemToAnotherVariable()
        {
            const string script = "int[] array = {1,2,3} int var = array[1]";
            const string variableName = "var";
            
            JiahuCompiler compiler = new JiahuCompiler();
            IManagedMemory managedMemory = compiler.SymbolTable;
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, new SymbolFacilitator());

            Assert.NotNull(compiler);
            Assert.NotNull(interpreter);
            Assert.DoesNotThrow(() => compiler.Compile(script));
            Assert.DoesNotThrow(() => interpreter.Visit(new ScriptAstGenerator().Generate(script)));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).HasSymbol(variableName));
            Assert.AreEqual(2, ((SymbolValue<int>)managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol(variableName)).Value);
        }
    }
}
