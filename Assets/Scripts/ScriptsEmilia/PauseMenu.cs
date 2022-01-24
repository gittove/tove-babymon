using System.Collections;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] 
    private GameObject pauseMenuCanvas;
    [SerializeField] 
    private GameObject controlsCanvas;
    
    public AnimationCurve animationCurveCanvas;
    
    private bool isShowingControls;
    
    private void Awake()
    {
        //Todo put in own set up method later?
        pauseMenuCanvas.SetActive(false);
        controlsCanvas.SetActive(false);
        isShowingControls = false;
    }

    public void ChangeOnPause(bool isPause)
    {
        Debug.Log(isPause);
        if (isPause)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    //Todo if continue to use scriptable objects with event listener, keep everything in origin script but add listener to pause observable?
    //Same with what happens on resume
    private void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        StartCoroutine(TestFadeIn());
        Debug.Log("pause game");
    }
    
    public void ResumeGame() 
    {
        pauseMenuCanvas.SetActive(false);
        Debug.Log("Resume game");
    }

    public void RestartGame()
    {
        Debug.Log("Restart lvl");
        //Add load the scene, reset everything?
    }

    public void ShowControls() //Todo change method name?
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
    
    private IEnumerator TestFadeIn()
    {
        Keyframe frame = animationCurveCanvas[animationCurveCanvas.length - 1];
        float time = frame.time;
        float elapsedTime = 0;
        while (elapsedTime <= time)
        {
            elapsedTime += Time.deltaTime;
            float curveValue = animationCurveCanvas.Evaluate(elapsedTime);
            pauseMenuCanvas.GetComponent<CanvasGroup>().alpha = curveValue;
            yield return null;
        }
    }
}
