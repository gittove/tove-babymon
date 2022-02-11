using UnityEngine;

public class BabyAudioEvent : MonoBehaviour
{
    public ScriptableAudioEvent _event;
    public void TriggerAudio(AudioData data) => _event.RaiseEvent(data.MixerGroup, data.AudioClip, transform.position);
}
