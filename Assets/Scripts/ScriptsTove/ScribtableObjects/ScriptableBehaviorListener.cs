using UnityEngine;
using UnityEngine.Events;

public class ScriptableBehaviorListener : MonoBehaviour
{
    [Header("Events to listen to:")] 
    [SerializeField] private ScriptableEvent _objectEvent;
    [SerializeField] private ScriptableEvent _wellbeingEvent;
    [SerializeField] private ScriptableEvent _loveEvent;
    
    [Header("Response to events")]
    [SerializeField] private UnityEvent _objectResponse;
    [SerializeField] private UnityEvent _wellbeingResponse;
    [SerializeField] private UnityEvent _loveResponse;
    
    private void OnObjectEventRaised()
    {
        _objectResponse.Invoke();
    }
    
    private void OnWellbeingEventRaised()
    {
        _wellbeingResponse.Invoke();
    }
    
    private void OnLoveEventRaised()
    {
        _loveResponse.Invoke();
    }
        
    private void OnEnable()
    {
        _objectEvent.Register(OnObjectEventRaised);
        _wellbeingEvent.Register(OnWellbeingEventRaised);
        _loveEvent.Register(OnLoveEventRaised);
    }

    private void OnDisable()
    {
        _objectEvent.Unregister(OnObjectEventRaised);
        _wellbeingEvent.Unregister(OnWellbeingEventRaised);
        _loveEvent.Unregister(OnLoveEventRaised);
    }
}
