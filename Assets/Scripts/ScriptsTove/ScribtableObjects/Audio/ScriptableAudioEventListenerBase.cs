using UnityEngine;
using UnityEngine.Events;

public class ScriptableAudioEventListenerBase<TAudioMixerGroup, TAudioClip, TVector3, TEvent, TUnityEventResponse> : MonoBehaviour
    where TEvent : ScriptableAudioEvent<TAudioMixerGroup, TAudioClip, TVector3>
    where TUnityEventResponse : UnityEvent<TAudioMixerGroup, TAudioClip, TVector3>
{
    [Header("Event to listen to:")]
    [SerializeField] 
    private TEvent eventPayload;
    [Header("Response to event")]
    [SerializeField] 
    private TUnityEventResponse responsePayload;
        
    private void OnEventRaised(TAudioMixerGroup audioMixerGroup, TAudioClip clip, TVector3 position)
    { 
        responsePayload.Invoke(audioMixerGroup, clip, position);
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
