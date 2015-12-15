using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using JiahuScriptRuntime.Utilities;

namespace JiahuScriptRuntime.Engine
{
    public class ScriptAstGenerator
    {
        public IParseTree Generate(string script, IAntlrErrorListener<IToken> errorListener)
        {
            Guard.ThrowOnNullOrEmpty(script, "script");

            ITokenSource lexer = new JiahuScriptLexer(new AntlrInputStream(script));
            ITokenStream tokens = new CommonTokenStream(lexer);
            JiahuScriptParser parser = new JiahuScriptParser(tokens);
            parser.AddErrorListener(errorListener ?? new JiahuParserErrorListener());

            return parser.script();
        }

        public IParseTree Generate(string script)
        {
            return Generate(script, null);
        }
    }
}
