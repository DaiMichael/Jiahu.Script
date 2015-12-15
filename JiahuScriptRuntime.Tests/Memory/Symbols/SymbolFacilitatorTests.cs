using System;
using System.Collections.Generic;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.Exceptions.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Memory.Symbols
{
    [TestFixture]
    public class SymbolFacilitatorTests
    {
        [Test]
        public void ShouldConstructFacilitator()
        {
            Assert.DoesNotThrow(()=> new SymbolFacilitator());
        }

        public void ShouldReturnThrowExceptionOnNullIdentifierContext()
        {
            SymbolFacilitator facilitator = new SymbolFacilitator();

            Assert.Throws<ArgumentNullException>(() => facilitator.Create(null, null));
        }

        [Test]
        public void ShouldReturnThrowExceptionOnNullDefinedTypeContext()
        {
            SymbolFacilitator facilitator = new SymbolFacilitator();
            
            Assert.Throws<ArgumentNullException>(() => facilitator.Create("var", null));
        }

        [Test]
        [TestCase("myVar", "int", typeof(IntVariableSymbol))]
        [TestCase("newVar", "string", typeof(StringVariableSymbol))]
        [TestCase("flag", "bool", typeof(BooleanVariableSymbol))]
        [TestCase("number", "decimal", typeof(DecimalVariableSymbol))]
        [TestCase("dob", "date", typeof(DateVariableSymbol))]
        [TestCase("timeOfDayAndDate", "datetime", typeof(DateTimeVariableSymbol))]
        [TestCase("newVar", "string[]", typeof(StringArrayVariableSymbol))]
        [TestCase("flag", "bool[]", typeof(BooleanArrayVariableSymbol))]
        [TestCase("number", "decimal[]", typeof(DecimalArrayVariableSymbol))]
        [TestCase("dob", "date[]", typeof(DateArrayVariableSymbol))]
        [TestCase("timeOfDayAndDate", "datetime[]", typeof(DateTimeArrayVariableSymbol))]
        [TestCase("myVar", "real", null, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void ShouldReturnCreatedSymbol(string variableName, string variableType, Type symbolType)
        {
            SymbolFacilitator facilitator = new SymbolFacilitator();
            Symbol symbol = facilitator.Create(variableName, variableType);

            Assert.NotNull(symbol);
            Assert.AreEqual(variableName, symbol.Name);
            Assert.AreEqual(symbolType, symbol.GetType());
        }

        [Test]
        [TestCase("string", typeof(string))]
        [TestCase("int", typeof(int))]
        [TestCase("bool", typeof(bool))]
        [TestCase("decimal", typeof(decimal))]
        [TestCase("date", typeof(DateTime))]
        [TestCase("datetime", typeof(DateTime))]
        [TestCase("float", null, ExpectedException = typeof(InvalidTypeException))]
        [TestCase("", null, ExpectedException = typeof(ArgumentNullException))]
        public void ShouldConvertValueType(string toConvertType, Type expectedType)
        {
            SymbolFacilitator facilitator = new SymbolFacilitator();

            Assert.AreEqual(expectedType, facilitator.ConvertValueType(toConvertType));
        }

        [Test]
        public void ShouldConvertStringArrayValueType()
        {
            Assert.AreEqual(typeof(string[]), new SymbolFacilitator().ConvertValueType("string[]"));
        }

        [Test]
        public void ShouldConvertIntArrayValueType()
        {
            Assert.AreEqual(typeof(int[]), new SymbolFacilitator().ConvertValueType("int[]"));
        }

        [Test]
        public void ShouldConvertDecimalArrayValueType()
        {
            Assert.AreEqual(typeof(decimal[]), new SymbolFacilitator().ConvertValueType("decimal[]"));
        }

        [Test]
        public void ShouldConvertBoolArrayValueType()
        {
            Assert.AreEqual(typeof(bool[]), new SymbolFacilitator().ConvertValueType("bool[]"));
        }

        [Test]
        public void ShouldConvertDateTimeArrayValueType()
        {
            Assert.AreEqual(typeof(DateTime[]), new SymbolFacilitator().ConvertValueType("datetime[]"));
        }

        [Test]
        public void ShouldConvertDateArrayValueType()
        {
            Assert.AreEqual(typeof(DateTime[]), new SymbolFacilitator().ConvertValueType("date[]"));
        }

        [Test]
        public void ShouldThrowExceptionOnInvalidArrayType()
        {
            Assert.Throws<InvalidTypeException>(() => new SymbolFacilitator().ConvertValueType("float[]"));
        }

        [Test, TestCaseSource("TestCaseDataShoulCheckTypesAreAssignable")]
        public bool ShouldCheckTypesAreAssignable(Symbol assigned, Symbol assigning)
        {
            return new SymbolFacilitator().AllowedTypeAssignment(assigned, assigning);
        }

        [Test]
        [TestCase("", ExpectedException = typeof(ArgumentNullException))]
        [TestCase("string", ExpectedResult = "string")]
        [TestCase("string[]", ExpectedResult = "string")]
        [TestCase("int", ExpectedResult = "int")]
        [TestCase("int[]", ExpectedResult = "int")]
        [TestCase("decimal", ExpectedResult = "decimal")]
        [TestCase("decimal[]", ExpectedResult = "decimal")]
        [TestCase("bool", ExpectedResult = "bool")]
        [TestCase("bool[]", ExpectedResult = "bool")]
        [TestCase("datetime", ExpectedResult = "datetime")]
        [TestCase("datetime[]", ExpectedResult = "datetime")]
        [TestCase("date", ExpectedResult = "date")]
        [TestCase("date[]", ExpectedResult = "date")]
        public string ShouldGetBaseTypeFromDefinedType(string type)
        {
            return new SymbolFacilitator().GetBaseType(type);
        }

        [Test, TestCaseSource("TestCaseDataShouldSetValueInSymbol")]
        public void ShouldSetValueInSymbol(Symbol variable, object value)
        {
            new SymbolFacilitator().SetSymbolValue(variable, value);
        }

        [Test, TestCaseSource("TestCaseDataShouldSetSymbolValueInSymbol")]
        public void ShouldSetSymbolValueInSymbol(Symbol variable, Symbol value)
        {
            new SymbolFacilitator().SetSymbolValue(variable, value);
        }

        [Test, TestCaseSource("TestCaseDataShouldReturnValueAsString")]
        public string ShouldReturnValueAsString(Symbol variable)
        {
            Console.WriteLine(variable.GetType().Name);
            return new SymbolFacilitator().GetValueAsString(variable);
        }

        [Test, TestCaseSource("TestCaseDataShouldReturnItemInArray")]
        public string ShouldReturnItemInArray(Symbol variable, int index)
        {
            Console.WriteLine(variable.GetType().Name);
            return new SymbolFacilitator().GetValueAsString(variable, index);
        }

        [Test, TestCaseSource("TestCaseDataShouldReturnObject")]
        public object ShouldGetValueAsObject(Symbol variable)
        {
            Console.WriteLine(variable.GetType().Name);
            return new SymbolFacilitator().GetValueAsObject(variable);
        }

        [Test, TestCaseSource("TestCaseDataShouldReturnObjectItemInArray")]
        public object ShouldGetItemFromArrayAsObject(Symbol variable, int index)
        {
            Console.WriteLine(variable.GetType().Name + ", " + index);
            return new SymbolFacilitator().GetValueAsObject(variable, index);
        }

        [Test]
        [TestCase("{1,2,3}", "int", ExpectedResult = 3)]
        [TestCase("{\"one\",\"two\",\"three\", \"four\"}", "string", ExpectedResult = 4)]
        [TestCase("{}", "string", ExpectedResult = 0)]
        [TestCase("{\"\"}", "string", ExpectedResult = 1)]
        [TestCase("{true, false}", "bool", ExpectedResult = 2)]
        [TestCase("{1, 1.3, 89.5}", "decimal", ExpectedResult = 3)]
        [TestCase("{true, nan}", "bool", ExpectedException = typeof(FormatException))]
        public int ShouldConvertStringToArray(string values, string type)
        {
            Array array = new SymbolFacilitator().ConvertToArray(values, type);
            return array.Length;
        }

        [Test]
        [TestCase(typeof(Single), ExpectedException = typeof(InvalidVariableTypeException))]
        [TestCase(typeof(string), ExpectedResult = "string")]
        [TestCase(typeof(String), ExpectedResult = "string")]
        [TestCase(typeof(string[]), ExpectedResult = "string[]")]
        [TestCase(typeof(String[]), ExpectedResult = "string[]")]
        [TestCase(typeof(decimal), ExpectedResult = "decimal")]
        [TestCase(typeof(Decimal), ExpectedResult = "decimal")]
        [TestCase(typeof(decimal[]), ExpectedResult = "decimal[]")]
        [TestCase(typeof(Decimal[]), ExpectedResult = "decimal[]")]
        [TestCase(typeof(int), ExpectedResult = "int")]
        [TestCase(typeof(Int32), ExpectedResult = "int")]
        [TestCase(typeof(int[]), ExpectedResult = "int[]")]
        [TestCase(typeof(Int32[]), ExpectedResult = "int[]")]
        [TestCase(typeof(bool), ExpectedResult = "bool")]
        [TestCase(typeof(Boolean), ExpectedResult = "bool")]
        [TestCase(typeof(bool[]), ExpectedResult = "bool[]")]
        [TestCase(typeof(Boolean[]), ExpectedResult = "bool[]")]
        [TestCase(typeof(DateTime), ExpectedResult = "datetime")]
        [TestCase(typeof(DateTime[]), ExpectedResult = "datetime[]")]
        public string ShouldReturnJaihuScriptType(Type type)
        {
            return new SymbolFacilitator().ConvertTypeName(type);
        }

        #region TestData

        public IEnumerable<TestCaseData> TestCaseDataShouldReturnObject
        {
            get
            {
                yield return new TestCaseData(new IntVariableSymbol("var") { Value = 1 }).Returns(1);
                yield return new TestCaseData(new IntVariableSymbol("var")).Returns(0);
                yield return new TestCaseData(new IntArrayVariableSymbol("var") { Value = new[] { 1, 2, 3 } }).Returns(new[] { 1, 2, 3 });
                yield return new TestCaseData(new IntArrayVariableSymbol("var")).Returns(new int[]{});
                yield return new TestCaseData(new DecimalVariableSymbol("var") { Value = 78.4m }).Returns(78.4m);
                yield return new TestCaseData(new DecimalArrayVariableSymbol("var") { Value = new[] { 1.2m, 32.5m, 3 } }).Returns(new [] {1.2m, 32.5m, 3m});
                yield return new TestCaseData(new StringVariableSymbol("var") { Value = "bob" }).Returns("bob");
                yield return new TestCaseData(new StringArrayVariableSymbol("var") { Value = new[] { "tom" } }).Returns(new [] {"tom"});
                yield return new TestCaseData(new BooleanVariableSymbol("var") { Value = true }).Returns(true);
                yield return new TestCaseData(new BooleanVariableSymbol("var")).Returns(false);
                yield return new TestCaseData(new BooleanArrayVariableSymbol("var") { Value = new[] { true, false, true } }).Returns(new [] { true, false, true});
                yield return new TestCaseData(new DateTimeVariableSymbol("var") { Value = new DateTime(2015, 1, 2, 15, 1, 45) }).Returns(new DateTime(2015, 1, 2, 15, 1, 45));
                yield return new TestCaseData(new DateTimeArrayVariableSymbol("var") { Value = new[] { new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23) } }).Returns(new[] { new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23) });
                yield return new TestCaseData(new DateVariableSymbol("var") { Value = new DateTime(2015, 1, 2, 15, 1, 45) }).Returns(new DateTime(2015, 1, 2, 15, 1, 45));
                yield return new TestCaseData(new DateArrayVariableSymbol("var") { Value = new[] { new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23) } }).Returns(new[] { new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23) });
            }
        }

        public IEnumerable<TestCaseData> TestCaseDataShouldReturnObjectItemInArray
        {
            get
            {
                yield return new TestCaseData(new IntVariableSymbol("var"), 1).Throws(typeof(ArgumentException));
                yield return new TestCaseData(new IntArrayVariableSymbol("var") { Value = new[] { 1, 2, 3 } }, 1).Returns(2);
                yield return new TestCaseData(new IntArrayVariableSymbol("var") { Value = new[] { 1, 2, 3 } }, 4).Throws(typeof(IndexOutOfRangeException));
                yield return new TestCaseData(new StringArrayVariableSymbol("var") { Value = new[] { "tom", "tim", "rob" } }, 2).Returns("rob");
                yield return new TestCaseData(new BooleanArrayVariableSymbol("var") { Value = new[] { true, false, true } }, 0).Returns(true);
                yield return new TestCaseData(new DateTimeArrayVariableSymbol("var") { Value = new[] { new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23) } }, 0).Returns(new DateTime(2015, 1, 2, 15, 1, 45));
                yield return new TestCaseData(new DateArrayVariableSymbol("var") { Value = new[] { new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23) } }, 1).Returns(new DateTime(2015, 6, 7, 9, 18, 23));
            }
        }

        public IEnumerable<TestCaseData> TestCaseDataShouldReturnItemInArray
        {
            get
            {
                yield return new TestCaseData(new IntVariableSymbol("var"), 1).Throws(typeof(ArgumentException));
                yield return new TestCaseData(new IntArrayVariableSymbol("var") {Value = new[] {1, 2, 3}}, 1).Returns("2");
                yield return new TestCaseData(new IntArrayVariableSymbol("var") { Value = new[] { 1, 2, 3 } }, 4).Throws(typeof(IndexOutOfRangeException));
                yield return new TestCaseData(new StringArrayVariableSymbol("var") {Value = new[] {"tom", "tim", "rob"}}, 2).Returns("rob");
                yield return new TestCaseData(new BooleanArrayVariableSymbol("var") {Value = new[] {true, false, true}}, 0).Returns("True");
                yield return new TestCaseData(new DateTimeArrayVariableSymbol("var") {Value = new[] {new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23)}}, 0).Returns("02/01/2015 15:01:45");
                yield return new TestCaseData(new DateArrayVariableSymbol("var") {Value = new[] {new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23)}}, 1).Returns("07/06/2015");
            }
        }

        public IEnumerable<TestCaseData> TestCaseDataShouldReturnValueAsString
        {
            get
            {
                yield return new TestCaseData(new IntVariableSymbol("var") { Value = 1 }).Returns("1");
                yield return new TestCaseData(new IntVariableSymbol("var")).Returns("0");
                yield return new TestCaseData(new IntArrayVariableSymbol("var") { Value = new [] {1,2,3}}).Returns("{1, 2, 3}");
                yield return new TestCaseData(new IntArrayVariableSymbol("var")).Returns("{}");
                yield return new TestCaseData(new DecimalVariableSymbol("var") { Value = 78.4m }).Returns("78.4");
                yield return new TestCaseData(new DecimalArrayVariableSymbol("var") { Value = new[] { 1.2m, 32.5m, 3 } }).Returns("{1.2, 32.5, 3}");
                yield return new TestCaseData(new StringVariableSymbol("var") { Value = "bob" }).Returns("bob");
                yield return new TestCaseData(new StringArrayVariableSymbol("var") { Value = new[] { "tom" } }).Returns("{tom}");
                yield return new TestCaseData(new BooleanVariableSymbol("var") { Value = true }).Returns("True");
                yield return new TestCaseData(new BooleanVariableSymbol("var")).Returns("False");
                yield return new TestCaseData(new BooleanArrayVariableSymbol("var") { Value = new[] { true, false, true } }).Returns("{True, False, True}");
                yield return new TestCaseData(new DateTimeVariableSymbol("var") { Value = new DateTime(2015, 1, 2, 15, 1, 45) }).Returns("02/01/2015 15:01:45");
                yield return new TestCaseData(new DateTimeArrayVariableSymbol("var") { Value = new[] { new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23) } }).Returns("{02/01/2015 15:01:45, 07/06/2015 09:18:23}");
                yield return new TestCaseData(new DateVariableSymbol("var") { Value = new DateTime(2015, 1, 2, 15, 1, 45) }).Returns("02/01/2015");
                yield return new TestCaseData(new DateArrayVariableSymbol("var") { Value = new[] { new DateTime(2015, 1, 2, 15, 1, 45), new DateTime(2015, 6, 7, 9, 18, 23) } }).Returns("{02/01/2015, 07/06/2015}"); 
            }
        }

        public IEnumerable<TestCaseData> TestCaseDataShouldSetSymbolValueInSymbol
        {
            get
            {
                yield return new TestCaseData(new IntVariableSymbol("var"), new StringVariableSymbol("assign") { Value = "error" }).Throws(typeof(InvalidVariableTypeException));
                yield return new TestCaseData(new IntVariableSymbol("var"), new IntVariableSymbol("assign") { Value = 23 });
                yield return new TestCaseData(new DecimalVariableSymbol("var"), new DecimalVariableSymbol("assign") { Value = 23.9m });
                yield return new TestCaseData(new StringVariableSymbol("var"), new StringVariableSymbol("assign") { Value = "hello" });
                yield return new TestCaseData(new BooleanVariableSymbol("var"), new BooleanVariableSymbol("assign") { Value = true });
                yield return new TestCaseData(new DateVariableSymbol("var"), new DateVariableSymbol("assign") { Value = new DateTime(2015, 3 , 11) });
                yield return new TestCaseData(new DateTimeVariableSymbol("var"), new DateTimeVariableSymbol("assign") { Value = new DateTime(2015, 3, 11, 15, 4, 23) });
                yield return new TestCaseData(new IntArrayVariableSymbol("var"), new IntArrayVariableSymbol("assign") { Value = new [] { 23, 1 } });
                yield return new TestCaseData(new DecimalArrayVariableSymbol("var"), new DecimalArrayVariableSymbol("assign") { Value = new [] { 23m, 89m } });
                yield return new TestCaseData(new BooleanArrayVariableSymbol("var"), new BooleanArrayVariableSymbol("assign") { Value = new [] { true, false } });
                yield return new TestCaseData(new StringArrayVariableSymbol("var"), new StringArrayVariableSymbol("assign") { Value = new[] { "here", "now" } });
                yield return new TestCaseData(new DateTimeArrayVariableSymbol("var"), new DateTimeArrayVariableSymbol("assign") { Value = new[] { new DateTime(2015, 3, 11), new DateTime(2015, 3, 1) } });
                yield return new TestCaseData(new DateArrayVariableSymbol("var"), new DateArrayVariableSymbol("assign") { Value = new[] { new DateTime(2015, 3, 11, 14, 52, 10), new DateTime(2013, 8, 12, 9, 23, 10) } });
            }
        }

        public IEnumerable<TestCaseData> TestCaseDataShouldSetValueInSymbol
        {
            get
            {
                yield return new TestCaseData(new IntVariableSymbol("var"), 1);
                yield return new TestCaseData(new IntVariableSymbol("var"), "S").Throws(typeof(ValueCastException));
                yield return new TestCaseData(new DecimalVariableSymbol("var"), 1);
                yield return new TestCaseData(new DecimalVariableSymbol("var"), 1.2m);
                yield return new TestCaseData(new DecimalVariableSymbol("var"), "S").Throws(typeof(ValueCastException));
                yield return new TestCaseData(new StringVariableSymbol("var"), "1.0");
                yield return new TestCaseData(new StringVariableSymbol("var"), "MyName");
                yield return new TestCaseData(new StringVariableSymbol("var"), String.Empty);
                yield return new TestCaseData(new BooleanVariableSymbol("var"), "true");
                yield return new TestCaseData(new BooleanVariableSymbol("var"), "false");
                yield return new TestCaseData(new BooleanVariableSymbol("var"), "ambivalent").Throws(typeof(ValueCastException));
                yield return new TestCaseData(new DateVariableSymbol("var"), "10/09/2015");
                yield return new TestCaseData(new DateVariableSymbol("var"), "01/03/1975");
                yield return new TestCaseData(new DateVariableSymbol("var"), new DateTime(2015, 3, 1));
                yield return new TestCaseData(new DateVariableSymbol("var"), "\"01/03/1975\"");
                yield return new TestCaseData(new DateVariableSymbol("var"), "Not-A-Date").Throws(typeof(ValueCastException));
                yield return new TestCaseData(new DateTimeVariableSymbol("var"), "25/12/2015 12:58:00");
                yield return new TestCaseData(new DateTimeVariableSymbol("var"), "01/03/1975 15:26:45");
                yield return new TestCaseData(new DateTimeVariableSymbol("var"), new DateTime(2015, 5, 7, 1, 30, 23));
                yield return new TestCaseData(new DateTimeVariableSymbol("var"), "Not-A-DateTime").Throws(typeof(ValueCastException));
                yield return new TestCaseData(new IntArrayVariableSymbol("var"), "{1, 2}");
                yield return new TestCaseData(new IntArrayVariableSymbol("var"), "{1}");
                yield return new TestCaseData(new IntArrayVariableSymbol("var"), new[] {1,2});
                yield return new TestCaseData(new IntArrayVariableSymbol("var"), "{1, 'string'}").Throws(typeof(ValueCastException));
                yield return new TestCaseData(new DecimalArrayVariableSymbol("var"), "{1, 2}");
                yield return new TestCaseData(new DecimalArrayVariableSymbol("var"), "{1.3, 2.4}");
                yield return new TestCaseData(new DecimalArrayVariableSymbol("var"), new[] { 1m, 2.4m });
                yield return new TestCaseData(new DecimalArrayVariableSymbol("var"), "{1, 'string'}").Throws(typeof(ValueCastException));
                yield return new TestCaseData(new StringArrayVariableSymbol("var"), "{'dave', 'bob'}");
                yield return new TestCaseData(new StringArrayVariableSymbol("var"), "{\"hello\", 'mixed'}");
                yield return new TestCaseData(new StringArrayVariableSymbol("var"), new[] {"hello", "mixed"});
                yield return new TestCaseData(new BooleanArrayVariableSymbol("var"), "{true}");
                yield return new TestCaseData(new BooleanArrayVariableSymbol("var"), "{'true', false}");
                yield return new TestCaseData(new BooleanArrayVariableSymbol("var"), "{'yes'}").Throws(typeof(ValueCastException));
                yield return new TestCaseData(new DateArrayVariableSymbol("var"), "{'10/09/2015'}");
                yield return new TestCaseData(new DateArrayVariableSymbol("var"), new[] {new DateTime(2015, 1, 1)});
                yield return new TestCaseData(new DateArrayVariableSymbol("var"), "{'10/09/2015', 01/03/1975}");
                yield return new TestCaseData(new DateArrayVariableSymbol("var"), "{'NADate'}").Throws(typeof(ValueCastException));
                yield return new TestCaseData(new DateTimeArrayVariableSymbol("var"), "{'10/09/2015 12:58:00'}");
                yield return new TestCaseData(new DateTimeArrayVariableSymbol("var"), "{'10/09/2015 12:58:00', 01/03/1975 15:26:45}");
                yield return new TestCaseData(new DateTimeArrayVariableSymbol("var"), new[] { new DateTime(2015, 1, 1, 1, 1, 1), new DateTime(2015, 3, 1, 12, 10, 11) });
                yield return new TestCaseData(new DateTimeArrayVariableSymbol("var"), "{'NADate'}").Throws(typeof(ValueCastException));
            }
        }

        public IEnumerable<TestCaseData> TestCaseDataShoulCheckTypesAreAssignable
        {
            get
            {
                // none array data
                yield return new TestCaseData(new IntVariableSymbol(""), new IntVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new IntVariableSymbol(""), new DecimalVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new IntVariableSymbol(""), new StringVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new IntVariableSymbol(""), new BooleanVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new IntVariableSymbol(""), new DateVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new IntVariableSymbol(""), new DateTimeVariableSymbol("")).Returns(false);

                yield return new TestCaseData(new DecimalVariableSymbol(""), new IntVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new DecimalVariableSymbol(""), new DecimalVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new DecimalVariableSymbol(""), new StringVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DecimalVariableSymbol(""), new BooleanVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DecimalVariableSymbol(""), new DateVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DecimalVariableSymbol(""), new DateTimeVariableSymbol("")).Returns(false);

                yield return new TestCaseData(new StringVariableSymbol(""), new IntVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringVariableSymbol(""), new DecimalVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringVariableSymbol(""), new StringVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringVariableSymbol(""), new BooleanVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringVariableSymbol(""), new DateVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringVariableSymbol(""), new DateTimeVariableSymbol("")).Returns(true);

                yield return new TestCaseData(new BooleanVariableSymbol(""), new IntVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new BooleanVariableSymbol(""), new DecimalVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new BooleanVariableSymbol(""), new StringVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new BooleanVariableSymbol(""), new BooleanVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new BooleanVariableSymbol(""), new DateVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new BooleanVariableSymbol(""), new DateTimeVariableSymbol("")).Returns(false);

                yield return new TestCaseData(new DateVariableSymbol(""), new IntVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateVariableSymbol(""), new DecimalVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateVariableSymbol(""), new StringVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateVariableSymbol(""), new BooleanVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateVariableSymbol(""), new DateVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new DateVariableSymbol(""), new DateTimeVariableSymbol("")).Returns(false);

                yield return new TestCaseData(new DateTimeVariableSymbol(""), new IntVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateTimeVariableSymbol(""), new DecimalVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateTimeVariableSymbol(""), new StringVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateTimeVariableSymbol(""), new BooleanVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateTimeVariableSymbol(""), new DateVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new DateTimeVariableSymbol(""), new DateTimeVariableSymbol("")).Returns(true);

                // array data
                yield return new TestCaseData(new IntArrayVariableSymbol(""), new IntArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new IntArrayVariableSymbol(""), new DecimalArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new IntArrayVariableSymbol(""), new StringArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new IntArrayVariableSymbol(""), new BooleanArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new IntArrayVariableSymbol(""), new DateArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new IntArrayVariableSymbol(""), new DateTimeArrayVariableSymbol("")).Returns(false);

                yield return new TestCaseData(new DecimalArrayVariableSymbol(""), new IntArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new DecimalArrayVariableSymbol(""), new DecimalArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new DecimalArrayVariableSymbol(""), new StringArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DecimalArrayVariableSymbol(""), new BooleanArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DecimalArrayVariableSymbol(""), new DateArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DecimalArrayVariableSymbol(""), new DateTimeArrayVariableSymbol("")).Returns(false);

                yield return new TestCaseData(new StringArrayVariableSymbol(""), new IntArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringArrayVariableSymbol(""), new DecimalArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringArrayVariableSymbol(""), new StringArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringArrayVariableSymbol(""), new BooleanArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringArrayVariableSymbol(""), new DateArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new StringArrayVariableSymbol(""), new DateTimeArrayVariableSymbol("")).Returns(true);

                yield return new TestCaseData(new BooleanArrayVariableSymbol(""), new IntArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new BooleanArrayVariableSymbol(""), new DecimalArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new BooleanArrayVariableSymbol(""), new StringArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new BooleanArrayVariableSymbol(""), new BooleanArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new BooleanArrayVariableSymbol(""), new DateArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new BooleanArrayVariableSymbol(""), new DateTimeArrayVariableSymbol("")).Returns(false);

                yield return new TestCaseData(new DateArrayVariableSymbol(""), new IntArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateArrayVariableSymbol(""), new DecimalArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateArrayVariableSymbol(""), new StringArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateArrayVariableSymbol(""), new BooleanArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateArrayVariableSymbol(""), new DateArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new DateArrayVariableSymbol(""), new DateTimeArrayVariableSymbol("")).Returns(false);

                yield return new TestCaseData(new DateTimeArrayVariableSymbol(""), new IntArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateTimeArrayVariableSymbol(""), new DecimalArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateTimeArrayVariableSymbol(""), new StringArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateTimeArrayVariableSymbol(""), new BooleanArrayVariableSymbol("")).Returns(false);
                yield return new TestCaseData(new DateTimeArrayVariableSymbol(""), new DateArrayVariableSymbol("")).Returns(true);
                yield return new TestCaseData(new DateTimeArrayVariableSymbol(""), new DateTimeArrayVariableSymbol("")).Returns(true);

                yield return new TestCaseData(null, null).Returns(false).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new DateArrayVariableSymbol(""), null).Returns(false).Throws(typeof(ArgumentNullException));
            }
        }

        #endregion
    }
}