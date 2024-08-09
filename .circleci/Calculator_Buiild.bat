msbuild Calculator/AnalizerClassLibrary/AnalizerClassLibrary.csproj /p:Configuration=Debug
if (-not $?) { exit 1 }
msbuild Calculator/CalcClassBr/CalcClassBr.csproj /p:Configuration=Debug
if (-not $?) { exit 1 }
msbuild Calculator/ErrorLibrary/ErrorLibrary.csproj /p:Configuration=Debug
if (-not $?) { exit 1 }
msbuild Calculator/GraphInterface/GraphInterface.csproj /p:Configuration=Debug
if (-not $?) { exit 1 }
msbuild Calculator/AnalizerClassLibrary.Tests/AnalizerClassLibrary.Tests.csproj /p:Configuration=Debug
if (-not $?) { exit 1 }
msbuild Calculator/xUnitProject/xUnitProject.csproj /p:Configuration=Debug
if (-not $?) { exit 1 }
msbuild Calculator/TestProject2.Tests/TestProject2.Tests.csproj /p:Configuration=Debug
if (-not $?) { exit 1 }
msbuild Calculator/TestProject3.Tests/TestProject3.Tests.csproj /p:Configuration=Debug
if (-not $?) { exit 1 }

pause
