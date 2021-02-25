# All that is open must be closed...

Implementation of the Kata [All that is open must be closed...](https://www.codewars.com/kata/55679d644c58e2df2a00009c) in C#.

# Development

## Prerequisites

To compile, test and run this project the latest [.NET Core SDK](https://dotnet.microsoft.com/download) is required on your machine.

## Build, Test, Run

On any computer with the [.NET Core SDK](https://dotnet.microsoft.com/download) run the following commands from the folder containing the `csharp.sln` file in order to build, test and run the application:

```sh
dotnet build
dotnet test
dotnet run --project "csharp.App"
```

## Identify Code Duplication (Windows only)

The `tools\dupfinder.bat` file calls the [JetBrains dupfinder](https://www.jetbrains.com/help/resharper/dupFinder.html) tool and creates an HTML report of duplicated code blocks in the solution directory.

In order to use the `tools\dupfinder.bat` you need to globally install the [JetBrains ReSharper Command Line Tools](https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html)

From the folder containing the `.sln` file run

```
tools\dupfinder.bat
```

The report will be created as `dupfinder-report.html` in the current directory.
