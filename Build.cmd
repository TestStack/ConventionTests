@ECHO OFF

SET msbuild="%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"

%msbuild% ConventionTests.proj

IF NOT ERRORLEVEL 0 EXIT /B %ERRORLEVEL%

pause