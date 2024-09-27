@echo off
dotnet test Calculator\xUnitProject\xUnitProject.csproj --configuration Release --no-build --logger "junit;LogFileName=C:\Users\circleci\project\Calculator\TestResults\test-results-1.xml" --collect:"XPlat Code Coverage" --results-directory C:/Users/circleci/project/Calculator/CodeCoverageResults
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

dotnet test Calculator\TestProject2.Tests\TestProject2.Tests.csproj --configuration Release --no-build --logger "junit;LogFileName=C:\Users\circleci\project\Calculator\TestResults\test-results-3.xml" --collect:"XPlat Code Coverage" --results-directory C:/Users/circleci/project/Calculator/CodeCoverageResults
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

dotnet test Calculator\TestProject3.Tests\TestProject3.Tests.csproj --configuration Release --no-build --logger "junit;LogFileName=C:\Users\circleci\project\Calculator\TestResults\test-results-4.xml" --collect:"XPlat Code Coverage" --results-directory C:/Users/circleci/project/Calculator/CodeCoverageResults
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

pause
