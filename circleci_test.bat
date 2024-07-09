dotnet test Calculator/xUnitProject/xUnitProject.csproj --configuration Release --logger "trx;LogFileName=xunit-test-results.xml" 
dotnet test Calculator/AnalizerClassLibrary.Tests/AnalizerClassLibrary.Tests.csproj --configuration Release --no-build --logger "trx;LogFileName=analizer-test-results.xml" 

pause