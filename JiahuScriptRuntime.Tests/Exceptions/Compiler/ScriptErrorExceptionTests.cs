using System;
using JiahuScriptRuntime.Exceptions.Compiler;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Exceptions.Compiler
{
    [TestFixture]
    public class ScriptErrorExceptionTests
    {
        [Test]
        public void ShouldConstruct()
        {
            Assert.DoesNotThrow(() => new ScriptErrorException("Message"));
        }

        [Test]
        public void ShouldReturnCorrectMessage()
        {
            ScriptErrorException exception = new ScriptErrorException("Message");

            Assert.IsNotNull(exception);
            Assert.AreEqual("Message", exception.Message);
        }

        [Test]
        public void ShouldAcceptInnerException()
        {
            Exception innerException = new Exception("Inner");
            ScriptErrorException exception = new ScriptErrorException("Message", innerException);

            Assert.IsNotNull(exception);
            Assert.IsNotNull(exception.InnerException);
            Assert.AreEqual("Message", exception.Message);
            Assert.AreEqual("Inner", exception.InnerException.Message);
        }
    }
}