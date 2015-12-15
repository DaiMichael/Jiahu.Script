using System;
using System.Collections.Generic;
using JiahuScriptRuntime.External.Reflectors;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External.Reflectors
{
    [TestFixture]
    public class DictionaryReflectorTests
    {
        [Test]
        public void ShouldThrowExceptionOnNullObject()
        {
            DictionaryReflector reflector = new DictionaryReflector();

            Assert.Throws<ArgumentNullException>(() => reflector.Reflect(null, string.Empty));
        }

        [Test]
        public void ShouldThrowExceptionOnNullOrEmptyCallName()
        {
            DictionaryReflector reflector = new DictionaryReflector();

            Assert.Throws<ArgumentNullException>(() => reflector.Reflect(new List<string>(), string.Empty));
        }

        [Test]
        public void ShouldThrowExceptionOnObjectNoDictionary()
        {
            DictionaryReflector reflector = new DictionaryReflector();

            Assert.Throws<ArgumentException>(() => reflector.Reflect(new List<string>(), "Item"));
        }

        [Test]
        public void ShouldThrowExceptionOnItemNotInDictionary()
        {
            DictionaryReflector reflector = new DictionaryReflector();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            Assert.Throws<ArgumentException>(() => reflector.Reflect(dictionary, "key"));
        }

        [Test]
        [TestCase("call1", ExpectedResult = 1)]
        [TestCase("call2", ExpectedResult = "2")]
        [TestCase("call3", ExpectedResult = false)]
        [TestCase("call4", ExpectedException = typeof(ArgumentException))]
        public object ShouldGetsKey(string itemName)
        {
            DictionaryReflector reflector = new DictionaryReflector();
            Dictionary<string, object> dictionary = new Dictionary<string, object> {{"call1", 1}, {"call2", "2"}, {"call3", false}};

            return reflector.Reflect(dictionary, itemName);
        }
    }
}
