using System;
using System.Collections.Generic;
using UnityEngine;

public class GenericQueue<T>
{
    private List<T> genericQueue = new();

    public T Peek()
    {
        return genericQueue[0];
    }

    public void Enqueue(T item)
    {
        genericQueue.Add(item);
    }

    public void Dequeue()
    {
        genericQueue.RemoveAt(0);
    }
}
