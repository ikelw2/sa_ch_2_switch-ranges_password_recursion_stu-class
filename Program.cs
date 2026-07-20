using Spectre.Console;
using System.Xml.Linq;
using StudentNamespace;
using System;
using System.Text;


#region StartupTasks
// Clearscreen and Welcome message using Spectre.Console
AnsiConsole.Clear();
AnsiConsole.Write(new Panel("[gray]Challenge 2: Switch Ranges, Password, Recursion, Stu-Class[/]").BorderColor(Color.MediumVioletRed));
#endregion





// Challenge 2.1 ///////////////////////////////////////////////////////////////////////
//
//          █████                ████  ████                                            ████████     ████ 
//         ░░███                ░░███ ░░███                                           ███░░░░███   ░░███ 
//  ██████  ░███████    ██████   ░███  ░███   ██████  ████████    ███████  ██████    ░░░    ░███    ░███ 
// ███░░███ ░███░░███  ░░░░░███  ░███  ░███  ███░░███░░███░░███  ███░░███ ███░░███      ███████     ░███ 
//░███ ░░░  ░███ ░███   ███████  ░███  ░███ ░███████  ░███ ░███ ░███ ░███░███████      ███░░░░      ░███ 
//░███  ███ ░███ ░███  ███░░███  ░███  ░███ ░███░░░   ░███ ░███ ░███ ░███░███░░░      ███      █    ░███ 
//░░██████  ████ █████░░████████ █████ █████░░██████  ████ █████░░███████░░██████    ░██████████ ██ █████
// ░░░░░░  ░░░░ ░░░░░  ░░░░░░░░ ░░░░░ ░░░░░  ░░░░░░  ░░░░ ░░░░░  ░░░░░███ ░░░░░░     ░░░░░░░░░░ ░░ ░░░░░ 
//                                                               ███ ░███                                
//                                                              ░░██████                                 
//                                                               ░░░░░░                                  
#region Challenge_2_1 
AnsiConsole.MarkupLine("\n[bold magenta]Challenge 2.1 - Temperature calculator[/]\n");

// step 1: get temp in farenheit
int tempFarenheit = AnsiConsole.Prompt(
    new TextPrompt<int>("Enter the temperature in Farenheit: ")
        .PromptStyle("yellow")
        .ValidationErrorMessage("[red]Invalid entry.[/] Must be a valid integer number.")
);
string description = tempFarenheit switch
{
    < 0 => "below freezing", // would be correct for Celsius (0) not Farenheit (32), but for the sake of this exercise...
    >= 0 and <= 10 => "Freezing",
    > 10 and <= 20 => "Very Cold",
    > 20 and <= 35 => "Cold",
    > 35 and <= 50 => "Normal",
    > 50 and <= 65 => "Hot",
    > 65 and <= 80 => "Very Hot",
    > 80 => "Too Hot"
};
AnsiConsole.MarkupLine($"\n[bold green] It's[/] [bold black on white]{description}[/] [bold green]weather out![/]\n");

#endregion
// Challenge_2_1 ///////////////////////////////////////////////////////////////////////





// Challenge 2.2 ///////////////////////////////////////////////////////////////////////
//
//          █████                ████  ████                                            ████████      ████████ 
//         ░░███                ░░███ ░░███                                           ███░░░░███    ███░░░░███
//  ██████  ░███████    ██████   ░███  ░███   ██████  ████████    ███████  ██████    ░░░    ░███   ░░░    ░███
// ███░░███ ░███░░███  ░░░░░███  ░███  ░███  ███░░███░░███░░███  ███░░███ ███░░███      ███████       ███████ 
//░███ ░░░  ░███ ░███   ███████  ░███  ░███ ░███████  ░███ ░███ ░███ ░███░███████      ███░░░░       ███░░░░  
//░███  ███ ░███ ░███  ███░░███  ░███  ░███ ░███░░░   ░███ ░███ ░███ ░███░███░░░      ███      █    ███      █
//░░██████  ████ █████░░████████ █████ █████░░██████  ████ █████░░███████░░██████    ░██████████ ██░██████████
// ░░░░░░  ░░░░ ░░░░░  ░░░░░░░░ ░░░░░ ░░░░░  ░░░░░░  ░░░░ ░░░░░  ░░░░░███ ░░░░░░     ░░░░░░░░░░ ░░ ░░░░░░░░░░ 
//                                                               ███ ░███                                     
//                                                              ░░██████                                      
//                                                               ░░░░░░                                       
//                                                                                                            
#region Challenge_2_2
AnsiConsole.MarkupLine("\n[bold magenta]Challenge 2.2 - UserID and Password Input[/]\n");


