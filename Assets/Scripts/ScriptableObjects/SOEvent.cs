using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEvent", menuName = "Scriptable Objects/Event/Without Parameters")]
public class SOEvent : ScriptableObject
{
    private readonly List<Action> _subscribers = new();

    public void Subscribe(Action callback)
    {
        if (!_subscribers.Contains(callback))
            _subscribers.Add(callback);
    }

    public void Unsubscribe(Action callback)
    {
        if (_subscribers.Contains(callback))
            _subscribers.Remove(callback);
    }

    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Invoke();
        }
    }
}