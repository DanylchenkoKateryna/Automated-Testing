@echo off
msbuild Calculator/AnalizerClassLibrary/AnalizerClassLibrary.csproj /p:Configuration=Release /m
msbuild Calculator/CalcClassBr/CalcClassBr.csproj /p:Configuration=Release /m
msbuild Calculator/ErrorLibrary/ErrorLibrary.csproj /p:Configuration=Release /m
msbuild Calculator/GraphInterface/GraphInterface.csproj /p:Configuration=Release /m
msbuild Calculator/AnalizerClassLibrary.Tests/AnalizerClassLibrary.Tests.csproj /p:Configuration=Release /m 
msbuild Calculator/xUnitProject/xUnitProject.csproj /p:Configuration=Release /m
msbuild Calculator/TestProject2.Tests/TestProject2.Tests.csproj /p:Configuration=Release /m
msbuild Calculator/TestProject3.Tests/TestProject3.Tests.csproj /p:Configuration=Release /m
pause
