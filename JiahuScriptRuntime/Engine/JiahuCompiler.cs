using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Engine.Compilers;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;

namespace JiahuScriptRuntime.Engine
{
    public class JiahuCompiler
    {
        private readonly IManagedMemory _symbolTable;
        private readonly SymbolCompiler _symbolCompiler;
        private readonly FunctionReferenceCompiler _functionCompiler;

        public IManagedMemory SymbolTable { get { return _symbolTable; } }

        public JiahuCompiler() : this(null) { }

        public JiahuCompiler(IRepository funcRepository)
        {
            _symbolTable = new ManagedMemory(true);
            _symbolCompiler = new SymbolCompiler(_symbolTable, new SymbolFacilitator());
            _functionCompiler = new FunctionReferenceCompiler(_symbolTable, new SymbolFacilitator(), funcRepository);
        }

        public bool Compile(string script)
        {
            IParseTree parseTree = new ScriptAstGenerator().Generate(script, new JiahuParserErrorListener());

            _symbolCompiler.Visit(parseTree);
            _functionCompiler.Visit(parseTree);

            return true;
        }
    }
}
