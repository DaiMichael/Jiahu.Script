using System;
using JiahuScriptRuntime.External.Reflectors;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External.Reflectors
{
    [TestFixture]
    public class PropertyReflectorTests
    {
        [Test]
        public void ShouldThrowExceptionOnNullObject()
        {
            PropertyReflector reflector = new PropertyReflector();

            Assert.Throws<ArgumentNullException>(() => reflector.Reflect(null, string.Empty));
        }

        [Test]
        public void ShouldThrowExceptionOnNullCallName()
        {
            PropertyReflector reflector = new PropertyReflector();

            Assert.Throws<ArgumentNullException>(() => reflector.Reflect(new TestItem(), string.Empty));
        }

        [Test]
        public void ShouldThrowExceptionOnInvalidProperty()
        {
            PropertyReflector reflector = new PropertyReflector();

            Assert.Throws<ArgumentException>(() => reflector.Reflect(new TestItem(), "Count"));
        }

        [Test]
        public void ShouldGetPropertyValue()
        {
            PropertyReflector reflector = new PropertyReflector();
            TestItem testItem = new TestItem {Id = 99, Flag = true, Name = "bob"};


            Assert.AreEqual(99, reflector.Reflect(testItem, "Id"));
            Assert.AreEqual("bob", reflector.Reflect(testItem, "Name"));
            Assert.AreEqual(true, reflector.Reflect(testItem, "Flag"));
        }

        [Test]
        public void ShouldGetPropertyValueOnNestedObject()
        {
            PropertyReflector reflector = new PropertyReflector();
            TestItem testItem = new TestItem { Id = -1501, Name = "tom", Flag = true };
            TestItemNested testItemNested = new TestItemNested { Id = 21, Name = "jane", Item = testItem };

            Assert.AreEqual(21, reflector.Reflect(testItemNested, "Id"));
            Assert.AreEqual("jane", reflector.Reflect(testItemNested, "Name"));
            Assert.AreEqual(testItem, reflector.Reflect(testItemNested, "Item"));
        }

        #region Test Stubs

        internal class TestItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Flag { get; set; }
        }

        internal class TestItemNested
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public TestItem Item { get; set; }
        }

        #endregion
    }
}
