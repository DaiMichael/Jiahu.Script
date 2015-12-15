grammar JiahuScript;

script : (stat | funcDec)+;														// script can be a 1 or more statments and 0 or more functions

funcDec : definedType identifier OPEN_PARENS funcParams* CLOSE_PARENS block;	// defines function i.e. int GetCount(int myVar) { //code }
funcParams : funcParam (COMMA funcParam)*;		 								// arg list
funcParam : definedType identifier;												// for function parameters "int myInt" or "bool myBool"

stat : block
	 | print
	 | break
	 | switchStat
	 | whileStat
	 | ifStat
	 | foreachStat												
	 | returnStat 																					
	 | assignment
	 | variableDecAssign
	 | expr;

print : PRINT OPEN_PARENS expr CLOSE_PARENS;
break : BREAK;																						// break to get out of loops
switchStat : SWITCH OPEN_PARENS expr CLOSE_PARENS OPEN_BRACE caseBlock+ defaultBlock? CLOSE_BRACE;	// switch(expr) { case : value expr } or switch(expr) { case : value expr default expr }
caseBlock : CASE value COLON block;											   						// case : "string" { return 1 } etc...
defaultBlock : DEFAULT COLON block;												   					// default { return "default" } etc...
whileStat : WHILE OPEN_PARENS expr CLOSE_PARENS block;						   						// while(expr) { statments }
ifStat : IF OPEN_PARENS expr CLOSE_PARENS ifBlock=block (ELSE elseBlock=block)?;					 // if (expr) { statements } or if (expr) { statements }
foreachStat : FOREACH OPEN_PARENS variableDec IN (arrayInitaliser 
													| objectCall 
													| functionCall
													| identifier ) CLOSE_PARENS block;				// foreach(myValue in myArray) { statments }
returnStat : RETURN expr?;													   						// standard return or return "expression"
block : OPEN_BRACE (stat+)? CLOSE_BRACE;										   					// allows braces i.e. { var = 1 }

variableDec : definedType identifier;								// basic assign to be used
variableDecAssign : variableDec (ASSIGN expr)?;						// int myVar = myArray[1] or bool myBool = func(1, 2) or int i etc...

assignment : identifier ASSIGN (expr);					   			// myVar = 1+2 etc..
arrayInitaliser : OPEN_BRACE expr (COMMA expr)* CLOSE_BRACE;		// {1,2,3}

objectCall : evalObject=identifier (DOT objectCallList)+;			// allow object.Hello.GoodBye()
objectCallList : (functionCall | identifier);

functionCall : identifier OPEN_PARENS functionList? CLOSE_PARENS;	// func() or func(1) or func("hello", 1+2) etc...
functionList : expr (COMMA expr)*;									// arg list 1 var or more

expr : left=expr op=EQUAL right=expr								// expression == expression
	 | left=expr op=NOT_EQUAL right=expr							// expression != expression
	 | op=NOT right=expr											// !expression i.e. not
	 | left=expr op=LESS_THAN right=expr							// expression < expression
	 | left=expr op=LESS_OR_EQUAL right=expr						// expression <= expression
	 | left=expr op=GREATER_THAN right=expr							// expression > expression
	 | left=expr op=GREATER_OR_EQUAL right=expr						// expression >= expression
	 | left=expr op=OR right=expr									// (true || false) -- or
	 | left=expr op=AND right=expr									// (true && false) -- and
	 | expr op=PLUSPLUS												// number++ to add
	 | expr op=MINUSMINUS											// number-- to minus
	 | expr op=QUESTION inlineTrue=expr COLON inlineFalse=expr		// (i == 1) ? "one" : "two"
	 | left=expr op=(TIMES|DIV) right=expr 							// maths definition allowed "eval * eval" or "eval / eval"
	 | left=expr op=(PLUS|MINUS) right=expr							// definition all
	 | functionCall													// function call
	 | objectCall													// object
	 | identifier													// variable / function
	 | value														// value (1, "string", true)...
	 | arrayIndexer													// vector[1] or func()[1]
	 | arrayInitaliser												// pass in {"string1", "string2"} short hand
	 | left=expr op=AMPERSAND right=expr							// allow "bob" & "bob"
	 | OPEN_PARENS expr CLOSE_PARENS;								// bracketed expression

