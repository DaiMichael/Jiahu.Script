using System;
using System.Collections.Generic;
using JiahuScriptRuntime.Engine.Processors;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Processors
{
    [TestFixture]
    public class MathProcessorTests
    {
        [Test]
        [TestCaseSource("TestDataShouldAdd")]
        public object ShouldAdd(object left, object right)
        {
            return new MathProcessor().Add(left, right);
        }

        [Test]
        [TestCaseSource("TestDataShouldMinus")]
        public object ShouldMinus(object left, object right)
        {
            return new MathProcessor().Minus(left, right);
        }

        [Test]
        [TestCaseSource("TestDataShouldMultiply")]
        public object ShouldMultiply(object left, object right)
        {
            return new MathProcessor().Multiply(left, right);
        }

        [Test]
        [TestCaseSource("TestDataShouldDivide")]
        public object ShouldDivide(object left, object right)
        {
            return new MathProcessor().Divide(left, right);
        }

        #region TestData

        public IEnumerable<TestCaseData> TestDataShouldAdd
        {
            get
            {
                yield return new TestCaseData(1, 2).Returns(3);
                yield return new TestCaseData(1.5m, 2.5m).Returns(4);
                yield return new TestCaseData(1, 2.5m).Returns(3.5m);
                yield return new TestCaseData(1.5m, 5).Returns(6.5m);
                yield return new TestCaseData("nan", 5).Throws(typeof(ArgumentException));
                yield return new TestCaseData(5, true).Throws(typeof(ArgumentException));
            }
        }

        public IEnumerable<TestCaseData> TestDataShouldMinus
        {
            get
            {
                yield return new TestCaseData(5, 3).Returns(2);
                yield return new TestCaseData(10m, 2.5m).Returns(7.5m);
                yield return new TestCaseData(-20, 2.5m).Returns(-22.5m);
                yield return new TestCaseData(7.5m, 5).Returns(2.5m);
                yield return new TestCaseData("nan", 5).Throws(typeof(ArgumentException));
                yield return new TestCaseData(5, true).Throws(typeof(ArgumentException));
            }
        }

        public IEnumerable<TestCaseData> TestDataShouldMultiply
        {
            get
            {
                yield return new TestCaseData(5, 3).Returns(15);
                yield return new TestCaseData(13m, 2.5m).Returns(32.5m);
                yield return new TestCaseData(-20, 2.5m).Returns(-50);
                yield return new TestCaseData(7.5m, 5).Returns(37.5m);
                yield return new TestCaseData("nan", 5).Throws(typeof(ArgumentException));
                yield return new TestCaseData(5, DateTime.Now).Throws(typeof(ArgumentException));
            }
        }

        public IEnumerable<TestCaseData> TestDataShouldDivide
        {
            get
            {
                yield return new TestCaseData(10, 2).Returns(5);
                yield return new TestCaseData(9, 2).Returns(4.5);
                yield return new TestCaseData(8.5m, 2.5m).Returns(3.4m);
                yield return new TestCaseData(-20, 2.5m).Returns(-8);
                yield return new TestCaseData(7.5m, 5).Returns(1.5m);
                yield return new TestCaseData(false, 5).Throws(typeof(ArgumentException));
                yield return new TestCaseData(5, DateTime.Now).Throws(typeof(ArgumentException));
            }
        }

        #endregion
    }
}