if (CredentialCheck.ResetCredentials()) // define credentials for testing VerifyCredentials functionality
{
    if (CredentialCheck.VerifyCredentials())
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nSucccesful logon.");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nToo many attempts - blocked.");
    }
    Console.ResetColor();
}
//Console.ReadLine(); 

#endregion
// Challenge 2.2 ///////////////////////////////////////////////////////////////////////












// Challenge 2.3 ///////////////////////////////////////////////////////////////////////
//
//          █████                ████  ████                                            ████████      ████████ 
//         ░░███                ░░███ ░░███                                           ███░░░░███    ███░░░░███
//  ██████  ░███████    ██████   ░███  ░███   ██████  ████████    ███████  ██████    ░░░    ░███   ░░░    ░███
// ███░░███ ░███░░███  ░░░░░███  ░███  ░███  ███░░███░░███░░███  ███░░███ ███░░███      ███████       ██████░ 
//░███ ░░░  ░███ ░███   ███████  ░███  ░███ ░███████  ░███ ░███ ░███ ░███░███████      ███░░░░       ░░░░░░███
//░███  ███ ░███ ░███  ███░░███  ░███  ░███ ░███░░░   ░███ ░███ ░███ ░███░███░░░      ███      █    ███   ░███
//░░██████  ████ █████░░████████ █████ █████░░██████  ████ █████░░███████░░██████    ░██████████ ██░░████████ 
// ░░░░░░  ░░░░ ░░░░░  ░░░░░░░░ ░░░░░ ░░░░░  ░░░░░░  ░░░░ ░░░░░  ░░░░░███ ░░░░░░     ░░░░░░░░░░ ░░  ░░░░░░░░  
//                                                               ███ ░███                                     
//                                                              ░░██████                                      
//                                                               ░░░░░░                                       
//
#region Challenge_2_3

AnsiConsole.MarkupLine("\n[bold magenta]Challenge 2.3 - Texture Triangle using Recursion[/]\n\n");

Console.Write("Enter a texture digit: ");
string myString = Convert.ToString(Console.ReadLine());

string texture = myString.Substring(0, 1);

Console.Write("\nEnter the desired width: ");
int width = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();
Console.WriteLine("method 1 - PrintTriangleRecursive");
PrintTriangleRecursive(width);   // TESTED, works;  recursive function uses more memory because whenever it calls itself 
                                 // it copies itself to the stack, therefore, it is better to use the regular for loop
                                 // It would be educational to demonstrate visually how this works... let me know if you
                                 // can help with a demo
Console.ReadLine();
Console.WriteLine();
Console.WriteLine("method 2 - PrintTriangleUsingNestedForLoop");
PrintTriangleUsingNestedForLoop(width); // DOES NOT WORK, but almost certainly better memory optimization than recursion
Console.ReadLine();

