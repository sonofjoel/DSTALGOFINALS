namespace DSTALGOPROJ1.ADTs;

public class CustomListClass
{
    private object[] array; // create the array here 
    private int index; // index here to count
    private bool isFound = false; // bool for the class to access 

    public CustomListClass() // constructor to initialize everything
    {
        index = -1;
        array = new object[8];
    }

    public void Add(object value) // Takes in 1 parameter. Increments first before checking if array can be added, if yes then add the value to the array. 
    {
        index++;
        if (index >= array.Length)
        {
            Resize();
        }
        array[index] = value;
    }

    private void Resize() // Resizes the array by copying it into a new array with double the previous size
    {
        int newSize = array.Length * 2;
        object[] newArray = new object[newSize];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        array = newArray;
    }

    public void PrintSchedule()
    {
        Console.WriteLine("Current Schedule:\n");

        for (int i = 0; i < 8; i++) // always show 8 slots
        {
            if (i < index && array[i] != null)
            {
                Console.WriteLine($"Slot {i + 1}: {array[i]}");
            }
            else
            {
                Console.WriteLine($"Slot {i + 1}: Empty");
            }
        }
    }

    public void ViewSubjectSchedule(string[][] subjects)
    {
        Console.WriteLine("===========================================================");
        Console.WriteLine("============== Available Subjects to Enroll ===============");
        Console.WriteLine("===========================================================");
        for (int i = 0; i < subjects.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {subjects[i][0]} - {subjects[i][1]} ({subjects[i][2]}) - {subjects[i][3]} units");
        }
    }


    public string GetList()
    {
        string result = "";
        for (int i = 0; i < index; i++)
        {
            result += array[i] + "\n";
        }
        return result.Trim();
    }

    public void Remove(object item) // removes an item at a specific index by iterating thru a for loop (easier that RemoveAt), loops through the array and checks if item is not null and if array index equals item, then removes by shifting to the left, decrements idex after, if not found then return cw error
    {

        for (int i = 0; i <= index; i++)
        {
            if (array[i] == item)
            {
                isFound = true;

                // nested loop: shift everything after i to the left
                for (int j = i; j < index; j++)
                {
                    array[j] = array[j + 1];
                }

                array[index] = null; // clear last 
                index--;
                break; // exit after removing first match
            }
        }

        if (isFound)
        {
            Console.WriteLine("Error! Data not found...");
        }
    }


    public object Search(object item) // searches for a specific item by using a for loop, if item is found, return that item, else return null
    {

        for (int i = 0; i <= index; i++)
        {
            if (array[i] == item)
            {
                return item;
            }
            else
            {
                Console.WriteLine("Error! Data not found...");
            }
        }
        return null;
    }
}
