using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioData data;
    public ScriptableAudioEvent audioEvent;

    public void PlaySound() => audioEvent.RaiseEvent(data.MixerGroup, data.AudioClip, transform.position);
}
