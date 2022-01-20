using System;

//Scriptable event with payload
public class ScriptableEvent<T>: ScriptableEventBase
{
    private event Action<T> eventPayload;

    public void Register(Action<T> onEvent)
    {
        eventPayload += onEvent;
    }
    
    public void Unregister(Action<T> onEvent)
    {
        eventPayload -= onEvent;
    }

    public void RaiseEvent(T value)
    {
        eventPayload?.Invoke(value);
    }
}
