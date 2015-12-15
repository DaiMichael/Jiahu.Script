using System;
using JiahuScriptRuntime.Exceptions.External;
using JiahuScriptRuntime.External.Attributes;
using JiahuScriptRuntime.External.RepositoryRegisters;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External.RepositoryRegisters
{
    [TestFixture]
    public class FunctionRepositoryRegisterBaseTests
    {
        [Test]
        public void ShouldRegisterFunctionByAttribute()
        {
            FunctionRepositoryRegisterTest register = new FunctionRepositoryRegisterTest();

            Assert.DoesNotThrow(register.RegisterUsingFunctionAttribute<FunctionTestOne>);
            Assert.IsTrue(register.Has("FuncOne"));
        }

        [Test]
        public void ShouldRegisterFunctionTwoKeysByAttribute()
        {
            FunctionRepositoryRegisterTest register = new FunctionRepositoryRegisterTest();

            Assert.DoesNotThrow(register.RegisterUsingFunctionAttribute<FunctionTestTwo>);
            Assert.IsTrue(register.Has("FuncTwo"));
            Assert.IsTrue(register.Has("F.FuncTwo"));
        }

        [Test]
        public void ShouldThrowExceptionWithNoFunctionAttribute()
        {
            FunctionRepositoryRegisterTest register = new FunctionRepositoryRegisterTest();

            Assert.Throws<MissingFunctionAttributeException>(register.RegisterUsingFunctionAttribute<List>);
        }
    }

    internal class FunctionRepositoryRegisterTest : FunctionRepositoryRegisterBase { }

    [Function("FuncOne", "General")]
    internal class FunctionTestOne { }

    [Function("FuncTwo", "General")]
    [Function("F.FuncTwo", "General")]
    internal class FunctionTestTwo { }
}
