java -cp antlr-4.5.1-complete.jar org.antlr.v4.Tool -visitor -no-listener -Dlanguage=CSharp .\..\JiahuScript\Grammar\JiahuScript.g4

@echo off
IF %ERRORLEVEL% NEQ 0 GOTO ERROR_HANDLER

mkdir .\..\JiahuScript\ParseTree >nul 2>&1
move /Y .\..\JiahuScript\Grammar\*.tokens .\..\JiahuScript\ParseTree\ >nul 2>&1
move /Y .\..\JiahuScript\Grammar\*.cs .\..\JiahuScript\ParseTree\ >nul 2>&1

:ERROR_HANDLER
@echo on