using System;
using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory
{
    [TestFixture]
    public class ScopeTests
    {
        [Test]
        public void ShouldThrowWithNullArgumentOnScopeOwner()
        {
            Assert.Throws<ArgumentNullException>(() => new Scope(null, null));
        }

        [Test]
        public void ShouldConstructScope()
        {
            Assert.DoesNotThrow(() => new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null));
        }

        [Test]
        public void ShouldAddSymbol()
        {
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, scope.Symbols.Count);
            scope.Add(new IntArrayVariableSymbol("i"));
            Assert.AreEqual(1, scope.Symbols.Count);
        }

        [Test]
        public void ShouldAddMultipleSymbol()
        {
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, scope.Symbols.Count);
            scope.Add(new IntArrayVariableSymbol("i"));
            scope.Add(new IntArrayVariableSymbol("x"));
            Assert.AreEqual(2, scope.Symbols.Count);
        }

        [Test]
        public void ShouldThrowExceptionOnDuplicateSymbol()
        {
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, scope.Symbols.Count);
            scope.Add(new IntArrayVariableSymbol("i"));
            Assert.Throws<DuplicateSymbolException>(() => scope.Add(new IntArrayVariableSymbol("i")));
        }

        [Test]
        public void ShouldAddSymbolAndGetVariable()
        {
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, scope.Symbols.Count);
            scope.Add(new IntArrayVariableSymbol("i"));
            scope.Add(new IntArrayVariableSymbol("z"));
            scope.Add(new StringVariableSymbol("f"));
            Assert.AreEqual(3, scope.Symbols.Count);
            Assert.AreEqual("i", scope.GetSymbol("i").Name);
            Assert.AreEqual(SymbolType.Variable, scope.GetSymbol("i").Type);
            Assert.AreEqual("f", scope.GetSymbol("f").Name);
            Assert.AreEqual(SymbolType.Variable, scope.GetSymbol("f").Type);
        }

        [Test]
        public void ShouldThrowExceptionOnSymbolMissing()
        {
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, scope.Symbols.Count);
            scope.Add(new IntArrayVariableSymbol("i"));
            scope.Add(new IntArrayVariableSymbol("z"));
            scope.Add(new StringVariableSymbol("f"));            
            Assert.AreEqual(3, scope.Symbols.Count);
            Assert.Throws<SymbolNotFoundException>(() => scope.GetSymbol("missing"));
        }

        [Test]
        public void ShouldAddSymbolAndSetValueAndCheckIt()
        {
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, scope.Symbols.Count);
            scope.Add(new IntVariableSymbol("i"));
            scope.Add(new StringVariableSymbol("f"));
            Assert.AreEqual(2, scope.Symbols.Count);
            Assert.AreEqual("f", scope.GetSymbol("f").Name);
            Assert.DoesNotThrow(() => scope.SetSymbol("f", "myValue"));
            Assert.AreEqual("myValue", ((SymbolValue<string>)scope.GetSymbol("f")).Value);
        }

        [Test]
        public void ShouldAddSymbolAndCheckViaListProperty()
        {
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, scope.Symbols.Count);
            scope.Add(new IntVariableSymbol("i"));
            scope.Add(new StringVariableSymbol("f"));
            Assert.AreEqual(2, scope.Symbols.Count);
            Assert.AreEqual("i", scope.Symbols[0].Name);
            Assert.AreEqual("f", scope.Symbols[1].Name);
        }

        [Test]
        public void ShouldClearSymbols()
        {
            Scope scope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            scope.Add(new IntArrayVariableSymbol("i"));
            scope.Add(new IntArrayVariableSymbol("z"));
            scope.Add(new StringVariableSymbol("f"));
            
            Assert.AreEqual(3, scope.Symbols.Count);
            Assert.DoesNotThrow(scope.Clear);
            Assert.AreEqual(0, scope.Symbols.Count);
        }

        [Test]
        public void ShouldAddScope()
        {
            Scope parentScope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, parentScope.Scopes.Count);
            parentScope.Add(new Scope(new ScopeOwner("while", ScopeOwnerType.Block), parentScope));
            Assert.AreEqual(1, parentScope.Scopes.Count);
        }

        [Test]
        public void ShouldAddMultipleScope()
        {
            Scope parentScope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, parentScope.Scopes.Count);
            parentScope.Add(new Scope(new ScopeOwner("while", ScopeOwnerType.Block), parentScope));
            parentScope.Add(new Scope(new ScopeOwner("for", ScopeOwnerType.Block), parentScope));
            Assert.AreEqual(2, parentScope.Scopes.Count);
        }

        [Test]
        public void ShouldAllowDuplicateScopeNamesButUseIndex()
        {
            Scope parentScope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, parentScope.Scopes.Count);
            parentScope.Add(new Scope(new ScopeOwner("while", ScopeOwnerType.Block), parentScope));
            parentScope.Add(new Scope(new ScopeOwner("while", ScopeOwnerType.Block), parentScope));

            Assert.AreEqual("while", parentScope.GetScope(new ScopeOwner("while", ScopeOwnerType.Block, 0)).Owner.Name);
            Assert.AreEqual(0, parentScope.GetScope(new ScopeOwner("while", ScopeOwnerType.Block, 0)).Owner.Id);
            Assert.AreEqual("while", parentScope.GetScope(new ScopeOwner("while", ScopeOwnerType.Block, 1)).Owner.Name);
            Assert.AreEqual(1, parentScope.GetScope(new ScopeOwner("while", ScopeOwnerType.Block, 1)).Owner.Id);
        }


        [Test]
        public void ShouldAddScopeAndCheckViaListProperty()
        {
            Scope parentScope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);

            Assert.AreEqual(0, parentScope.Scopes.Count);
            parentScope.Add(new Scope(new ScopeOwner("while", ScopeOwnerType.Block), parentScope));
            parentScope.Add(new Scope(new ScopeOwner("for", ScopeOwnerType.Block), parentScope));
            Assert.AreEqual(2, parentScope.Scopes.Count);
            Assert.AreEqual("while", parentScope.Scopes[0].Owner.Name);
            Assert.AreEqual("for", parentScope.Scopes[1].Owner.Name);
        }

        [Test]
        public void ShouldThrowExceptionOnMissingScope()
        {
            Scope functionScope = new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null);
            
            Assert.Throws<ScopeNotFoundException>(() => functionScope.GetScope(new ScopeOwner("while", ScopeOwnerType.Block)));
        }

        [Test]
        public void ShouldGetVariableSymbolFromParentScope()
        {
            Scope functionScope = new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null);
            Scope whileScope = new Scope(new ScopeOwner("while", ScopeOwnerType.Block), functionScope);

            functionScope.Add(new IntVariableSymbol("id"));
            functionScope.Add(whileScope);

            Assert.AreEqual(SymbolType.Variable, whileScope.GetSymbol("id").Type);
        }

        [Test]
        public void ShouldGetVariableSymbolFromMulitpleNestedScopes()
        {
            Scope functionScope = new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null);
            Scope forScope = new Scope(new ScopeOwner("for", ScopeOwnerType.Block), functionScope);
            Scope whileScope = new Scope(new ScopeOwner("while", ScopeOwnerType.Block), forScope);

            functionScope.Add(new IntVariableSymbol("count"));
            functionScope.Add(forScope);
            forScope.Add(whileScope);

            Assert.AreEqual(SymbolType.Variable, forScope.GetSymbol("count").Type);
            Assert.AreEqual(SymbolType.Variable, whileScope.GetSymbol("count").Type);
        }

        [Test]
        public void ShouldThrowExceptionAsVariableOutsideFunction()
        {
            Scope mainScope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Function), null);
            Scope functionScope = new Scope(new ScopeOwner("func", ScopeOwnerType.Function), mainScope);
            Scope forScope = new Scope(new ScopeOwner("for", ScopeOwnerType.Block), functionScope);
            Scope whileScope = new Scope(new ScopeOwner("while", ScopeOwnerType.Block), forScope);

            mainScope.Add(new IntVariableSymbol("count"));
            mainScope.Add(functionScope);
            functionScope.Add(forScope);
            forScope.Add(whileScope);

            Assert.Throws<SymbolNotFoundException>(() => whileScope.GetSymbol("count"));
        }

        [Test]
        public void ShouldClearScope()
        {
            Scope mainScope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Function), null);
            Scope functionScope = new Scope(new ScopeOwner("func", ScopeOwnerType.Function), mainScope);
            Scope forScope = new Scope(new ScopeOwner("for", ScopeOwnerType.Block), functionScope);
            Scope whileScope = new Scope(new ScopeOwner("while", ScopeOwnerType.Block), forScope);

            mainScope.Add(functionScope);
            mainScope.Add(forScope);
            mainScope.Add(whileScope);

            Assert.AreEqual(3, mainScope.Scopes.Count);
            Assert.DoesNotThrow(mainScope.Clear);
            Assert.AreEqual(0, mainScope.Scopes.Count);
        }

        [Test]
        public void ShouldThrowExceptionAsVariableDefinedInHigherScope()
        {
            Scope functionScope = new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null);
            Scope forScope = new Scope(new ScopeOwner("for", ScopeOwnerType.Block), functionScope);
            Scope whileScope = new Scope(new ScopeOwner("while", ScopeOwnerType.Block), forScope);

            functionScope.Add(new IntVariableSymbol("count"));
            functionScope.Add(forScope);
            forScope.Add(whileScope);

            Assert.Throws<DuplicateSymbolException>(() => whileScope.Add(new IntVariableSymbol("count")));
        }

        [Test]
        public void ShouldAddSameSymbolsInDifferentScopes()
        {
            Scope functionScope = new Scope(new ScopeOwner("func", ScopeOwnerType.Function), null);
            Scope forScope = new Scope(new ScopeOwner("for", ScopeOwnerType.Block), functionScope);
            Scope whileScope = new Scope(new ScopeOwner("while", ScopeOwnerType.Block), functionScope);

            functionScope.Add(forScope);
            functionScope.Add(whileScope);
            
            Assert.DoesNotThrow(() => forScope.Add(new IntVariableSymbol("count")));
            Assert.DoesNotThrow(() => whileScope.Add(new IntVariableSymbol("count")));
        }

        [Test]
        public void ShouldAllowDuplicateFunctionParamNameAsMain()
        {
            Scope mainScope = new Scope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main), null);
            Scope functionScope = new Scope(new ScopeOwner("func", ScopeOwnerType.Function), mainScope);
            
            mainScope.Add(new IntVariableSymbol("i"));

            Assert.DoesNotThrow(() => functionScope.Add(new IntVariableSymbol("i")));
        }
    }
}
