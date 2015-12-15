using System;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External
{
    [TestFixture]
    public class VariableRepositoryTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.IsNotNull(new VariableRepository());
        }

        [Test]
        public void ShouldAddOneSymbol()
        {
            VariableRepository repository = new VariableRepository();

            Assert.AreEqual(0, repository.Count);
            Assert.DoesNotThrow(() => repository.Register(new IntVariableSymbol("count")));
            Assert.AreEqual(1, repository.Count);
        }


        [Test]
        public void ShouldAddTwoSymbol()
        {
            VariableRepository repository = new VariableRepository();

            Assert.AreEqual(0, repository.Count);
            Assert.DoesNotThrow(() => repository.Register(new IntVariableSymbol("count")));
            Assert.DoesNotThrow(() => repository.Register(new BooleanVariableSymbol("flag")));
            Assert.AreEqual(2, repository.Count);
        }

        [Test]
        public void ShouldCanResolveVariable()
        {
            VariableRepository repository = new VariableRepository();

            Assert.AreEqual(0, repository.Count);
            Assert.DoesNotThrow(() => repository.Register(new IntVariableSymbol("count")));
            Assert.DoesNotThrow(() => repository.Register(new BooleanVariableSymbol("flag")));
            Assert.AreEqual("count", repository.Resolve<Symbol>("count").Name);
            Assert.AreEqual("flag", repository.Resolve<Symbol>("flag").Name);
        }

        [Test]
        public void ShouldCanForEachAllItems()
        {
            int count = 0;
            VariableRepository repository = new VariableRepository();

            Assert.AreEqual(0, repository.Count);
            Assert.DoesNotThrow(() => repository.Register(new IntVariableSymbol("count")));
            Assert.DoesNotThrow(() => repository.Register(new BooleanVariableSymbol("flag")));

            foreach (var symbol in repository)
            {
                count++;
            }
            
            Assert.AreEqual(2, count);
        }

        [Test]
        public void ShouldThrowExceptionOnDuplicateSymbolNames()
        {
            VariableRepository repository = new VariableRepository();

            repository.Register(new BooleanVariableSymbol("flag"));
            Assert.Throws<ArgumentException>(() => repository.Register(new BooleanArrayVariableSymbol("flag")));
        }

        [Test]
        public void TypeResolveNotImplemented()
        {
            VariableRepository repository = new VariableRepository();

            Assert.Throws<NotImplementedException>(() => repository.Resolve<BooleanVariableSymbol>());
            Assert.Throws<NotImplementedException>(() => repository.Has<BooleanVariableSymbol>());
        }
    }
}
