using UnityEngine;
using System.Collections.Generic;

public class GenericStack<T>
{
    private List<T> stackList = new List<T>();
    public int GetCount() {
        return stackList.Count;
    }
    public void Push(T item) {
        stackList.Add(item);
    }

    public T Pop() {
        T temp = Peek();
        stackList.RemoveAt(stackList.Count-1);
        return temp;
    }

    public T Peek() {
        return stackList[stackList.Count-1];
    }

}