Console.WriteLine();
Console.WriteLine("method 3 - PrintTriangleUsingSingleForLoop");
PrintTriangleUsingSingleForLoop(); // works fine, and almost certainly better memory optimization than nested for loop
Console.ReadLine();
//-----------------------------------------------------------
void PrintTriangleRecursive (int number) // works, but due to recursion, likely not the most efficient memory usage wise, esp in large cases
{
    for (int i = number; i > 0; i--)
    {
        Console.Write(texture);
    }
    Console.WriteLine();
    if (number > 1)
    {
        PrintTriangleRecursive(number - 1);
    }
}
//-----------------------------------------------------------
void PrintTriangleUsingNestedForLoop (int number) // UNTESTED
{
    StringBuilder sb = new();
    int lineWidth = number;
    char firstChar = texture[0];
    for (int i = 0; i < number; i++) // repeat for number lines 
    {
        for (int j = 0; j > lineWidth; j++) // add character for lineWidth width, decrementing each line
        {
            sb.Append(firstChar);
        }
        sb.AppendLine();
        lineWidth--;
    }
    Console.WriteLine(sb.ToString());
}
//-----------------------------------------------------------
void PrintTriangleUsingSingleForLoop () // UNTESTED
{
    StringBuilder sb = new();
    char firstChar = texture[0];
    for (int i = width; i > 0; i--) // 4, 3, 2, 1
    {
        sb.Append(firstChar, i); // #### // appends the quantity of characters as well 
        sb.AppendLine(); // newline
    }
    Console.WriteLine(sb.ToString());
}
//-----------------------------------------------------------

// Write a C# Sharp program that takes a number and a width also a number, as input and then displays a triangle of that width, using that number.
// Test Data
// Enter a number: 6
// Enter the desired width: 6
// Expected Output:

// 666666
// 66666
// 6666
// 666
// 66
// 6

#endregion
// Challenge 2.3 ///////////////////////////////////////////////////////////////////////











// Challenge 2.4 ///////////////////////////////////////////////////////////////////////
//
//          █████                ████  ████                                            ████████     █████ █████ 
//         ░░███                ░░███ ░░███                                           ███░░░░███   ░░███ ░░███  
//  ██████  ░███████    ██████   ░███  ░███   ██████  ████████    ███████  ██████    ░░░    ░███    ░███  ░███ █
// ███░░███ ░███░░███  ░░░░░███  ░███  ░███  ███░░███░░███░░███  ███░░███ ███░░███      ███████     ░███████████
//░███ ░░░  ░███ ░███   ███████  ░███  ░███ ░███████  ░███ ░███ ░███ ░███░███████      ███░░░░      ░░░░░░░███░█
//░███  ███ ░███ ░███  ███░░███  ░███  ░███ ░███░░░   ░███ ░███ ░███ ░███░███░░░      ███      █          ░███░ 
//░░██████  ████ █████░░████████ █████ █████░░██████  ████ █████░░███████░░██████    ░██████████ ██       █████ 
// ░░░░░░  ░░░░ ░░░░░  ░░░░░░░░ ░░░░░ ░░░░░  ░░░░░░  ░░░░ ░░░░░  ░░░░░███ ░░░░░░     ░░░░░░░░░░ ░░       ░░░░░  
//                                                               ███ ░███                                       
//                                                              ░░██████                                        
//                                                               ░░░░░░                                         
#region Challenge_2_4

AnsiConsole.MarkupLine("\n[bold magenta]Challenge 2.4 - Student Class Structure[/]\n\n");
// using StudentNamespace; // included at the top of this file

Student myStudentTestCase = new();  

myStudentTestCase.SetStudentFullName();
myStudentTestCase.SetRollNumber();
myStudentTestCase.SetNumberOfClasses();
myStudentTestCase.SetClasses();
myStudentTestCase.SetMarks();

myStudentTestCase.GetStudentSummaryData();

#endregion
// Challenge 2.4 ///////////////////////////////////////////////////////////////////////






#region ShutdownTasks
// ------------------------------------------------------------------------
// End of Code, wait for user to press enter, and clear background
Console.ReadLine();
AnsiConsole.Clear();
//
#endregion
