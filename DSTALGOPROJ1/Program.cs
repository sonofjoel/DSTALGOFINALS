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

            string[][] Subjects =
            {
                new string[] {"ISPRGG1", "M 8:00AM - 11:00AM"},
                new string[] {"ISPRGG2", "M 2:40PM - 5:40PM"},
                new string[] {"INCOMPU", "T 11:20AM - 2:20PM" },
                new string[] {"MATHWRLD", "W 11:20AM - 2:40PM" },
                new string[] {"SCITECH", "H 8:00AM - 11:00AM"},
                new string[] {"CSBLIFE", "F 2:40 - 5:40" },
                new string[] {"NSTP01", "T 8:00AM - 11:00AM" }
            };

            // So... predetermined data we have should be schedules and 

            Console.WriteLine("-------Welcome to Student Enrollment System (S.E.S)-------");

            Console.WriteLine("1: View Subject Schedule");
            Console.WriteLine("2: View Student Schedule");
            Console.WriteLine("3: Add Subjects to Schedule");
            Console.WriteLine("4: Change Year Term and ID");
            Console.WriteLine("5: Exit Program");
            
            while (running)
            {
                Console.Write("\nUser: ");
                int userchoice = Convert.ToInt32(Console.ReadLine());


                switch (userchoice)
                {
                    case 1:
                        MyList.ViewSubjectSchedule();
                        break;
                    case 2:
                        MyList.PrintSchedule();
                        break;
                    case 3:
                        Console.WriteLine("Please choose a subject to add: ");
                        
                        for (int i = 0; i < Subjects.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {Subjects[i][0]} - {Subjects[i][1]}");
                        }
                        Console.Write("\nUser: ");
                        int subjectchoice = Convert.ToInt32(Console.ReadLine());

                        // Di pa tapossss
                        break;
                    case 4:

                        break;
                    case 5:
                        Console.WriteLine("Thank you for using this program!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice...");
                        break;
                }

            }

            Console.ReadKey();
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