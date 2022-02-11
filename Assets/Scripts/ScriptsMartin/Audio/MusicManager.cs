using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
	public static MusicManager instance;

    public AnimationCurve fadeOut, fadeIn;

    [SerializeField]public AudioTrack[] tracks;

    int currentTrack;

	private void Awake()
	{
		if (instance == null)
        {
			instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
	}

	public void PlayStem(musicState state, float fadeTime)
	{
        for (int i = 0; i < tracks.Length; i++)
        {
            if(tracks[i].state == state && i != currentTrack)
            {
                instance.StartCoroutine(FadeTracks(tracks[currentTrack].source, tracks[i].source, fadeTime));
                currentTrack = i;
                break;
            }
            else
                continue;
        }
    }

    public IEnumerator FadeTracks(AudioSource _old, AudioSource _new, float fadeTime)
    {
        float t = 1f;

        _new.Stop();
        _new.Play();

        while (t >= 0f)
        {
            t -= Time.unscaledDeltaTime;

            float time = Remap(t, 1f, 0f, 0f, fadeTime);

            _old.volume = fadeOut.Evaluate(time);

            _new.volume = fadeIn.Evaluate(time);

            yield return null;
        }
    }

    public float Remap(float t, float a1, float b1, float a2, float b2)
    {
        float a = Mathf.Lerp(a1, b1, t);
        float b = Mathf.InverseLerp(a2, b2, a);
        return b;
    }
}

[Serializable] public struct AudioTrack
{
    public AudioSource source;
    public musicState state;
}

public enum musicState
{
	Menu,
	BetweenDays,
	InGame
}