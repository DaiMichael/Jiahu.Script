using JiahuScriptRuntime.Exceptions.External;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.External
{
    [TestFixture]
    public class MissingFunctionAttributeExceptionTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new MissingFunctionAttributeException(typeof(int)));
        }
    }
}