using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] 
    private AudioMixer audioMixer;
    [SerializeField] 
    private AnimationCurve volumeCurve;
    [SerializeField] 
    private Slider masterSlider;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sfxSlider;

    private void Start()
    {
        audioMixer.GetFloat("masterVolume", out float masterVolume);
        masterSlider.value = Remapping(masterVolume, -80, 20, 0, 1);

        audioMixer.GetFloat("musicVolume", out float musicVolume);
        musicSlider.value = Remapping(musicVolume, -80, 20, 0, 1);

        audioMixer.GetFloat("sfxVolume", out float sfxVolume);
        sfxSlider.value = Remapping(sfxVolume, -80, 20, 0, 1);
    }

    private float Remapping(float value, float oldMinimum, float oldMaximum, float newMin, float newMax)
    {
        float a = Mathf.InverseLerp(oldMinimum, oldMaximum, value);
        return Mathf.Lerp(newMin, newMax, a);
    }

    public void SetMasterVolume(float volume)
    {
        float vol = volumeCurve.Evaluate(volume);
        audioMixer.SetFloat("masterVolume", vol);
    }
    
    public void SetMusicVolume(float volume)
    {
        float vol = volumeCurve.Evaluate(volume);
        audioMixer.SetFloat("musicVolume", vol);
    }
    
    public void SetSFXVolume(float volume)
    {
        float vol = volumeCurve.Evaluate(volume);
        audioMixer.SetFloat("sfxVolume", vol);
    }

    public void SetFullScreen(bool value)
    {
        Screen.fullScreen = value;
    }
}
