using System;
using System.Collections.Generic;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.External.RepositoryRegisters;
using Moq;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Mock<IRepositoryRegister> mockRegisterMock = new Mock<IRepositoryRegister>();

            Assert.DoesNotThrow(() => new Repository(mockRegisterMock.Object));
        }

        [Test]
        public void ShouldThrowOnConstruct()
        {
            Assert.Throws<ArgumentNullException>(() => new Repository(null));
        }

        [Test]
        public void ShouldReturnRegisteredCounts()
        {
            Mock<IRepositoryRegister> mockRegisterMock = new Mock<IRepositoryRegister>();
            IRepository repository = new Repository(mockRegisterMock.Object);

            mockRegisterMock.Setup(x => x.Count).Returns(2);

            Assert.AreEqual(2, repository.Count);
        }

        [Test]
        public void ShouldHaveRegisteredItem()
        {
            Mock<IRepositoryRegister> mockRegisterMock = new Mock<IRepositoryRegister>();
            IRepository repository = new Repository(mockRegisterMock.Object);

            mockRegisterMock.Setup(x => x.Has<Int32>()).Returns(true);
            mockRegisterMock.Setup(x => x.Has<Decimal>()).Returns(false);
            mockRegisterMock.Setup(x => x.Has<String>()).Returns(true);
            mockRegisterMock.Setup(x => x.Has<Boolean>()).Returns(false);
            mockRegisterMock.Setup(x => x.Has("my-key")).Returns(true);
            mockRegisterMock.Setup(x => x.Has("no-key")).Returns(false);

            Assert.IsTrue(repository.Has<Int32>());
            Assert.IsTrue(repository.Has<String>());
            Assert.IsTrue(repository.Has("my-key"));

            Assert.IsFalse(repository.Has<Decimal>());
            Assert.IsFalse(repository.Has<Boolean>());
            Assert.IsFalse(repository.Has("no-key"));
        }

        [Test]
        public void ShouldResolveRegisteredItem()
        {
            Mock<IRepositoryRegister> mockRegisterMock = new Mock<IRepositoryRegister>();
            IRepository repository = new Repository(mockRegisterMock.Object);

            mockRegisterMock.Setup(x => x.Resolve<TestActivateOne>()).Returns(new TestActivateOne());
            mockRegisterMock.Setup(x => x.Resolve<TestActivateTwo>()).Returns(new TestActivateTwo());
            mockRegisterMock.Setup(x => x.Resolve<TestActivateTwo>("key")).Returns(new TestActivateTwo());
            mockRegisterMock.Setup(x => x.Resolve<string>()).Throws<KeyNotFoundException>();

            Assert.NotNull(repository.Resolve<TestActivateOne>());
            Assert.NotNull(repository.Resolve<TestActivateTwo>());
            Assert.NotNull(repository.Resolve<TestActivateTwo>("key"));
            Assert.Throws<KeyNotFoundException>(() => repository.Resolve<string>());
        }

        private class TestActivateOne { }
        private class TestActivateTwo { }
    }
}
