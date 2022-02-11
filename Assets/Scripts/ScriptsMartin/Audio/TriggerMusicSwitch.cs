using UnityEngine;
using UnityEngine.UI;

public class TriggerMusicSwitch : MonoBehaviour
{

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(SwitchToMainMenuMusic);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(SwitchToMainMenuMusic);
    }

    public void SwitchToMainMenuMusic()
    {
        MusicManager.instance.PlayStem(musicState.Menu, 1f);
    }
}
