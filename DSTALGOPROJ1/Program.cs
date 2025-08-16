using DSTALGOPROJ1.ADTs;

namespace DSTALGOPROJ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
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

                        break;
                    case 2:
                        CustomListClass MyList = new CustomListClass();

                        Console.WriteLine("Current Schedule: " + MyList.GetList()); // Not sure yet what to do with this..
                        break;
                    case 3:

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