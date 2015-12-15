using System;
using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Engine;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine
{
    [TestFixture]
    public class ScriptAstGeneratorTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new ScriptAstGenerator());
        }

        [Test]
        public void ShouldThrowExceptionOneEmptyScript()
        {
            ScriptAstGenerator generator = new ScriptAstGenerator();

            Assert.Throws<ArgumentNullException>(() => generator.Generate(string.Empty));
        }

        [Test]
        public void ShouldProduceAstParseTree()
        {
            ScriptAstGenerator generator = new ScriptAstGenerator();

            IParseTree tree = generator.Generate("int i");

            Assert.NotNull(tree);
        }
    }
}
