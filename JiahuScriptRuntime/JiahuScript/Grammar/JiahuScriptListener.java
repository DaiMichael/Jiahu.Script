// Generated from .\..\JiahuScript\Grammar\JiahuScript.g4 by ANTLR 4.5.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link JiahuScriptParser}.
 */
public interface JiahuScriptListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#script}.
	 * @param ctx the parse tree
	 */
	void enterScript(JiahuScriptParser.ScriptContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#script}.
	 * @param ctx the parse tree
	 */
	void exitScript(JiahuScriptParser.ScriptContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#funcDec}.
	 * @param ctx the parse tree
	 */
	void enterFuncDec(JiahuScriptParser.FuncDecContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#funcDec}.
	 * @param ctx the parse tree
	 */
	void exitFuncDec(JiahuScriptParser.FuncDecContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#funcParams}.
	 * @param ctx the parse tree
	 */
	void enterFuncParams(JiahuScriptParser.FuncParamsContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#funcParams}.
	 * @param ctx the parse tree
	 */
	void exitFuncParams(JiahuScriptParser.FuncParamsContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#funcParam}.
	 * @param ctx the parse tree
	 */
	void enterFuncParam(JiahuScriptParser.FuncParamContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#funcParam}.
	 * @param ctx the parse tree
	 */
	void exitFuncParam(JiahuScriptParser.FuncParamContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#stat}.
	 * @param ctx the parse tree
	 */
	void enterStat(JiahuScriptParser.StatContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#stat}.
	 * @param ctx the parse tree
	 */
	void exitStat(JiahuScriptParser.StatContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#print}.
	 * @param ctx the parse tree
	 */
	void enterPrint(JiahuScriptParser.PrintContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#print}.
	 * @param ctx the parse tree
	 */
	void exitPrint(JiahuScriptParser.PrintContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#break}.
	 * @param ctx the parse tree
	 */
	void enterBreak(JiahuScriptParser.BreakContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#break}.
	 * @param ctx the parse tree
	 */
	void exitBreak(JiahuScriptParser.BreakContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#switchStat}.
	 * @param ctx the parse tree
	 */
	void enterSwitchStat(JiahuScriptParser.SwitchStatContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#switchStat}.
	 * @param ctx the parse tree
	 */
	void exitSwitchStat(JiahuScriptParser.SwitchStatContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#caseBlock}.
	 * @param ctx the parse tree
	 */
	void enterCaseBlock(JiahuScriptParser.CaseBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#caseBlock}.
	 * @param ctx the parse tree
	 */
	void exitCaseBlock(JiahuScriptParser.CaseBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#defaultBlock}.
	 * @param ctx the parse tree
	 */
	void enterDefaultBlock(JiahuScriptParser.DefaultBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#defaultBlock}.
	 * @param ctx the parse tree
	 */
	void exitDefaultBlock(JiahuScriptParser.DefaultBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#whileStat}.
	 * @param ctx the parse tree
	 */
	void enterWhileStat(JiahuScriptParser.WhileStatContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#whileStat}.
	 * @param ctx the parse tree
	 */
	void exitWhileStat(JiahuScriptParser.WhileStatContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#ifStat}.
	 * @param ctx the parse tree
	 */
	void enterIfStat(JiahuScriptParser.IfStatContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#ifStat}.
	 * @param ctx the parse tree
	 */
	void exitIfStat(JiahuScriptParser.IfStatContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#foreachStat}.
	 * @param ctx the parse tree
	 */
	void enterForeachStat(JiahuScriptParser.ForeachStatContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#foreachStat}.
	 * @param ctx the parse tree
	 */
	void exitForeachStat(JiahuScriptParser.ForeachStatContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#returnStat}.
	 * @param ctx the parse tree
	 */
	void enterReturnStat(JiahuScriptParser.ReturnStatContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#returnStat}.
	 * @param ctx the parse tree
	 */
	void exitReturnStat(JiahuScriptParser.ReturnStatContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#block}.
	 * @param ctx the parse tree
	 */
	void enterBlock(JiahuScriptParser.BlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#block}.
	 * @param ctx the parse tree
	 */
	void exitBlock(JiahuScriptParser.BlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#variableDec}.
	 * @param ctx the parse tree
	 */
	void enterVariableDec(JiahuScriptParser.VariableDecContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#variableDec}.
	 * @param ctx the parse tree
	 */
	void exitVariableDec(JiahuScriptParser.VariableDecContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#variableDecAssign}.
	 * @param ctx the parse tree
	 */
	void enterVariableDecAssign(JiahuScriptParser.VariableDecAssignContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#variableDecAssign}.
	 * @param ctx the parse tree
	 */
	void exitVariableDecAssign(JiahuScriptParser.VariableDecAssignContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#assignment}.
	 * @param ctx the parse tree
	 */
	void enterAssignment(JiahuScriptParser.AssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#assignment}.
	 * @param ctx the parse tree
	 */
	void exitAssignment(JiahuScriptParser.AssignmentContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#arrayInitaliser}.
	 * @param ctx the parse tree
	 */
	void enterArrayInitaliser(JiahuScriptParser.ArrayInitaliserContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#arrayInitaliser}.
	 * @param ctx the parse tree
	 */
	void exitArrayInitaliser(JiahuScriptParser.ArrayInitaliserContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#objectCall}.
	 * @param ctx the parse tree
	 */
	void enterObjectCall(JiahuScriptParser.ObjectCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#objectCall}.
	 * @param ctx the parse tree
	 */
	void exitObjectCall(JiahuScriptParser.ObjectCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#objectCallList}.
	 * @param ctx the parse tree
	 */
	void enterObjectCallList(JiahuScriptParser.ObjectCallListContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#objectCallList}.
	 * @param ctx the parse tree
	 */
	void exitObjectCallList(JiahuScriptParser.ObjectCallListContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void enterFunctionCall(JiahuScriptParser.FunctionCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void exitFunctionCall(JiahuScriptParser.FunctionCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#functionList}.
	 * @param ctx the parse tree
	 */
	void enterFunctionList(JiahuScriptParser.FunctionListContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#functionList}.
	 * @param ctx the parse tree
	 */
	void exitFunctionList(JiahuScriptParser.FunctionListContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#expr}.
	 * @param ctx the parse tree
	 */
	void enterExpr(JiahuScriptParser.ExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#expr}.
	 * @param ctx the parse tree
	 */
	void exitExpr(JiahuScriptParser.ExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#call}.
	 * @param ctx the parse tree
	 */
	void enterCall(JiahuScriptParser.CallContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#call}.
	 * @param ctx the parse tree
	 */
	void exitCall(JiahuScriptParser.CallContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#arrayIndexer}.
	 * @param ctx the parse tree
	 */
	void enterArrayIndexer(JiahuScriptParser.ArrayIndexerContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#arrayIndexer}.
	 * @param ctx the parse tree
	 */
	void exitArrayIndexer(JiahuScriptParser.ArrayIndexerContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#arrayAccessor}.
	 * @param ctx the parse tree
	 */
	void enterArrayAccessor(JiahuScriptParser.ArrayAccessorContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#arrayAccessor}.
	 * @param ctx the parse tree
	 */
	void exitArrayAccessor(JiahuScriptParser.ArrayAccessorContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#definedType}.
	 * @param ctx the parse tree
	 */
	void enterDefinedType(JiahuScriptParser.DefinedTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#definedType}.
	 * @param ctx the parse tree
	 */
	void exitDefinedType(JiahuScriptParser.DefinedTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#value}.
	 * @param ctx the parse tree
	 */
	void enterValue(JiahuScriptParser.ValueContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#value}.
	 * @param ctx the parse tree
	 */
	void exitValue(JiahuScriptParser.ValueContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#identifier}.
	 * @param ctx the parse tree
	 */
	void enterIdentifier(JiahuScriptParser.IdentifierContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#identifier}.
	 * @param ctx the parse tree
	 */
	void exitIdentifier(JiahuScriptParser.IdentifierContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#number}.
	 * @param ctx the parse tree
	 */
	void enterNumber(JiahuScriptParser.NumberContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#number}.
	 * @param ctx the parse tree
	 */
	void exitNumber(JiahuScriptParser.NumberContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#sign}.
	 * @param ctx the parse tree
	 */
	void enterSign(JiahuScriptParser.SignContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#sign}.
	 * @param ctx the parse tree
	 */
	void exitSign(JiahuScriptParser.SignContext ctx);
	/**
	 * Enter a parse tree produced by {@link JiahuScriptParser#noneNumber}.
	 * @param ctx the parse tree
	 */
	void enterNoneNumber(JiahuScriptParser.NoneNumberContext ctx);
	/**
	 * Exit a parse tree produced by {@link JiahuScriptParser#noneNumber}.
	 * @param ctx the parse tree
	 */
	void exitNoneNumber(JiahuScriptParser.NoneNumberContext ctx);
}