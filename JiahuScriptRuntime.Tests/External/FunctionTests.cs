using System;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.External.Attributes;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.External
{
    [TestFixture]
    public class FunctionTests
    {
        [Test]
        public void ShouldConstructFunction()
        {
            Assert.DoesNotThrow(() => new TestFunctionNoPrams());
        }

        [Test]
        public void ShouldThrowExceptionOnNoFunctionAttribute()
        {
            Assert.Throws<ArgumentNullException>(() => new TestFunctionExceptionNoFunctionAttribute());
        }

        [Test]
        public void ShouldThrowExceptionOnNoReturnTypeAttribute()
        {
            Assert.Throws<ArgumentNullException>(() => new TestFunctionExceptionNoReturnTypeAttribute());
        }

        [Test]
        public void ShouldHaveNoParameters()
        {
            IFunction function = new TestFunctionNoPrams();

            Assert.AreEqual("FuncNoParams", function.Definitions.Find(x => x.Name == "FuncNoParams").Name);
            Assert.AreEqual("General", function.Definitions.Find(x => x.Name == "FuncNoParams").Category);
            Assert.AreEqual(0, function.Parameters.Count);
            Assert.AreEqual(typeof(int), function.ReturnType.Type);
        }

        [Test]
        public void ShouldHaveOneParameters()
        {
            IFunction function = new TestFunctionOneParam();

            Assert.IsNotNull(function.Definitions.Find(x => x.Name == "FuncOneParams" && x.Category == "General"));
            Assert.IsNotNull(function.Definitions.Find(x => x.Name == "F.Func" && x.Category == "Legacy"));
            Assert.AreEqual(1, function.Parameters.Count);
            Assert.AreEqual("id", function.Parameters[0].Name);
            Assert.AreEqual(typeof(int), function.Parameters[0].Type);
            Assert.AreEqual(typeof(bool), function.ReturnType.Type);
        }

        [Test]
        public void ShouldHaveTwoParameters()
        {
            IFunction function = new TestFunctionTwoParam();

            Assert.IsNotNull(function.Definitions.Find(x => x.Name == "FuncTwoParams" && x.Category == "Maths"));
            Assert.AreEqual(2, function.Parameters.Count);
            Assert.AreEqual("id", function.Parameters[0].Name);
            Assert.AreEqual(typeof(int), function.Parameters[0].Type);
            Assert.AreEqual("name", function.Parameters[1].Name);
            Assert.AreEqual(typeof(string), function.Parameters[1].Type);
            Assert.AreEqual(typeof(decimal), function.ReturnType.Type);
        }

        [Test]
        public void ShouldCheckCorrectNumberOfParametersAndType()
        {
            IFunction function = new TestFunctionOneParam();

            Assert.DoesNotThrow(() => function.Eval(string.Empty, new object[] {1}));
        }

        [Test]
        public void ShouldThrowsOnIncorrectParameters()
        {
            IFunction function = new TestFunctionOneParam();

            Assert.Throws<FunctionParameterCountException>(() => function.Eval(string.Empty, new object[] { 1, 2 }));
        }

        [Test]
        public void ShouldPassParameterCountCheckOnOptional()
        {
            IFunction function = new TestFunctionTwoParam();

            Assert.DoesNotThrow(() => function.Eval(string.Empty, new object[] { 1 }));
            Assert.DoesNotThrow(() => function.Eval(string.Empty, new object[] { 1, "bob" }));
        }

        [Test]
        public void ShouldThrowOnInvalidParameterType()
        {
            IFunction function = new TestFunctionTwoParam();

            Assert.Throws<InvalidFunctionParameterException>(() => function.Eval(string.Empty, new object[] { 1, 1 }));
        }

        [Test]
        [TestCase("PlainFunction", ExpectedResult = "PlainFunction")]
        [TestCase("F.TagFunction", ExpectedResult = "TagFunction")]
        [TestCase("", ExpectedResult = "")]
        [TestCase(".Function", ExpectedResult = "Function")]
        [TestCase("T.", ExpectedResult = "")]
        [TestCase("T.F.Name", ExpectedResult = "Name")]
        public string ShouldReturnCorrectFunctioName(string name)
        {
            return new TestFunctionName().FunctionName(name);
        }

        [Function("FuncNoParams", "General")]
        [ReturnType(typeof(int))]
        internal class TestFunctionNoPrams : FunctionBase { }

        [Function("F.Func", "Legacy")]
        [Function("FuncOneParams", "General")]
        [Parameter(1, "id", typeof (int))]
        [ReturnType(typeof (bool))]
        internal class TestFunctionOneParam : FunctionBase
        {
            public override object Eval(string functionName, object[] parameters)
            {
                CheckParametersAndThrowOnMissMatch(parameters);
                return true;
            }
        }

        [Function("FuncTwoParams", "Maths")]
        [Parameter(1, "id", typeof (int))]
        [Parameter(2, "name", typeof (string), true)]
        [ReturnType(typeof (decimal))]
        internal class TestFunctionTwoParam : FunctionBase
        {
            public override object Eval(string functionName, object[] parameters)
            {
                CheckParametersAndThrowOnMissMatch(parameters);
                return true;
            }
        }

        internal class TestFunctionExceptionNoFunctionAttribute : FunctionBase { }

        [Function("TestFunctionExceptionNoReturnTypeAttribute", "General")]
        internal class TestFunctionExceptionNoReturnTypeAttribute : FunctionBase { }

        [Function("FuncName", "General")]
        [ReturnType(typeof (int))]
        internal class TestFunctionName : FunctionBase
        {
            public string FunctionName(string functionName)
            {
                return GetFunctionNameWithoutTag(functionName);
            }
        }
    }
}
