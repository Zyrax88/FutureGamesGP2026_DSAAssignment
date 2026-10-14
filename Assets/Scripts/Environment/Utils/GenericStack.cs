using System;
using System.Collections.Generic;
public class GenericStack<T>
{
    private List<T> stack;

    public GenericStack()
    {
        stack = new List<T>();
    }

    public T Peek()
    {
        return stack[stack.Count - 1];
    }

    public void Push(T tile)
    {
        stack.Add(tile); //Add tile to the stack.
    }

    public T Pop()
    {
        T stackValue = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return stackValue;
    }
}
