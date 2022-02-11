using System;

public class ScriptableAudioEvent<AudioMixerGroup, AudioClip, Vector3> : ScriptableEventBase
{
    private event Action<AudioMixerGroup, AudioClip, Vector3> eventPayload;

    public void Register(Action<AudioMixerGroup, AudioClip, Vector3> onEvent)
    {
        eventPayload += onEvent;
    }
    
    public void Unregister(Action<AudioMixerGroup, AudioClip, Vector3> onEvent)
    {
        eventPayload -= onEvent;
    }

    public void RaiseEvent(AudioMixerGroup audioMixerGroup, AudioClip audioClip, Vector3 position)
    {
        eventPayload?.Invoke(audioMixerGroup, audioClip, position);
    }
}
