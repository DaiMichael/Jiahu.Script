using JiahuScriptRuntime.Engine.Delegates;
using JiahuScriptRuntime.Engine.Interpreters;
using JiahuScriptRuntime.External;
using JiahuScriptRuntime.Memory;
using JiahuScriptRuntime.Memory.Symbols;

namespace JiahuScriptRuntime.Engine
{
    public class JiahuInterpreter
    {
        private readonly JiahuCompiler _jiahuCompiler;
        private readonly ScriptInterpreter _scriptInterpreter;

        public IManagedMemory ManagedMemory { get { return _jiahuCompiler.SymbolTable; } }

        public JiahuInterpreter(IRepository functionRepository = null, Output.Print print = null)
        {
            _jiahuCompiler = new JiahuCompiler(functionRepository);
            _scriptInterpreter = new ScriptInterpreter(ManagedMemory, new SymbolFacilitator(), functionRepository, print);
        }

        public void Run(string script)
        {
            _jiahuCompiler.Compile(script);
            _scriptInterpreter.Visit(new ScriptAstGenerator().Generate(script));
        }
    }
}
