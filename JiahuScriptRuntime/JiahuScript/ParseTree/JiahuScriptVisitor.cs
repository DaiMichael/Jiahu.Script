//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\..\JiahuScript\Grammar\JiahuScript.g4 by ANTLR 4.5.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="JiahuScriptParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.1")]
[System.CLSCompliant(false)]
public interface IJiahuScriptVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.script"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScript([NotNull] JiahuScriptParser.ScriptContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.funcDec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncDec([NotNull] JiahuScriptParser.FuncDecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.funcParams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncParams([NotNull] JiahuScriptParser.FuncParamsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.funcParam"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncParam([NotNull] JiahuScriptParser.FuncParamContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStat([NotNull] JiahuScriptParser.StatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.print"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrint([NotNull] JiahuScriptParser.PrintContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.break"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBreak([NotNull] JiahuScriptParser.BreakContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.switchStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSwitchStat([NotNull] JiahuScriptParser.SwitchStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.caseBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCaseBlock([NotNull] JiahuScriptParser.CaseBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.defaultBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefaultBlock([NotNull] JiahuScriptParser.DefaultBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.whileStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStat([NotNull] JiahuScriptParser.WhileStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.ifStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStat([NotNull] JiahuScriptParser.IfStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.foreachStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForeachStat([NotNull] JiahuScriptParser.ForeachStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.returnStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnStat([NotNull] JiahuScriptParser.ReturnStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] JiahuScriptParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.variableDec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableDec([NotNull] JiahuScriptParser.VariableDecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.variableDecAssign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableDecAssign([NotNull] JiahuScriptParser.VariableDecAssignContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] JiahuScriptParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.arrayInitaliser"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayInitaliser([NotNull] JiahuScriptParser.ArrayInitaliserContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.objectCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObjectCall([NotNull] JiahuScriptParser.ObjectCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.objectCallList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObjectCallList([NotNull] JiahuScriptParser.ObjectCallListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCall([NotNull] JiahuScriptParser.FunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.functionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionList([NotNull] JiahuScriptParser.FunctionListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] JiahuScriptParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.arrayIndexer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayIndexer([NotNull] JiahuScriptParser.ArrayIndexerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.arrayAccessor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayAccessor([NotNull] JiahuScriptParser.ArrayAccessorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.definedType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinedType([NotNull] JiahuScriptParser.DefinedTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] JiahuScriptParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifier([NotNull] JiahuScriptParser.IdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] JiahuScriptParser.NumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.sign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSign([NotNull] JiahuScriptParser.SignContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JiahuScriptParser.noneNumber"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNoneNumber([NotNull] JiahuScriptParser.NoneNumberContext context);
}
