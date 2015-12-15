using Antlr4.Runtime;
using JiahuScriptRuntime.Exceptions.Compiler;

namespace JiahuScriptRuntime.Engine
{
    public class JiahuParserErrorListener : IAntlrErrorListener<IToken>
    {
        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new ScriptErrorException(string.Format("Jiahu script error on line {0} at position {1} : {2}.", line, charPositionInLine, msg), e);
        }
    }
}