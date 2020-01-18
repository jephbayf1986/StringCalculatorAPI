# String Calculator API
###  C# web-based API application that evaluates a string expression consisting of non-negative integers and the + - / * operators only

## Notes
 * Developed in .Net CORE 3.1
 * The following Libraries were for Testing: XUnit, Moq, Shouldly
 
## Thought Process
 * The main problems I had to overcome:
   * Splitting a string up into potentially infinite calculations
   * Calculating in the correct order *(BO)DMAS*
   * Retrieving the Calculation String via API in the most User Friendly way (As GET doesn't allow Body in Apps such as Postman)

## Solution
The method I used is as follows:
 * Regular Expressions used to identify smaller calculations within the overall string
 * In order of *(BO)DMAS* (Divide, then Multiply etc) identify each smaller calculation then replace that with it's result
 * Continue until all operators have been removed, or only 1 or 2 negative signs remain at the start.
 * Considered throwing an error whenever a Subtraction results in a negative, however this was not specified.
I implemented the following to ensure maintainable and production quality code:
 * Split up architecture into 3 projects: Core Logic, Presentation to User and Testing.
 * All operators to inherit from the same abstract **Operator** class
 * Abstract Factory Pattern to create Operator
 * Dependency Inversion by using Interfaces
 * Avoided use of lots of `IF ELSE` statements, making code difficult to read.

# How to Build, Run and Test the Application

**Important:** You need to have .NET Core SDK 3.1 by clicking [here](https://dotnet.microsoft.com/download/dotnet-core, ".Net Core SDKs"):

### Visual Studio:

 * After Downloading the files, open *StringCalculator.sln* in Visual Studio
 * When the Project has loaded tap **Ctrl + Shift + B** to Build the Application
 * Tap **F5** to Run the Application
 * Use an API support application such as [Postman](https://www.getpostman.com) to test the Calculation, as you need to POST the calculation in the request body.
 * To Test the application open the Test Explorer in Visual Studio with **Ctrl + E + T** and **Ctrl + A + R** to run the tests.
