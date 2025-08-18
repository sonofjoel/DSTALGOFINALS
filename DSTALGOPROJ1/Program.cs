using DSTALGOPROJ1.ADTs;
using System.Security.Cryptography.X509Certificates;

namespace DSTALGOPROJ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // initialize and create
            bool running = true;
            CustomListClass MyList = new CustomListClass();
            UADT StudentSched = new UADT();
            UADT UnitsStack = new UADT(); // Added: Separate stack for units
            int TotUnits = 0;

            string[][] Subjects =
            {
                new string[] {"ISPRGG1", "Introduction to Programming 1", "M 8:00AM - 11:00AM", "3"},
                new string[] {"ISPRGG2", "Introduction to Programming 2", "M 2:40PM - 5:40PM", "3"},
                new string[] {"INCOMPU", "Introduction to Computing", "T 11:20AM - 2:20PM", "3"},
                new string[] {"MATHWRLD", "Mathematics in the Modern World", "W 11:20AM - 2:40PM", "3"},
                new string[] {"SCITECH", "Science Technology and Society", "H 8:00AM - 11:00AM", "3"},
                new string[] {"CSBLIFE", "Computer Science and Life", "F 2:40PM - 5:40PM", "2"},
                new string[] {"NSTP01", "National Service Training Program 1", "T 8:00AM - 11:00AM", "3"},
                new string[] {"DSTALGO", "Data Structure and Algorithms", "T 11:20AM - 2:20PM", "3"}
            }; // Jagged array that stores the subject, full name, day and time

            Console.Clear();
            DisplayMenu();

            while (running)
            {
                Console.Write("\nUser: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                int userchoice = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                switch (userchoice)
                {
                    case 1:
                        Console.Clear();
                        MyList.ViewSubjectSchedule(Subjects);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        DisplayMenu();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Your Current Schedule :");
                        if (TotUnits == 0)
                        {
                            Console.WriteLine("No subjects enlisted yet.");
                        }
                        else
                        {
                            StudentSched.PrintStack();
                        }
                        Console.WriteLine("\nTotal Units Enlisted: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(TotUnits);
                        Console.Write("/21");
                        Console.ResetColor();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        DisplayMenu();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Please choose a subject to add: ");

                        for (int i = 0; i < Subjects.Length; i++) // iterates and displayes the subjects
                        {
                            Console.WriteLine($"{i + 1}. {Subjects[i][0]} - {Subjects[i][1]} ({Subjects[i][2]}) - {Subjects[i][3]} units");
                        } // [i] = what subject it is, [0,1,2,3] = the index in the jagged array

                        Console.Write("\nUser: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string input = Console.ReadLine();
                        Console.ResetColor();

                        if (string.IsNullOrWhiteSpace(input)) // checks if the user typed nothing
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You must enter a number.");
                            Console.ResetColor();
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            DisplayMenu(); // calls the method to display the menu
                            break;
                        }

                        int subjectchoice = Convert.ToInt32(input);

                        if (subjectchoice >= 1 && subjectchoice <= Subjects.Length)
                        {
                            int subjectUnits = Convert.ToInt32(Subjects[subjectchoice - 1][3]); // -1 because the arrays are zero-basedd

                            if (TotUnits + subjectUnits > 21) // checks if totalunits are more that 21
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERROR!");
                                Console.ResetColor();
                                Console.WriteLine($"You can only enlist a maximum of 21 units. Current units: {TotUnits}, \nAttempted to add: {subjectUnits} units.");
                            }
                            else if (StudentSched.CheckDup(Subjects[subjectchoice - 1][0])) // checks if its a duplicate via CheckDup() Method
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You cannot enlist the same subject twice.");
                                Console.ResetColor();
                            }
                            else
                            {
                                string selectedSubject = $"{Subjects[subjectchoice - 1][0]} - {Subjects[subjectchoice - 1][1]} ({Subjects[subjectchoice - 1][2]}) - {Subjects[subjectchoice - 1][3]} units"; // converts the selected subbject into string format then pushes into a stack, formats into a single string

                                StudentSched.Push(selectedSubject); // pushes into StudentSched
                                UnitsStack.Push(subjectUnits); // pushes into UnitsStack
                                TotUnits += subjectUnits;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Successfully added: ");
                                Console.ResetColor();
                                Console.Write(selectedSubject);
                                Console.Write(" Total units enrolled: ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(TotUnits);
                                Console.Write("/21");
                                Console.ResetColor();
                            }
                        }
                        else // error statement when user doesn't type a valid option
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please select a valid subject number.");
                            Console.ResetColor();
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        DisplayMenu();
                        break;
                    case 4: // displaying the current schedule
                        Console.Clear();
                        Console.WriteLine("Your Current Schedule :");
                        if (TotUnits == 0) // checks if stack is not full
                        {
                            Console.WriteLine("No subjects enlisted yet.");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            DisplayMenu();
                            break;
                        }
                        else // calls the printstack() method
                        {
                            StudentSched.PrintStack();
                        }
                        Console.WriteLine($"\nTotal Units Enlisted: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(TotUnits);
                        Console.Write("/21");
                        Console.ResetColor();
                        Console.WriteLine("\nRemove Options:"); // another switch
                        Console.WriteLine("1: Remove Last Added Subject (Top of Stack)");
                        Console.WriteLine("2: Remove All Subjects");
                        Console.WriteLine("3: Go Back to Main Menu");
                        Console.Write("\nUser: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        

                        int removeChoice = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();

                        switch (removeChoice)
                        {
                            case 1: // removes the chosen subject via its index
                                try
                                {
                                    object removedSubject = StudentSched.Pop();
                                    int removedUnits = (int)UnitsStack.Pop(); 
                                    TotUnits -= removedUnits;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Successfully removed: ");
                                    Console.ResetColor();
                                    Console.Write(removedSubject);
                                    Console.Write($" Total units enrolled: ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(TotUnits);
                                    Console.Write("/21");
                                    Console.ResetColor();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                DisplayMenu();
                                break;

                            case 2: // clears the stack, removing all of the current enlisted subjects
                                StudentSched.Clear(); 
                                UnitsStack.Clear(); 
                                TotUnits = 0;
                                Console.WriteLine("All subjects removed successfully.");
                                Console.WriteLine($"Total units enrolled: {TotUnits}/21");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                DisplayMenu();
                                break;

                            case 3: // goes back to menu
                                Console.Clear();
                                DisplayMenu();
                                break;

                            default: 
                                Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                DisplayMenu();
                                break;
                        }
                        break;

                    case 5: // displays the enrollable subjects
                        Console.Clear();
                        if (TotUnits == 0) // checks if there are no subjects, displays error
                        {
                            Console.WriteLine("No subjects to enroll. Please add subjects first.");
                        }
                        else // displays finished
                        {
                            Console.WriteLine("You have successfully enlisted the following subjects:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            StudentSched.PrintStack();
                            Console.ResetColor();
                            Console.WriteLine($"\nTotal Units Enrolled: {TotUnits}/21");
                        }
                        Console.WriteLine("\nThank you for using the Student Enrollment System!");
                        running = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid choice...");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        DisplayMenu();
                        break;
                }
            }

            Console.ReadKey();
        }

        static void DisplayMenu() // method to display the menu
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("======= Welcome to Student Enrollment System (S.E.S) =======");
            Console.WriteLine("============================================================");
            Console.WriteLine("1: View Subject Schedule");
            Console.WriteLine("2: View Enlisted Subjects");
            Console.WriteLine("3: Add Subjects to Schedule");
            Console.WriteLine("4: Remove Subjects");
            Console.WriteLine("5: Enrolled Subjects");
        }
    }
}