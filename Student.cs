using Spectre.Console;
using System;
using System.Numerics;

namespace StudentNamespace;


public class Student
{
    const int SizeOfArrays = 10; // read-only because in order to allow for flex within that limit, we must set
                                 // the length of the arrays when we instantiate the class, because array length must be CONSTant
    public int RollNumber { get; set; } // AKA "Student ID number"
    public string StudentFullName { get; set; }
    public int NumberOfClasses { get; set; }
    public int[] Marks { get; set; }
    public string[] Classes { get; set; }
    public int TotalMarks { get; set; }
    public double Percentage { get; set; }
    public string Division { get; set; } // AKA "GPA"


    public Student( int rollnumber = 1, string studentFullName = "unnamed", int numberOfClasses = 1) 
	{
        RollNumber = rollnumber;
        StudentFullName = studentFullName;
        if (numberOfClasses >= 1 && numberOfClasses <= SizeOfArrays)
        {
            NumberOfClasses = numberOfClasses;
        }
        else
        {
            NumberOfClasses = 1;
        }

        // NOTE: here we instantiate array with PRESET constant value, instead of the "NumberOfClasses", 
        // we only access the number of classes, which is less than or equal to 10
        Marks = new int[SizeOfArrays]; 
        Classes = new string[SizeOfArrays];
    }

    public void SetStudentFullName()
    {
        StudentFullName = AnsiConsole.Prompt(
            new TextPrompt<string>($"Please enter the Student Full Name: ")
                .PromptStyle("yellow")
                .ValidationErrorMessage("[red]Invalid entry.[/] Must be a valid string.")
        );
    }
    public void SetRollNumber()
    {
        RollNumber = AnsiConsole.Prompt(
            new TextPrompt<int>($"Please enter the Roll Number for [yellow bold]{StudentFullName}[/]: ")
                .PromptStyle("yellow")
                .ValidationErrorMessage("[red]Invalid entry.[/] Must be a valid integer between 101 and 500 inclusive.")
                .Validate(amount =>
                {
                    return amount switch
                    {
                        <= 100 => ValidationResult.Error("[red]The Roll Number must be above 100.[/]"),
                        > 500 => ValidationResult.Error($"[red]The Roll Number cannot exceed 500.[/]"),
                        _ => ValidationResult.Success()
                    };
                })
        );
    }

    public void SetNumberOfClasses()
    {
        // this doesn't change the size of the Arrays, which must remain constant throughout instance of class, but rather,
        // it changes the total number of elements which we access for this particular student - we don't access the entire array,
        // in other words

        NumberOfClasses = AnsiConsole.Prompt(
            new TextPrompt<int>($"Enter number of classes that [yellow bold]{StudentFullName}[/] attended: ")
                .PromptStyle("yellow")
                .ValidationErrorMessage("[red]Invalid entry.[/] Must be a valid integer number.")
                .Validate(amount =>
                {
                    return amount switch
                    {
                        <= 0 => ValidationResult.Error("[red]The number of classes must be greater than 0.[/]"),
                        > SizeOfArrays => ValidationResult.Error($"[red]The number of classes must cannot exceed {SizeOfArrays} (talk to IT if you need to fix this).[/]"),
                        _ => ValidationResult.Success()
                    };
                })
            );
    }

    public void SetClasses()
    {
        AnsiConsole.Markup($"Please enter the title, for each class that [yellow bold]{StudentFullName}[/] attended.\n");
        for (int i = 0; i < NumberOfClasses; i++)
        {
            Classes[i] = AnsiConsole.Prompt(
                new TextPrompt<string>($"Class {(i+1)}: ")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("[red]Invalid entry.[/] Must be a valid string.")
            );
        }
    }

    public void SetMarks()
    {
        AnsiConsole.Markup($"Please enter the the marks, for each class that [yellow bold]{StudentFullName}[/] attended.\n");
        for (int i = 0; i < NumberOfClasses; i++)
        {
            int tempMarks = AnsiConsole.Prompt(
                new TextPrompt<int>($"Marks in {Classes[i]}: ")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("[red]Invalid entry.[/] Must be a valid integer number.")
                    .Validate(amount =>
                    {
                        return amount switch
                        {
                            <= 0 => ValidationResult.Error("[red]The marks must be greater than 0.[/]"),
                            >= 101 => ValidationResult.Error($"[red]The marks cannot meet or exceed 101 (no extra credit here).[/]"),
                            _ => ValidationResult.Success()
                        };
                    })
                );
            Marks[i] = tempMarks;
        }
    }

    public void GetStudentSummaryData()
    {
        Console.WriteLine();
        AnsiConsole.Markup($"[white on blue]     Student Summary:                                                    [/]\n");
        AnsiConsole.Markup($"Roll No : [yellow bold]{RollNumber}[/]\n");
        AnsiConsole.Markup($"Name of Student : [yellow bold]{StudentFullName}[/]\n");
        int totalMarks = 0;
        for (int i = 0; i < NumberOfClasses; i++)
        {
            AnsiConsole.Markup($"Marks in [yellow bold]{Classes[i]}[/] : {Marks[i]}\n");
            totalMarks += Marks[i];
        }
        double avgMarks = totalMarks / NumberOfClasses;
        AnsiConsole.Markup($"Total Marks : [yellow bold]{totalMarks:N0}[/]\n");
        AnsiConsole.Markup($"Percentage : [yellow bold]{avgMarks:N2}[/]\n");
        string division = avgMarks switch
        {
            <= 60 => "failed",
            > 60 and <= 70 => "fourth",
            > 70 and <= 80 => "third",
            > 80 and <= 90 => "second",
            > 90 and <= 100 => "first"
        };
        AnsiConsole.Markup($"Division : [yellow bold]{division}[/]\n");
        AnsiConsole.Markup($"[white on blue]                                                                         [/]\n");
    }

    // 4.Write a C# Sharp program to
    // read roll no, name and marks of three subjects and calculate the total, percentage and division.
    // (use a struct / class to represent the student)

    // Test Data :
    // Input the Roll Number of the student :784
    // Input the Name of the Student :James
    // Input the marks of Physics, Chemistry and Computer Application : 70 80 90

    // Expected Output :
    // Roll No : 784
    // Name of Student : James
    // Marks in Physics : 70
    // Marks in Chemistry : 80
    // Marks in Computer Application : 90
    // Total Marks = 240
    // Percentage = 80.00
    // Division = First

}
