@echo off
start msbuild Calculator/AnalizerClassLibrary/AnalizerClassLibrary.csproj /p:Configuration=Release
start msbuild Calculator/CalcClassBr/CalcClassBr.csproj /p:Configuration=Release
start msbuild Calculator/ErrorLibrary/ErrorLibrary.csproj /p:Configuration=Release
start msbuild Calculator/GraphInterface/GraphInterface.csproj /p:Configuration=Release 
start msbuild Calculator/AnalizerClassLibrary.Tests/AnalizerClassLibrary.Tests.csproj /p:Configuration=Release >> build_output.txt
start msbuild Calculator/xUnitProject/xUnitProject.csproj /p:Configuration=Release >> build_output.txt
start msbuild Calculator/TestProject2.Tests/TestProject2.Tests.csproj /p:Configuration=Release >> build_output.txt
start msbuild Calculator/TestProject3.Tests/TestProject3.Tests.csproj /p:Configuration=Release >> build_output.txt

pause
