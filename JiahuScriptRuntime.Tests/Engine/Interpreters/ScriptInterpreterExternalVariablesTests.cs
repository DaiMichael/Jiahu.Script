using System;
using System.Collections.Generic;
using System.Dynamic;
using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Engine;
using JiahuScriptRuntime.Engine.Compilers;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;
using NUnit.Framework;

namespace JiahuScriptRuntime.Tests.Engine.Interpreters
{
    [TestFixture]
    public class ScriptInterpreterExternalVariablesTests
    {
        [Test]
        [TestCase("string stringVar = P.Id", ExpectedResult = "89")]
        [TestCase("string stringVar = P.Name", ExpectedResult = "Stock")]
        [TestCase("string stringVar = P.ListedExchange.Name", ExpectedResult = "LSE")]
        [TestCase("string stringVar = P.GetExchange().Id", ExpectedResult = "99")]
        [TestCase("string stringVar = D.ExchangeTestData.Id", ExpectedResult = "67")]
        [TestCase("string stringVar = P.GetStrike(0)", ExpectedResult = "1.2")]
        [TestCase("string stringVar = P.GetStrike(2)", ExpectedResult = "5.4")]
        [TestCase("string stringVar = \"nan\" foreach(decimal strike in P.Strikes) { stringVar = strike }", ExpectedResult = "5.4")]
        [TestCase("string stringVar = \"nan\" foreach(decimal strike in P.Strikes) { stringVar = strike break }", ExpectedResult = "1.2")]
        [TestCase("string stringVar = D.NotHere.Id", ExpectedException = typeof(ArgumentException))]
        [TestCase("string stringVar = F.NOT-DEFINED", ExpectedException = typeof(VariableNotDefinedException))]
        public string ShouldRunExternalVariableStatements(string script)
        {
            VariableRepository variableRepository = new VariableRepository();
            SymbolFacilitator symbolFacilitator = new SymbolFacilitator();
            IManagedMemory managedMemory = new ManagedMemory(true);
            IParseTree parseTree = new ScriptAstGenerator().Generate(script);

            variableRepository.Register(new ObjectVariableSymbol("P") { Value = CreateData() });
            variableRepository.Register(new ObjectVariableSymbol("D") { Value = CreateDictionary() });
            ManagedMemory.ApplyGlobalVariables(managedMemory, variableRepository);

            SymbolCompiler symbolCompiler = new SymbolCompiler(managedMemory, symbolFacilitator);
            FunctionReferenceCompiler functionReferenceCompiler = new FunctionReferenceCompiler(managedMemory, symbolFacilitator);
            ScriptInterpreter interpreter = new ScriptInterpreter(managedMemory, symbolFacilitator);

            symbolCompiler.Visit(parseTree);
            functionReferenceCompiler.Visit(parseTree);
            interpreter.Visit(parseTree);

            return symbolFacilitator.GetValueAsString(managedMemory.GetScope(new ScopeOwner(ScopeOwner.Main, ScopeOwnerType.Main)).GetSymbol("stringVar"));
        }

        #region Test Classes

        private Dictionary<string, object> CreateDictionary()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("ExchangeTestData", new ExchangeTestData {Id = 67, Name = "NYSE"});
            return dictionary;
        }

        private ProductTestData CreateData()
        {
            return new ProductTestData {Id = 89, Name = "Stock", Strikes = new[] {1.2, 3.4, 5.4}, ListedExchange = new ExchangeTestData {Id = 99, Name = "LSE"}};
        }

        public class ProductTestData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double[] Strikes { get; set; }
            public ExchangeTestData ListedExchange { get; set; }
            public ExchangeTestData GetExchange() { return ListedExchange; }
            public double GetStrike(int index) { return Strikes[index]; }
        }

        public class ExchangeTestData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        #endregion
    }
}
