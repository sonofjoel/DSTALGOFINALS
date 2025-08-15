namespace DSTALGOPROJ1.ADTs
{
    public class CustomListClass
    {
        private object[] array;
        private int index;
        public CustomListClass()
        {
            array = new object[5];
            index = -1;
        }
        public void Add(int item)
        {
            index++;
            if (index < array.Length - 1)
            {
                array[index] = item;
            }
            else 
            {
                // Resize the array if it is full
                object[] newArray = new object[array.Length * 2];
                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
                array[index] = item;
            }
        }
        public void Insert() { }
        public void Remove() { }
        public void RemoveAt(int index) { }
        public void Clear() { }
        public void Sort() { }
        public void Search() { }

    }
}
