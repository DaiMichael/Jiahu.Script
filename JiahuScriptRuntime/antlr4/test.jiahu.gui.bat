@echo off

java -cp .;antlr-4.5.1-complete.jar org.antlr.v4.Tool .\..\JiahuScript\Grammar\JiahuScript.g4

IF %ERRORLEVEL% NEQ 0 GOTO ERROR_HANDLER

mkdir .\tmpTestRig >nul 2>&1
move /Y .\..\JiahuScript\Grammar\*.tokens .\tmpTestRig\ >nul 2>&1
move /Y .\..\JiahuScript\Grammar\*.java .\tmpTestRig\ >nul 2>&1
copy /Y antlr-4.5.1-complete.jar .\tmpTestRig\ >nul 2>&1

cd tmpTestRig
javac -cp .;antlr-4.5.1-complete.jar *.java
java -cp .;antlr-4.5.1-complete.jar org.antlr.v4.gui.TestRig JiahuScript script -tokens -tree -gui %*
cd ..

rmdir /s /q .\tmpTestRig

:ERROR_HANDLER
@echo on