using System;
using UnityEngine;

public class ScriptableEventTwoPayloadBase<TPayload1, TPayload2>: ScriptableEventBase
{
    private event Action<TPayload1, TPayload2> eventPayload;

    public void Register(Action<TPayload1, TPayload2> onEvent)
    {
        eventPayload += onEvent;
    }
    
    public void Unregister(Action<TPayload1, TPayload2> onEvent)
    {
        eventPayload -= onEvent;
    }

    public void RaiseEvent(TPayload1 value1, TPayload2 value2)
    {
        eventPayload?.Invoke(value1, value2);
    }
}
