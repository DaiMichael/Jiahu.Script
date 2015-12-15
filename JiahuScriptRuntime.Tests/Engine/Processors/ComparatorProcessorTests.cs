using System;
using System.Collections.Generic;
using JiahuScriptRuntime.Engine.Processors;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Processors
{
    [TestFixture]
    public class ComparatorProcessorTests
    {      
        [Test]
        [TestCaseSource("TestDataShouldValuesEqual")]
        public bool ShouldValuesEqual(object left, object right)
        {
            return (bool) new ComparatorProcessor().Equal(left, right);
        }

        public IEnumerable<TestCaseData> TestDataShouldValuesEqual
        {
            get
            {
                yield return new TestCaseData(1, 2).Returns(false);
                yield return new TestCaseData(200, 200).Returns(true);
                yield return new TestCaseData("200", 200).Returns(false);
                yield return new TestCaseData(true, true).Returns(true);
                yield return new TestCaseData(false, true).Returns(false);
                yield return new TestCaseData(32.5m, 32.5m).Returns(true);
                yield return new TestCaseData(32.5m, 32.4m).Returns(false);
                yield return new TestCaseData("hello", "hello").Returns(true);
                yield return new TestCaseData("goodbye", "hello").Returns(false);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 1)).Returns(true);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 11)).Returns(false);
            }
        }

        [Test]
        [TestCaseSource("TestDataShouldValuesBeGreaterThan")]
        public bool ShouldValuesBeGreaterThan(object left, object right)
        {
            return (bool) new ComparatorProcessor().GreaterThan(left, right);
        }

        public IEnumerable<TestCaseData> TestDataShouldValuesBeGreaterThan
        {
            get
            {
                yield return new TestCaseData(1, 2).Returns(false);
                yield return new TestCaseData(200, 200).Returns(false);
                yield return new TestCaseData(210, 200).Returns(true);
                yield return new TestCaseData(true, true).Returns(false);
                yield return new TestCaseData(false, true).Returns(false);
                yield return new TestCaseData(32.5m, 32.5m).Returns(false);
                yield return new TestCaseData(32.5m, 32.4m).Returns(true);
                yield return new TestCaseData(31.5m, 32.4m).Returns(false);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 1)).Returns(false);
                yield return new TestCaseData(new DateTime(2015, 4, 1), new DateTime(2015, 3, 1)).Returns(true);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 11)).Returns(false);
            }
        }

        [Test]
        [TestCaseSource("TestDataShouldValuesBeGreaterThanOrEqual")]
        public bool ShouldValuesBeGreaterThanOrEqual(object left, object right)
        {
            return (bool)new ComparatorProcessor().GreaterThanOrEqual(left, right);
        }

        public IEnumerable<TestCaseData> TestDataShouldValuesBeGreaterThanOrEqual
        {
            get
            {
                yield return new TestCaseData(1, 2).Returns(false);
                yield return new TestCaseData(200, 200).Returns(true);
                yield return new TestCaseData(210, 200).Returns(true);
                yield return new TestCaseData(true, true).Returns(true);
                yield return new TestCaseData(false, true).Returns(false);
                yield return new TestCaseData(32.5m, 32.5m).Returns(true);
                yield return new TestCaseData(32.5m, 32.4m).Returns(true);
                yield return new TestCaseData(31.5m, 32.4m).Returns(false);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 1)).Returns(true);
                yield return new TestCaseData(new DateTime(2015, 4, 1), new DateTime(2015, 3, 1)).Returns(true);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 11)).Returns(false);
            }
        }

        [Test]
        [TestCaseSource("TestDataShouldValuesBeLessThan")]
        public bool ShouldValuesBeLessThan(object left, object right)
        {
            return (bool)new ComparatorProcessor().LessThan(left, right);
        }

        public IEnumerable<TestCaseData> TestDataShouldValuesBeLessThan
        {
            get
            {
                yield return new TestCaseData(1, 2).Returns(true);
                yield return new TestCaseData(200, 200).Returns(false);
                yield return new TestCaseData(210, 200).Returns(false);
                yield return new TestCaseData(true, true).Returns(false);
                yield return new TestCaseData(false, true).Returns(false);
                yield return new TestCaseData(32.5m, 32.5m).Returns(false);
                yield return new TestCaseData(32.5m, 32.4m).Returns(false);
                yield return new TestCaseData(31.5m, 32.4m).Returns(true);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 1)).Returns(false);
                yield return new TestCaseData(new DateTime(2015, 4, 1), new DateTime(2015, 3, 1)).Returns(false);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 11)).Returns(true);
            }
        }

        [Test]
        [TestCaseSource("TestDataShouldValuesBeLessThanOrEqual")]
        public bool ShouldValuesBeLessThanOrEqual(object left, object right)
        {
            return (bool)new ComparatorProcessor().LessThanOrEqual(left, right);
        }

        public IEnumerable<TestCaseData> TestDataShouldValuesBeLessThanOrEqual
        {
            get
            {
                yield return new TestCaseData(1, 2).Returns(true);
                yield return new TestCaseData(200, 200).Returns(true);
                yield return new TestCaseData(210, 200).Returns(false);
                yield return new TestCaseData(true, true).Returns(true);
                yield return new TestCaseData(false, true).Returns(false);
                yield return new TestCaseData(32.5m, 32.5m).Returns(true);
                yield return new TestCaseData(32.5m, 32.4m).Returns(false);
                yield return new TestCaseData(31.5m, 32.4m).Returns(true);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 1)).Returns(true);
                yield return new TestCaseData(new DateTime(2015, 4, 1), new DateTime(2015, 3, 1)).Returns(false);
                yield return new TestCaseData(new DateTime(2015, 3, 1), new DateTime(2015, 3, 11)).Returns(true);
            }
        }

        [Test]
        [TestCase(true, true, ExpectedResult = true)]
        [TestCase(false, false, ExpectedResult = false)]
        [TestCase(true, false, ExpectedResult = false)]
        [TestCase(false, true, ExpectedResult = false)]
        public bool ShouldTestAnd(object left, object right)
        {
            return (bool)new ComparatorProcessor().And(left, right);
        }

        [Test]
        [TestCase(true, true, ExpectedResult = true)]
        [TestCase(false, false, ExpectedResult = false)]
        [TestCase(true, false, ExpectedResult = true)]
        [TestCase(false, true, ExpectedResult = true)]
        public bool ShouldTestOr(object left, object right)
        {
            return (bool)new ComparatorProcessor().Or(left, right);
        }
    }
}
