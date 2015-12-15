using System.Reflection;
using JiahuScriptRuntime.External.Attributes;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External.Attributes
{
    [TestFixture]
    public class ReturnTypeAttributeTests
    {
        [Test]
        public void ShouldGetAttributeBasicDetails()
        {
            Assert.AreEqual(typeof(int), typeof(TestFunctionalClassOne).GetCustomAttribute<ReturnTypeAttribute>().Type);
            Assert.AreEqual(typeof(string), typeof(TestFunctionalClassTwo).GetCustomAttribute<ReturnTypeAttribute>().Type);
        }

        [ReturnType(typeof(int))]
        internal class TestFunctionalClassOne { }

        [ReturnType(typeof(string))]
        internal class TestFunctionalClassTwo { }
    }
}
