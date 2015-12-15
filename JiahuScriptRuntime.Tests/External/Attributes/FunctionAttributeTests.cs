using System.Linq;
using System.Reflection;
using JiahuScriptRuntime.External.Attributes;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External.Attributes
{
    [TestFixture]
    public class FunctionAttributeTests
    {
        [Test]
        public void ShouldGetAttributeBasicDetails()
        {
            Assert.AreEqual("Func1", typeof(TestFunctionalClassOne).GetCustomAttribute<FunctionAttribute>().Name);
            Assert.AreEqual("General", typeof(TestFunctionalClassOne).GetCustomAttribute<FunctionAttribute>().Category);
        }

        [Test]
        public void ShouldGetAttributeMultipleDetails()
        {
            Assert.AreEqual(1, typeof(TestFunctionalClassTwo).GetCustomAttributes<FunctionAttribute>().Count(x => x.Name == "Func2" && x.Category == "General"));
            Assert.AreEqual(1, typeof(TestFunctionalClassTwo).GetCustomAttributes<FunctionAttribute>().Count(x => x.Name == "F.Func2" && x.Category == "Legacy"));
        }

        [Function("Func1", "General")]
        internal class TestFunctionalClassOne { }

        [Function("Func2", "General")]
        [Function("F.Func2", "Legacy")]
        internal class TestFunctionalClassTwo { }
    }
}
