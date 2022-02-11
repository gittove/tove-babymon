using System.Collections.Generic;
using UnityEngine;

public class mAudio : MonoBehaviour
{
    [HideInInspector] public List<AudioSource> sources = new List<AudioSource>();
    public int poolSize = 128;

    #region Monobehaviour

    public static mAudio instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject x = new GameObject("pooledAudioSource");
            x.hideFlags = HideFlags.HideInHierarchy;
            x.transform.parent = transform;
            AudioSource y = x.AddComponent<AudioSource>();
            sources.Add(y);
        }
    }
    private void OnValidate()
    {
        if (instance == null)
        {
            if (GameObject.Find("mAudioManager"))
                instance = this;
            else
                CreateNewInstance();
        }

        instance.gameObject.name = "mAudioManager";
    }
    private static mAudio CreateNewInstance()
    {
        if (instance == null)
        {
            GameObject mTween = new GameObject("mAudioManager");
            mAudio x = mTween.AddComponent<mAudio>();
            instance = x;
            return x;
        }
        else
            return instance;
    }
    public static void TryGetReference()
    {
        CreateNewInstance();
    }

    #endregion

    public AudioSource GetFirstFreeSource()
    {
        TryGetReference();

        for (int i = 0; i < instance.sources.Count; i++)
        {
            if(instance.sources[i].clip == null)
                return instance.sources[i];
            else
                continue;
        }
        return null;
    }
    public void Dispose(AudioSource source)
    {
        for (int i = 0; i < instance.sources.Count; i++)
        {
            if (instance.sources[i] == source)
            {
                instance.sources[i].clip = null;
                instance.sources[i].transform.parent = transform;
                instance.sources[i].transform.localPosition = Vector3.zero;
            }
        }
    }

}
