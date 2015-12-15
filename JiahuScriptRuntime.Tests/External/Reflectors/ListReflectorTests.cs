using System;
using System.Collections.Generic;
using JiahuScriptRuntime.External.Reflectors;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External.Reflectors
{
    [TestFixture]
    public class ListReflectorTests
    {
        [Test]
        public void ShouldThrowExceptionOnNullObject()
        {
            ListReflector reflector = new ListReflector();

            Assert.Throws<ArgumentNullException>(() => reflector.Reflect(null, string.Empty));
        }

        [Test]
        public void ShouldThrowExceptionOnObjectNotList()
        {
            ListReflector reflector = new ListReflector();

            Assert.Throws<ArgumentException>(() => reflector.Reflect(new Dictionary<string, object>(), "Item"));
        }

        [Test]
        public void ShouldReturnListAsArray()
        {
            ListReflector reflector = new ListReflector();
            List<object> list = new List<object> {"hello", "here"};

            Assert.AreEqual("hello", ((object[])reflector.Reflect(list, string.Empty))[0]);
            Assert.AreEqual("here", ((object[])reflector.Reflect(list, string.Empty))[1]);
        }
    }
}
