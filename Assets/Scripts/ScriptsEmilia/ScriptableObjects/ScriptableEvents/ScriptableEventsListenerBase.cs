using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventListenerBase : MonoBehaviour
{
    [Header("Event to listen to:")]
    [SerializeField] 
    private ScriptableEvent eventNoPayload;
    [Header("Response to event")]
    [SerializeField] 
    private UnityEvent responseNoPayload;
    
    private void OnEventRaised()
    {
        responseNoPayload.Invoke();
    }
        
    private void OnEnable()
    {
        eventNoPayload.Register(OnEventRaised);
    }

    private void OnDisable()
    {
        eventNoPayload.Unregister(OnEventRaised);
    }
}


