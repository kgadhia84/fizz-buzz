@echo on

dotnet restore
dotnet build -c release FizzBuzz.sln
dotnet run --project ./FizzBuzz/FizzBuzz.csproj
dotnet test

set /p=Press Enter to complete.