using System;
using UnityEngine;

//Scriptable event without any payload
public abstract class ScriptableEventBase : ScriptableObject
{
    private event Action eventNoPayload;

    public void Register(Action onEvent)
    {
        eventNoPayload += onEvent;
    }
    
    public void Unregister(Action onEvent)
    {
        eventNoPayload -= onEvent;
    }

    public void RaiseEvent()
    {
        eventNoPayload?.Invoke();
    }
}

[CreateAssetMenu(fileName = "new ScriptableEvent", menuName = "ScriptableObjects/ScriptableEvent", order = 0)]
public class ScriptableEvent : ScriptableEventBase
{
    
}
