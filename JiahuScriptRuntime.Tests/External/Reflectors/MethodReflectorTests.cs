using System;
using JiahuScriptRuntime.External.Reflectors;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External.Reflectors
{
    [TestFixture]
    public class MethodReflectorTests
    {
        [Test]
        public void ShouldThrowExceptionOnNullItem()
        {
            MethodReflector reflector = new MethodReflector();

            Assert.Throws<ArgumentNullException>(() => reflector.Reflect(null, string.Empty));
        }

        [Test]
        public void ShouldThrowExceptionOnNullCallItem()
        {
            MethodReflector reflector = new MethodReflector();

            Assert.Throws<ArgumentNullException>(() => reflector.Reflect(new List(), string.Empty));
        }

        [Test]
        public void ShouldThrowExceptionOnInvalidMethodCall()
        {
            MethodReflector reflector = new MethodReflector();

            Assert.Throws<ArgumentException>(() => reflector.Reflect(new List(), "NotACall"));
        }

        [Test]
        public void ShouldCallNoneParameteredMethod()
        {
            MethodReflector reflector = new MethodReflector();
            TestItem testItem = new TestItem { Id = 66 };

            Assert.AreEqual(66, reflector.Reflect(testItem, "GetId"));
        }

        [Test]
        public void ShouldCallWithIntParameteredMethod()
        {
            MethodReflector reflector = new MethodReflector();
            TestItem testItem = new TestItem { Id = 66 };

            Assert.AreEqual(5, reflector.Reflect(testItem, "Add", new object[]{2,3}));
        }

        [Test]
        public void ShouldCallWithStringParameteredMethod()
        {
            MethodReflector reflector = new MethodReflector();
            TestItem testItem = new TestItem { Id = 66 };

            Assert.AreEqual("Hello, I'm Zues!", reflector.Reflect(testItem, "Concat", new object[] { "Hello, ", "I'm", " Zues!" }));
        }

        #region Test Data

        internal class TestItem
        {
            public int Id { get; set; }

            public int GetId()
            {
                return Id;
            }

            public int Add(int a, int b)
            {
                return a + b;
            }

            public string Concat(string a, string b, string c)
            {
                return a + b + c;
            }
        }

        #endregion
    }
}
