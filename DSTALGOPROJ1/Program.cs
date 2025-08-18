using DSTALGOPROJ1.ADTs;
using System.Security.Cryptography.X509Certificates;

namespace DSTALGOPROJ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            };

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
                            Console.WriteLine("No subjects enrolled yet.");
                        }
                        else
                        {
                            StudentSched.PrintStack();
                        }
                        Console.WriteLine($"\nTotal Units Enrolled: {TotUnits}/21");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        DisplayMenu();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Please choose a subject to add: ");

                        for (int i = 0; i < Subjects.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {Subjects[i][0]} - {Subjects[i][1]} ({Subjects[i][2]}) - {Subjects[i][3]} units");
                        }
                        Console.Write("\nUser: ");
                        int subjectchoice = Convert.ToInt32(Console.ReadLine());

                        if (subjectchoice >= 1 && subjectchoice <= Subjects.Length)
                        {
                            int subjectUnits = Convert.ToInt32(Subjects[subjectchoice - 1][3]);

                            if (TotUnits + subjectUnits > 21)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERROR!");
                                Console.ResetColor();
                                Console.WriteLine($"You can only enroll a maximum of 21 units. Current units: {TotUnits}, \nAttempted to add: {subjectUnits} units.");
                            }
                            else if (StudentSched.CheckDup(Subjects[subjectchoice - 1][0]))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You cannot enroll the same subject twice.");
                                Console.ResetColor();
                            }
                            else
                            {
                                string selectedSubject = $"{Subjects[subjectchoice - 1][0]} - {Subjects[subjectchoice - 1][1]} ({Subjects[subjectchoice - 1][2]}) - {Subjects[subjectchoice - 1][3]} units";

                                StudentSched.Push(selectedSubject);
                                UnitsStack.Push(subjectUnits); 
                                TotUnits += subjectUnits;
                                Console.WriteLine($"Successfully added: {selectedSubject}");
                                Console.WriteLine($"Total units enrolled: {TotUnits}/21");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please select a valid subject number.");
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        DisplayMenu();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Your Current Schedule :");
                        if (TotUnits == 0)
                        {
                            Console.WriteLine("No subjects enrolled yet.");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            DisplayMenu();
                            break;
                        }
                        else
                        {
                            StudentSched.PrintStack();
                        }
                        Console.WriteLine($"\nTotal Units Enrolled: {TotUnits}/21");
                        Console.WriteLine("\nRemove Options:");
                        Console.WriteLine("1: Remove Last Added Subject (Top of Stack)");
                        Console.WriteLine("2: Remove All Subjects");
                        Console.WriteLine("3: Go Back to Main Menu");
                        Console.Write("\nUser: ");

                        int removeChoice = Convert.ToInt32(Console.ReadLine());

                        switch (removeChoice)
                        {
                            case 1:
                                try
                                {
                                    object removedSubject = StudentSched.Pop();
                                    int removedUnits = (int)UnitsStack.Pop(); 
                                    TotUnits -= removedUnits;
                                    Console.WriteLine($"Successfully removed: {removedSubject}");
                                    Console.WriteLine($"Total units enrolled: {TotUnits}/21");
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

                            case 2:
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

                            case 3:
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

                    case 5:
                        Console.Clear();
                        if (TotUnits == 0)
                        {
                            Console.WriteLine("No subjects to enlist. Please add subjects first.");
                        }
                        else
                        {
                            Console.WriteLine("You have successfully enlisted the following subjects:");
                            StudentSched.PrintStack();
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

        static void DisplayMenu()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("======= Welcome to Student Enrollment System (S.E.S) =======");
            Console.WriteLine("============================================================");
            Console.WriteLine("1: View Subject Schedule");
            Console.WriteLine("2: View Enrolled Subjects");
            Console.WriteLine("3: Add Subjects to Schedule");
            Console.WriteLine("4: Remove Subjects");
            Console.WriteLine("5: Enlist Subjects");
        }
    }
}





// Subject Schedule visual (not sure pa) ;-;
/*
 
Current Schedule:

ISPRGG - M 8:00 - 11:00 (this is sample data)

Slot 2

Slot 3

Slot 4

Slot 5

Slot 6

Slot 7

Slot 8

 */