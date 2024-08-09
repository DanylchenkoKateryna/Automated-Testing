@echo off
msbuild Calculator/AnalizerClassLibrary/AnalizerClassLibrary.csproj /p:Configuration=Debug


msbuild Calculator/CalcClassBr/CalcClassBr.csproj /p:Configuration=Debug


msbuild Calculator/ErrorLibrary/ErrorLibrary.csproj /p:Configuration=Debug


msbuild Calculator/GraphInterface/GraphInterface.csproj /p:Configuration=Debug


msbuild Calculator/AnalizerClassLibrary.Tests/AnalizerClassLibrary.Tests.csproj /p:Configuration=Debug


msbuild Calculator/xUnitProject/xUnitProject.csproj /p:Configuration=Debug


msbuild Calculator/TestProject2.Tests/TestProject2.Tests.csproj /p:Configuration=Debug


msbuild Calculator/TestProject3.Tests/TestProject3.Tests.csproj /p:Configuration=Debug


pause
