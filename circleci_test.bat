dotnet test Calculator/xUnitProject/xUnitProject.csproj --configuration Release --logger "junit;LogFileName=xunit-test-results.xml" 
dotnet test Calculator/AnalizerClassLibrary.Tests/AnalizerClassLibrary.Tests.csproj --configuration Release --no-build --logger "junit;LogFileName=analizer-test-results.xml" 
dotnet test Calculator/TestProject2.Tests/TestProject2.Tests.csproj --configuration Release --logger "junit;LogFileName=xunit2-test-results.xml" 
dotnet test Calculator/TestProject2.Tests/TestProject2.Tests.csproj --configuration Release --logger "junit;LogFileName=xunit3-test-results.xml" 
pause
