/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG6221
/// </summary>
/// 
///References
///Chand, M., 2018. C# Corner. [Online] 
///Available at: https://www.c-sharpcorner.com/article/change-console-foreground-and-background-color-in-c-sharp/
///[Accessed 15 April 2024].
///
///Microsoft, 2022.Learn Microsoft. [Online]
///Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
///[Accessed 30 May 2024].
///
///Microsoft, 2024. Learn Microsoft. [Online] 
///Available at: https://learn.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing?view=vs-2022&tabs=dotnet%2Cmstest
///[Accessed 30 May 2024].
///
///Troelsen, A. & Japikse, P., 2022.Pro C# 10 with .NET 6 Foundational Principles and Practices in Programming. 11th ed. USA: Apress.
///
///TutorialsTeacher, 2024. TutorialsTeacher. [Online]
///Available at: https://www.tutorialsteacher.com/csharp/csharp-list
///[Accessed 28 May 2024].
///
///w3resource, 2024.w3resource. [Online]
///Available at: https://www.w3resource.com/csharp-exercises/exception-handling/csharp-exception-handling-exercise-6.php
///[Accessed 15 April 2024].
///

using RecipeApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This is my main class that will be used run the RecipeApp. 
/// It will call the RecipeDetails class to run the RecipeAppMenu method.
/// </summary> 
namespace RecipeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startProgram = new RecipeMethods();
            startProgram.RecipeAppMenu();
        }
    }
}
