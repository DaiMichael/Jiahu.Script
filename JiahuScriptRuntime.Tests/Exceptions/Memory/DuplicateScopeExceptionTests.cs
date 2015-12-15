using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.Memory;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Memory
{
    [TestFixture]
    public class DuplicateScopeExceptionTests
    {
        [Test]
        public void ShouldConstructException()
        {
            Assert.DoesNotThrow(() => new DuplicateScopeException(new ScopeOwner("while", ScopeOwnerType.Block)));
        }

        [Test]
        public void ShouldReturnValidMessage()
        {
            DuplicateScopeException exception = new DuplicateScopeException(new ScopeOwner("while", ScopeOwnerType.Block));

            Assert.AreEqual("Duplicate scope name [while] of type [Block].", exception.Message);
        }
    }
}
