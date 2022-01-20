using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

[AddComponentMenu("Audio/UI Audio Trigger")]
public class UIAudioTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AudioMixerGroup _output;

    public AudioClip onMouseEnter;
    public AudioClip onMouseExit;
    public AudioClip onMouseClick;

    public void OnPointerEnter(PointerEventData eventData) => SelectSoundType(0);
    public void OnPointerExit(PointerEventData eventData) => SelectSoundType(1);
    public void OnPointerClick(PointerEventData eventData) => SelectSoundType(2);
    private void OnMouseEnter() => SelectSoundType(0);
    private void OnMouseExit() => SelectSoundType(1);
    public void OnMouseUpAsButton() => SelectSoundType(2);

    void SelectSoundType(int i)
    {
        AudioClip clip = GetClip(i);

        if(clip != null && _output != null)
            AudioManager._instance.PlaySound(_output, clip);
    }
    public AudioClip GetClip(int i)
    {
        switch (i)
        {
            case 0: if (onMouseEnter != null) return onMouseEnter; else break;
            case 1: if (onMouseExit != null) return onMouseExit; else break;
            case 2: if (onMouseClick != null) return onMouseClick; else break;
        }

        return null;
    }
}