# ChangeCalculatorApp

Lightweight .NET 9 console app that computes change (pounds/pence). This README explains how to build, run, and test the project from a Github clone.

## Prerequisites
- .NET 9 SDK installed (verify with `dotnet --info`).
- Git.
- Visual Studio 2022 (optional)
- XUnit (required for running unit tests)

## How to build

### Visual Studio
Open up .sln file, right click on ChangeCalculatorApp project and set as startup project, select build -> build solution. After this is done the project and unit tests should be runnable from within visual studio

### CLI
'dotnet restore dotnet build'
'dotnet run --project ChangeCalculatorApp/ChangeCalculatorApp.csproj'

## Structure
App contains two projects 
ChangeCalculatorApp contains all of the logic required for the application with ChangeCalculator.cs being a class that implements most of the change caluclating functionality and Program.cs containing the main function that allows for input and output
ChangeCalculatorApp.Tests contains all of the XUnit unit tests, these can either be run manually through 'dotnet test' or through visual studio

## Usage
Running the app should open up a console window, the user will first be prompted to input an initial money amount, this can either be done in whole pounds, pounds and pence or just pence for example, "£5", "£5.00" or "500p"
typing in the amount in a wrong format will inform the user there was a mistake and allow them to reinput the value, next the player will be prompted to input the cost of the item following the same rules and at the end
the application will output the change given going from highest denomination to lowest.
