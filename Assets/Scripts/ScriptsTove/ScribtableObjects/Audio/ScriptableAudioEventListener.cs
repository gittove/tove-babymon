using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class ScriptableAudioEventListener : ScriptableAudioEventListenerBase<AudioMixerGroup, AudioClip, Vector3, ScriptableAudioEvent<AudioMixerGroup, AudioClip, Vector3>, UnityEvent<AudioMixerGroup, AudioClip, Vector3>>
{
}
