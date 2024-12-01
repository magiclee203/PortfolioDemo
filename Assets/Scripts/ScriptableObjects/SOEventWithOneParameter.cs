using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOEvent<T> : ScriptableObject
{
    private readonly List<Action<T>> _subscribers = new();

    public void Subscribe(Action<T> callback)
    {
        if (!_subscribers.Contains(callback))
            _subscribers.Add(callback);
    }

    public void Unsubscribe(Action<T> callback)
    {
        if (_subscribers.Contains(callback))
            _subscribers.Remove(callback);
    }

    public void Notify(T value)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Invoke(value);
        }
    }
}