namespace DSTALGOPROJ1.ADTs
{
    class UADT
    {
        private int top;
        private object[] array;

        public UADT()
        {
            int top = -1;
            array = new object[5];
        }

        public void Push(object item)
        {
            if (top < array.Length - 1)
            {
                top++;
                array[top] = item;
            }
            else throw new Exception("Stack Overflow...");
        }

        public object Pop()
        {
            if (top > -1)
            {
                object item = array[top];
                top--;
                return item;
            }
            else throw new Exception("Stack Underflow");
        }

        public object Peek()
        {
            if (top > -1)
            {
                object item = array[top];

                return item;
            }
            else throw new Exception("Stack Underflow");
        }

        public void clear()
        {
            top = -1;
        }

        public void PrintStack()
        {
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
        }






    }
}
