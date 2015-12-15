using System.Linq;
using System.Reflection;
using JiahuScriptRuntime.External.Attributes;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External.Attributes
{
    [TestFixture]
    public class ParameterAttributeTests
    {
        [Test]
        public void ShouldGetAttributeBasicDetails()
        {
            Assert.AreEqual("Param1", typeof(TestFunctionalClassOne).GetCustomAttribute<ParameterAttribute>().Name);
            Assert.AreEqual(typeof(int), typeof(TestFunctionalClassOne).GetCustomAttribute<ParameterAttribute>().Type);
        }

        [Test]
        public void ShouldGetAttributeMultipleDetails()
        {
            Assert.AreEqual(1, typeof(TestFunctionalClassTwo).GetCustomAttributes<ParameterAttribute>().Count(x => x.Name == "Param1" && x.Type == typeof(int)));
            Assert.AreEqual(1, typeof(TestFunctionalClassTwo).GetCustomAttributes<ParameterAttribute>().Count(x => x.Name == "Param2" && x.Type == typeof(string) && x.Description == "my desc" && x.Optional));
        }

        [Parameter(1, "Param1", typeof(int))]
        internal class TestFunctionalClassOne { }

        [Parameter(1, "Param1", typeof(int))]
        [Parameter(2, "Param2", typeof(string), true, "my desc")]
        internal class TestFunctionalClassTwo { }
    }
}