arrayIndexer : (identifier | functionCall | objectCall) arrayAccessor;	// vector[1] or func()[1]
arrayAccessor : OPEN_BRACKET expr CLOSE_BRACKET;						// [1] or [idx]
definedType : TYPE | ARRAY;
value : noneNumber | number;
identifier : ID | FUNCID;
number : (sign)? NUMBERS;
sign : MINUS;
noneNumber : NONE_NUMBER_VALUES;

//
// lexer definitions
//
NUMBERS : INT_VALUE | DECIMAL_VALUE;
NONE_NUMBER_VALUES : STRING_VALUE									// easy notation for the value types, i.e. "my string" or 1 or True
				   | BOOL_VALUE
				   | DATE_VALUE
				   | DATETIME_VALUE
				   | NULL;

TYPE : INT															// easy notation for different values i.e. int or string etc...
     | DECIMAL 
	 | STRING 
	 | BOOL
	 | DATE
	 | DATETIME
	 | OBJECT;

ARRAY : TYPE OPEN_BRACKET CLOSE_BRACKET;

DOUBLE : 'double';													// only used for casting external values to decimal
NULL : 'null';
BOOL : 'bool';
STRING : 'string';
INT : 'int';
DECIMAL : 'decimal';
DATE : 'date';
DATETIME : 'datetime';
OBJECT : 'object';
FUNCTION : 'function';
VOID : 'void';
PRINT : 'print';
IF : 'if';
ELSE : 'else';
WHILE : 'while';
SWITCH : 'switch';
CASE : 'case';
DEFAULT : 'default';
RETURN : 'return';
FOREACH : 'foreach';
BREAK : 'break';
IN : 'in';
FALSE : 'false' | '0';
TRUE : 'true' | '1';

OPEN_BRACE : '{';
CLOSE_BRACE : '}';
OPEN_BRACKET : '[';
CLOSE_BRACKET : ']';
OPEN_PARENS : '(';
CLOSE_PARENS : ')';
COMMA : ',';
COLON : ':';
QUESTION : '?';

PLUS : '+';
MINUS : '-';
TIMES : '*';
DIV : '/';

PLUSPLUS : '++';
MINUSMINUS : '--';
NOT : '!';
NOT_EQUAL : '!=';
LESS_OR_EQUAL : '<=';
GREATER_OR_EQUAL : '>=';
GREATER_THAN : '>';
LESS_THAN : '<';
EQUAL : '==';
ASSIGN : '=';
DOT : '.';
AMPERSAND : '&';
AND : '&&';
OR : '||';

LINE_COMMENT : '//' ~[\r\n]* -> skip;
COMMENT : '/*' .*? '*/' -> skip;
WS : [ \r\n\t]+ -> skip;

FUNCID : (LETTER | UNDERSCORE )+ (LETTER | DIGIT | UNDERSCORE)+;
ID : (LETTER | UNDERSCORE ) (LETTER | DIGIT | UNDERSCORE)*;


fragment DECIMAL_VALUE : DIGIT+ | DIGIT+ DOT DIGIT+ | DOT DIGIT+;
fragment INT_VALUE : DIGIT+;
fragment STRING_VALUE : '"' (ESCAPE|.)*? '"';
fragment BOOL_VALUE : TRUE | FALSE;
fragment DATE_VALUE : '"' RAW_DATE '"';
fragment TIME_VALUE : '"' RAW_TIME '"';
fragment DATETIME_VALUE : '"' DATE_VALUE 'T' TIME_VALUE '"';
fragment LETTER : [a-zA-Z];
fragment DIGIT : [0-9];
fragment ESCAPE : '\\"' | '\\\\';
fragment HYPHEN : '-';
fragment UNDERSCORE : '_';
fragment RAW_DATE : DIGIT DIGIT DIGIT DIGIT HYPHEN DIGIT DIGIT HYPHEN DIGIT DIGIT;		// using basic ISO8601 (dates are a nightmare....)
fragment RAW_TIME : DIGIT DIGIT COLON DIGIT DIGIT COLON DIGIT DIGIT;					// using basic ISO8601