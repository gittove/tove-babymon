using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] 
    private GameObject controlsCanvas;
    
    private bool isShowingControls;
    
    public void StartGame()
    {
        MusicManager.instance.PlayStem(musicState.InGame, 0.2f);
        SceneManager.LoadScene(1);
    }
    
    public void OpenSettings()
    {
        Debug.Log("Open Settings");
    }
    
    public void ShowControls()
    {
        if (isShowingControls)
        {
            controlsCanvas.SetActive(false);
            isShowingControls = false;
        }
        else
        {
            controlsCanvas.SetActive(true);
            isShowingControls = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
