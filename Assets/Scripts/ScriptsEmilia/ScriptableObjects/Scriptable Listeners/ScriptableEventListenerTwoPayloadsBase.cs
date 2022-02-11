using UnityEngine;
using UnityEngine.Events;

public abstract class ScriptableEventListenerTwoPayloadsBase<TEvent, TUnityEventResponse> : MonoBehaviour
    where TEvent : ScriptableEventTwoPayloadBase<Effect, Vector3>
    where TUnityEventResponse : UnityEvent<Effect, Vector3>
{
    [Header("Event to listen to:")]
    [SerializeField] 
    private TEvent eventPayload;
    [Header("Response to event")]
    [SerializeField] 
    private TUnityEventResponse responsePayload;
        
    private void OnEventRaised(Effect payload, Vector3 vector3)
    {
        responsePayload.Invoke(payload, vector3);
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