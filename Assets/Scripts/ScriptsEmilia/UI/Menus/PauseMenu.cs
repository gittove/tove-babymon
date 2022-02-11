using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] 
    private GameObject pauseMenuCanvas;
    [SerializeField] 
    private GameObject controlsCanvas;
    [SerializeField]
    private AnimationCurve animationCurveEnter;
    
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
        if (isPause)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    private void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        StartCoroutine(TestFadeIn());
    }
    
    private void ResumeGame() 
    {
        pauseMenuCanvas.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ShowControlsCanvas()
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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame() 
    {
        Application.Quit();
    }
    
    private IEnumerator TestFadeIn()
    {
        Keyframe frame = animationCurveEnter[animationCurveEnter.length - 1];
        float time = frame.time;
        float elapsedTime = 0;
        while (elapsedTime <= time)
        {
            elapsedTime += Time.deltaTime;
            float curveValue = animationCurveEnter.Evaluate(elapsedTime);
            pauseMenuCanvas.GetComponent<CanvasGroup>().alpha = curveValue;
            yield return null;
        }
    }
}
