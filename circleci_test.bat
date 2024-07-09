dotnet test Calculator/xUnitProject/xUnitProject.csproj --configuration Release --no-build --logger "junit;LogFileName=xunit-test-results.xml" 
dotnet test Calculator/AnalizerClassLibrary.Tests/AnalizerClassLibrary.Tests.csproj --configuration Release --logger "junit;LogFileName=analizer-test-results.xml" 

pause