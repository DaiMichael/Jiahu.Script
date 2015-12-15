using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory
{
    [TestFixture]
    public class ManagedMemoryTests
    {
        [Test]
        public void ShouldConstructHeap()
        {
            Assert.DoesNotThrow(() => new ManagedMemory());
        }

        [Test]
        public void ShouldAddScope()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.Scopes.Count);
            memory.Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
            Assert.AreEqual(1, memory.Scopes.Count);
        }

        [Test]
        public void ShouldAddMultipleScopes()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.Scopes.Count);
            memory.Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
            memory.Add(new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null));
            Assert.AreEqual(2, memory.Scopes.Count);
        }

        [Test]
        public void ShouldThrowDuplicateExceptions()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.Scopes.Count);
            memory.Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
            Assert.Throws<DuplicateScopeException>(() => memory.Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null)));
        }

        [Test]
        public void ShouldClearScopes()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.Scopes.Count);
            memory.Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
            memory.Add(new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null));
            Assert.AreEqual(2, memory.Scopes.Count);
            Assert.DoesNotThrow(memory.Clear);
            Assert.AreEqual(0, memory.Scopes.Count);
        }

        [Test]
        public void ShouldAddMultipleScopesAndGet()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.Scopes.Count);
            memory.Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
            memory.Add(new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null));
            Assert.AreEqual(2, memory.Scopes.Count);
            Assert.AreEqual(ScopeOwner.Main, memory[new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)].Owner.Name);
            Assert.AreEqual("func", memory[new ScopeOwner("func", ScopeOwnerType.Function)].Owner.Name);
        }

        [Test]
        public void ShouldThrowExceptionOnMissingScope()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.Scopes.Count);
            memory.Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
            memory.Add(new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null));
            Assert.AreEqual(2, memory.Scopes.Count);
            Assert.AreEqual(ScopeOwner.Main, memory[new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)].Owner.Name);
            Assert.AreEqual("func", memory[new ScopeOwner("func", ScopeOwnerType.Function)].Owner.Name);
            Assert.Throws<ScopeNotFoundException>(delegate { Scope scope = memory[new ScopeOwner("noFunc", ScopeOwnerType.Function)]; });
        }

        [Test]
        public void ShouldAddMultipleScopesAndGetViaProertyList()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.Scopes.Count);
            memory.Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
            memory.Add(new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null));
            Assert.AreEqual(2, memory.Scopes.Count);
            Assert.AreEqual(ScopeOwner.Main, memory.Scopes[0].Owner.Name);
            Assert.AreEqual("func", memory.Scopes[1].Owner.Name);
        }

        [Test]
        public void ShouldAddMultipleScopesAndGetViaFunctionGet()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.Scopes.Count);
            memory.Add(new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
            memory.Add(new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null));
            Assert.AreEqual(2, memory.Scopes.Count);
            Assert.AreEqual(ScopeOwner.Main, memory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).Owner.Name);
            Assert.AreEqual("func", memory.GetScope(new ScopeOwner("func", ScopeOwnerType.Function)).Owner.Name);
        }

        [Test]
        public void ShouldAddFunctionToMemory()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.FunctionSymbols.Count);

            memory.Add(new FunctionSymbol("func"));

            Assert.AreEqual(1, memory.FunctionSymbols.Count);
        }

        [Test]
        public void ShouldAddMultipleFunctionsToMemory()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.FunctionSymbols.Count);

            memory.Add(new FunctionSymbol("func1"));
            memory.Add(new FunctionSymbol("func2"));
            memory.Add(new FunctionSymbol("func3"));

            Assert.AreEqual(3, memory.FunctionSymbols.Count);
        }

        [Test]
        public void ShouldThrowExceptionOnDuplicateFunction()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.FunctionSymbols.Count);

            memory.Add(new FunctionSymbol("func1"));
            memory.Add(new FunctionSymbol("func2"));
            Assert.Throws<DuplicateSymbolException>(() => memory.Add(new FunctionSymbol("func1")));
        }

        [Test]
        public void ShouldGetFunctionFromMemory()
        {
            ManagedMemory memory = new ManagedMemory();

            Assert.AreEqual(0, memory.FunctionSymbols.Count);

            memory.Add(new FunctionSymbol("func1"));
            memory.Add(new FunctionSymbol("func2"));
            memory.Add(new FunctionSymbol("func3"));

            Assert.AreEqual("func1", memory.GetFunction("func1").Name);
            Assert.AreEqual("func2", memory.GetFunction("func2").Name);
            Assert.AreEqual("func3", memory.GetFunction("func3").Name);
        }

        [Test]
        public void ShouldCreateMainScopeOnConstruction()
        {
            ManagedMemory managedMemory = new ManagedMemory(true);

            Assert.True(managedMemory.HasScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)));
        }

        [Test]
        public void ShouldDoesNotCreateMainScopeOnConstruction()
        {
            ManagedMemory managedMemory = new ManagedMemory();

            Assert.False(managedMemory.HasScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)));
        }

        [Test]
        public void ShouldCreateGlobalScopeOnConstruction()
        {
            ManagedMemory managedMemory = new ManagedMemory(true);

            Assert.True(managedMemory.HasScope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global)));
        }

        [Test]
        public void ShouldDoesNotCreateGlobalScopeOnConstruction()
        {
            ManagedMemory managedMemory = new ManagedMemory();

            Assert.False(managedMemory.HasScope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global)));
        }

        [Test]
        public void ShouldThrowScopeException()
        {
            ManagedMemory managedMemory = new ManagedMemory();

            Assert.Throws<ScopeNotFoundException>(() => ManagedMemory.ApplyGlobalVariables(managedMemory, new VariableRepository()));
        }

        [Test]
        public void ShouldAddVariablesToGlobalScope()
        {
            ManagedMemory managedMemory = new ManagedMemory(true);
            VariableRepository variableRepository = new VariableRepository();

            variableRepository.Register(new BooleanVariableSymbol("flag"));

            Assert.DoesNotThrow(() => ManagedMemory.ApplyGlobalVariables(managedMemory, variableRepository));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global)).HasSymbol("flag"));
        }

        [Test]
        public void ShouldAddTwoVariablesToGlobalScope()
        {
            ManagedMemory managedMemory = new ManagedMemory(true);
            VariableRepository variableRepository = new VariableRepository();

            variableRepository.Register(new BooleanVariableSymbol("flag"));
            variableRepository.Register(new IntVariableSymbol("count"));

            Assert.DoesNotThrow(() => ManagedMemory.ApplyGlobalVariables(managedMemory, variableRepository));

            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global)).HasSymbol("flag"));
            Assert.IsTrue(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Global, ScopeOwnerType.Global)).HasSymbol("count"));
        }
    }
}