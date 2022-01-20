using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    [HideInInspector] public AudioEventInstance[] audioEvent;

    private void Awake()
    {
        GetStaticInstance();
        CreateAudioSources();
    }
    private void Reset()
    {
        GetStaticInstance();
    }
    private void GetStaticInstance()
    {
        _instance = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        if (_instance == null)
            _instance = this;
    }
    private void CreateAudioSources()
    {
        AudioMixer mixer = Resources.Load("MasterMixer") as AudioMixer;
        AudioMixerGroup[] outputs = mixer.FindMatchingGroups("Master");
        audioEvent = new AudioEventInstance[outputs.Length];

        for (int i = 0; i < outputs.Length; i++)
        {
            GameObject instance = new GameObject(outputs[i].name, typeof(AudioSource));
            instance.transform.parent = transform;

            audioEvent[i].manager = this;
            audioEvent[i].gameObject = instance;
            audioEvent[i].source = instance.GetComponent<AudioSource>();
            audioEvent[i].source.outputAudioMixerGroup = outputs[i];
        }
    }

    public void PlaySound(AudioMixerGroup ID, AudioClip clip)
    {
        for (int i = 0; i < audioEvent.Length; i++)
        {
            if (ID == audioEvent[i].GetID())
            {
                audioEvent[i].PlaySound(clip);
                break;
            }
        }
    }
    public void PlaySound(AudioMixerGroup ID, AudioClip clip, Vector3 position)
    {
        for (int i = 0; i < audioEvent.Length; i++)
        {
            if (ID == audioEvent[i].GetID())
            {
                audioEvent[i].SetPosition(position);
                audioEvent[i].PlaySound(clip);
                break;
            }
        }
    }
    public void ResetEvent(AudioMixerGroup ID)
    {
        for (int i = 0; i < audioEvent.Length; i++)
        {
            if (ID == audioEvent[i].GetID())
            {
                audioEvent[i].ResetPosition();
                break;
            }
        }
    }


    public AudioEventInstance GetAudioEvent(AudioMixerGroup ID)
    {
        for (int i = 0; i < audioEvent.Length; i++)
            if (ID == audioEvent[i].GetID())
                return audioEvent[i];

        return audioEvent[0];
    }
}

[Serializable] public struct AudioEventInstance
{
    public AudioManager manager;
    public AudioSource source;
    public GameObject gameObject;

    public AudioMixerGroup GetID() => source.outputAudioMixerGroup;

    public void SetPosition(Vector3 pos)
    {
        gameObject.transform.parent = null;
        gameObject.transform.position = pos;
    }
    public void ResetPosition()
    {
        gameObject.transform.parent = manager.transform;
        gameObject.transform.position = Vector3.zero;
    }

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}