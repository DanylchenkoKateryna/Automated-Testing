dotnet test Calculator/xUnitProject/xUnitProject.csproj --configuration Release --logger "junit;LogFileName=C:\Users\circleci\project\Calculator\TestResults\test-results-1.xml" --collect:"XPlat Code Coverage" --results-directory C:\Users\circleci\project\Calculator\CodeCoverageResults
dotnet test Calculator/AnalizerClassLibrary.Tests/AnalizerClassLibrary.Tests.csproj --configuration Release --no-build --logger "junit;LogFileName=C:\Users\circleci\project\Calculator\TestResults\test-results-2.xml" --collect:"XPlat Code Coverage" --results-directory C:\Users\circleci\project\Calculator\CodeCoverageResults
dotnet test Calculator/TestProject2.Tests/TestProject2.Tests.csproj --configuration Release --logger "junit;LogFileName=C:\Users\circleci\project\Calculator\TestResults\test-results-3.xml" --collect:"XPlat Code Coverage" --results-directory C:\Users\circleci\project\Calculator\CodeCoverageResults
dotnet test Calculator/TestProject2.Tests/TestProject2.Tests.csproj --configuration Release --logger "junit;LogFileName=C:\Users\circleci\project\Calculator\TestResults\test-results-4.xml" --collect:"XPlat Code Coverage" --results-directory C:\Users\circleci\project\Calculator\CodeCoverageResults
pause
