using System;
using JiahuScriptRuntime.Memory;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory
{
    [TestFixture]
    public class ScopeOwnerTests
    {
        [Test]
        public void ShouldCompareValidWithSameValues()
        {
            ScopeOwner owner1 = new ScopeOwner("function1", ScopeOwnerType.Function);
            ScopeOwner owner2 = new ScopeOwner("function1", ScopeOwnerType.Function);

            Assert.AreEqual(0, owner1.CompareTo(owner2));
        }

        [Test]
        public void ShouldCompareInvalidWithDifferntNameValues()
        {
            ScopeOwner owner1 = new ScopeOwner("function1", ScopeOwnerType.Function);
            ScopeOwner owner2 = new ScopeOwner("function2", ScopeOwnerType.Function);

            Assert.AreEqual(1, owner1.CompareTo(owner2));
        }

        [Test]
        public void ShouldCompareInvalidWithDifferntTypeValues()
        {
            ScopeOwner owner1 = new ScopeOwner("function1", ScopeOwnerType.Function);
            ScopeOwner owner2 = new ScopeOwner("function1", ScopeOwnerType.Main);

            Assert.AreEqual(1, owner1.CompareTo(owner2));
        }

        [Test]
        public void ShouldCompareInvalidWithDifferntBothValues()
        {
            ScopeOwner owner1 = new ScopeOwner("function1", ScopeOwnerType.Function);
            ScopeOwner owner2 = new ScopeOwner("function2", ScopeOwnerType.Main);

            Assert.AreEqual(1, owner1.CompareTo(owner2));
        }

        [Test]
        public void ShouldThrowExceptionOnInvalidObject()
        {
            ScopeOwner owner1 = new ScopeOwner("function1", ScopeOwnerType.Function);
            
            Assert.Throws<InvalidCastException>(()=> owner1.CompareTo(new int()));
        }
    }
}
