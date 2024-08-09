@echo off
dotnet build Calculator/AnalizerClassLibrary/AnalizerClassLibrary.csproj /p:Configuration=Release
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

msbuild Calculator/CalcClassBr/CalcClassBr.csproj /p:Configuration=Release
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

msbuild Calculator/ErrorLibrary/ErrorLibrary.csproj /p:Configuration=Release
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

msbuild Calculator/GraphInterface/GraphInterface.csproj /p:Configuration=Release 
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

msbuild Calculator/AnalizerClassLibrary.Tests/AnalizerClassLibrary.Tests.csproj /p:Configuration=Release >> build_output.txt
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

msbuild Calculator/xUnitProject/xUnitProject.csproj /p:Configuration=Release >> build_output.txt
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

msbuild Calculator/TestProject2.Tests/TestProject2.Tests.csproj /p:Configuration=Release >> build_output.txt
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

msbuild Calculator/TestProject3.Tests/TestProject3.Tests.csproj /p:Configuration=Release >> build_output.txt
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

pause
