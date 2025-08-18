namespace DSTALGOPROJ1.ADTs
{
    class UADT
    {
        private int top;
        private object[] array;

        public UADT()
        {
            top = -1;
            array = new object[5]; 
        }

        public void Push(object item)
        {
            if (top >= array.Length - 1)
            {
                Resize();
            }
            top++;
            array[top] = item;
        }

        private void Resize()
        {
            int newSize = array.Length * 2;
            object[] newArray = new object[newSize];

            for (int i = 0; i <= top; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
          
        }

        public object Pop()
        {
            if (top > -1)
            {
                object item = array[top];
                top--;
                return item;
            }
            else throw new Exception("No subjects to remove");
        }

        public object Peek()
        {
            if (top > -1)
            {
                return array[top];
            }
            else throw new Exception("No subjects enrolled");
        }

        public void Clear()
        {
            top = -1;
        }

        public void PrintStack()
        {
            if (top == -1)
            {
                Console.WriteLine("No subjects enrolled yet.");
                return;
            }

            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
        }

        public bool CheckDup(string subjectCode)
        {
            for (int i = top; i >= 0; i--)
            {
                if (array[i].ToString().StartsWith(subjectCode))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
