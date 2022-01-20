using UnityEngine;
using UnityEngine.Events;

public abstract class ScriptableEventListener<TPayload, TEvent, TUnityEventResponse> : MonoBehaviour
    where TEvent : ScriptableEvent<TPayload>
    where TUnityEventResponse : UnityEvent<TPayload>
{
    [Header("Event to listen to:")]
    [SerializeField] 
    private TEvent eventPayload;
    [Header("Response to event")]
    [SerializeField] 
    private TUnityEventResponse responsePayload;
        
    private void OnEventRaised(TPayload payload)
    {
        responsePayload.Invoke(payload);
    }
        
    private void OnEnable()
    {
        eventPayload.Register(OnEventRaised);
    }

    private void OnDisable()
    {
        eventPayload.Unregister(OnEventRaised);
    }
}
