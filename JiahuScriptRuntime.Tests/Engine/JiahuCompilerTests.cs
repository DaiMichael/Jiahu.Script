using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine
{
    [TestFixture]
    public class JiahuCompilerTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(()=> new JiahuCompiler());
        }

        [Test]
        public void ShouldCompile()
        {
            JiahuCompiler compiler = new JiahuCompiler();

            Assert.DoesNotThrow(() => compiler.Compile("int i = 1 int x = i string func(int i) { return i }"));

            Assert.AreEqual("i" , compiler.SymbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("i").Name);
            Assert.AreEqual("x", compiler.SymbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("x").Name);
            Assert.AreEqual(SymbolType.Variable, compiler.SymbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("i").Type);
            Assert.AreEqual(SymbolType.Variable, compiler.SymbolTable.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("x").Type);
            Assert.IsTrue(compiler.SymbolTable.HasFunction("func"));
        }

        [Test]
        public void ShouldThrowExceptionOnBadScript()
        {
            JiahuCompiler compiler = new JiahuCompiler();

            Assert.Throws<VariableNotDefinedException>(() => compiler.Compile("int i = 1 int x = b"));
        }
    }
}
