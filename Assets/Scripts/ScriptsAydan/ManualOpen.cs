using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ManualOpen : MonoBehaviour
{
    public GameObject monsterManual;
    [SerializeField] private BoolObservable _pauseObservable;
    private bool GamePaused = false;
    private KeyCode key = KeyCode.A;
    void Start()
    {
        monsterManual.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && GamePaused == false)
                {
            Debug.Log("M was pressed");
            Pause(); 
        }
        else if (Input.GetKeyDown(KeyCode.M) && GamePaused == true)
        {
            Resume();
        }
    }

    private void Pause()
    {
        monsterManual.SetActive(true);
        Debug.Log(SceneManager.sceneCount);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            _pauseObservable.SetValue(true);
        }

        GamePaused = true;
        Debug.Log("game paused and manual open");
    }

    public void Resume()
    {
        monsterManual.SetActive(false);
        _pauseObservable.SetValue(false);
        GamePaused = false; 
    }
}
