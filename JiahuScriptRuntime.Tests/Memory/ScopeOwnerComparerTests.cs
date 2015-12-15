using JiahuScriptRuntime.Memory;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory
{
    [TestFixture]
    public class ScopeOwnerComparerTests
    {
        [Test]
        public void ShouldCompareEqual()
        {
            ScopeOwnerComparer comparer = new ScopeOwnerComparer();
            ScopeOwner scopeOwner1 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main);
            ScopeOwner scopeOwner2 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main);

            Assert.IsTrue(comparer.Equals(scopeOwner1, scopeOwner2));
        }

        [Test]
        public void ShouldCompareEqualSameObject()
        {
            ScopeOwnerComparer comparer = new ScopeOwnerComparer();
            ScopeOwner scopeOwner1 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main);

            Assert.IsTrue(comparer.Equals(scopeOwner1, scopeOwner1));
        }

        [Test]
        public void ShouldCompareNotEqualOnName()
        {
            ScopeOwnerComparer comparer = new ScopeOwnerComparer();
            ScopeOwner scopeOwner1 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main);
            ScopeOwner scopeOwner2 = new ScopeOwner("notMain", ScopeOwnerType.Main);

            Assert.IsFalse(comparer.Equals(scopeOwner1, scopeOwner2));
        }

        [Test]
        public void ShouldCompareNotEqualOnType()
        {
            ScopeOwnerComparer comparer = new ScopeOwnerComparer();
            ScopeOwner scopeOwner1 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main);
            ScopeOwner scopeOwner2 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Block);

            Assert.IsFalse(comparer.Equals(scopeOwner1, scopeOwner2));
        }

        [Test]
        public void ShouldCompareNotEqualOnBoth()
        {
            ScopeOwnerComparer comparer = new ScopeOwnerComparer();
            ScopeOwner scopeOwner1 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main);
            ScopeOwner scopeOwner2 = new ScopeOwner("notMain", ScopeOwnerType.Block);

            Assert.IsFalse(comparer.Equals(scopeOwner1, scopeOwner2));
        }

        [Test]
        public void ShouldCompareNotEqualWithDifferentId()
        {
            ScopeOwnerComparer comparer = new ScopeOwnerComparer();
            ScopeOwner scopeOwner1 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main, 1);
            ScopeOwner scopeOwner2 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main, 2);

            Assert.IsFalse(comparer.Equals(scopeOwner1, scopeOwner2));
        }

        [Test]
        public void ShouldCompareEqualWithSameId()
        {
            ScopeOwnerComparer comparer = new ScopeOwnerComparer();
            ScopeOwner scopeOwner1 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main, 1);
            ScopeOwner scopeOwner2 = new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main, 1);

            Assert.IsTrue(comparer.Equals(scopeOwner1, scopeOwner2));
        }
    }
}