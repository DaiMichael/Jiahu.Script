// Generated from .\..\JiahuScript\Grammar\JiahuScript.g4 by ANTLR 4.5.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JiahuScriptLexer extends Lexer {
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
	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"NUMBERS", "NONE_NUMBER_VALUES", "TYPE", "ARRAY", "NULL", "BOOL", "STRING", 
		"INT", "DECIMAL", "DATE", "DATETIME", "OBJECT", "FUNCTION", "VOID", "PRINT", 
		"IF", "ELSE", "WHILE", "SWITCH", "CASE", "DEFAULT", "RETURN", "FOREACH", 
		"BREAK", "IN", "FALSE", "TRUE", "OPEN_BRACE", "CLOSE_BRACE", "OPEN_BRACKET", 
		"CLOSE_BRACKET", "OPEN_PARENS", "CLOSE_PARENS", "COMMA", "COLON", "QUESTION", 
		"PLUS", "MINUS", "TIMES", "DIV", "PLUSPLUS", "MINUSMINUS", "NOT", "NOT_EQUAL", 
		"LESS_OR_EQUAL", "GREATER_OR_EQUAL", "GREATER_THAN", "LESS_THAN", "EQUAL", 
		"ASSIGN", "AMPERSAND", "DOT", "LINE_COMMENT", "COMMENT", "WS", "FUNCID", 
		"ID", "DECIMAL_VALUE", "INT_VALUE", "STRING_VALUE", "BOOL_VALUE", "DATE_VALUE", 
		"TIME_VALUE", "DATETIME_VALUE", "LETTER", "DIGIT", "ESCAPE", "HYPHEN", 
		"UNDERSCORE", "RAW_DATE", "RAW_TIME"
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


	public JiahuScriptLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "JiahuScript.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u0430\ud6d1\u8206\uad2d\u4417\uaef1\u8d80\uaadd\2;\u0204\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\4=\t="+
		"\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\4F\tF\4G\tG\4H\tH\3\2"+
		"\3\2\5\2\u0094\n\2\3\3\3\3\3\3\3\3\3\3\5\3\u009b\n\3\3\4\3\4\3\4\3\4\3"+
		"\4\3\4\3\4\5\4\u00a4\n\4\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3"+
		"\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n"+
		"\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f"+
		"\3\f\3\f\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16"+
		"\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\20\3\20\3\20\3\20\3\20\3\20\3\21"+
		"\3\21\3\21\3\22\3\22\3\22\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23\3\24"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\3\25\3\25\3\25\3\25\3\25\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\30\3\30"+
		"\3\30\3\30\3\30\3\30\3\30\3\30\3\31\3\31\3\31\3\31\3\31\3\31\3\32\3\32"+
		"\3\32\3\33\3\33\3\33\3\33\3\33\3\33\5\33\u0130\n\33\3\34\3\34\3\34\3\34"+
		"\3\34\5\34\u0137\n\34\3\35\3\35\3\36\3\36\3\37\3\37\3 \3 \3!\3!\3\"\3"+
		"\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3(\3)\3)\3*\3*\3*\3+\3+\3+\3,\3"+
		",\3-\3-\3-\3.\3.\3.\3/\3/\3/\3\60\3\60\3\61\3\61\3\62\3\62\3\62\3\63\3"+
		"\63\3\64\3\64\3\65\3\65\3\66\3\66\3\66\3\66\7\66\u0175\n\66\f\66\16\66"+
		"\u0178\13\66\3\66\3\66\3\67\3\67\3\67\3\67\7\67\u0180\n\67\f\67\16\67"+
		"\u0183\13\67\3\67\3\67\3\67\3\67\3\67\38\68\u018b\n8\r8\168\u018c\38\3"+
		"8\39\39\69\u0193\n9\r9\169\u0194\39\39\39\69\u019a\n9\r9\169\u019b\3:"+
		"\3:\5:\u01a0\n:\3:\3:\3:\7:\u01a5\n:\f:\16:\u01a8\13:\3;\6;\u01ab\n;\r"+
		";\16;\u01ac\3;\6;\u01b0\n;\r;\16;\u01b1\3;\3;\6;\u01b6\n;\r;\16;\u01b7"+
		"\3;\3;\6;\u01bc\n;\r;\16;\u01bd\5;\u01c0\n;\3<\6<\u01c3\n<\r<\16<\u01c4"+
		"\3=\3=\3=\7=\u01ca\n=\f=\16=\u01cd\13=\3=\3=\3>\3>\5>\u01d3\n>\3?\3?\3"+
		"?\3?\3@\3@\3@\3@\3A\3A\3A\3A\3A\3A\3B\3B\3C\3C\3D\3D\3D\3D\5D\u01eb\n"+
		"D\3E\3E\3F\3F\3G\3G\3G\3G\3G\3G\3G\3G\3G\3G\3G\3H\3H\3H\3H\3H\3H\3H\3"+
		"H\3H\4\u0181\u01cb\2I\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27"+
		"\r\31\16\33\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33"+
		"\65\34\67\359\36;\37= ?!A\"C#E$G%I&K\'M(O)Q*S+U,W-Y.[/]\60_\61a\62c\63"+
		"e\64g\65i\66k\67m8o9q:s;u\2w\2y\2{\2}\2\177\2\u0081\2\u0083\2\u0085\2"+
		"\u0087\2\u0089\2\u008b\2\u008d\2\u008f\2\3\2\6\4\2\f\f\17\17\5\2\13\f"+
		"\17\17\"\"\4\2C\\c|\3\2\62;\u0219\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2"+
		"\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3"+
		"\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2"+
		"\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2"+
		"\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2"+
		"\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2"+
		"\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2"+
		"O\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\2U\3\2\2\2\2W\3\2\2\2\2Y\3\2\2\2\2[\3"+
		"\2\2\2\2]\3\2\2\2\2_\3\2\2\2\2a\3\2\2\2\2c\3\2\2\2\2e\3\2\2\2\2g\3\2\2"+
		"\2\2i\3\2\2\2\2k\3\2\2\2\2m\3\2\2\2\2o\3\2\2\2\2q\3\2\2\2\2s\3\2\2\2\3"+
		"\u0093\3\2\2\2\5\u009a\3\2\2\2\7\u00a3\3\2\2\2\t\u00a5\3\2\2\2\13\u00a9"+
		"\3\2\2\2\r\u00ae\3\2\2\2\17\u00b3\3\2\2\2\21\u00ba\3\2\2\2\23\u00be\3"+
		"\2\2\2\25\u00c6\3\2\2\2\27\u00cb\3\2\2\2\31\u00d4\3\2\2\2\33\u00db\3\2"+
		"\2\2\35\u00e4\3\2\2\2\37\u00e9\3\2\2\2!\u00ef\3\2\2\2#\u00f2\3\2\2\2%"+
		"\u00f7\3\2\2\2\'\u00fd\3\2\2\2)\u0104\3\2\2\2+\u0109\3\2\2\2-\u0111\3"+
		"\2\2\2/\u0118\3\2\2\2\61\u0120\3\2\2\2\63\u0126\3\2\2\2\65\u012f\3\2\2"+
		"\2\67\u0136\3\2\2\29\u0138\3\2\2\2;\u013a\3\2\2\2=\u013c\3\2\2\2?\u013e"+
		"\3\2\2\2A\u0140\3\2\2\2C\u0142\3\2\2\2E\u0144\3\2\2\2G\u0146\3\2\2\2I"+
		"\u0148\3\2\2\2K\u014a\3\2\2\2M\u014c\3\2\2\2O\u014e\3\2\2\2Q\u0150\3\2"+
		"\2\2S\u0152\3\2\2\2U\u0155\3\2\2\2W\u0158\3\2\2\2Y\u015a\3\2\2\2[\u015d"+
		"\3\2\2\2]\u0160\3\2\2\2_\u0163\3\2\2\2a\u0165\3\2\2\2c\u0167\3\2\2\2e"+
		"\u016a\3\2\2\2g\u016c\3\2\2\2i\u016e\3\2\2\2k\u0170\3\2\2\2m\u017b\3\2"+
		"\2\2o\u018a\3\2\2\2q\u0192\3\2\2\2s\u019f\3\2\2\2u\u01bf\3\2\2\2w\u01c2"+
		"\3\2\2\2y\u01c6\3\2\2\2{\u01d2\3\2\2\2}\u01d4\3\2\2\2\177\u01d8\3\2\2"+
		"\2\u0081\u01dc\3\2\2\2\u0083\u01e2\3\2\2\2\u0085\u01e4\3\2\2\2\u0087\u01ea"+
		"\3\2\2\2\u0089\u01ec\3\2\2\2\u008b\u01ee\3\2\2\2\u008d\u01f0\3\2\2\2\u008f"+
		"\u01fb\3\2\2\2\u0091\u0094\5w<\2\u0092\u0094\5u;\2\u0093\u0091\3\2\2\2"+
		"\u0093\u0092\3\2\2\2\u0094\4\3\2\2\2\u0095\u009b\5y=\2\u0096\u009b\5{"+
		">\2\u0097\u009b\5}?\2\u0098\u009b\5\u0081A\2\u0099\u009b\5\13\6\2\u009a"+
		"\u0095\3\2\2\2\u009a\u0096\3\2\2\2\u009a\u0097\3\2\2\2\u009a\u0098\3\2"+
		"\2\2\u009a\u0099\3\2\2\2\u009b\6\3\2\2\2\u009c\u00a4\5\21\t\2\u009d\u00a4"+
		"\5\23\n\2\u009e\u00a4\5\17\b\2\u009f\u00a4\5\r\7\2\u00a0\u00a4\5\25\13"+
		"\2\u00a1\u00a4\5\27\f\2\u00a2\u00a4\5\31\r\2\u00a3\u009c\3\2\2\2\u00a3"+
		"\u009d\3\2\2\2\u00a3\u009e\3\2\2\2\u00a3\u009f\3\2\2\2\u00a3\u00a0\3\2"+
		"\2\2\u00a3\u00a1\3\2\2\2\u00a3\u00a2\3\2\2\2\u00a4\b\3\2\2\2\u00a5\u00a6"+
		"\5\7\4\2\u00a6\u00a7\5=\37\2\u00a7\u00a8\5? \2\u00a8\n\3\2\2\2\u00a9\u00aa"+
		"\7p\2\2\u00aa\u00ab\7w\2\2\u00ab\u00ac\7n\2\2\u00ac\u00ad\7n\2\2\u00ad"+
		"\f\3\2\2\2\u00ae\u00af\7d\2\2\u00af\u00b0\7q\2\2\u00b0\u00b1\7q\2\2\u00b1"+
		"\u00b2\7n\2\2\u00b2\16\3\2\2\2\u00b3\u00b4\7u\2\2\u00b4\u00b5\7v\2\2\u00b5"+
		"\u00b6\7t\2\2\u00b6\u00b7\7k\2\2\u00b7\u00b8\7p\2\2\u00b8\u00b9\7i\2\2"+
		"\u00b9\20\3\2\2\2\u00ba\u00bb\7k\2\2\u00bb\u00bc\7p\2\2\u00bc\u00bd\7"+
		"v\2\2\u00bd\22\3\2\2\2\u00be\u00bf\7f\2\2\u00bf\u00c0\7g\2\2\u00c0\u00c1"+
		"\7e\2\2\u00c1\u00c2\7k\2\2\u00c2\u00c3\7o\2\2\u00c3\u00c4\7c\2\2\u00c4"+
		"\u00c5\7n\2\2\u00c5\24\3\2\2\2\u00c6\u00c7\7f\2\2\u00c7\u00c8\7c\2\2\u00c8"+
		"\u00c9\7v\2\2\u00c9\u00ca\7g\2\2\u00ca\26\3\2\2\2\u00cb\u00cc\7f\2\2\u00cc"+
		"\u00cd\7c\2\2\u00cd\u00ce\7v\2\2\u00ce\u00cf\7g\2\2\u00cf\u00d0\7v\2\2"+
		"\u00d0\u00d1\7k\2\2\u00d1\u00d2\7o\2\2\u00d2\u00d3\7g\2\2\u00d3\30\3\2"+
		"\2\2\u00d4\u00d5\7q\2\2\u00d5\u00d6\7d\2\2\u00d6\u00d7\7l\2\2\u00d7\u00d8"+
		"\7g\2\2\u00d8\u00d9\7e\2\2\u00d9\u00da\7v\2\2\u00da\32\3\2\2\2\u00db\u00dc"+
		"\7h\2\2\u00dc\u00dd\7w\2\2\u00dd\u00de\7p\2\2\u00de\u00df\7e\2\2\u00df"+
		"\u00e0\7v\2\2\u00e0\u00e1\7k\2\2\u00e1\u00e2\7q\2\2\u00e2\u00e3\7p\2\2"+
		"\u00e3\34\3\2\2\2\u00e4\u00e5\7x\2\2\u00e5\u00e6\7q\2\2\u00e6\u00e7\7"+
		"k\2\2\u00e7\u00e8\7f\2\2\u00e8\36\3\2\2\2\u00e9\u00ea\7r\2\2\u00ea\u00eb"+
		"\7t\2\2\u00eb\u00ec\7k\2\2\u00ec\u00ed\7p\2\2\u00ed\u00ee\7v\2\2\u00ee"+
		" \3\2\2\2\u00ef\u00f0\7k\2\2\u00f0\u00f1\7h\2\2\u00f1\"\3\2\2\2\u00f2"+
		"\u00f3\7g\2\2\u00f3\u00f4\7n\2\2\u00f4\u00f5\7u\2\2\u00f5\u00f6\7g\2\2"+
		"\u00f6$\3\2\2\2\u00f7\u00f8\7y\2\2\u00f8\u00f9\7j\2\2\u00f9\u00fa\7k\2"+
		"\2\u00fa\u00fb\7n\2\2\u00fb\u00fc\7g\2\2\u00fc&\3\2\2\2\u00fd\u00fe\7"+
		"u\2\2\u00fe\u00ff\7y\2\2\u00ff\u0100\7k\2\2\u0100\u0101\7v\2\2\u0101\u0102"+
		"\7e\2\2\u0102\u0103\7j\2\2\u0103(\3\2\2\2\u0104\u0105\7e\2\2\u0105\u0106"+
		"\7c\2\2\u0106\u0107\7u\2\2\u0107\u0108\7g\2\2\u0108*\3\2\2\2\u0109\u010a"+
		"\7f\2\2\u010a\u010b\7g\2\2\u010b\u010c\7h\2\2\u010c\u010d\7c\2\2\u010d"+
		"\u010e\7w\2\2\u010e\u010f\7n\2\2\u010f\u0110\7v\2\2\u0110,\3\2\2\2\u0111"+
		"\u0112\7t\2\2\u0112\u0113\7g\2\2\u0113\u0114\7v\2\2\u0114\u0115\7w\2\2"+
		"\u0115\u0116\7t\2\2\u0116\u0117\7p\2\2\u0117.\3\2\2\2\u0118\u0119\7h\2"+
		"\2\u0119\u011a\7q\2\2\u011a\u011b\7t\2\2\u011b\u011c\7g\2\2\u011c\u011d"+
		"\7c\2\2\u011d\u011e\7e\2\2\u011e\u011f\7j\2\2\u011f\60\3\2\2\2\u0120\u0121"+
		"\7d\2\2\u0121\u0122\7t\2\2\u0122\u0123\7g\2\2\u0123\u0124\7c\2\2\u0124"+
		"\u0125\7m\2\2\u0125\62\3\2\2\2\u0126\u0127\7k\2\2\u0127\u0128\7p\2\2\u0128"+
		"\64\3\2\2\2\u0129\u012a\7h\2\2\u012a\u012b\7c\2\2\u012b\u012c\7n\2\2\u012c"+
		"\u012d\7u\2\2\u012d\u0130\7g\2\2\u012e\u0130\7\62\2\2\u012f\u0129\3\2"+
		"\2\2\u012f\u012e\3\2\2\2\u0130\66\3\2\2\2\u0131\u0132\7v\2\2\u0132\u0133"+
		"\7t\2\2\u0133\u0134\7w\2\2\u0134\u0137\7g\2\2\u0135\u0137\7\63\2\2\u0136"+
		"\u0131\3\2\2\2\u0136\u0135\3\2\2\2\u01378\3\2\2\2\u0138\u0139\7}\2\2\u0139"+
		":\3\2\2\2\u013a\u013b\7\177\2\2\u013b<\3\2\2\2\u013c\u013d\7]\2\2\u013d"+
		">\3\2\2\2\u013e\u013f\7_\2\2\u013f@\3\2\2\2\u0140\u0141\7*\2\2\u0141B"+
		"\3\2\2\2\u0142\u0143\7+\2\2\u0143D\3\2\2\2\u0144\u0145\7.\2\2\u0145F\3"+
		"\2\2\2\u0146\u0147\7<\2\2\u0147H\3\2\2\2\u0148\u0149\7A\2\2\u0149J\3\2"+
		"\2\2\u014a\u014b\7-\2\2\u014bL\3\2\2\2\u014c\u014d\7/\2\2\u014dN\3\2\2"+
		"\2\u014e\u014f\7,\2\2\u014fP\3\2\2\2\u0150\u0151\7\61\2\2\u0151R\3\2\2"+
		"\2\u0152\u0153\7-\2\2\u0153\u0154\7-\2\2\u0154T\3\2\2\2\u0155\u0156\7"+
		"/\2\2\u0156\u0157\7/\2\2\u0157V\3\2\2\2\u0158\u0159\7#\2\2\u0159X\3\2"+
		"\2\2\u015a\u015b\7#\2\2\u015b\u015c\7?\2\2\u015cZ\3\2\2\2\u015d\u015e"+
		"\7>\2\2\u015e\u015f\7?\2\2\u015f\\\3\2\2\2\u0160\u0161\7@\2\2\u0161\u0162"+
		"\7?\2\2\u0162^\3\2\2\2\u0163\u0164\7@\2\2\u0164`\3\2\2\2\u0165\u0166\7"+
		">\2\2\u0166b\3\2\2\2\u0167\u0168\7?\2\2\u0168\u0169\7?\2\2\u0169d\3\2"+
		"\2\2\u016a\u016b\7?\2\2\u016bf\3\2\2\2\u016c\u016d\7(\2\2\u016dh\3\2\2"+
		"\2\u016e\u016f\7\60\2\2\u016fj\3\2\2\2\u0170\u0171\7\61\2\2\u0171\u0172"+
		"\7\61\2\2\u0172\u0176\3\2\2\2\u0173\u0175\n\2\2\2\u0174\u0173\3\2\2\2"+
		"\u0175\u0178\3\2\2\2\u0176\u0174\3\2\2\2\u0176\u0177\3\2\2\2\u0177\u0179"+
		"\3\2\2\2\u0178\u0176\3\2\2\2\u0179\u017a\b\66\2\2\u017al\3\2\2\2\u017b"+
		"\u017c\7\61\2\2\u017c\u017d\7,\2\2\u017d\u0181\3\2\2\2\u017e\u0180\13"+
		"\2\2\2\u017f\u017e\3\2\2\2\u0180\u0183\3\2\2\2\u0181\u0182\3\2\2\2\u0181"+
		"\u017f\3\2\2\2\u0182\u0184\3\2\2\2\u0183\u0181\3\2\2\2\u0184\u0185\7,"+
		"\2\2\u0185\u0186\7\61\2\2\u0186\u0187\3\2\2\2\u0187\u0188\b\67\2\2\u0188"+
		"n\3\2\2\2\u0189\u018b\t\3\2\2\u018a\u0189\3\2\2\2\u018b\u018c\3\2\2\2"+
		"\u018c\u018a\3\2\2\2\u018c\u018d\3\2\2\2\u018d\u018e\3\2\2\2\u018e\u018f"+
		"\b8\2\2\u018fp\3\2\2\2\u0190\u0193\5\u0083B\2\u0191\u0193\5\u008bF\2\u0192"+
		"\u0190\3\2\2\2\u0192\u0191\3\2\2\2\u0193\u0194\3\2\2\2\u0194\u0192\3\2"+
		"\2\2\u0194\u0195\3\2\2\2\u0195\u0199\3\2\2\2\u0196\u019a\5\u0083B\2\u0197"+
		"\u019a\5\u0085C\2\u0198\u019a\5\u008bF\2\u0199\u0196\3\2\2\2\u0199\u0197"+
		"\3\2\2\2\u0199\u0198\3\2\2\2\u019a\u019b\3\2\2\2\u019b\u0199\3\2\2\2\u019b"+
		"\u019c\3\2\2\2\u019cr\3\2\2\2\u019d\u01a0\5\u0083B\2\u019e\u01a0\5\u008b"+
		"F\2\u019f\u019d\3\2\2\2\u019f\u019e\3\2\2\2\u01a0\u01a6\3\2\2\2\u01a1"+
		"\u01a5\5\u0083B\2\u01a2\u01a5\5\u0085C\2\u01a3\u01a5\5\u008bF\2\u01a4"+
		"\u01a1\3\2\2\2\u01a4\u01a2\3\2\2\2\u01a4\u01a3\3\2\2\2\u01a5\u01a8\3\2"+
		"\2\2\u01a6\u01a4\3\2\2\2\u01a6\u01a7\3\2\2\2\u01a7t\3\2\2\2\u01a8\u01a6"+
		"\3\2\2\2\u01a9\u01ab\5\u0085C\2\u01aa\u01a9\3\2\2\2\u01ab\u01ac\3\2\2"+
		"\2\u01ac\u01aa\3\2\2\2\u01ac\u01ad\3\2\2\2\u01ad\u01c0\3\2\2\2\u01ae\u01b0"+
		"\5\u0085C\2\u01af\u01ae\3\2\2\2\u01b0\u01b1\3\2\2\2\u01b1\u01af\3\2\2"+
		"\2\u01b1\u01b2\3\2\2\2\u01b2\u01b3\3\2\2\2\u01b3\u01b5\5i\65\2\u01b4\u01b6"+
		"\5\u0085C\2\u01b5\u01b4\3\2\2\2\u01b6\u01b7\3\2\2\2\u01b7\u01b5\3\2\2"+
		"\2\u01b7\u01b8\3\2\2\2\u01b8\u01c0\3\2\2\2\u01b9\u01bb\5i\65\2\u01ba\u01bc"+
		"\5\u0085C\2\u01bb\u01ba\3\2\2\2\u01bc\u01bd\3\2\2\2\u01bd\u01bb\3\2\2"+
		"\2\u01bd\u01be\3\2\2\2\u01be\u01c0\3\2\2\2\u01bf\u01aa\3\2\2\2\u01bf\u01af"+
		"\3\2\2\2\u01bf\u01b9\3\2\2\2\u01c0v\3\2\2\2\u01c1\u01c3\5\u0085C\2\u01c2"+
		"\u01c1\3\2\2\2\u01c3\u01c4\3\2\2\2\u01c4\u01c2\3\2\2\2\u01c4\u01c5\3\2"+
		"\2\2\u01c5x\3\2\2\2\u01c6\u01cb\7$\2\2\u01c7\u01ca\5\u0087D\2\u01c8\u01ca"+
		"\13\2\2\2\u01c9\u01c7\3\2\2\2\u01c9\u01c8\3\2\2\2\u01ca\u01cd\3\2\2\2"+
		"\u01cb\u01cc\3\2\2\2\u01cb\u01c9\3\2\2\2\u01cc\u01ce\3\2\2\2\u01cd\u01cb"+
		"\3\2\2\2\u01ce\u01cf\7$\2\2\u01cfz\3\2\2\2\u01d0\u01d3\5\67\34\2\u01d1"+
		"\u01d3\5\65\33\2\u01d2\u01d0\3\2\2\2\u01d2\u01d1\3\2\2\2\u01d3|\3\2\2"+
		"\2\u01d4\u01d5\7$\2\2\u01d5\u01d6\5\u008dG\2\u01d6\u01d7\7$\2\2\u01d7"+
		"~\3\2\2\2\u01d8\u01d9\7$\2\2\u01d9\u01da\5\u008fH\2\u01da\u01db\7$\2\2"+
		"\u01db\u0080\3\2\2\2\u01dc\u01dd\7$\2\2\u01dd\u01de\5}?\2\u01de\u01df"+
		"\7V\2\2\u01df\u01e0\5\177@\2\u01e0\u01e1\7$\2\2\u01e1\u0082\3\2\2\2\u01e2"+
		"\u01e3\t\4\2\2\u01e3\u0084\3\2\2\2\u01e4\u01e5\t\5\2\2\u01e5\u0086\3\2"+
		"\2\2\u01e6\u01e7\7^\2\2\u01e7\u01eb\7$\2\2\u01e8\u01e9\7^\2\2\u01e9\u01eb"+
		"\7^\2\2\u01ea\u01e6\3\2\2\2\u01ea\u01e8\3\2\2\2\u01eb\u0088\3\2\2\2\u01ec"+
		"\u01ed\7/\2\2\u01ed\u008a\3\2\2\2\u01ee\u01ef\7a\2\2\u01ef\u008c\3\2\2"+
		"\2\u01f0\u01f1\5\u0085C\2\u01f1\u01f2\5\u0085C\2\u01f2\u01f3\5\u0085C"+
		"\2\u01f3\u01f4\5\u0085C\2\u01f4\u01f5\5\u0089E\2\u01f5\u01f6\5\u0085C"+
		"\2\u01f6\u01f7\5\u0085C\2\u01f7\u01f8\5\u0089E\2\u01f8\u01f9\5\u0085C"+
		"\2\u01f9\u01fa\5\u0085C\2\u01fa\u008e\3\2\2\2\u01fb\u01fc\5\u0085C\2\u01fc"+
		"\u01fd\5\u0085C\2\u01fd\u01fe\5G$\2\u01fe\u01ff\5\u0085C\2\u01ff\u0200"+
		"\5\u0085C\2\u0200\u0201\5G$\2\u0201\u0202\5\u0085C\2\u0202\u0203\5\u0085"+
		"C\2\u0203\u0090\3\2\2\2\34\2\u0093\u009a\u00a3\u012f\u0136\u0176\u0181"+
		"\u018c\u0192\u0194\u0199\u019b\u019f\u01a4\u01a6\u01ac\u01b1\u01b7\u01bd"+
		"\u01bf\u01c4\u01c9\u01cb\u01d2\u01ea\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}