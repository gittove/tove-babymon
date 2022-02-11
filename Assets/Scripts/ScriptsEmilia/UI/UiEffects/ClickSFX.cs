using UnityEngine;

public class ClickSFX : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] 
    private ScriptableAudioEvent onButtonClick;
    [SerializeField] 
    private AudioData buttonClickSfx;  

    public void PlayButtonSFX()
    {
        onButtonClick.RaiseEvent(buttonClickSfx.MixerGroup, buttonClickSfx.AudioClip, Vector3.zero);
        Debug.Log("sound event raised");
    }
}
