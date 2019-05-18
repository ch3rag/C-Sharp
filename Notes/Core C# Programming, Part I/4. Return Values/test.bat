@echo off
rem A batch file for Test.exe
rem which captures the app's return value

rem Run Test Application
Test

@if "%ERRORLEVEL%" == "0" goto sucess
	
:fail
	echo This application has failed
	echo return value = %ERRORLEVEL%
	goto end
:sucess
	echo This application has succeeded!
	echo return value = %ERRORLEVEL%
	goto end
:end	
	echo All Done.
	