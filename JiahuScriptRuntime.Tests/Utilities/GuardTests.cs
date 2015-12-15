using System;
using NUnit.Framework;
using JGuard = JiahuScriptRuntime.Utilities.Guard;

namespace JiahuScriptRuntime.Tests.Utilities
{
    [TestFixture]
    public class GuardTests
    {
        [Test]
        public void ShouldNotThrowOnNoneNullObject()
        {
            Assert.DoesNotThrow(() => JGuard.ThrowOnNull(new Int32(), "variable"));
        }

        [Test]
        public void ShouldThrowOnNullObject()
        { 
            Assert.Throws<ArgumentNullException>(() => JGuard.ThrowOnNull(null, "variable"));
        }

        [Test]
        public void ShouldNotThrowOnNoneNullString()
        {
            Assert.DoesNotThrow(() => JGuard.ThrowOnNullOrEmpty("here is some text", "variable"));
        }

        [Test]
        public void ShouldThrowOnNullString()
        {
            Assert.Throws<ArgumentNullException>(() => JGuard.ThrowOnNullOrEmpty(null, "variable"));
        }

        [Test]
        public void ShouldThrowOnEmptyString()
        {
            Assert.Throws<ArgumentNullException>(() => JGuard.ThrowOnNullOrEmpty("", "variable"));
        }
    }
}
