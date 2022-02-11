using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "new AudioData", menuName = "ScriptableObjects/Audio/AudioData")]
public class AudioData : ScriptableObject
{
    [SerializeField] private List<AudioClip> _audioClipList;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    public AudioClip AudioClip
    {
        get
        {
            int i = 0;
            if (_audioClipList.Count > 1)
            {
                i = Random.Range(0, _audioClipList.Count);
            }

            return _audioClipList[i];
        }
    }
    public AudioMixerGroup MixerGroup => _mixerGroup;
}
