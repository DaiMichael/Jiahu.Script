using System;
using System.Collections.Generic;
using JiahuScriptRuntime.External.RepositoryRegisters;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External.RepositoryRegisters
{
    [TestFixture]
    public class RepositoryRegisterTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new RepositoryRegister());
        }

        [Test]
        public void ShouldAddItemToRegister()
        {
            int local = 99;
            RepositoryRegister register = new RepositoryRegister();

            Assert.IsNotNull(register);
            Assert.AreEqual(0, register.Count);

            register.Register(local);

            Assert.AreEqual(1, register.Count);
            Assert.AreEqual(local, register.Resolve<int>());
        }

        [Test]
        public void ShouldAddTwoSameItemToRegister()
        {
            TestStubOne testStubOne = new TestStubOne { Id = 1 };
            TestStubOne testStubTwo = new TestStubOne { Id = 2 };

            RepositoryRegister register = new RepositoryRegister();

            Assert.IsNotNull(register);
            Assert.AreEqual(0, register.Count);

            register.Register(testStubOne);
            register.Register("a-key", testStubTwo);

            Assert.AreEqual(2, register.Count);
            Assert.AreEqual(testStubOne.Id, register.Resolve<TestStubOne>().Id);
            Assert.AreEqual(testStubTwo.Id, register.Resolve<TestStubOne>("a-key").Id);
        }

        [Test]
        public void ShouldThrowExceptionForDuplicateType()
        {
            RepositoryRegister register = new RepositoryRegister();

            Assert.DoesNotThrow(() => register.Register(new TestStubOne()));
            Assert.Throws<ArgumentException>(() => register.Register(new TestStubOne()));
        }

        [Test]
        public void ShouldThrowExceptionForTypeNotFound()
        {
            RepositoryRegister register = new RepositoryRegister();

            Assert.DoesNotThrow(() => register.Register(new TestStubOne()));
            Assert.Throws<KeyNotFoundException>(() => register.Resolve<Int32>());
        }

        internal class TestStubOne
        {
            public int Id { get; set; }
        }
    }
}
