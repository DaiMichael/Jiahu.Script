// Generated from .\..\JiahuScript\Grammar\JiahuScript.g4 by ANTLR 4.5.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JiahuScriptParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.5.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		NUMBERS=1, NONE_NUMBER_VALUES=2, TYPE=3, ARRAY=4, NULL=5, BOOL=6, STRING=7, 
		INT=8, DECIMAL=9, DATE=10, DATETIME=11, OBJECT=12, FUNCTION=13, VOID=14, 
		PRINT=15, IF=16, ELSE=17, WHILE=18, SWITCH=19, CASE=20, DEFAULT=21, RETURN=22, 
		FOREACH=23, BREAK=24, IN=25, FALSE=26, TRUE=27, OPEN_BRACE=28, CLOSE_BRACE=29, 
		OPEN_BRACKET=30, CLOSE_BRACKET=31, OPEN_PARENS=32, CLOSE_PARENS=33, COMMA=34, 
		COLON=35, QUESTION=36, PLUS=37, MINUS=38, TIMES=39, DIV=40, PLUSPLUS=41, 
		MINUSMINUS=42, NOT=43, NOT_EQUAL=44, LESS_OR_EQUAL=45, GREATER_OR_EQUAL=46, 
		GREATER_THAN=47, LESS_THAN=48, EQUAL=49, ASSIGN=50, AMPERSAND=51, DOT=52, 
		LINE_COMMENT=53, COMMENT=54, WS=55, FUNCID=56, ID=57;
	public static final int
		RULE_script = 0, RULE_funcDec = 1, RULE_funcParams = 2, RULE_funcParam = 3, 
		RULE_stat = 4, RULE_print = 5, RULE_break = 6, RULE_switchStat = 7, RULE_caseBlock = 8, 
		RULE_defaultBlock = 9, RULE_whileStat = 10, RULE_ifStat = 11, RULE_foreachStat = 12, 
		RULE_returnStat = 13, RULE_block = 14, RULE_variableDec = 15, RULE_variableDecAssign = 16, 
		RULE_assignment = 17, RULE_arrayInitaliser = 18, RULE_objectCall = 19, 
		RULE_objectCallList = 20, RULE_functionCall = 21, RULE_functionList = 22, 
		RULE_expr = 23, RULE_call = 24, RULE_arrayIndexer = 25, RULE_arrayAccessor = 26, 
		RULE_definedType = 27, RULE_value = 28, RULE_identifier = 29, RULE_number = 30, 
		RULE_sign = 31, RULE_noneNumber = 32;
	public static final String[] ruleNames = {
		"script", "funcDec", "funcParams", "funcParam", "stat", "print", "break", 
		"switchStat", "caseBlock", "defaultBlock", "whileStat", "ifStat", "foreachStat", 
		"returnStat", "block", "variableDec", "variableDecAssign", "assignment", 
		"arrayInitaliser", "objectCall", "objectCallList", "functionCall", "functionList", 
		"expr", "call", "arrayIndexer", "arrayAccessor", "definedType", "value", 
		"identifier", "number", "sign", "noneNumber"
	};

	private static final String[] _LITERAL_NAMES = {
		null, null, null, null, null, "'null'", "'bool'", "'string'", "'int'", 
		"'decimal'", "'date'", "'datetime'", "'object'", "'function'", "'void'", 
		"'print'", "'if'", "'else'", "'while'", "'switch'", "'case'", "'default'", 
		"'return'", "'foreach'", "'break'", "'in'", null, null, "'{'", "'}'", 
		"'['", "']'", "'('", "')'", "','", "':'", "'?'", "'+'", "'-'", "'*'", 
		"'/'", "'++'", "'--'", "'!'", "'!='", "'<='", "'>='", "'>'", "'<'", "'=='", 
		"'='", "'&'", "'.'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "NUMBERS", "NONE_NUMBER_VALUES", "TYPE", "ARRAY", "NULL", "BOOL", 
		"STRING", "INT", "DECIMAL", "DATE", "DATETIME", "OBJECT", "FUNCTION", 
		"VOID", "PRINT", "IF", "ELSE", "WHILE", "SWITCH", "CASE", "DEFAULT", "RETURN", 
		"FOREACH", "BREAK", "IN", "FALSE", "TRUE", "OPEN_BRACE", "CLOSE_BRACE", 
		"OPEN_BRACKET", "CLOSE_BRACKET", "OPEN_PARENS", "CLOSE_PARENS", "COMMA", 
		"COLON", "QUESTION", "PLUS", "MINUS", "TIMES", "DIV", "PLUSPLUS", "MINUSMINUS", 
		"NOT", "NOT_EQUAL", "LESS_OR_EQUAL", "GREATER_OR_EQUAL", "GREATER_THAN", 
		"LESS_THAN", "EQUAL", "ASSIGN", "AMPERSAND", "DOT", "LINE_COMMENT", "COMMENT", 
		"WS", "FUNCID", "ID"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "JiahuScript.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public JiahuScriptParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ScriptContext extends ParserRuleContext {
		public List<StatContext> stat() {
			return getRuleContexts(StatContext.class);
		}
		public StatContext stat(int i) {
			return getRuleContext(StatContext.class,i);
		}
		public List<FuncDecContext> funcDec() {
			return getRuleContexts(FuncDecContext.class);
		}
		public FuncDecContext funcDec(int i) {
			return getRuleContext(FuncDecContext.class,i);
		}
		public ScriptContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_script; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterScript(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitScript(this);
		}
	}

	public final ScriptContext script() throws RecognitionException {
		ScriptContext _localctx = new ScriptContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_script);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(68); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				setState(68);
				switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
				case 1:
					{
					setState(66);
					stat();
					}
					break;
				case 2:
					{
					setState(67);
					funcDec();
					}
					break;
				}
				}
				setState(70); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NUMBERS) | (1L << NONE_NUMBER_VALUES) | (1L << TYPE) | (1L << ARRAY) | (1L << PRINT) | (1L << IF) | (1L << WHILE) | (1L << SWITCH) | (1L << RETURN) | (1L << FOREACH) | (1L << BREAK) | (1L << OPEN_BRACE) | (1L << OPEN_PARENS) | (1L << MINUS) | (1L << NOT) | (1L << FUNCID) | (1L << ID))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FuncDecContext extends ParserRuleContext {
		public DefinedTypeContext definedType() {
			return getRuleContext(DefinedTypeContext.class,0);
		}
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode OPEN_PARENS() { return getToken(JiahuScriptParser.OPEN_PARENS, 0); }
		public TerminalNode CLOSE_PARENS() { return getToken(JiahuScriptParser.CLOSE_PARENS, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public List<FuncParamsContext> funcParams() {
			return getRuleContexts(FuncParamsContext.class);
		}
		public FuncParamsContext funcParams(int i) {
			return getRuleContext(FuncParamsContext.class,i);
		}
		public FuncDecContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_funcDec; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterFuncDec(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitFuncDec(this);
		}
	}

	public final FuncDecContext funcDec() throws RecognitionException {
		FuncDecContext _localctx = new FuncDecContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_funcDec);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(72);
			definedType();
			setState(73);
			identifier();
			setState(74);
			match(OPEN_PARENS);
			setState(78);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==TYPE || _la==ARRAY) {
				{
				{
				setState(75);
				funcParams();
				}
				}
				setState(80);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(81);
			match(CLOSE_PARENS);
			setState(82);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FuncParamsContext extends ParserRuleContext {
		public List<FuncParamContext> funcParam() {
			return getRuleContexts(FuncParamContext.class);
		}
		public FuncParamContext funcParam(int i) {
			return getRuleContext(FuncParamContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(JiahuScriptParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(JiahuScriptParser.COMMA, i);
		}
		public FuncParamsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_funcParams; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterFuncParams(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitFuncParams(this);
		}
	}

	public final FuncParamsContext funcParams() throws RecognitionException {
		FuncParamsContext _localctx = new FuncParamsContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_funcParams);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(84);
			funcParam();
			setState(89);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(85);
				match(COMMA);
				setState(86);
				funcParam();
				}
				}
				setState(91);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FuncParamContext extends ParserRuleContext {
		public DefinedTypeContext definedType() {
			return getRuleContext(DefinedTypeContext.class,0);
		}
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public FuncParamContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_funcParam; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterFuncParam(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitFuncParam(this);
		}
	}

	public final FuncParamContext funcParam() throws RecognitionException {
		FuncParamContext _localctx = new FuncParamContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_funcParam);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(92);
			definedType();
			setState(93);
			identifier();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatContext extends ParserRuleContext {
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public PrintContext print() {
			return getRuleContext(PrintContext.class,0);
		}
		public BreakContext break() {
			return getRuleContext(BreakContext.class,0);
		}
		public SwitchStatContext switchStat() {
			return getRuleContext(SwitchStatContext.class,0);
		}
		public WhileStatContext whileStat() {
			return getRuleContext(WhileStatContext.class,0);
		}
		public IfStatContext ifStat() {
			return getRuleContext(IfStatContext.class,0);
		}
		public ForeachStatContext foreachStat() {
			return getRuleContext(ForeachStatContext.class,0);
		}
		public ReturnStatContext returnStat() {
			return getRuleContext(ReturnStatContext.class,0);
		}
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public VariableDecAssignContext variableDecAssign() {
			return getRuleContext(VariableDecAssignContext.class,0);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public StatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stat; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterStat(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitStat(this);
		}
	}

	public final StatContext stat() throws RecognitionException {
		StatContext _localctx = new StatContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_stat);
		try {
			setState(106);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(95);
				block();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(96);
				print();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(97);
				break();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(98);
				switchStat();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(99);
				whileStat();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(100);
				ifStat();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(101);
				foreachStat();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(102);
				returnStat();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(103);
				assignment();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(104);
				variableDecAssign();
				}
				break;
			case 11:
				enterOuterAlt(_localctx, 11);
				{
				setState(105);
				expr(0);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PrintContext extends ParserRuleContext {
		public TerminalNode PRINT() { return getToken(JiahuScriptParser.PRINT, 0); }
		public TerminalNode OPEN_PARENS() { return getToken(JiahuScriptParser.OPEN_PARENS, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PARENS() { return getToken(JiahuScriptParser.CLOSE_PARENS, 0); }
		public PrintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_print; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterPrint(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitPrint(this);
		}
	}

	public final PrintContext print() throws RecognitionException {
		PrintContext _localctx = new PrintContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_print);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(108);
			match(PRINT);
			setState(109);
			match(OPEN_PARENS);
			setState(110);
			expr(0);
			setState(111);
			match(CLOSE_PARENS);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BreakContext extends ParserRuleContext {
		public TerminalNode BREAK() { return getToken(JiahuScriptParser.BREAK, 0); }
		public BreakContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_break; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterBreak(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitBreak(this);
		}
	}

	public final BreakContext break() throws RecognitionException {
		BreakContext _localctx = new BreakContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_break);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(113);
			match(BREAK);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SwitchStatContext extends ParserRuleContext {
		public TerminalNode SWITCH() { return getToken(JiahuScriptParser.SWITCH, 0); }
		public TerminalNode OPEN_PARENS() { return getToken(JiahuScriptParser.OPEN_PARENS, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PARENS() { return getToken(JiahuScriptParser.CLOSE_PARENS, 0); }
		public TerminalNode OPEN_BRACE() { return getToken(JiahuScriptParser.OPEN_BRACE, 0); }
		public TerminalNode CLOSE_BRACE() { return getToken(JiahuScriptParser.CLOSE_BRACE, 0); }
		public List<CaseBlockContext> caseBlock() {
			return getRuleContexts(CaseBlockContext.class);
		}
		public CaseBlockContext caseBlock(int i) {
			return getRuleContext(CaseBlockContext.class,i);
		}
		public DefaultBlockContext defaultBlock() {
			return getRuleContext(DefaultBlockContext.class,0);
		}
		public SwitchStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_switchStat; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterSwitchStat(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitSwitchStat(this);
		}
	}

	public final SwitchStatContext switchStat() throws RecognitionException {
		SwitchStatContext _localctx = new SwitchStatContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_switchStat);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(115);
			match(SWITCH);
			setState(116);
			match(OPEN_PARENS);
			setState(117);
			expr(0);
			setState(118);
			match(CLOSE_PARENS);
			setState(119);
			match(OPEN_BRACE);
			setState(121); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(120);
				caseBlock();
				}
				}
				setState(123); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==CASE );
			setState(126);
			_la = _input.LA(1);
			if (_la==DEFAULT) {
				{
				setState(125);
				defaultBlock();
				}
			}

			setState(128);
			match(CLOSE_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CaseBlockContext extends ParserRuleContext {
		public TerminalNode CASE() { return getToken(JiahuScriptParser.CASE, 0); }
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public TerminalNode COLON() { return getToken(JiahuScriptParser.COLON, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public CaseBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_caseBlock; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterCaseBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitCaseBlock(this);
		}
	}

	public final CaseBlockContext caseBlock() throws RecognitionException {
		CaseBlockContext _localctx = new CaseBlockContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_caseBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
			match(CASE);
			setState(131);
			value();
			setState(132);
			match(COLON);
			setState(133);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DefaultBlockContext extends ParserRuleContext {
		public TerminalNode DEFAULT() { return getToken(JiahuScriptParser.DEFAULT, 0); }
		public TerminalNode COLON() { return getToken(JiahuScriptParser.COLON, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public DefaultBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_defaultBlock; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterDefaultBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitDefaultBlock(this);
		}
	}

	public final DefaultBlockContext defaultBlock() throws RecognitionException {
		DefaultBlockContext _localctx = new DefaultBlockContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_defaultBlock);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
			match(DEFAULT);
			setState(136);
			match(COLON);
			setState(137);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class WhileStatContext extends ParserRuleContext {
		public TerminalNode WHILE() { return getToken(JiahuScriptParser.WHILE, 0); }
		public TerminalNode OPEN_PARENS() { return getToken(JiahuScriptParser.OPEN_PARENS, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PARENS() { return getToken(JiahuScriptParser.CLOSE_PARENS, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public WhileStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileStat; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterWhileStat(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitWhileStat(this);
		}
	}

	public final WhileStatContext whileStat() throws RecognitionException {
		WhileStatContext _localctx = new WhileStatContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_whileStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(139);
			match(WHILE);
			setState(140);
			match(OPEN_PARENS);
			setState(141);
			expr(0);
			setState(142);
			match(CLOSE_PARENS);
			setState(143);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IfStatContext extends ParserRuleContext {
		public BlockContext ifBlock;
		public BlockContext elseBlock;
		public TerminalNode IF() { return getToken(JiahuScriptParser.IF, 0); }
		public TerminalNode OPEN_PARENS() { return getToken(JiahuScriptParser.OPEN_PARENS, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PARENS() { return getToken(JiahuScriptParser.CLOSE_PARENS, 0); }
		public List<BlockContext> block() {
			return getRuleContexts(BlockContext.class);
		}
		public BlockContext block(int i) {
			return getRuleContext(BlockContext.class,i);
		}
		public TerminalNode ELSE() { return getToken(JiahuScriptParser.ELSE, 0); }
		public IfStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifStat; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterIfStat(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitIfStat(this);
		}
	}

	public final IfStatContext ifStat() throws RecognitionException {
		IfStatContext _localctx = new IfStatContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_ifStat);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(145);
			match(IF);
			setState(146);
			match(OPEN_PARENS);
			setState(147);
			expr(0);
			setState(148);
			match(CLOSE_PARENS);
			setState(149);
			((IfStatContext)_localctx).ifBlock = block();
			setState(152);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(150);
				match(ELSE);
				setState(151);
				((IfStatContext)_localctx).elseBlock = block();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ForeachStatContext extends ParserRuleContext {
		public TerminalNode FOREACH() { return getToken(JiahuScriptParser.FOREACH, 0); }
		public TerminalNode OPEN_PARENS() { return getToken(JiahuScriptParser.OPEN_PARENS, 0); }
		public VariableDecContext variableDec() {
			return getRuleContext(VariableDecContext.class,0);
		}
		public TerminalNode IN() { return getToken(JiahuScriptParser.IN, 0); }
		public TerminalNode CLOSE_PARENS() { return getToken(JiahuScriptParser.CLOSE_PARENS, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public ArrayInitaliserContext arrayInitaliser() {
			return getRuleContext(ArrayInitaliserContext.class,0);
		}
		public ObjectCallContext objectCall() {
			return getRuleContext(ObjectCallContext.class,0);
		}
		public CallContext call() {
			return getRuleContext(CallContext.class,0);
		}
		public ForeachStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_foreachStat; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterForeachStat(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitForeachStat(this);
		}
	}

	public final ForeachStatContext foreachStat() throws RecognitionException {
		ForeachStatContext _localctx = new ForeachStatContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_foreachStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(154);
			match(FOREACH);
			setState(155);
			match(OPEN_PARENS);
			setState(156);
			variableDec();
			setState(157);
			match(IN);
			setState(161);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				setState(158);
				arrayInitaliser();
				}
				break;
			case 2:
				{
				setState(159);
				objectCall();
				}
				break;
			case 3:
				{
				setState(160);
				call();
				}
				break;
			}
			setState(163);
			match(CLOSE_PARENS);
			setState(164);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReturnStatContext extends ParserRuleContext {
		public TerminalNode RETURN() { return getToken(JiahuScriptParser.RETURN, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public ReturnStatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_returnStat; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterReturnStat(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitReturnStat(this);
		}
	}

	public final ReturnStatContext returnStat() throws RecognitionException {
		ReturnStatContext _localctx = new ReturnStatContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_returnStat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(166);
			match(RETURN);
			setState(168);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				{
				setState(167);
				expr(0);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BlockContext extends ParserRuleContext {
		public TerminalNode OPEN_BRACE() { return getToken(JiahuScriptParser.OPEN_BRACE, 0); }
		public TerminalNode CLOSE_BRACE() { return getToken(JiahuScriptParser.CLOSE_BRACE, 0); }
		public List<StatContext> stat() {
			return getRuleContexts(StatContext.class);
		}
		public StatContext stat(int i) {
			return getRuleContext(StatContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitBlock(this);
		}
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(170);
			match(OPEN_BRACE);
			setState(176);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NUMBERS) | (1L << NONE_NUMBER_VALUES) | (1L << TYPE) | (1L << ARRAY) | (1L << PRINT) | (1L << IF) | (1L << WHILE) | (1L << SWITCH) | (1L << RETURN) | (1L << FOREACH) | (1L << BREAK) | (1L << OPEN_BRACE) | (1L << OPEN_PARENS) | (1L << MINUS) | (1L << NOT) | (1L << FUNCID) | (1L << ID))) != 0)) {
				{
				setState(172); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(171);
					stat();
					}
					}
					setState(174); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NUMBERS) | (1L << NONE_NUMBER_VALUES) | (1L << TYPE) | (1L << ARRAY) | (1L << PRINT) | (1L << IF) | (1L << WHILE) | (1L << SWITCH) | (1L << RETURN) | (1L << FOREACH) | (1L << BREAK) | (1L << OPEN_BRACE) | (1L << OPEN_PARENS) | (1L << MINUS) | (1L << NOT) | (1L << FUNCID) | (1L << ID))) != 0) );
				}
			}

			setState(178);
			match(CLOSE_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VariableDecContext extends ParserRuleContext {
		public DefinedTypeContext definedType() {
			return getRuleContext(DefinedTypeContext.class,0);
		}
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public VariableDecContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variableDec; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterVariableDec(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitVariableDec(this);
		}
	}

	public final VariableDecContext variableDec() throws RecognitionException {
		VariableDecContext _localctx = new VariableDecContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_variableDec);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(180);
			definedType();
			setState(181);
			identifier();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VariableDecAssignContext extends ParserRuleContext {
		public VariableDecContext variableDec() {
			return getRuleContext(VariableDecContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(JiahuScriptParser.ASSIGN, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public VariableDecAssignContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variableDecAssign; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterVariableDecAssign(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitVariableDecAssign(this);
		}
	}

	public final VariableDecAssignContext variableDecAssign() throws RecognitionException {
		VariableDecAssignContext _localctx = new VariableDecAssignContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_variableDecAssign);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(183);
			variableDec();
			setState(186);
			_la = _input.LA(1);
			if (_la==ASSIGN) {
				{
				setState(184);
				match(ASSIGN);
				setState(185);
				expr(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(JiahuScriptParser.ASSIGN, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterAssignment(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitAssignment(this);
		}
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(188);
			identifier();
			setState(189);
			match(ASSIGN);
			{
			setState(190);
			expr(0);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArrayInitaliserContext extends ParserRuleContext {
		public TerminalNode OPEN_BRACE() { return getToken(JiahuScriptParser.OPEN_BRACE, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode CLOSE_BRACE() { return getToken(JiahuScriptParser.CLOSE_BRACE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(JiahuScriptParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(JiahuScriptParser.COMMA, i);
		}
		public ArrayInitaliserContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arrayInitaliser; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterArrayInitaliser(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitArrayInitaliser(this);
		}
	}

	public final ArrayInitaliserContext arrayInitaliser() throws RecognitionException {
		ArrayInitaliserContext _localctx = new ArrayInitaliserContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_arrayInitaliser);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(192);
			match(OPEN_BRACE);
			setState(193);
			expr(0);
			setState(198);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(194);
				match(COMMA);
				setState(195);
				expr(0);
				}
				}
				setState(200);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(201);
			match(CLOSE_BRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ObjectCallContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode DOT() { return getToken(JiahuScriptParser.DOT, 0); }
		public ObjectCallListContext objectCallList() {
			return getRuleContext(ObjectCallListContext.class,0);
		}
		public ObjectCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_objectCall; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterObjectCall(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitObjectCall(this);
		}
	}

	public final ObjectCallContext objectCall() throws RecognitionException {
		ObjectCallContext _localctx = new ObjectCallContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_objectCall);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(203);
			identifier();
			setState(204);
			match(DOT);
			setState(205);
			objectCallList();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ObjectCallListContext extends ParserRuleContext {
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<TerminalNode> DOT() { return getTokens(JiahuScriptParser.DOT); }
		public TerminalNode DOT(int i) {
			return getToken(JiahuScriptParser.DOT, i);
		}
		public ObjectCallListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_objectCallList; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterObjectCallList(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitObjectCallList(this);
		}
	}

	public final ObjectCallListContext objectCallList() throws RecognitionException {
		ObjectCallListContext _localctx = new ObjectCallListContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_objectCallList);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(207);
			expr(0);
			setState(212);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,14,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(208);
					match(DOT);
					setState(209);
					expr(0);
					}
					} 
				}
				setState(214);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,14,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionCallContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode OPEN_PARENS() { return getToken(JiahuScriptParser.OPEN_PARENS, 0); }
		public TerminalNode CLOSE_PARENS() { return getToken(JiahuScriptParser.CLOSE_PARENS, 0); }
		public FunctionListContext functionList() {
			return getRuleContext(FunctionListContext.class,0);
		}
		public FunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCall; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterFunctionCall(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitFunctionCall(this);
		}
	}

	public final FunctionCallContext functionCall() throws RecognitionException {
		FunctionCallContext _localctx = new FunctionCallContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_functionCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(215);
			identifier();
			setState(216);
			match(OPEN_PARENS);
			setState(218);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NUMBERS) | (1L << NONE_NUMBER_VALUES) | (1L << OPEN_BRACE) | (1L << OPEN_PARENS) | (1L << MINUS) | (1L << NOT) | (1L << FUNCID) | (1L << ID))) != 0)) {
				{
				setState(217);
				functionList();
				}
			}

			setState(220);
			match(CLOSE_PARENS);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionListContext extends ParserRuleContext {
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(JiahuScriptParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(JiahuScriptParser.COMMA, i);
		}
		public FunctionListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionList; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterFunctionList(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitFunctionList(this);
		}
	}

	public final FunctionListContext functionList() throws RecognitionException {
		FunctionListContext _localctx = new FunctionListContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_functionList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(222);
			expr(0);
			setState(227);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(223);
				match(COMMA);
				setState(224);
				expr(0);
				}
				}
				setState(229);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExprContext extends ParserRuleContext {
		public ExprContext left;
		public Token op;
		public ExprContext right;
		public ExprContext inlineTrue;
		public ExprContext inlineFalse;
		public TerminalNode NOT() { return getToken(JiahuScriptParser.NOT, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public ObjectCallContext objectCall() {
			return getRuleContext(ObjectCallContext.class,0);
		}
		public CallContext call() {
			return getRuleContext(CallContext.class,0);
		}
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public ArrayIndexerContext arrayIndexer() {
			return getRuleContext(ArrayIndexerContext.class,0);
		}
		public ArrayInitaliserContext arrayInitaliser() {
			return getRuleContext(ArrayInitaliserContext.class,0);
		}
		public TerminalNode OPEN_PARENS() { return getToken(JiahuScriptParser.OPEN_PARENS, 0); }
		public TerminalNode CLOSE_PARENS() { return getToken(JiahuScriptParser.CLOSE_PARENS, 0); }
		public TerminalNode EQUAL() { return getToken(JiahuScriptParser.EQUAL, 0); }
		public TerminalNode NOT_EQUAL() { return getToken(JiahuScriptParser.NOT_EQUAL, 0); }
		public TerminalNode LESS_THAN() { return getToken(JiahuScriptParser.LESS_THAN, 0); }
		public TerminalNode LESS_OR_EQUAL() { return getToken(JiahuScriptParser.LESS_OR_EQUAL, 0); }
		public TerminalNode GREATER_THAN() { return getToken(JiahuScriptParser.GREATER_THAN, 0); }
		public TerminalNode GREATER_OR_EQUAL() { return getToken(JiahuScriptParser.GREATER_OR_EQUAL, 0); }
		public TerminalNode COLON() { return getToken(JiahuScriptParser.COLON, 0); }
		public TerminalNode QUESTION() { return getToken(JiahuScriptParser.QUESTION, 0); }
		public TerminalNode TIMES() { return getToken(JiahuScriptParser.TIMES, 0); }
		public TerminalNode DIV() { return getToken(JiahuScriptParser.DIV, 0); }
		public TerminalNode PLUS() { return getToken(JiahuScriptParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(JiahuScriptParser.MINUS, 0); }
		public TerminalNode AMPERSAND() { return getToken(JiahuScriptParser.AMPERSAND, 0); }
		public TerminalNode PLUSPLUS() { return getToken(JiahuScriptParser.PLUSPLUS, 0); }
		public TerminalNode MINUSMINUS() { return getToken(JiahuScriptParser.MINUSMINUS, 0); }
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterExpr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitExpr(this);
		}
	}

	public final ExprContext expr() throws RecognitionException {
		return expr(0);
	}

	private ExprContext expr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExprContext _localctx = new ExprContext(_ctx, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 46;
		enterRecursionRule(_localctx, 46, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(242);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				{
				setState(231);
				((ExprContext)_localctx).op = match(NOT);
				setState(232);
				((ExprContext)_localctx).right = expr(17);
				}
				break;
			case 2:
				{
				setState(233);
				objectCall();
				}
				break;
			case 3:
				{
				setState(234);
				call();
				}
				break;
			case 4:
				{
				setState(235);
				value();
				}
				break;
			case 5:
				{
				setState(236);
				arrayIndexer();
				}
				break;
			case 6:
				{
				setState(237);
				arrayInitaliser();
				}
				break;
			case 7:
				{
				setState(238);
				match(OPEN_PARENS);
				setState(239);
				expr(0);
				setState(240);
				match(CLOSE_PARENS);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(283);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(281);
					switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						_localctx.left = _prevctx;
						_localctx.left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(244);
						if (!(precpred(_ctx, 19))) throw new FailedPredicateException(this, "precpred(_ctx, 19)");
						setState(245);
						((ExprContext)_localctx).op = match(EQUAL);
						setState(246);
						((ExprContext)_localctx).right = expr(20);
						}
						break;
					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						_localctx.left = _prevctx;
						_localctx.left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(247);
						if (!(precpred(_ctx, 18))) throw new FailedPredicateException(this, "precpred(_ctx, 18)");
						setState(248);
						((ExprContext)_localctx).op = match(NOT_EQUAL);
						setState(249);
						((ExprContext)_localctx).right = expr(19);
						}
						break;
					case 3:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						_localctx.left = _prevctx;
						_localctx.left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(250);
						if (!(precpred(_ctx, 16))) throw new FailedPredicateException(this, "precpred(_ctx, 16)");
						setState(251);
						((ExprContext)_localctx).op = match(LESS_THAN);
						setState(252);
						((ExprContext)_localctx).right = expr(17);
						}
						break;
					case 4:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						_localctx.left = _prevctx;
						_localctx.left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(253);
						if (!(precpred(_ctx, 15))) throw new FailedPredicateException(this, "precpred(_ctx, 15)");
						setState(254);
						((ExprContext)_localctx).op = match(LESS_OR_EQUAL);
						setState(255);
						((ExprContext)_localctx).right = expr(16);
						}
						break;
					case 5:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						_localctx.left = _prevctx;
						_localctx.left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(256);
						if (!(precpred(_ctx, 14))) throw new FailedPredicateException(this, "precpred(_ctx, 14)");
						setState(257);
						((ExprContext)_localctx).op = match(GREATER_THAN);
						setState(258);
						((ExprContext)_localctx).right = expr(15);
						}
						break;
					case 6:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						_localctx.left = _prevctx;
						_localctx.left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(259);
						if (!(precpred(_ctx, 13))) throw new FailedPredicateException(this, "precpred(_ctx, 13)");
						setState(260);
						((ExprContext)_localctx).op = match(GREATER_OR_EQUAL);
						setState(261);
						((ExprContext)_localctx).right = expr(14);
						}
						break;
					case 7:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(262);
						if (!(precpred(_ctx, 10))) throw new FailedPredicateException(this, "precpred(_ctx, 10)");
						setState(263);
						((ExprContext)_localctx).op = match(QUESTION);
						setState(264);
						((ExprContext)_localctx).inlineTrue = expr(0);
						setState(265);
						match(COLON);
						setState(266);
						((ExprContext)_localctx).inlineFalse = expr(11);
						}
						break;
					case 8:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						_localctx.left = _prevctx;
						_localctx.left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(268);
						if (!(precpred(_ctx, 9))) throw new FailedPredicateException(this, "precpred(_ctx, 9)");
						setState(269);
						((ExprContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !(_la==TIMES || _la==DIV) ) {
							((ExprContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						} else {
							consume();
						}
						setState(270);
						((ExprContext)_localctx).right = expr(10);
						}
						break;
					case 9:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						_localctx.left = _prevctx;
						_localctx.left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(271);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(272);
						((ExprContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
							((ExprContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						} else {
							consume();
						}
						setState(273);
						((ExprContext)_localctx).right = expr(9);
						}
						break;
					case 10:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						_localctx.left = _prevctx;
						_localctx.left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(274);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(275);
						((ExprContext)_localctx).op = match(AMPERSAND);
						setState(276);
						((ExprContext)_localctx).right = expr(3);
						}
						break;
					case 11:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(277);
						if (!(precpred(_ctx, 12))) throw new FailedPredicateException(this, "precpred(_ctx, 12)");
						setState(278);
						((ExprContext)_localctx).op = match(PLUSPLUS);
						}
						break;
					case 12:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(279);
						if (!(precpred(_ctx, 11))) throw new FailedPredicateException(this, "precpred(_ctx, 11)");
						setState(280);
						((ExprContext)_localctx).op = match(MINUSMINUS);
						}
						break;
					}
					} 
				}
				setState(285);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class CallContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public CallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_call; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterCall(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitCall(this);
		}
	}

	public final CallContext call() throws RecognitionException {
		CallContext _localctx = new CallContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_call);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(288);
			switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
			case 1:
				{
				setState(286);
				identifier();
				}
				break;
			case 2:
				{
				setState(287);
				functionCall();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArrayIndexerContext extends ParserRuleContext {
		public ArrayAccessorContext arrayAccessor() {
			return getRuleContext(ArrayAccessorContext.class,0);
		}
		public CallContext call() {
			return getRuleContext(CallContext.class,0);
		}
		public ObjectCallContext objectCall() {
			return getRuleContext(ObjectCallContext.class,0);
		}
		public ArrayIndexerContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arrayIndexer; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterArrayIndexer(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitArrayIndexer(this);
		}
	}

	public final ArrayIndexerContext arrayIndexer() throws RecognitionException {
		ArrayIndexerContext _localctx = new ArrayIndexerContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_arrayIndexer);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(292);
			switch ( getInterpreter().adaptivePredict(_input,21,_ctx) ) {
			case 1:
				{
				setState(290);
				call();
				}
				break;
			case 2:
				{
				setState(291);
				objectCall();
				}
				break;
			}
			setState(294);
			arrayAccessor();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArrayAccessorContext extends ParserRuleContext {
		public TerminalNode OPEN_BRACKET() { return getToken(JiahuScriptParser.OPEN_BRACKET, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_BRACKET() { return getToken(JiahuScriptParser.CLOSE_BRACKET, 0); }
		public ArrayAccessorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arrayAccessor; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterArrayAccessor(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitArrayAccessor(this);
		}
	}

	public final ArrayAccessorContext arrayAccessor() throws RecognitionException {
		ArrayAccessorContext _localctx = new ArrayAccessorContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_arrayAccessor);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(296);
			match(OPEN_BRACKET);
			setState(297);
			expr(0);
			setState(298);
			match(CLOSE_BRACKET);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DefinedTypeContext extends ParserRuleContext {
		public TerminalNode TYPE() { return getToken(JiahuScriptParser.TYPE, 0); }
		public TerminalNode ARRAY() { return getToken(JiahuScriptParser.ARRAY, 0); }
		public DefinedTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_definedType; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterDefinedType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitDefinedType(this);
		}
	}

	public final DefinedTypeContext definedType() throws RecognitionException {
		DefinedTypeContext _localctx = new DefinedTypeContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_definedType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(300);
			_la = _input.LA(1);
			if ( !(_la==TYPE || _la==ARRAY) ) {
			_errHandler.recoverInline(this);
			} else {
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ValueContext extends ParserRuleContext {
		public NoneNumberContext noneNumber() {
			return getRuleContext(NoneNumberContext.class,0);
		}
		public NumberContext number() {
			return getRuleContext(NumberContext.class,0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterValue(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitValue(this);
		}
	}

	public final ValueContext value() throws RecognitionException {
		ValueContext _localctx = new ValueContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_value);
		try {
			setState(304);
			switch (_input.LA(1)) {
			case NONE_NUMBER_VALUES:
				enterOuterAlt(_localctx, 1);
				{
				setState(302);
				noneNumber();
				}
				break;
			case NUMBERS:
			case MINUS:
				enterOuterAlt(_localctx, 2);
				{
				setState(303);
				number();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IdentifierContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(JiahuScriptParser.ID, 0); }
		public TerminalNode FUNCID() { return getToken(JiahuScriptParser.FUNCID, 0); }
		public IdentifierContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_identifier; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterIdentifier(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitIdentifier(this);
		}
	}

	public final IdentifierContext identifier() throws RecognitionException {
		IdentifierContext _localctx = new IdentifierContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_identifier);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(306);
			_la = _input.LA(1);
			if ( !(_la==FUNCID || _la==ID) ) {
			_errHandler.recoverInline(this);
			} else {
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumberContext extends ParserRuleContext {
		public TerminalNode NUMBERS() { return getToken(JiahuScriptParser.NUMBERS, 0); }
		public SignContext sign() {
			return getRuleContext(SignContext.class,0);
		}
		public NumberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_number; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterNumber(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitNumber(this);
		}
	}

	public final NumberContext number() throws RecognitionException {
		NumberContext _localctx = new NumberContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_number);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(309);
			_la = _input.LA(1);
			if (_la==MINUS) {
				{
				setState(308);
				sign();
				}
			}

			setState(311);
			match(NUMBERS);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SignContext extends ParserRuleContext {
		public TerminalNode MINUS() { return getToken(JiahuScriptParser.MINUS, 0); }
		public SignContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sign; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterSign(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitSign(this);
		}
	}

	public final SignContext sign() throws RecognitionException {
		SignContext _localctx = new SignContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_sign);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(313);
			match(MINUS);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NoneNumberContext extends ParserRuleContext {
		public TerminalNode NONE_NUMBER_VALUES() { return getToken(JiahuScriptParser.NONE_NUMBER_VALUES, 0); }
		public NoneNumberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_noneNumber; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).enterNoneNumber(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof JiahuScriptListener ) ((JiahuScriptListener)listener).exitNoneNumber(this);
		}
	}

	public final NoneNumberContext noneNumber() throws RecognitionException {
		NoneNumberContext _localctx = new NoneNumberContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_noneNumber);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(315);
			match(NONE_NUMBER_VALUES);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 23:
			return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 19);
		case 1:
			return precpred(_ctx, 18);
		case 2:
			return precpred(_ctx, 16);
		case 3:
			return precpred(_ctx, 15);
		case 4:
			return precpred(_ctx, 14);
		case 5:
			return precpred(_ctx, 13);
		case 6:
			return precpred(_ctx, 10);
		case 7:
			return precpred(_ctx, 9);
		case 8:
			return precpred(_ctx, 8);
		case 9:
			return precpred(_ctx, 2);
		case 10:
			return precpred(_ctx, 12);
		case 11:
			return precpred(_ctx, 11);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u0430\ud6d1\u8206\uad2d\u4417\uaef1\u8d80\uaadd\3;\u0140\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\3\2\3\2\6\2G\n\2\r\2\16\2H\3\3\3\3\3\3\3\3\7\3O\n\3\f\3\16"+
		"\3R\13\3\3\3\3\3\3\3\3\4\3\4\3\4\7\4Z\n\4\f\4\16\4]\13\4\3\5\3\5\3\5\3"+
		"\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\5\6m\n\6\3\7\3\7\3\7\3\7\3"+
		"\7\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\t\6\t|\n\t\r\t\16\t}\3\t\5\t\u0081\n"+
		"\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f"+
		"\3\f\3\r\3\r\3\r\3\r\3\r\3\r\3\r\5\r\u009b\n\r\3\16\3\16\3\16\3\16\3\16"+
		"\3\16\3\16\5\16\u00a4\n\16\3\16\3\16\3\16\3\17\3\17\5\17\u00ab\n\17\3"+
		"\20\3\20\6\20\u00af\n\20\r\20\16\20\u00b0\5\20\u00b3\n\20\3\20\3\20\3"+
		"\21\3\21\3\21\3\22\3\22\3\22\5\22\u00bd\n\22\3\23\3\23\3\23\3\23\3\24"+
		"\3\24\3\24\3\24\7\24\u00c7\n\24\f\24\16\24\u00ca\13\24\3\24\3\24\3\25"+
		"\3\25\3\25\3\25\3\26\3\26\3\26\7\26\u00d5\n\26\f\26\16\26\u00d8\13\26"+
		"\3\27\3\27\3\27\5\27\u00dd\n\27\3\27\3\27\3\30\3\30\3\30\7\30\u00e4\n"+
		"\30\f\30\16\30\u00e7\13\30\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31"+
		"\3\31\3\31\3\31\5\31\u00f5\n\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31"+
		"\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31"+
		"\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31"+
		"\3\31\7\31\u011c\n\31\f\31\16\31\u011f\13\31\3\32\3\32\5\32\u0123\n\32"+
		"\3\33\3\33\5\33\u0127\n\33\3\33\3\33\3\34\3\34\3\34\3\34\3\35\3\35\3\36"+
		"\3\36\5\36\u0133\n\36\3\37\3\37\3 \5 \u0138\n \3 \3 \3!\3!\3\"\3\"\3\""+
		"\2\3\60#\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668"+
		":<>@B\2\6\3\2)*\3\2\'(\3\2\5\6\3\2:;\u014f\2F\3\2\2\2\4J\3\2\2\2\6V\3"+
		"\2\2\2\b^\3\2\2\2\nl\3\2\2\2\fn\3\2\2\2\16s\3\2\2\2\20u\3\2\2\2\22\u0084"+
		"\3\2\2\2\24\u0089\3\2\2\2\26\u008d\3\2\2\2\30\u0093\3\2\2\2\32\u009c\3"+
		"\2\2\2\34\u00a8\3\2\2\2\36\u00ac\3\2\2\2 \u00b6\3\2\2\2\"\u00b9\3\2\2"+
		"\2$\u00be\3\2\2\2&\u00c2\3\2\2\2(\u00cd\3\2\2\2*\u00d1\3\2\2\2,\u00d9"+
		"\3\2\2\2.\u00e0\3\2\2\2\60\u00f4\3\2\2\2\62\u0122\3\2\2\2\64\u0126\3\2"+
		"\2\2\66\u012a\3\2\2\28\u012e\3\2\2\2:\u0132\3\2\2\2<\u0134\3\2\2\2>\u0137"+
		"\3\2\2\2@\u013b\3\2\2\2B\u013d\3\2\2\2DG\5\n\6\2EG\5\4\3\2FD\3\2\2\2F"+
		"E\3\2\2\2GH\3\2\2\2HF\3\2\2\2HI\3\2\2\2I\3\3\2\2\2JK\58\35\2KL\5<\37\2"+
		"LP\7\"\2\2MO\5\6\4\2NM\3\2\2\2OR\3\2\2\2PN\3\2\2\2PQ\3\2\2\2QS\3\2\2\2"+
		"RP\3\2\2\2ST\7#\2\2TU\5\36\20\2U\5\3\2\2\2V[\5\b\5\2WX\7$\2\2XZ\5\b\5"+
		"\2YW\3\2\2\2Z]\3\2\2\2[Y\3\2\2\2[\\\3\2\2\2\\\7\3\2\2\2][\3\2\2\2^_\5"+
		"8\35\2_`\5<\37\2`\t\3\2\2\2am\5\36\20\2bm\5\f\7\2cm\5\16\b\2dm\5\20\t"+
		"\2em\5\26\f\2fm\5\30\r\2gm\5\32\16\2hm\5\34\17\2im\5$\23\2jm\5\"\22\2"+
		"km\5\60\31\2la\3\2\2\2lb\3\2\2\2lc\3\2\2\2ld\3\2\2\2le\3\2\2\2lf\3\2\2"+
		"\2lg\3\2\2\2lh\3\2\2\2li\3\2\2\2lj\3\2\2\2lk\3\2\2\2m\13\3\2\2\2no\7\21"+
		"\2\2op\7\"\2\2pq\5\60\31\2qr\7#\2\2r\r\3\2\2\2st\7\32\2\2t\17\3\2\2\2"+
		"uv\7\25\2\2vw\7\"\2\2wx\5\60\31\2xy\7#\2\2y{\7\36\2\2z|\5\22\n\2{z\3\2"+
		"\2\2|}\3\2\2\2}{\3\2\2\2}~\3\2\2\2~\u0080\3\2\2\2\177\u0081\5\24\13\2"+
		"\u0080\177\3\2\2\2\u0080\u0081\3\2\2\2\u0081\u0082\3\2\2\2\u0082\u0083"+
		"\7\37\2\2\u0083\21\3\2\2\2\u0084\u0085\7\26\2\2\u0085\u0086\5:\36\2\u0086"+
		"\u0087\7%\2\2\u0087\u0088\5\36\20\2\u0088\23\3\2\2\2\u0089\u008a\7\27"+
		"\2\2\u008a\u008b\7%\2\2\u008b\u008c\5\36\20\2\u008c\25\3\2\2\2\u008d\u008e"+
		"\7\24\2\2\u008e\u008f\7\"\2\2\u008f\u0090\5\60\31\2\u0090\u0091\7#\2\2"+
		"\u0091\u0092\5\36\20\2\u0092\27\3\2\2\2\u0093\u0094\7\22\2\2\u0094\u0095"+
		"\7\"\2\2\u0095\u0096\5\60\31\2\u0096\u0097\7#\2\2\u0097\u009a\5\36\20"+
		"\2\u0098\u0099\7\23\2\2\u0099\u009b\5\36\20\2\u009a\u0098\3\2\2\2\u009a"+
		"\u009b\3\2\2\2\u009b\31\3\2\2\2\u009c\u009d\7\31\2\2\u009d\u009e\7\"\2"+
		"\2\u009e\u009f\5 \21\2\u009f\u00a3\7\33\2\2\u00a0\u00a4\5&\24\2\u00a1"+
		"\u00a4\5(\25\2\u00a2\u00a4\5\62\32\2\u00a3\u00a0\3\2\2\2\u00a3\u00a1\3"+
		"\2\2\2\u00a3\u00a2\3\2\2\2\u00a4\u00a5\3\2\2\2\u00a5\u00a6\7#\2\2\u00a6"+
		"\u00a7\5\36\20\2\u00a7\33\3\2\2\2\u00a8\u00aa\7\30\2\2\u00a9\u00ab\5\60"+
		"\31\2\u00aa\u00a9\3\2\2\2\u00aa\u00ab\3\2\2\2\u00ab\35\3\2\2\2\u00ac\u00b2"+
		"\7\36\2\2\u00ad\u00af\5\n\6\2\u00ae\u00ad\3\2\2\2\u00af\u00b0\3\2\2\2"+
		"\u00b0\u00ae\3\2\2\2\u00b0\u00b1\3\2\2\2\u00b1\u00b3\3\2\2\2\u00b2\u00ae"+
		"\3\2\2\2\u00b2\u00b3\3\2\2\2\u00b3\u00b4\3\2\2\2\u00b4\u00b5\7\37\2\2"+
		"\u00b5\37\3\2\2\2\u00b6\u00b7\58\35\2\u00b7\u00b8\5<\37\2\u00b8!\3\2\2"+
		"\2\u00b9\u00bc\5 \21\2\u00ba\u00bb\7\64\2\2\u00bb\u00bd\5\60\31\2\u00bc"+
		"\u00ba\3\2\2\2\u00bc\u00bd\3\2\2\2\u00bd#\3\2\2\2\u00be\u00bf\5<\37\2"+
		"\u00bf\u00c0\7\64\2\2\u00c0\u00c1\5\60\31\2\u00c1%\3\2\2\2\u00c2\u00c3"+
		"\7\36\2\2\u00c3\u00c8\5\60\31\2\u00c4\u00c5\7$\2\2\u00c5\u00c7\5\60\31"+
		"\2\u00c6\u00c4\3\2\2\2\u00c7\u00ca\3\2\2\2\u00c8\u00c6\3\2\2\2\u00c8\u00c9"+
		"\3\2\2\2\u00c9\u00cb\3\2\2\2\u00ca\u00c8\3\2\2\2\u00cb\u00cc\7\37\2\2"+
		"\u00cc\'\3\2\2\2\u00cd\u00ce\5<\37\2\u00ce\u00cf\7\66\2\2\u00cf\u00d0"+
		"\5*\26\2\u00d0)\3\2\2\2\u00d1\u00d6\5\60\31\2\u00d2\u00d3\7\66\2\2\u00d3"+
		"\u00d5\5\60\31\2\u00d4\u00d2\3\2\2\2\u00d5\u00d8\3\2\2\2\u00d6\u00d4\3"+
		"\2\2\2\u00d6\u00d7\3\2\2\2\u00d7+\3\2\2\2\u00d8\u00d6\3\2\2\2\u00d9\u00da"+
		"\5<\37\2\u00da\u00dc\7\"\2\2\u00db\u00dd\5.\30\2\u00dc\u00db\3\2\2\2\u00dc"+
		"\u00dd\3\2\2\2\u00dd\u00de\3\2\2\2\u00de\u00df\7#\2\2\u00df-\3\2\2\2\u00e0"+
		"\u00e5\5\60\31\2\u00e1\u00e2\7$\2\2\u00e2\u00e4\5\60\31\2\u00e3\u00e1"+
		"\3\2\2\2\u00e4\u00e7\3\2\2\2\u00e5\u00e3\3\2\2\2\u00e5\u00e6\3\2\2\2\u00e6"+
		"/\3\2\2\2\u00e7\u00e5\3\2\2\2\u00e8\u00e9\b\31\1\2\u00e9\u00ea\7-\2\2"+
		"\u00ea\u00f5\5\60\31\23\u00eb\u00f5\5(\25\2\u00ec\u00f5\5\62\32\2\u00ed"+
		"\u00f5\5:\36\2\u00ee\u00f5\5\64\33\2\u00ef\u00f5\5&\24\2\u00f0\u00f1\7"+
		"\"\2\2\u00f1\u00f2\5\60\31\2\u00f2\u00f3\7#\2\2\u00f3\u00f5\3\2\2\2\u00f4"+
		"\u00e8\3\2\2\2\u00f4\u00eb\3\2\2\2\u00f4\u00ec\3\2\2\2\u00f4\u00ed\3\2"+
		"\2\2\u00f4\u00ee\3\2\2\2\u00f4\u00ef\3\2\2\2\u00f4\u00f0\3\2\2\2\u00f5"+
		"\u011d\3\2\2\2\u00f6\u00f7\f\25\2\2\u00f7\u00f8\7\63\2\2\u00f8\u011c\5"+
		"\60\31\26\u00f9\u00fa\f\24\2\2\u00fa\u00fb\7.\2\2\u00fb\u011c\5\60\31"+
		"\25\u00fc\u00fd\f\22\2\2\u00fd\u00fe\7\62\2\2\u00fe\u011c\5\60\31\23\u00ff"+
		"\u0100\f\21\2\2\u0100\u0101\7/\2\2\u0101\u011c\5\60\31\22\u0102\u0103"+
		"\f\20\2\2\u0103\u0104\7\61\2\2\u0104\u011c\5\60\31\21\u0105\u0106\f\17"+
		"\2\2\u0106\u0107\7\60\2\2\u0107\u011c\5\60\31\20\u0108\u0109\f\f\2\2\u0109"+
		"\u010a\7&\2\2\u010a\u010b\5\60\31\2\u010b\u010c\7%\2\2\u010c\u010d\5\60"+
		"\31\r\u010d\u011c\3\2\2\2\u010e\u010f\f\13\2\2\u010f\u0110\t\2\2\2\u0110"+
		"\u011c\5\60\31\f\u0111\u0112\f\n\2\2\u0112\u0113\t\3\2\2\u0113\u011c\5"+
		"\60\31\13\u0114\u0115\f\4\2\2\u0115\u0116\7\65\2\2\u0116\u011c\5\60\31"+
		"\5\u0117\u0118\f\16\2\2\u0118\u011c\7+\2\2\u0119\u011a\f\r\2\2\u011a\u011c"+
		"\7,\2\2\u011b\u00f6\3\2\2\2\u011b\u00f9\3\2\2\2\u011b\u00fc\3\2\2\2\u011b"+
		"\u00ff\3\2\2\2\u011b\u0102\3\2\2\2\u011b\u0105\3\2\2\2\u011b\u0108\3\2"+
		"\2\2\u011b\u010e\3\2\2\2\u011b\u0111\3\2\2\2\u011b\u0114\3\2\2\2\u011b"+
		"\u0117\3\2\2\2\u011b\u0119\3\2\2\2\u011c\u011f\3\2\2\2\u011d\u011b\3\2"+
		"\2\2\u011d\u011e\3\2\2\2\u011e\61\3\2\2\2\u011f\u011d\3\2\2\2\u0120\u0123"+
		"\5<\37\2\u0121\u0123\5,\27\2\u0122\u0120\3\2\2\2\u0122\u0121\3\2\2\2\u0123"+
		"\63\3\2\2\2\u0124\u0127\5\62\32\2\u0125\u0127\5(\25\2\u0126\u0124\3\2"+
		"\2\2\u0126\u0125\3\2\2\2\u0127\u0128\3\2\2\2\u0128\u0129\5\66\34\2\u0129"+
		"\65\3\2\2\2\u012a\u012b\7 \2\2\u012b\u012c\5\60\31\2\u012c\u012d\7!\2"+
		"\2\u012d\67\3\2\2\2\u012e\u012f\t\4\2\2\u012f9\3\2\2\2\u0130\u0133\5B"+
		"\"\2\u0131\u0133\5> \2\u0132\u0130\3\2\2\2\u0132\u0131\3\2\2\2\u0133;"+
		"\3\2\2\2\u0134\u0135\t\5\2\2\u0135=\3\2\2\2\u0136\u0138\5@!\2\u0137\u0136"+
		"\3\2\2\2\u0137\u0138\3\2\2\2\u0138\u0139\3\2\2\2\u0139\u013a\7\3\2\2\u013a"+
		"?\3\2\2\2\u013b\u013c\7(\2\2\u013cA\3\2\2\2\u013d\u013e\7\4\2\2\u013e"+
		"C\3\2\2\2\32FHP[l}\u0080\u009a\u00a3\u00aa\u00b0\u00b2\u00bc\u00c8\u00d6"+
		"\u00dc\u00e5\u00f4\u011b\u011d\u0122\u0126\u0132\u0137";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}